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
            Dictionary<string, object> injectedProps = DT_CommonProps.InsertDynamicProperties(properties);
            _reportLoadBegin(id, type, platform, seq, injectedProps, mediation, mediationId);
        }


        public void ReportLoadEnd(string id, AdType type, AdPlatform platform, long duration, bool result, string seq,
            int errorCode = 0, string errorMessage = "",
            Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            Dictionary<string, object> injectedProps = DT_CommonProps.InsertDynamicProperties(properties);
            _reportLoadEnd(id, type, platform, duration, result, seq, errorCode, errorMessage, injectedProps, mediation, mediationId);
        }

        public void ReportToShow(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",
            Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            Dictionary<string, object> injectedProps = DT_CommonProps.InsertDynamicProperties(properties);
            _reportToShow(id, type, platform, location, seq, entrance, injectedProps, mediation, mediationId);
        }
        
        public void ReportShow(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",
            Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            Dictionary<string, object> injectedProps = DT_CommonProps.InsertDynamicProperties(properties);
            _reportShow(id, type, platform, location, seq, entrance, injectedProps, mediation, mediationId);
        }

        public void ReportShowFailed(string id, AdType type, AdPlatform platform, string location, string seq,
            int errorCode,
            string errorMessage,
            string entrance = "",
            Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            Dictionary<string, object> injectedProps = DT_CommonProps.InsertDynamicProperties(properties);
            _reportShowFailed(id, type, platform, location, seq, errorCode, errorMessage, entrance, injectedProps, mediation, mediationId);
        }


        public void ReportClose(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",
            Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            Dictionary<string, object> injectedProps = DT_CommonProps.InsertDynamicProperties(properties);
            _reportClose(id, type, platform, location, seq, entrance, injectedProps, mediation, mediationId);
        }

        public void ReportClick(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",
            Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            Dictionary<string, object> injectedProps = DT_CommonProps.InsertDynamicProperties(properties);
            _reportClick(id, type, platform, location, seq, entrance, injectedProps, mediation, mediationId);
        }

        public void ReportRewarded(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",
            Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            Dictionary<string, object> injectedProps = DT_CommonProps.InsertDynamicProperties(properties);
            _reportRewarded(id, type, platform, location, seq, entrance, injectedProps, mediation, mediationId);
        }

        public void ReportLeftApp(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",
            Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            Dictionary<string, object> injectedProps = DT_CommonProps.InsertDynamicProperties(properties);
            _reportLeftApp(id, type, platform, location, seq, entrance, injectedProps, mediation, mediationId);
        }

        public void ReportConversionByClick(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",
            Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            Dictionary<string, object> injectedProps = DT_CommonProps.InsertDynamicProperties(properties);
            _reportConversionByClick(id, type, platform, location, seq, entrance, injectedProps, mediation, mediationId);
        }

        public void ReportConversionByLeftApp(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",
            Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            Dictionary<string, object> injectedProps = DT_CommonProps.InsertDynamicProperties(properties);
            _reportConversionByLeftApp(id, type, platform, location, seq, entrance, injectedProps, mediation, mediationId);
        }


        public void ReportConversionByRewarded(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",
            Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            Dictionary<string, object> injectedProps = DT_CommonProps.InsertDynamicProperties(properties);
            _reportConversionByRewarded(id, type, platform, location, seq, entrance, injectedProps, mediation, mediationId);
        }

        public void ReportPaid(string id, AdType type, AdPlatform platform, string location, string seq, double value,
            string currency, string precision, string entrance = "",
            Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            Dictionary<string, object> injectedProps = DT_CommonProps.InsertDynamicProperties(properties);
            _reportPaid(id, type, platform, location, seq, value, currency, precision, entrance, injectedProps, mediation, mediationId);
        }

        public void ReportPaid(string id, AdType type, AdPlatform platform, string location, string seq,
            AdMediation mediation, string mediationId, double value,
            string precision, string country, Dictionary<string, object> properties = null)
        {
            Dictionary<string, object> injectedProps = DT_CommonProps.InsertDynamicProperties(properties);
            _reportPaid(id, type, platform, location, seq, mediation, mediationId, value, precision, country,
                injectedProps);
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