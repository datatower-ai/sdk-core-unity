
using ROIQuery.Utils;

namespace ROIQuery.IAPReport.Wrapper
{
    public partial class ROIQueryIAPReportWrapper
    {

#if UNITY_STANDALONE || UNITY_EDITOR
        private void _init()
        {
            R_Log.Debug("Editor Log: calling init.");
        }

        private void _reportEntrance(string order, string sku, double price,  string currency,string seq, string entrance = "")
        {
            R_Log.Debug("Editor Log: calling reportEntrance.");
        }


        private void _reportToPurchase(string order, string sku, double price, string currency, string seq,string entrance = "")
        {
            R_Log.Debug("Editor Log: calling reportToPurchase.");
        }


        private void _reportPurchased(string order, string sku, double price, string currency,string seq, string entrance = "")
        {
            R_Log.Debug("Editor Log: calling reportPurchased.");
        }


        private void _reportNotToPurchased(string order, string sku, double price, string currency,string seq, string code, string entrance = "", string msg = "")
        {
            R_Log.Debug("Editor Log: calling reportNotToPurchased.");
        }


#endif
    }
}