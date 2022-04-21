

using UnityEngine;

namespace ROIQuery
{
    public partial class ROIQueryIAPReportWrapper
    {
#if UNITY_ANDROID && !(UNITY_EDITOR)

        //获取类，通过包名+类名方式
        private static readonly AndroidJavaClass ROIQueryIAPReport = new AndroidJavaClass("com.roiquery.iap.ROIQueryIAPReport");
        

        private void _init()
        {
            
        }

        private void _reportEntrance(string order, string sku, double price, string currency,  string seq, string placement = "")
        {
            ROIQueryIAPReport.CallStatic("reportEntrance", order, sku, price,  currency,seq, placement);
        }


        private void _reportToPurchase(string order, string sku, double price,  string currency, string seq,  string entrance = "")
        {
            ROIQueryIAPReport.CallStatic("reportToPurchase", order, sku, price,  currency, seq,entrance);
        }


        private void _reportPurchased(string order, string sku, double price, string currency, string seq,  string entrance = "")
        {
            ROIQueryIAPReport.CallStatic("reportPurchased", order, sku, price,  currency,seq, entrance);
        }


        private void _reportNotToPurchased(string order, string sku, double price,  string currency,  string seq, string code, string entrance = "", string msg = "")
        {
            ROIQueryIAPReport.CallStatic("reportNotToPurchased", order, sku, price, currency, seq, code, entrance,msg);
        }



#endif
    }
}
