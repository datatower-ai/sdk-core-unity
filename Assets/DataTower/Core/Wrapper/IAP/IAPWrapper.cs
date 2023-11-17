

using System.Collections.Generic;

namespace DataTower.Core
{
    

    public partial class DTIAPReportWrapper
    {
        private DTIAPReportWrapper()
        {
            _init();
        }

        public static DTIAPReportWrapper Instance => Nested.Instance;


        public void ReportEntrance(string order, string sku, double price, string currency, string seq,
            string placement = "")
        {
            _reportEntrance(order, sku, price, currency, seq, placement);
        }


        public void ReportToPurchase(string order, string sku, double price, string currency, string seq,
            string entrance = "")
        {
            _reportToPurchase(order, sku, price, currency, seq, entrance);
        }


        public void ReportPurchased(string order, string sku, double price, string currency, string seq,
            string entrance = "")
        {
            _reportPurchased(order, sku, price, currency, seq, entrance);
        }


        public void ReportNotToPurchased(string order, string sku, double price, string currency, string seq,
            string code, string entrance = "", string msg = "")
        {
            _reportNotToPurchased(order, sku, price, currency, seq, code, entrance, msg);
        }

        public void ReportPurchaseSuccess(string order, string sku, double price, string currency,
            Dictionary<string, object> properties = null)
        {
            _reportPurchaseSuccess(order, sku, price, currency, properties);
        }

        private class Nested
        {
            internal static readonly DTIAPReportWrapper Instance = new DTIAPReportWrapper();

            //Explicit static constructor to tell C# compiler
            //not to mark type as beforefieldinit
            static Nested()
            {
            }
        }

        /*public string GenerateUUID()
        {
            return _generateUUID();
        }*/
    }
}