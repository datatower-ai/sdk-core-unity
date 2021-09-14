using System.Collections.Generic;
using ROIQuery.Utils;

namespace ROIQuery.AdReport.Wrapper
{
    public partial class ROIQueryAdReportWrapper
    {
#if UNITY_STANDALONE || UNITY_EDITOR
        private void _init()
        {
            R_Log.Debug("Editor Log: calling init.");
        }


        private void _reportEntrance(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",Dictionary<string, object> properties = null)
        {
            R_Log.Debug("Editor Log: calling reportEntrance.");
        }

        private void _reportToShow(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",Dictionary<string, object> properties = null)
        {
            R_Log.Debug("Editor Log: calling reportToShow.");
        }


        private void _reportShow(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",Dictionary<string, object> properties = null)
        {
            R_Log.Debug("Editor Log: calling reportShow.");
        }

        private void _reportImpression(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",Dictionary<string, object> properties = null)
        {
            R_Log.Debug("Editor Log: calling reportShow.");
        }

        private void _reportClose(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",Dictionary<string, object> properties = null)
        {
            R_Log.Debug("Editor Log: calling reportClose.");
        }

        private void _reportClick(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",Dictionary<string, object> properties = null)
        {
            R_Log.Debug("Editor Log: calling reportClick.");
        }

        private void _reportRewarded(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",Dictionary<string, object> properties = null)
        {
            R_Log.Debug("Editor Log: calling reportRewarded.");
        }

        private void _reportLeftApp(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",Dictionary<string, object> properties = null)
        {
            R_Log.Debug("Editor Log: calling reportLeftApp.");
        }

        private void _reportConversionByClick(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",Dictionary<string, object> properties = null)
        {
            R_Log.Debug("Editor Log: calling reportConversionByClick.");
        }

        private void _reportConversionByLeftApp(string id, AdType type, AdPlatform platform, string location,
            string seq, string entrance = "",Dictionary<string, object> properties = null)
        {
            R_Log.Debug("Editor Log: calling reportConversionByLeftApp.");
        }

        private void _reportConversionByImpression(string id, AdType type, AdPlatform platform, string location,
            string seq, string entrance = "",Dictionary<string, object> properties = null)
        {
            R_Log.Debug("Editor Log: calling reportConversionByImpression.");
        }

        private void _reportConversionByRewarded(string id, AdType type, AdPlatform platform, string location,
            string seq, string entrance = "",Dictionary<string, object> properties = null)
        {
            R_Log.Debug("Editor Log: calling reportConversionByRewarded.");
        }

        private void _reportPaid(string id, AdType type, AdPlatform platform, string location, string seq, string value,
            string currency, string precision, string entrance = "",Dictionary<string, object> properties = null)
        {
            R_Log.Debug("Editor Log: calling reportPaid.");
        }


        private void _reportPaid(string id, AdType type, string platform, string location, string seq,
            AdMediation mediation, string mediationId, string value, string currency, string precision, string country,
            string entrance = "",Dictionary<string, object> properties = null)
        {
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