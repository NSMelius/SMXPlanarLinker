using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Input = Microsoft.Xna.Framework.Input;
namespace SMXPlanarLinker.XInput
{
    class XInputHandler
    {
        private int hController1Update;
        
        private GamePadStateAds gamePadStateAds = new GamePadStateAds();

        GamePadState[] gamePadState = new GamePadState[4];
        float vibrationAmount = 0.0f;

        public GamePadStateAds UpdateADS(GamePadState gamePadState)
        {


            gamePadStateAds.leftThumbStick.X = gamePadState.ThumbSticks.Left.X;
            gamePadStateAds.leftThumbStick.Y = gamePadState.ThumbSticks.Left.Y;
            gamePadStateAds.rightThumbStick.X = gamePadState.ThumbSticks.Right.X;
            gamePadStateAds.rightThumbStick.Y = gamePadState.ThumbSticks.Right.Y;

            gamePadStateAds.leftTrigger = gamePadState.Triggers.Left;
            gamePadStateAds.rightTrigger = gamePadState.Triggers.Right;

            gamePadStateAds.packetNumber = gamePadState.PacketNumber;
            gamePadStateAds.isConnected = gamePadState.IsConnected;


            gamePadStateAds.directionPad.Down = gamePadState.DPad.Down == Input.ButtonState.Pressed;
            gamePadStateAds.directionPad.Left = gamePadState.DPad.Left == Input.ButtonState.Pressed;
            gamePadStateAds.directionPad.Right = gamePadState.DPad.Right == Input.ButtonState.Pressed;
            gamePadStateAds.directionPad.Up = gamePadState.DPad.Up == Input.ButtonState.Pressed;

            gamePadStateAds.y = gamePadState.Buttons.Y == Input.ButtonState.Pressed;

            gamePadStateAds.x = gamePadState.Buttons.X == Input.ButtonState.Pressed;
            gamePadStateAds.b = gamePadState.Buttons.B == Input.ButtonState.Pressed;
            gamePadStateAds.a = gamePadState.Buttons.A == Input.ButtonState.Pressed;
            gamePadStateAds.back = gamePadState.Buttons.Back == Input.ButtonState.Pressed;
            //gamePadStateAds.bigButton = gamePadState.Buttons.BigButton == Input.ButtonState.Pressed;  //bigbutton is not the xbox button.  It is from big button pad
            gamePadStateAds.start = gamePadState.Buttons.Start == Input.ButtonState.Pressed;
            gamePadStateAds.leftShoulder = gamePadState.Buttons.LeftShoulder == Input.ButtonState.Pressed;
            gamePadStateAds.rightShoulder = gamePadState.Buttons.RightShoulder == Input.ButtonState.Pressed;
            gamePadStateAds.leftStick = gamePadState.Buttons.LeftStick == Input.ButtonState.Pressed;
            gamePadStateAds.rightStick = gamePadState.Buttons.RightStick == Input.ButtonState.Pressed;

            return gamePadStateAds;
            
        }

        public GamePadStateAds UpdateInput()
        {
            for (PlayerIndex i = PlayerIndex.One; i <= PlayerIndex.Four; i++)
            {
                gamePadState[(int)i] = GamePad.GetState(i);
                
            }

            //Todo implement outputs from plc for vibration.  Sample code below.
            #region "Output vibration code from sample code https://msdn.microsoft.com/en-us/library/bb203900.aspx"
            // Process input only if connected and button A is pressed.
            if (gamePadState[0].IsConnected && gamePadState[0].Buttons.A ==
                Microsoft.Xna.Framework.Input.ButtonState.Pressed)
            {
                // Button A is currently being pressed; add vibration.
                vibrationAmount =
                    MathHelper.Clamp(vibrationAmount + 0.03f, 0.0f, 1.0f);
                GamePad.SetVibration(PlayerIndex.One,
                    vibrationAmount, vibrationAmount);
            }
            else
            {
                // Button A is not being pressed; subtract some vibration.
                vibrationAmount =
                    MathHelper.Clamp(vibrationAmount - 0.05f, 0.0f, 1.0f);
                GamePad.SetVibration(PlayerIndex.One,
                    vibrationAmount, vibrationAmount);
            }
            #endregion

            //send controller 1 status to PLC
            return UpdateADS(gamePadState[0]);
        }
        private void tmrPoll_Tick(object sender, EventArgs e)
        {
            UpdateInput();
        }
    }//class

    #region "ADS Classes instead of XNAs GamePadState due to allignment issues"

    // TwinCAT2 Pack = 1, TwinCAT3 Pack = 0
    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    public class GamePadStateAds
    {
        public ThumbStick leftThumbStick = new ThumbStick();
        public ThumbStick rightThumbStick = new ThumbStick();
        public float leftTrigger;
        public float rightTrigger;

        // Connection Status
        public int packetNumber;
        [MarshalAs(UnmanagedType.I1)]
        public bool isConnected;

        // Direction Pad
        public DirectionPad directionPad = new DirectionPad();

        //Buttons

        [MarshalAs(UnmanagedType.I1)]
        public bool x;
        [MarshalAs(UnmanagedType.I1)]
        public bool y;
        [MarshalAs(UnmanagedType.I1)]
        public bool a;
        [MarshalAs(UnmanagedType.I1)]
        public bool b;
        [MarshalAs(UnmanagedType.I1)]
        public bool back;
        //[MarshalAs(UnmanagedType.I1)]
        //public bool bigButton;
        [MarshalAs(UnmanagedType.I1)]
        public bool start;
        [MarshalAs(UnmanagedType.I1)]
        public bool leftShoulder;
        [MarshalAs(UnmanagedType.I1)]
        public bool rightShoulder;
        [MarshalAs(UnmanagedType.I1)]
        public bool leftStick;
        [MarshalAs(UnmanagedType.I1)]
        public bool rightStick;
    }

    // TwinCAT2 Pack = 1, TwinCAT3 Pack = 0
    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    public class DirectionPad
    {
        [MarshalAs(UnmanagedType.I1)]
        public bool Down;
        [MarshalAs(UnmanagedType.I1)]
        public bool Left;
        [MarshalAs(UnmanagedType.I1)]
        public bool Right;
        [MarshalAs(UnmanagedType.I1)]
        public bool Up;
    }


    // TwinCAT2 Pack = 1, TwinCAT3 Pack = 0
    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    public class ThumbStick
    {
        public float X;
        public float Y;
    }

    #endregion "ADS class:
}//namespace
