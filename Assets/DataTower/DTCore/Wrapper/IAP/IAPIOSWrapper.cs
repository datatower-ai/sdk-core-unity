
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

namespace DataTower
{
    public partial class ROIQueryIAPReportWrapper
    {
#if UNITY_IOS && !(UNITY_EDITOR)
        [DllImport("__Internal")]
        private static extern void reportIapEntrance(string order, string sku, double price, string currency, string seq,
            string entrance);
        
        [DllImport("__Internal")]
        private static extern void reportToPurchase(string order, string sku, double price, string currency, string seq,
            string entrance);
        
        [DllImport("__Internal")]
        private static extern void reportPurchased(string order, string sku, double price, string currency, string seq,
            string entrance);
        
        [DllImport("__Internal")]
        private static extern void reportNotToPurchased(string order, string sku, double price, string currency,
            string seq, string code, string entrance, string msg);


       private void _init()
        {
            // R_Log.Debug("Editor Log: calling init.");
        }

        private void _reportEntrance(string order, string sku, double price, string currency, string seq, string entrance
 = "")
        {
            reportIapEntrance(order,sku,price,currency,seq,entrance);
            R_Log.Debug("Editor Log: calling reportEntrance.");
        }


        private void _reportToPurchase(string order, string sku, double price, string currency, string seq, string entrance
 = "")
        {
            reportToPurchase(order,sku,price,currency,seq,entrance);
            R_Log.Debug("Editor Log: calling reportToPurchase.");
        }


        private void _reportPurchased(string order, string sku, double price, string currency, string seq, string entrance
 = "")
        {
            reportPurchased(order,sku,price,currency,seq,entrance);
            R_Log.Debug("Editor Log: calling reportPurchased.");
        }


        private void _reportNotToPurchased(string order, string sku, double price, string currency, string seq, string code, string entrance
 = "", string msg = "")
        {
            reportNotToPurchased(order,sku,price,currency,seq,code,entrance,msg);
            R_Log.Debug("Editor Log: calling reportNotToPurchased.");
        }

     
        private void _reportPurchaseSuccess(string order, string sku, double price, string currency,
            Dictionary<string, object> properties = null)
        {
        }

#endif
    }
}