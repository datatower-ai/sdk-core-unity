using System;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

namespace ROIQuery
{
    public partial class ROIQueryAdReportWrapper
    {
        #if UNITY_IOS && !(UNITY_EDITOR)

        [DllImport("__Internal")]
        private static extern void reportLoadBegin(string id, int type, int platform, string seq, string properties);


        [DllImport("__Internal")]
        private static extern void reportLoadEnd(string id, int type, int platform, long duration, bool result, string seq, int errorCode, string errorMessage, string properties);


        [DllImport("__Internal")]
        private static extern void reportShowFailed(string id, int type, int platform, string location, string seq, int errorCode, string errorMessage, string entrance, string properties);


        [DllImport("__Internal")]
        private static extern void reportEntrance(string id, int type, int platform, string location, string seq,
                    string properties,string entrance);

        [DllImport("__Internal")]
        private static extern void reportToShow(string id, int type, int platform, string location, string seq,
            string properties,string entrance);

        [DllImport("__Internal")]
        private static extern void reportShow(string id, int type, int platform, string location, string seq,
            string properties,string entrance);

        [DllImport("__Internal")]
        private static extern void reportImpression(string id, int type, int platform, string location, string seq,
            string properties,string entrance);

        [DllImport("__Internal")]
        private static extern void reportClose(string id, int type, int platform, string location, string seq,
            string properties,string entrance);

        [DllImport("__Internal")]
        private static extern void reportClick(string id, int type, int platform, string location, string seq,
            string properties,string entrance);

        [DllImport("__Internal")]
        private static extern void reportRewarded(string id, int type, int platform, string location, string seq,
            string properties,string entrance);

        [DllImport("__Internal")]
        private static extern void reportLeftApp(string id, int type, int platform, string location, string seq,
            string properties,string entrance);

        [DllImport("__Internal")]
        private static extern void reportConversionByClick(string id, int type, int platform, string location,
            string seq, string properties,string entrance);

        [DllImport("__Internal")]
        private static extern void reportConversionByLeftApp(string id, int type, int platform, string location,
            string seq, string properties,string entrance);

        [DllImport("__Internal")]
        private static extern void reportConversionByImpression(string id, int type, int platform, string location,
            string seq, string properties, string entrance);

        [DllImport("__Internal")]
        private static extern void reportConversionByRewarded(string id, int type, int platform, string location,
            string seq, string properties, string entrance);

        [DllImport("__Internal")]
        private static extern void reportPaid(string id, int type, int platform, string location, string seq,
            string value, string currency, string precision, string properties, string entrance);

        [DllImport("__Internal")]
        private static extern void reportPaidWithMediation(string id, int type, string platform,string adgroupType, string location,
            string seq,
            int mediation, string mediationId, string value, string currency, string precision, string country,
            string properties, string entrance);

        [DllImport("__Internal")]
        private static extern int getPlatform(int mediation, string networkName, string networkPlacementId,
            string adgroupType);
        
        [DllImport("__Internal")]
        private static extern string generateUUID();
        
        
        
        private AdPlatform ParseToAdPlatform(int platform)
        {
            return Enum.TryParse(platform.ToString(), out AdPlatform adPlatform) ? adPlatform : AdPlatform.IDLE;
        }
        private void _init()
        {
            R_Log.Debug("Editor Log: calling init.");
        }


