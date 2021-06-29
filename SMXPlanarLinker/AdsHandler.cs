using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using TwinCAT;
using TwinCAT.Ads;
using TwinCAT.Ads.TypeSystem;
using TwinCAT.TypeSystem;
using System.Text.RegularExpressions;

namespace SMXPlanarLinker.Ads
{
    
    class AdsHandler
    {
        private AdsClient adsClient;
        private ISymbolLoader loader;
        private const int defaultPlcPort = 851;
        private const string structureName = "SpaceMouseInputs";
        #region Enums and Structs
        public struct AdsSymbol
        {
            public string name;
            public uint varHandle;
            public SM_INPUTS input;
            public DataType type;

        }
        public enum SM_INPUTS
        {
            X_AXIS,
            Y_AXIS,
            Z_AXIS,
            A_AXIS,
            B_AXIS,
            C_AXIS,
            BUTTON_1,
            BUTTON_2
        }
        public enum eAdsDataTypes
        {
            ADS_BYTE,
            ADS_BOOL,
            ADS_SINT,
            ADS_USINT,
            ADS_WORD,
            ADS_INT,
            ADS_UINT,
            ADS_DINT,
            ADS_UDINT,
            ADS_LINT,
            ADS_ULINT,
            ADS_REAL,
            ADS_LREAL,
            ADS_STRING,
            ADS_WSTRING,
            ADS_ANY
        }
        private Dictionary<eAdsDataTypes, string> AdsDataTypes = new Dictionary<eAdsDataTypes, string>()
        {
            {eAdsDataTypes.ADS_BYTE,"BYTE"},
            {eAdsDataTypes.ADS_BOOL,"BOOL" },
            {eAdsDataTypes.ADS_SINT,"SINT" },
            {eAdsDataTypes.ADS_USINT,"USINT"},
            {eAdsDataTypes.ADS_WORD,"WORD" },
            {eAdsDataTypes.ADS_INT ,"INT" },
            {eAdsDataTypes.ADS_UINT ,"UINT" },
            {eAdsDataTypes.ADS_DINT ,"DINT" },
            {eAdsDataTypes.ADS_UDINT ,"UDINT" },
            {eAdsDataTypes.ADS_LINT ,"LINT" },
            {eAdsDataTypes.ADS_ULINT ,"ULINT" },
            {eAdsDataTypes.ADS_REAL ,"REAL" },
            {eAdsDataTypes.ADS_LREAL ,"LREAL" },
            {eAdsDataTypes.ADS_STRING ,"STRING" },
            {eAdsDataTypes.ADS_WSTRING ,"WSTRING" },
            {eAdsDataTypes.ADS_ANY, " " }
        };
        #endregion
        public AdsHandler()
        {     
             adsClient = new AdsClient();
        }

        #region Class Methods
        public List<string> getAdsSymbols(eAdsDataTypes eDataType)
        {
            Regex filter = new Regex(pattern: @"^MAIN.*");
            if (!checkAdsConnection())
                return null;

                List<string> symbolNames = new List<string>();
                
                
                foreach(Symbol symbol in this.loader.Symbols)
            {
                if (filter.IsMatch(symbol.InstancePath))
                {

                    
                        symbolNames.AddRange(getChildSymbols(symbol, eDataType));
                }
            }
               
            return symbolNames;
        }

        public void writeAdsSymbol(AdsHandler.AdsSymbol symbol, Object value)
        {
            if (checkMatchingType(symbol,eAdsDataTypes.ADS_INT))
            {
                writeInt(symbol, (int)value);
            }
            else if (checkMatchingType(symbol, eAdsDataTypes.ADS_BOOL))
            {
                writeBoolean(symbol, (bool)value);
            }
            else if(checkMatchingType(symbol, eAdsDataTypes.ADS_REAL))
            {

            }
           
        }

        public uint getVarHandle(string symbolPath)
        {
            
                return adsClient.CreateVariableHandle(symbolPath);
        }

        private void adsDisconnect()
        {
            this.adsClient.Disconnect();
 

        }

        public AdsErrorCode adsConnect(string amsNetId, int port = defaultPlcPort)
        {
            StateInfo state;
            AdsErrorCode adsError;
            if (checkAdsConnection())
                adsDisconnect();
            this.adsClient.Connect(amsNetId, port);
            adsError = this.adsClient.TryReadState(out state);
            if(adsError == AdsErrorCode.NoError)
                this.loader = SymbolLoaderFactory.Create(adsClient, SymbolLoaderSettings.Default);
            return adsError;
        }

        private bool checkAdsConnection()
        {
            StateInfo state;
            try
            {
                AdsErrorCode adsCode = adsClient.TryReadState(out state);
                if (adsCode == AdsErrorCode.NoError)
                    return true;
                else
                    return false;
            }
            catch(TwinCAT.ClientNotConnectedException e)
            {
                return false;
            }
            
        }
        private List<string> getChildSymbols( Symbol symbol,eAdsDataTypes eDataType)
        {
            List<string> list = new List<string>();
            if (symbol.SubSymbolCount != 0)
            {
                foreach (Symbol sub in symbol.SubSymbols)
                {

                    if (eDataType == eAdsDataTypes.ADS_ANY ||
                        sub.DataType.Name.Equals(AdsDataTypes[eDataType]) ||
                        sub.DataType.Name.Equals(structureName))
                    { list.AddRange(getChildSymbols(sub, eDataType)); }

                }
            }
            list.Add(symbol.InstancePath);
            return list;
        }
        public AdsHandler.AdsSymbol getSymbolInfo(string symbolPath)
        {
            AdsHandler.AdsSymbol symbol = new AdsHandler.AdsSymbol();
            symbol.name = symbolPath;
            symbol.varHandle = getVarHandle(symbolPath);
            symbol.type = (DataType)loader.Symbols[symbolPath].DataType;
            return symbol;
        }

        public void deleteSymbolHandle(AdsHandler.AdsSymbol symbol)
        {
            if (checkAdsConnection())
                try { 
                adsClient.DeleteVariableHandle(symbol.varHandle);
                }catch(Exception e)
                {

                }
        }
        public bool checkMatchingType(AdsHandler.AdsSymbol symbol,eAdsDataTypes eDataType)
        {
            if (symbol.type.Name.Equals(AdsDataTypes[eDataType]))
                return true;
            else
                return false;
        }
        public void closeAds(List<AdsHandler.AdsSymbol> symbols)
        {
            if (checkAdsConnection())
            {
                foreach(AdsHandler.AdsSymbol symbol in symbols)
                {
                    deleteSymbolHandle(symbol);
                }
                adsDisconnect();
            }
        }

        private void writeInt(AdsHandler.AdsSymbol symbol, int value)
        {
            Int16 maxVal = 350;
            Int16 minVal = -350;
            Int16 val = (Int16)value > maxVal ? maxVal : (Int16)value < minVal ? minVal : (Int16)value;
            if (checkAdsConnection())
            {

                adsClient.WriteAny(symbol.varHandle, val);

            }
        }
        private void writeBoolean(AdsHandler.AdsSymbol symbol, bool value)
        {
            adsClient.WriteAny(symbol.varHandle, value);
        }
        #endregion
    }
}
