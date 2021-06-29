using System;
using System.Collections.Generic;
using _3Dconnexion;
using System.Security.Permissions;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using SMXPlanarLinker.Ads;
using System.IO;
using SMXPlanarLinker.XInput;

namespace SMXPlanarLinker
{
    public partial class Form1 : Form
    {
        #region Class Basics
        #region Constants
        private const string appName = "SMXplanarLinker";
        private const string logFileName = "log.txt";
        private const string templateTR = "TX: {1,-7}{0}TY: {2,-7}{0}TZ: {3,-7}{0}RX: {4,-7}{0}RY: {5,-7}{0}RZ: {6,-7}{0}P: {7}";
        #endregion
        #region Class variables
        private IntPtr hWnd = IntPtr.Zero;
        private IntPtr devHdl = IntPtr.Zero;
        private SiApp.SpwRetVal res;
        private AdsHandler Ads;
        private List<string> adsSymbolNames;
        private List<AdsHandler.AdsSymbol> adsSymbols;
        private XInputHandler gamePad;
        private eControlMethod CM;
        private bool disableRotation = false;
        #endregion
        #region Enums
        private enum eControlMethod
        {
            CM_SPACEMOUSE,
            CM_XINPUT
        }
        #endregion
        public Form1()
        {
            hWnd = Handle;
            InitializeComponent();
            if (InitializeSiApp())
            {
                InitAds();
                adsSymbols = new List<AdsHandler.AdsSymbol>();
                Log("SiOpen", devHdl.ToString());
                //TO-DO
            }
           
        }//Form1()
        #endregion
        #region SpaceMouse Interface
        private bool InitializeSiApp()
        {
            res = SiApp.SiInitialize();
            if(res != SiApp.SpwRetVal.SPW_NO_ERROR){
                MessageBox.Show("Initializtion of SiApp failed! Value returned: " + res.ToString());
                return false;
            }//if cannot init SiApp
            SiApp.SiOpenData openData = new SiApp.SiOpenData();
            SiApp.SiOpenWinInit(openData, hWnd);

            devHdl = SiApp.SiOpen(appName, SiApp.SI_ANY_DEVICE, IntPtr.Zero, SiApp.SI_EVENT, openData);
            if (devHdl == IntPtr.Zero)
                MessageBox.Show("Open() returns empty device handle");
            return (devHdl != IntPtr.Zero);
        }//Init SiApp
        private void CloseSiApp()
        {
            SiApp.SpwRetVal retVal = SiApp.SiClose(devHdl);
            Log("SiClose", retVal.ToString());
            int res = SiApp.SiTerminate();
            Log("SiTerminate", res.ToString());
        }
        #endregion

