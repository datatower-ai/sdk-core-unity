

namespace ROIQuery
{
    

    public partial class ROIQueryIAPReportWrapper
    {
        private ROIQueryIAPReportWrapper()
        {
            _init();
        }

        public static ROIQueryIAPReportWrapper Instance { get { return Nested.instance; } }

        private class Nested
        {
            //Explicit static constructor to tell C# compiler
            //not to mark type as beforefieldinit
            static Nested()
            {

            }

            internal static readonly ROIQueryIAPReportWrapper instance = new ROIQueryIAPReportWrapper();
        }


    

        public void ReportEntrance(string order, string sku, double price,  string currency, string seq, string placement = "")
        { 
            _reportEntrance(order, sku, price, currency,seq,placement);
        }


        public void ReportToPurchase(string order, string sku, double price,  string currency,string seq, string entrance = "")
        {
            _reportToPurchase(order, sku, price,  currency, seq,entrance);
        }


        public void ReportPurchased(string order, string sku, double price,  string currency,string seq, string entrance = "")
        {
            _reportPurchased(order, sku, price,  currency,seq, entrance);
        }


        public void ReportNotToPurchased(string order, string sku, double price,  string currency,string seq, string code, string entrance = "", string msg = "")
        {
            _reportNotToPurchased(order, sku, price, currency,seq,code,entrance,msg);
        }

    }
}