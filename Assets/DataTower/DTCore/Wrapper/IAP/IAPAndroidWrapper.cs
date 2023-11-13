

using UnityEngine;
using System.Collections.Generic;

namespace DataTower
{
    public partial class DTIAPReportWrapper
    {
#if UNITY_ANDROID && !(UNITY_EDITOR)
        //获取类，通过包名+类名方式
        private static readonly AndroidJavaClass DTIAPReport = new AndroidJavaClass("ai.datatower.iap.DTIAPReport");
        

        private void _init()
        {
            
        }

        private void _reportEntrance(string order, string sku, double price, string currency,  string seq, string placement
 = "")
        {
            DTIAPReport.CallStatic("reportEntrance", order, sku, price,  currency,seq, placement);
        }


        private void _reportToPurchase(string order, string sku, double price,  string currency, string seq,  string entrance
 = "")
        {
            DTIAPReport.CallStatic("reportToPurchase", order, sku, price,  currency, seq,entrance);
        }


        private void _reportPurchased(string order, string sku, double price, string currency, string seq,  string entrance
 = "")
        {
            DTIAPReport.CallStatic("reportPurchased", order, sku, price,  currency,seq, entrance);
        }


        private void _reportNotToPurchased(string order, string sku, double price,  string currency,  string seq, string code, string entrance
 = "", string msg = "")
        {
            DTIAPReport.CallStatic("reportNotToPurchased", order, sku, price, currency, seq, code, entrance,msg);
        }

        private void _reportPurchaseSuccess(string order, string sku, double price, string currency,
            Dictionary<string, object> properties = null)
        {
            DTIAPReport.CallStatic("reportPurchaseSuccess", order, sku, price, currency, R_Utils.ParseDic2Map(properties));
        }

     private string _generateUUID()
        {
           return DTIAPReport.CallStatic<string>("generateUUID");
        }

#endif
    }
}