using System.Collections.Generic;

namespace DataTower.Core.Wrapper
{
    public partial class DTAdReportWrapper
    {
        private DTAdReportWrapper()
        {
            _init();
        }

        public static DTAdReportWrapper Instance => Nested.Instance;


        public void ReportLoadBegin(string id, AdType type, AdPlatform platform, string seq,
            Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            _reportLoadBegin(id, type, platform, seq, properties, mediation, mediationId);
        }


        public void ReportLoadEnd(string id, AdType type, AdPlatform platform, long duration, bool result, string seq,
            int errorCode = 0, string errorMessage = "",
            Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            _reportLoadEnd(id, type, platform, duration, result, seq, errorCode, errorMessage, properties, mediation, mediationId);
        }

        public void ReportToShow(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",
            Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            _reportToShow(id, type, platform, location, seq, entrance, properties, mediation, mediationId);
        }
        
        public void ReportShow(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",
            Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            _reportShow(id, type, platform, location, seq, entrance, properties, mediation, mediationId);
        }

        public void ReportShowFailed(string id, AdType type, AdPlatform platform, string location, string seq,
            int errorCode,
            string errorMessage,
            string entrance = "",
            Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            _reportShowFailed(id, type, platform, location, seq, errorCode, errorMessage, entrance, properties, mediation, mediationId);
        }


        public void ReportClose(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",
            Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            _reportClose(id, type, platform, location, seq, entrance, properties, mediation, mediationId);
        }

        public void ReportClick(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",
            Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            _reportClick(id, type, platform, location, seq, entrance, properties, mediation, mediationId);
        }

        public void ReportRewarded(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",
            Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            _reportRewarded(id, type, platform, location, seq, entrance, properties, mediation, mediationId);
        }

        public void ReportLeftApp(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",
            Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            _reportLeftApp(id, type, platform, location, seq, entrance, properties, mediation, mediationId);
        }

        public void ReportConversionByClick(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",
            Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            _reportConversionByClick(id, type, platform, location, seq, entrance, properties, mediation, mediationId);
        }

        public void ReportConversionByLeftApp(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",
            Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            _reportConversionByLeftApp(id, type, platform, location, seq, entrance, properties, mediation, mediationId);
        }


        public void ReportConversionByRewarded(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",
            Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            _reportConversionByRewarded(id, type, platform, location, seq, entrance, properties, mediation, mediationId);
        }

        public void ReportPaid(string id, AdType type, AdPlatform platform, string location, string seq, double value,
            string currency, string precision, string entrance = "",
            Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            _reportPaid(id, type, platform, location, seq, value, currency, precision, entrance, properties, mediation, mediationId);
        }

        public void ReportPaid(string id, AdType type, string platform, string adgroupName, string adgroupType,
            string location, string seq,
            AdMediation mediation, string mediationId, double value, string currency, string precision, string country,
            string entrance = "",
            Dictionary<string, object> properties = null)
        {
            _reportPaid(id, type, platform, adgroupName, adgroupType, location, seq, mediation, mediationId, value,
                currency,
                precision, country, entrance, properties);
        }

        public void ReportPaid(string id, AdType type, AdPlatform platform, string location, string seq,
            AdMediation mediation, string mediationId, double value,
            string precision, string country, Dictionary<string, object> properties = null)
        {
            _reportPaid(id, type, platform, location, seq, mediation, mediationId, value, precision, country,
                properties);
        }

        public void ReportReturnApp()
        {
            _reportReturnApp();
        }

        private class Nested
        {
            internal static readonly DTAdReportWrapper Instance = new DTAdReportWrapper();

            //Explicit static constructor to tell C# compiler
            //not to mark type as beforefieldinit
            static Nested()
            {
            }
        }
    }
}