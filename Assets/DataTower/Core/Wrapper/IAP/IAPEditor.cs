using System.Collections.Generic;

namespace DataTower.Core.Wrapper
{
    public partial class DTIAPReportWrapper
    {
#if UNITY_STANDALONE || UNITY_EDITOR
        private void _init()
        {
            R_Log.Debug("Editor Log: calling init.");
        }

        private void _reportEntrance(string order, string sku, double price, string currency, string seq,
            string placement = "")
        {
            R_Log.Debug("Editor Log: calling reportEntrance.");
        }


        private void _reportToPurchase(string order, string sku, double price, string currency, string seq,
            string entrance = "")
        {
            R_Log.Debug("Editor Log: calling reportToPurchase.");
        }


        private void _reportPurchased(string order, string sku, double price, string currency, string seq,
            string entrance = "")
        {
            R_Log.Debug("Editor Log: calling reportPurchased.");
        }


        private void _reportNotToPurchased(string order, string sku, double price, string currency, string seq,
            string code, string entrance = "", string msg = "")
        {
            R_Log.Debug("Editor Log: calling reportNotToPurchased.");
        }

        private void _reportPurchaseSuccess(string order, string sku, double price, string currency,
            Dictionary<string, object> properties = null)
        {
            R_Log.Debug("Editor Log: calling reportPurchaseSuccess.");
            R_Utils.ValidateJsonDictionary(properties);
        }


#endif
    }
}