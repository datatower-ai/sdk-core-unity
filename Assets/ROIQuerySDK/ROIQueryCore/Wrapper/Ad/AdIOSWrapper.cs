using System.Collections.Generic;
using ROIQuery.Utils;
using UnityEngine;
using System.Runtime.InteropServices;

namespace ROIQuery.AdReport.Wrapper
{
    public partial class ROIQueryAdReportWrapper
    {
#if UNITY_IOS && !(UNITY_EDITOR)
        [DllImport("__Internal")]
        private static extern void reportEntrance(string id, int type, int platform, string location, string seq,
            string entrance);

        [DllImport("__Internal")]
        private static extern void reportToShow(string id, int type, int platform, string location, string seq,
            string entrance);

        [DllImport("__Internal")]
        private static extern void reportShow(string id, int type, int platform, string location, string seq,
            string entrance);

        [DllImport("__Internal")]
        private static extern void reportImpression(string id, int type, int platform, string location, string seq,
            string entrance);

        [DllImport("__Internal")]
        private static extern void reportClose(string id, int type, int platform, string location, string seq,
            string entrance);

        [DllImport("__Internal")]
        private static extern void reportClick(string id, int type, int platform, string location, string seq,
            string entrance);

        [DllImport("__Internal")]
        private static extern void reportRewarded(string id, int type, int platform, string location, string seq,
            string entrance);

        [DllImport("__Internal")]
        private static extern void reportLeftApp(string id, int type, int platform, string location, string seq,
            string entrance);

        [DllImport("__Internal")]
        private static extern void reportConversionByClick(string id, int type, int platform, string location,
            string seq, string entrance);

        [DllImport("__Internal")]
        private static extern void reportConversionByLeftApp(string id, int type, int platform, string location,
            string seq, string entrance);

        [DllImport("__Internal")]
        private static extern void reportConversionByImpression(string id, int type, int platform, string location,
            string seq, string entrance);

        [DllImport("__Internal")]
        private static extern void reportConversionByRewarded(string id, int type, int platform, string location,
            string seq, string entrance);

        [DllImport("__Internal")]
        private static extern void reportPaid(string id, int type, int platform, string location, string seq,
            string value, string currency, string precision, string entrance);

        [DllImport("__Internal")]
        private static extern void reportPaidWithMediation(string id, int type, string platform, string location,
            string seq,
            int mediation, string mediationId, string value, string currency, string precision, string country,
            string entrance);

        private void _init()
        {
            R_Log.Debug("Editor Log: calling init.");
        }


        private void _reportEntrance(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "")
        {
            reportEntrance(id, (int) type, (int) platform, location, seq, entrance);
            R_Log.Debug("Editor Log: calling reportEntrance.seq:" + seq);
        }

        private void _reportToShow(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "")
        {
            reportToShow(id, (int) type, (int) platform, location, seq, entrance);
            R_Log.Debug("Editor Log: calling reportToShow.");
        }

        private void _reportShow(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "")
        {
            reportShow(id, (int) type, (int) platform, location, seq, entrance);
            R_Log.Debug("Editor Log: calling reportShow.");
        }

        private void _reportImpression(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "")
        {
            reportImpression(id, (int) type, (int) platform, location, seq, entrance);
            R_Log.Debug("Editor Log: calling reportImpression.");
        }

        private void _reportClose(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "")
        {
            reportClose(id, (int) type, (int) platform, location, seq, entrance);
            R_Log.Debug("Editor Log: calling reportClose.");
        }

        private void _reportClick(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "")
        {
            reportClick(id, (int) type, (int) platform, location, seq, entrance);
            R_Log.Debug("Editor Log: calling reportClick.");
        }

        private void _reportRewarded(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "")
        {
            reportRewarded(id, (int) type, (int) platform, location, seq, entrance);
            R_Log.Debug("Editor Log: calling reportRewarded.");
        }

        private void _reportLeftApp(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "")
        {
            reportLeftApp(id, (int) type, (int) platform, location, seq, entrance);
            R_Log.Debug("Editor Log: calling reportLeftApp.");
        }

        private void _reportConversionByClick(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "")
        {
            reportConversionByClick(id, (int) type, (int) platform, location, seq, entrance);
            R_Log.Debug("Editor Log: calling reportConversionByClick.");
        }

        private void _reportConversionByLeftApp(string id, AdType type, AdPlatform platform, string location,
            string seq, string entrance = "")
        {
            reportConversionByLeftApp(id, (int) type, (int) platform, location, seq, entrance);
            R_Log.Debug("Editor Log: calling reportConversionByLeftApp.");
        }

        private void _reportConversionByImpression(string id, AdType type, AdPlatform platform, string location,
            string seq, string entrance = "")
        {
            reportConversionByImpression(id, (int) type, (int) platform, location, seq, entrance);
            R_Log.Debug("Editor Log: calling reportConversionByImpression.");
        }

        private void _reportConversionByRewarded(string id, AdType type, AdPlatform platform, string location,
            string seq, string entrance = "")
        {
            reportConversionByRewarded(id, (int) type, (int) platform, location, seq, entrance);
            R_Log.Debug("Editor Log: calling reportConversionByRewarded.");
        }

        private void _reportPaid(string id, AdType type, AdPlatform platform, string location, string seq, string value,
            string currency, string precision, string entrance = "")
        {
            reportPaid(id, (int) type, (int) platform, location, seq, value, currency, precision, entrance);
            R_Log.Debug("Editor Log: calling reportPaid.");
        }


        private void _reportPaid(string id, AdType type, string platform, string location, string seq,
            AdMediation mediation, string mediationId, string value, string currency, string precision, string country,
            string entrance = "")
        {
            reportPaidWithMediation(id, (int) type, platform, location, seq, (int) mediation, mediationId, value,
                currency,
                precision, country, entrance);
            R_Log.Debug("Editor Log: calling reportPaid.");
        }


        private string _generateUUID()
        {
            R_Log.Debug("Editor Log: calling onAppBackgrounded.");
            return "";
        }

#endif
    }
}