using System.Collections.Generic;

namespace DataTower
{
    public partial class DTAdReportWrapper
    {
        private DTAdReportWrapper()
        {
            _init();
        }

        public static DTAdReportWrapper Instance => Nested.instance;


        public void ReportLoadBegin(string id, AdType type, AdPlatform platform, string seq,
            Dictionary<string, object> properties = null)
        {
            _reportLoadBegin(id, type, platform, seq, properties);
        }


        public void ReportLoadEnd(string id, AdType type, AdPlatform platform, long duration, bool result, string seq,
            int errorCode = 0, string errorMessage = "",
            Dictionary<string, object> properties = null)
        {
            _reportLoadEnd(id, type, platform, duration, result, seq, errorCode, errorMessage, properties);
        }

        public void ReportToShow(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",
            Dictionary<string, object> properties = null)
        {
            _reportToShow(id, type, platform, location, seq, entrance, properties);
        }

        public void ReportImpression(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",
            Dictionary<string, object> properties = null)
        {
            _reportImpression(id, type, platform, location, seq, entrance, properties);
        }


        public void ReportShow(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",
            Dictionary<string, object> properties = null)
        {
            _reportShow(id, type, platform, location, seq, entrance, properties);
        }

        public void ReportShowFailed(string id, AdType type, AdPlatform platform, string location, string seq,
            int errorCode,
            string errorMessage,
            string entrance = "",
            Dictionary<string, object> properties = null)
        {
            _reportShowFailed(id, type, platform, location, seq, errorCode, errorMessage, entrance, properties);
        }


        public void ReportClose(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",
            Dictionary<string, object> properties = null)
        {
            _reportClose(id, type, platform, location, seq, entrance, properties);
        }

        public void ReportClick(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",
            Dictionary<string, object> properties = null)
        {
            _reportClick(id, type, platform, location, seq, entrance, properties);
        }

        public void ReportRewarded(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",
            Dictionary<string, object> properties = null)
        {
            _reportRewarded(id, type, platform, location, seq, entrance, properties);
        }

        public void ReportLeftApp(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",
            Dictionary<string, object> properties = null)
        {
            _reportLeftApp(id, type, platform, location, seq, entrance, properties);
        }

        public void ReportConversionByClick(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",
            Dictionary<string, object> properties = null)
        {
            _reportConversionByClick(id, type, platform, location, seq, entrance, properties);
        }

        public void ReportConversionByLeftApp(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",
            Dictionary<string, object> properties = null)
        {
            _reportConversionByLeftApp(id, type, platform, location, seq, entrance, properties);
        }


        public void ReportConversionByRewarded(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",
            Dictionary<string, object> properties = null)
        {
            _reportConversionByRewarded(id, type, platform, location, seq, entrance, properties);
        }

        public void ReportPaid(string id, AdType type, AdPlatform platform, string location, string seq, string value,
            string currency, string precision, string entrance = "",
            Dictionary<string, object> properties = null)
        {
            _reportPaid(id, type, platform, location, seq, value, currency, precision, entrance, properties);
        }

        public void ReportPaid(string id, AdType type, string platform, string adgroupName, string adgroupType,
            string location, string seq,
            AdMediation mediation, string mediationId, string value, string currency, string precision, string country,
            string entrance = "",
            Dictionary<string, object> properties = null)
        {
            _reportPaid(id, type, platform, adgroupName, adgroupType, location, seq, mediation, mediationId, value,
                currency,
                precision, country, entrance, properties);
        }

        public void ReportPaid(string id, AdType type, AdPlatform platform, string location, string seq,
            AdMediation mediation, string mediationId, string value,
            string precision, string country, Dictionary<string, object> properties = null)
        {
            _reportPaid(id, type, platform, location, seq, mediation, mediationId, value, precision, country,
                properties);
        }

        private class Nested
        {
            internal static readonly DTAdReportWrapper instance = new DTAdReportWrapper();

            //Explicit static constructor to tell C# compiler
            //not to mark type as beforefieldinit
            static Nested()
            {
            }
        }
    }
}