        #region Input Events
        private void trackSpaceMouse(Message msg)
        {
            //make sure the message is from the SpaceMouse, stop her if it is not
            if (!SiApp.IsSpaceMouseMessage(msg.Msg))
                return;

            //get the event data related to the message we received
            SiApp.SiGetEventData eventData = new SiApp.SiGetEventData();
            SiApp.SiGetEventWinInit(eventData, msg.Msg, msg.WParam, msg.LParam);

            SiApp.SiSpwEvent spwEvent = new SiApp.SiSpwEvent();
            SiApp.SpwRetVal retVal = SiApp.SiGetEvent(devHdl, SiApp.SI_AVERAGE_EVENTS, eventData, spwEvent);

            if (retVal == SiApp.SpwRetVal.SI_IS_EVENT)
            {
                //which type of event we get changes what needs to be done.
                //However, for this application, we only care about motion from the joystick.
                //As such, we only care if there is a motion event, or if there is a zero event, which indicates the end of messages.
                switch (spwEvent.type)
                {
                    case 0:
                        break;
                    case SiApp.SiEventType.SI_MOTION_EVENT:
                    case SiApp.SiEventType.SI_ZERO_EVENT:
                        {
                            updateTrackBars(spwEvent.spwData.mData);
                            if (adsSymbols.Count != 0)
                            {
                                foreach (AdsHandler.AdsSymbol symbol in adsSymbols)
                                {
                                    
                                        switch (symbol.input)
                                        {
                                            case AdsHandler.SM_INPUTS.X_AXIS:
                                                if (tbXAxis.Enabled)
                                                    writeToAdsSymbol(symbol, spwEvent.spwData.mData[0]);
                                                break;
                                            case AdsHandler.SM_INPUTS.Y_AXIS: //We need to swap the Y and Z axis, to match the orientation of the Xplanar mover.
                                                if (tbYAxis.Enabled)
                                                    writeToAdsSymbol(symbol, spwEvent.spwData.mData[2]);
                                                break;
                                            case AdsHandler.SM_INPUTS.Z_AXIS:
                                                if (tbZAxis.Enabled)
                                                    writeToAdsSymbol(symbol, spwEvent.spwData.mData[1]);
                                                break;
                                            case AdsHandler.SM_INPUTS.A_AXIS:
                                                if (tbAAxis.Enabled)
                                                    writeToAdsSymbol(symbol, spwEvent.spwData.mData[3]);
                                                break;
                                            case AdsHandler.SM_INPUTS.B_AXIS://We'll swap the rotation as well to keep it consistent.
                                                if (tbBAxis.Enabled)
                                                    writeToAdsSymbol(symbol, spwEvent.spwData.mData[5]);
                                                break;
                                            case AdsHandler.SM_INPUTS.C_AXIS:
                                                if (tbCAxis.Enabled)
                                                    writeToAdsSymbol(symbol, spwEvent.spwData.mData[4]);
                                                break;
                                            default: break;
                                        }//switch
                                }
                            }


                            break;
                        }
                    case SiApp.SiEventType.SI_BUTTON_EVENT:
                        int buttonPressed = SiApp.SiButtonPressed(spwEvent.spwData);
                        if(buttonPressed != 0)
                        {
                            switch (spwEvent.spwData.bData.pressed)
                            {
                                case 2:
                                    chkbDisableRotation.Checked = !chkbDisableRotation.Checked;
                                    break;
                                case 4:
                                    if (adsSymbols.Count != 0)
                                    {
                                        int index = adsSymbols.FindIndex(item => item.input.Equals(AdsHandler.SM_INPUTS.BUTTON_2));
                                        writeToAdsSymbol(adsSymbols[index], true);
                                    }
                                    break;
                                default:
                                    break;
                            }//switch for bData pressed
                        }//ifbuttonPressed
                        else
                        {
                            if(spwEvent.spwData.bData.released == 4)
                            {
                                int index = adsSymbols.FindIndex(item => item.input.Equals(AdsHandler.SM_INPUTS.BUTTON_2));
                                writeToAdsSymbol(adsSymbols[index], false);
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        [PermissionSet(SecurityAction.Demand, Name= "FullTrust")]
        protected override void WndProc(ref Message msg)
        {
         
                trackSpaceMouse(msg);
            

            base.WndProc(ref msg);
        }
        #endregion
       
        #region ADS interfacing
        private void writeToAdsSymbol(AdsHandler.AdsSymbol symbol, Object value)
        {
            Ads.writeAdsSymbol(symbol, value);
        }
        //Initialize the Ads Client to connect to the Ads Server
        public void InitAds()
        {
            Ads = new AdsHandler();
        }
        //Ask the ADS client to provide us with a new symbol object to keep track of which symbol is getting input data from which input of the Space Mouse
        private void linkInputToAdsSymbol(AdsHandler.SM_INPUTS input, string symbolName)
        {
            cullSymbolLinks(input);
            AdsHandler.AdsSymbol symbol = Ads.getSymbolInfo(symbolName);
            symbol.input = input;
            adsSymbols.Add(symbol);
        }
        //Request a variable handle from the AdsClient
        public uint GetAdsVarHandle(string symbolPath)
        {
            return Ads.getVarHandle(symbolPath);
        }
        //Tell the Ads Client to connect to the Ads Server using the data rom our two textboxes
        private int connectToAdsServer()
        {
            int result;
            result = (int)Ads.adsConnect(tbAmsNetId.Text.ToString(), int.Parse(tbAdsPort.Text.ToString()));
            
                
            return result;
        }
        //get a list of all symbols from the Ads client
        private void getAdsSymbols()
        {
           getAdsSymbols(AdsHandler.eAdsDataTypes.ADS_ANY);
        }
        private void getAdsSymbols(AdsHandler.eAdsDataTypes eDataType )
        {
            adsSymbolNames = Ads.getAdsSymbols(eDataType);
        }
        //each input should only be linked to 1 symbol. so we need to cull the List of any symbols that are linked to the passed input before changing the link.
        private void cullSymbolLinks(AdsHandler.SM_INPUTS input)
        {
            if (adsSymbols.Count == 0)
                return;

            int i = 0;
            foreach (AdsHandler.AdsSymbol symbol in adsSymbols)
            {
                if (symbol.input == input)
                    i++;

            }//for each symbol in the list of symbols
            if (i != 0)
            {
                int index = adsSymbols.FindIndex(item => item.input == input);
                Ads.deleteSymbolHandle(adsSymbols[index]);
                adsSymbols.RemoveAt(index);
            }//if we have a match
        }
        #endregion

        #region Control Actions
        private void btnAdsConnect_Click(object sender, EventArgs e)
        {
            int result;
            result = connectToAdsServer();
            if (result == 0) { //Ads Error Code 0 means no error
                getAdsSymbols(AdsHandler.eAdsDataTypes.ADS_INT);
            cbXSymbols.DataSource = new List<string>(adsSymbolNames);
            cbYSymbols.DataSource = new List<string>(adsSymbolNames);
            cbZSymbols.DataSource = new List<string>(adsSymbolNames);
            cbASymbols.DataSource = new List<string>(adsSymbolNames);
            cbBSymbols.DataSource = new List<string>(adsSymbolNames);
            cbCSymbols.DataSource = new List<string>(adsSymbolNames);
                getAdsSymbols(AdsHandler.eAdsDataTypes.ADS_BOOL);
            cbSnapRotationSymbols.DataSource = new List<string>(adsSymbolNames);
            }//if we connected without error
        }
        private void cbXSymbols_SelectedIndexChanged(object sender, EventArgs e)
        {
            linkInputToAdsSymbol(AdsHandler.SM_INPUTS.X_AXIS, cbXSymbols.SelectedItem.ToString());
        }
        private void cbYsymbols_SelectedIndexChanged(object sender, EventArgs e)
        {
            linkInputToAdsSymbol(AdsHandler.SM_INPUTS.Y_AXIS, cbYSymbols.SelectedItem.ToString());
        }
        private void cbZSymbols_SelectedIndexChanged(object sender, EventArgs e)
        {
            linkInputToAdsSymbol(AdsHandler.SM_INPUTS.Z_AXIS, cbZSymbols.SelectedItem.ToString());
        }
        private void cbASymbols_SelectedIndexChanged(object sender, EventArgs e)
        {
            linkInputToAdsSymbol(AdsHandler.SM_INPUTS.A_AXIS, cbASymbols.SelectedItem.ToString());
        }
        private void cbBSymbols_SelectedIndexChanged(object sender, EventArgs e)
        {
            linkInputToAdsSymbol(AdsHandler.SM_INPUTS.B_AXIS, cbBSymbols.SelectedItem.ToString());
        }
        private void cbCSymbols_SelectedIndexChanged(object sender, EventArgs e)
        {
            linkInputToAdsSymbol(AdsHandler.SM_INPUTS.C_AXIS, cbCSymbols.SelectedItem.ToString());
        }
        private void cbSnapRotationSymbols_SelectedIndexChanged(object sender, EventArgs e)
        {
            linkInputToAdsSymbol(AdsHandler.SM_INPUTS.BUTTON_2, cbSnapRotationSymbols.SelectedItem.ToString());
        }
        private void btnX_Click(object sender, EventArgs e)
        {
            tbXAxis.Enabled = !tbXAxis.Enabled;
        }
        private void BtnY_Click(object sender, EventArgs e)
        {
            tbYAxis.Enabled = !tbYAxis.Enabled;
        }
        private void btnZ_Click(object sender, EventArgs e)
        {
            tbZAxis.Enabled = !tbZAxis.Enabled;
        }
        private void btnC_Click(object sender, EventArgs e)
        {
            tbCAxis.Enabled = !tbCAxis.Enabled;
        }
        private void btnA_Click(object sender, EventArgs e)
        {
            tbAAxis.Enabled = !tbAAxis.Enabled;
        }
        private void btnB_Click(object sender, EventArgs e)
        {
            tbBAxis.Enabled = !tbBAxis.Enabled;
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseSiApp();
            Ads.closeAds(adsSymbols);
        }
        public void updateTrackBars(int[] data)
        {
            int size = data.Length;
            int maxRange = 350;
            int minRange = -350;
            int x, y, z, a, b, c;
            //0=x, 1=y, 2=z, 3=a, 4=b, 5=c
            //We will swap the y and x axes to better match how the Xplanar mover is oriented.
            x = data[0] > maxRange ? maxRange : data[0] < minRange ? minRange : data[0];
            y = data[2] > maxRange ? maxRange : data[2] < minRange ? minRange : data[2];
            z = data[1] > maxRange ? maxRange : data[1] < minRange ? minRange : data[1];
            a = data[3] > maxRange ? maxRange : data[3] < minRange ? minRange : data[3];
            b = data[5] > maxRange ? maxRange : data[5] < minRange ? minRange : data[5];
            c = data[4] > maxRange ? maxRange : data[4] < minRange ? minRange : data[4];
            if(tbXAxis.Enabled)
                tbXAxis.Value = x;
            if (tbYAxis.Enabled)
                tbYAxis.Value = y;
            if (tbZAxis.Enabled)
                tbZAxis.Value = z;
            if (tbAAxis.Enabled)
                tbAAxis.Value = a;
            if (tbBAxis.Enabled)
                tbBAxis.Value = b;
            if (tbCAxis.Enabled)
                tbCAxis.Value = c;
        }
        private void chkbDisableRotation_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbDisableRotation.Checked)
            {
                btnA.Enabled = false;
                btnB.Enabled = false;
                btnC.Enabled = false;
                tbAAxis.Enabled = false;
                tbBAxis.Enabled = false;
                tbCAxis.Enabled = false;
                this.disableRotation = true;
            }
            else
            {
                btnA.Enabled = true;
                btnB.Enabled = true;
                btnC.Enabled = true;
                tbAAxis.Enabled = true;
                tbBAxis.Enabled = true;
                tbCAxis.Enabled = true;
                this.disableRotation = false;
            }

        }
        #endregion

        #region Logging
        public void Log(string functionName, string result)
        {
            string msg = string.Format("{0}: Function {1} returns {2}{3}", DateTime.Now, functionName, result, Environment.NewLine);
            File.AppendAllText(logFileName, msg);
        }



        #endregion

        private void btnSnapRotation_Click(object sender, EventArgs e)
        {

        }
    }//Form1 class
}//SMXplanarLinker Namespace