        private void _reportEntrance(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",Dictionary<string, object> properties = null)
        {
            reportEntrance(id, (int) type, (int) platform, location, seq, R_Utils.Parse2JsonStr(properties), entrance);
            R_Log.Debug("Editor Log: calling reportEntrance.seq:" + seq);
        }

        private void _reportToShow(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",Dictionary<string, object> properties = null)
        {
            reportToShow(id, (int) type, (int) platform, location, seq, R_Utils.Parse2JsonStr(properties),  entrance);
            R_Log.Debug("Editor Log: calling reportToShow.");
        }

        private void _reportShow(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",Dictionary<string, object> properties = null)
        {
            reportShow(id, (int) type, (int) platform, location, seq, R_Utils.Parse2JsonStr(properties),  entrance);
            R_Log.Debug("Editor Log: calling reportShow.");
        }

        private void _reportImpression(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",Dictionary<string, object> properties = null)
        {
            reportImpression(id, (int) type, (int) platform, location, seq, R_Utils.Parse2JsonStr(properties),  entrance);
            R_Log.Debug("Editor Log: calling reportImpression.");
        }

        private void _reportClose(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",Dictionary<string, object> properties = null)
        {
            reportClose(id, (int) type, (int) platform, location, seq, R_Utils.Parse2JsonStr(properties),  entrance);
            R_Log.Debug("Editor Log: calling reportClose.");
        }

        private void _reportClick(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",Dictionary<string, object> properties = null)
        {
            reportClick(id, (int) type, (int) platform, location, seq,  R_Utils.Parse2JsonStr(properties), entrance);
            R_Log.Debug("Editor Log: calling reportClick.");
        }

        private void _reportRewarded(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",Dictionary<string, object> properties = null)
        {
            reportRewarded(id, (int) type, (int) platform, location, seq, R_Utils.Parse2JsonStr(properties),  entrance);
            R_Log.Debug("Editor Log: calling reportRewarded.");
        }

        private void _reportLeftApp(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",Dictionary<string, object> properties = null)
        {
            reportLeftApp(id, (int) type, (int) platform, location, seq, R_Utils.Parse2JsonStr(properties),  entrance);
            R_Log.Debug("Editor Log: calling reportLeftApp.");
        }

        private void _reportConversionByClick(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",Dictionary<string, object> properties = null)
        {
            reportConversionByClick(id, (int) type, (int) platform, location, seq, R_Utils.Parse2JsonStr(properties),  entrance);
            R_Log.Debug("Editor Log: calling reportConversionByClick.");
        }

        private void _reportConversionByLeftApp(string id, AdType type, AdPlatform platform, string location,
            string seq, string entrance = "",Dictionary<string, object> properties = null)
        {
            reportConversionByLeftApp(id, (int) type, (int) platform, location, seq, R_Utils.Parse2JsonStr(properties),  entrance);
            R_Log.Debug("Editor Log: calling reportConversionByLeftApp.");
        }

        private void _reportConversionByImpression(string id, AdType type, AdPlatform platform, string location,
            string seq, string entrance = "",Dictionary<string, object> properties = null)
        {
            reportConversionByImpression(id, (int) type, (int) platform, location, seq, R_Utils.Parse2JsonStr(properties),  entrance);
            R_Log.Debug("Editor Log: calling reportConversionByImpression.");
        }

        private void _reportConversionByRewarded(string id, AdType type, AdPlatform platform, string location,
            string seq, string entrance = "",Dictionary<string, object> properties = null)
        {
            reportConversionByRewarded(id, (int) type, (int) platform, location, seq, R_Utils.Parse2JsonStr(properties),  entrance);
            R_Log.Debug("Editor Log: calling reportConversionByRewarded.");
        }

        private void _reportPaid(string id, AdType type, AdPlatform platform, string location, string seq, string value,
            string currency, string precision, string entrance = "",Dictionary<string, object> properties = null)
        {
            reportPaid(id, (int) type, (int) platform, location, seq, value, currency, precision, R_Utils.Parse2JsonStr(properties),  entrance);
            R_Log.Debug("Editor Log: calling reportPaid.");
        }


        private void _reportPaid(string id, AdType type, string platform,string adgroupName, string adgroupType, string location, string seq,
            AdMediation mediation, string mediationId, string value, string currency, string precision, string country,
            string entrance = "",Dictionary<string, object> properties = null)
        {
            reportPaidWithMediation(id, (int) type, platform, adgroupType, location, seq, (int) mediation, mediationId, value,
                currency,
                precision, country,  R_Utils.Parse2JsonStr(properties), entrance);
            R_Log.Debug("Editor Log: calling reportPaid.");
        }

        private void _reportPaid(string id, AdType type, AdPlatform platform, string location, string seq,AdMediation mediation, string mediationId,  string value,
            string precision, string country, Dictionary<string, object> properties = null)
        {
            R_Log.Debug("Editor Log: calling reportPaid.");
        }

        private string _generateUUID()
        {
            R_Log.Debug("Editor Log: calling onAppBackgrounded.");
            return generateUUID();
        }

         private AdPlatform _getPlatform(AdMediation mediation, string networkName, string networkPlacementId, string adgroupName, string adgroupType)
         {
             return ParseToAdPlatform(getPlatform((int) mediation, networkName, networkPlacementId, adgroupType));
         }
#endif
    }
}