using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DataTower.Core
{
    public partial class DTAdReportWrapper
    {
#if UNITY_IOS && !(UNITY_EDITOR)
        [DllImport("__Internal")]
        private static extern void reportLoadBegin(string id, int type, int platform, string seq, int mediation, string mediationId, string properties);
        
        
        [DllImport("__Internal")]
        private static extern void reportLoadEnd(string id, int type, int platform, long duration, bool result, string seq, int mediation, string mediationId, int errorCode, string errorMessage, string properties);
        
        
        [DllImport("__Internal")]
        private static extern void reportShowFailed(string id, int type, int platform, string location, string seq, int mediation, string mediationId, int errorCode, string errorMessage, string entrance, string properties);
        
        [DllImport("__Internal")]
        private static extern void reportToShow(string id, int type, int platform, string location, string seq,int mediation, string mediationId, 
            string properties,string entrance);
        
        [DllImport("__Internal")]
        private static extern void reportShow(string id, int type, int platform, string location, string seq,
            int mediation, string mediationId, string properties,string entrance);
        
        [DllImport("__Internal")]
        private static extern void reportAdShowFail(string id, int type, int platform, string location, string seq,int mediation, string mediationId, 
            int errorCode, string errorMessage,string properties,string entrance);
        
        [DllImport("__Internal")]
        private static extern void reportImpression(string id, int type, int platform, string location, string seq,int mediation, string mediationId, 
            string properties,string entrance);
        
        [DllImport("__Internal")]
        private static extern void reportClose(string id, int type, int platform, string location, string seq,
            int mediation, string mediationId, string properties,string entrance);
        
        [DllImport("__Internal")]
        private static extern void reportClick(string id, int type, int platform, string location, string seq,
            int mediation, string mediationId, string properties,string entrance);
        
        [DllImport("__Internal")]
        private static extern void reportRewarded(string id, int type, int platform, string location, string seq,int mediation, string mediationId, 
            string properties,string entrance);
        
        [DllImport("__Internal")]
        private static extern void reportLeftApp(string id, int type, int platform, string location, string seq,int mediation, string mediationId, 
            string properties,string entrance);
        
        [DllImport("__Internal")]
        private static extern void reportConversionByClick(string id, int type, int platform, string location,
            string seq, int mediation, string mediationId, string properties,string entrance);
        
        [DllImport("__Internal")]
        private static extern void reportConversionByLeftApp(string id, int type, int platform, string location,
            string seq, int mediation, string mediationId, string properties,string entrance);
        
        [DllImport("__Internal")]
        private static extern void reportConversionByRewarded(string id, int type, int platform, string location,
            string seq, int mediation, string mediationId, string properties, string entrance);
        
        [DllImport("__Internal")]
        private static extern void reportPaid(string id, int type, int platform, string location, string seq,
            int mediation, string mediationId, double value, string currency, string precision, string properties, string entrance);
        
        // [DllImport("__Internal")]
        // private static extern void reportPaidWithMediation(string id, int type, int platform,string adgroupType, string location,
        //     string seq,
        //     int mediation, string mediationId, string value, string currency, string precision, string country,
        //     string properties, string entrance);
        
        private void _init()
        {
            // R_Log.Debug("Editor Log: calling init.");
        }
        
        private void _reportLoadBegin(string id, AdType type, AdPlatform platform,string seq,Dictionary<string, object> properties
 = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            reportLoadBegin(id, (int) type, (int) platform,  seq, (int)mediation, mediationId, R_Utils.Parse2JsonStr(properties));
            R_Log.Debug("Editor Log: calling reportEntrance.seq:" + seq);
        }

        private void _reportLoadEnd(string id, AdType type, AdPlatform platform, long duration,  bool result, string seq,
            int errorCode, string errorMessage,Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            reportLoadEnd(id,(int) type, (int) platform,  duration, result,seq, (int)mediation, mediationId,errorCode, errorMessage,
                R_Utils.Parse2JsonStr(properties));
        }
        private void _reportToShow(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            reportToShow(id, (int) type, (int) platform, location, seq, (int)mediation, mediationId, R_Utils.Parse2JsonStr(properties),  entrance);
            R_Log.Debug("Editor Log: calling reportToShow.");
        }

        private void _reportShow(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            reportShow(id, (int) type, (int) platform, location, seq, (int)mediation, mediationId, R_Utils.Parse2JsonStr(properties),  entrance);
            R_Log.Debug("Editor Log: calling reportShow.");
        }
        
        private void _reportShowFailed(string id, AdType type, AdPlatform platform, string location, string seq, 
            int errorCode, string errorMessage, string entrance, Dictionary<string, object> properties, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            reportAdShowFail(id,(int) type, (int) platform, location, seq, (int)mediation, mediationId, errorCode,errorMessage,R_Utils.Parse2JsonStr(properties),entrance);
            R_Log.Debug("Editor Log: calling reportShow Fail.");
        }

        private void _reportImpression(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            reportImpression(id, (int) type, (int) platform, location, seq, (int)mediation, mediationId, R_Utils.Parse2JsonStr(properties),  entrance);
            R_Log.Debug("Editor Log: calling reportImpression.");
        }

        private void _reportClose(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            reportClose(id, (int) type, (int) platform, location, seq, (int)mediation, mediationId, R_Utils.Parse2JsonStr(properties),  entrance);
            R_Log.Debug("Editor Log: calling reportClose.");
        }

        private void _reportClick(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            reportClick(id, (int) type, (int) platform, location, seq, (int)mediation, mediationId,  R_Utils.Parse2JsonStr(properties), entrance);
            R_Log.Debug("Editor Log: calling reportClick.");
        }

        private void _reportRewarded(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            reportRewarded(id, (int) type, (int) platform, location, seq,(int)mediation, mediationId,  R_Utils.Parse2JsonStr(properties),  entrance);
            R_Log.Debug("Editor Log: calling reportRewarded.");
        }

        private void _reportLeftApp(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            reportLeftApp(id, (int) type, (int) platform, location, seq, (int)mediation, mediationId, R_Utils.Parse2JsonStr(properties),  entrance);
            R_Log.Debug("Editor Log: calling reportLeftApp.");
        }

        private void _reportConversionByClick(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            reportConversionByClick(id, (int) type, (int) platform, location, seq, (int)mediation, mediationId, R_Utils.Parse2JsonStr(properties),  entrance);
            R_Log.Debug("Editor Log: calling reportConversionByClick.");
        }

        private void _reportConversionByLeftApp(string id, AdType type, AdPlatform platform, string location,
            string seq, string entrance = "",Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            reportConversionByLeftApp(id, (int) type, (int) platform, location, seq, (int)mediation, mediationId, R_Utils.Parse2JsonStr(properties),  entrance);
            R_Log.Debug("Editor Log: calling reportConversionByLeftApp.");
        }


        private void _reportConversionByRewarded(string id, AdType type, AdPlatform platform, string location,
            string seq, string entrance = "",Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            reportConversionByRewarded(id, (int) type, (int) platform, location, seq, (int)mediation, mediationId, R_Utils.Parse2JsonStr(properties),  entrance);
            R_Log.Debug("Editor Log: calling reportConversionByRewarded.");
        }

        private void _reportPaid(string id, AdType type, AdPlatform platform, string location, string seq, double value,
            string currency, string precision, string entrance = "",Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            reportPaid(id, (int) type, (int) platform, location, seq, (int)mediation, mediationId, value, currency, precision, R_Utils.Parse2JsonStr(properties),  entrance);
            R_Log.Debug("Editor Log: calling reportPaid.");
        }


        private void _reportPaid(string id, AdType type, string platform, string adgroupName, string adgroupType, string location, string seq,
            AdMediation mediation, string mediationId, double value, string currency, string precision, string country,
            string entrance = "",Dictionary<string, object> properties = null)
        {
            // int intPlatform = platformFromString(platform);
            // reportPaidWithMediation(id, (int) type, intPlatform, adgroupType, location, seq, (int) mediation, mediationId, value,
            //     currency,
            //     precision, country,  R_Utils.Parse2JsonStr(properties), entrance);
            // R_Log.Debug("Editor Log: calling reportPaid.");
        }

        private void _reportPaid(string id, AdType type, AdPlatform platform, string location, string seq,AdMediation mediation, string mediationId,  double value,
            string precision, string country, Dictionary<string, object> properties = null)
        {
            // R_Log.Debug("Editor Log: calling reportPaid.");
        }

        private void _reportReturnApp()
        {
        }
#endif
    }
}