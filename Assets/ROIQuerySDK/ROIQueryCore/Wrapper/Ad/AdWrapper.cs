

namespace ROIQuery.AdReport.Wrapper
{
    

    public partial class ROIQueryAdReportWrapper
    {

        private ROIQueryAdReportWrapper() {
            _init();
        }

        public static ROIQueryAdReportWrapper Instance { get { return Nested.instance; } }

        private class Nested
        {
            //Explicit static constructor to tell C# compiler
            //not to mark type as beforefieldinit
            static Nested()
            {

            }
            internal static readonly ROIQueryAdReportWrapper instance = new ROIQueryAdReportWrapper();
        }


        public void ReportEntrance(string id, AdType type, AdPlatform platform, string location, string seq, string entrance = "")
        {
            _reportEntrance(id,type,platform,location,seq,entrance);
        }

        public void ReportToShow(string id, AdType type, AdPlatform platform, string location, string seq, string entrance = "")
        {
            _reportToShow(id, type, platform, location, seq, entrance);
        }

        public void ReportImpression(string id, AdType type, AdPlatform platform, string location, string seq, string entrance = "")
        {
            _reportImpression(id, type, platform, location, seq, entrance);
        }


        public void ReportShow(string id, AdType type, AdPlatform platform, string location, string seq, string entrance = "")
        {
            _reportShow(id, type, platform, location, seq, entrance);
        }

        public void ReportClose(string id, AdType type, AdPlatform platform, string location, string seq, string entrance = "")
        {
            _reportClose(id, type, platform, location, seq, entrance);
        }

        public void ReportClick(string id, AdType type, AdPlatform platform, string location, string seq, string entrance = "")
        {
            _reportClick(id, type, platform, location, seq, entrance);
        }

        public void ReportRewarded(string id, AdType type, AdPlatform platform, string location, string seq, string entrance = "")
        {
            _reportRewarded(id, type, platform, location, seq, entrance);
        }

        public void ReportLeftApp(string id, AdType type, AdPlatform platform, string location, string seq, string entrance = "")
        {
            _reportLeftApp(id, type, platform, location, seq, entrance);
        }

        public void ReportConversionByClick(string id, AdType type, AdPlatform platform, string location, string seq, string entrance = "")
        {
            _reportConversionByClick(id, type, platform, location, seq, entrance);
        }

        public void ReportConversionByLeftApp(string id, AdType type, AdPlatform platform, string location, string seq, string entrance = "")
        {
            _reportConversionByLeftApp(id, type, platform, location, seq, entrance);
        }

        public void ReportConversionByImpression(string id, AdType type, AdPlatform platform, string location, string seq, string entrance = "")
        {
            _reportConversionByImpression(id, type, platform, location, seq, entrance);
        }

        public void ReportConversionByRewarded(string id, AdType type, AdPlatform platform, string location, string seq, string entrance = "")
        {
            _reportConversionByRewarded(id, type, platform, location, seq, entrance);
        }

        public void ReportPaid(string id, AdType type, AdPlatform platform, string location, string seq, string value, string currency, string precision, string entrance = "")
        {
            _reportPaid(id, type, platform, location, seq,value, currency, precision, entrance);
        }

        public void ReportPaid(string id, AdType type, string platform, string location, string seq, AdMediation mediation, string mediationId, string value, string currency, string precision, string country, string entrance = "")
        {
            _reportPaid(id, type, platform, location, seq, mediation , mediationId, value, currency, precision, country, entrance);
        }

        public string GenerateUUID()
        {
            return _generateUUID();
        
        }

        

    }
}