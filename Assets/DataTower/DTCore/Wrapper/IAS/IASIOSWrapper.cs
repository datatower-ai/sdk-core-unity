using System.Collections.Generic;

namespace DataTower.Wrapper.IAS
{
    public partial class ROIQueryIASReportWrapper

    {
#if UNITY_IOS && !UNITY_EDITOR
        // [DllImport("__Internal")]
        // private static extern void reportIasToShow(string iasSeq, string iasEntrance, string iasPlacement);
        //
        // [DllImport("__Internal")]
        // private static extern void reportShowSuccess(string iasSeq, string iasEntrance, string iasPlacement);
        //
        // [DllImport("__Internal")]
        // private static extern void reportShowFail(string iasSeq, string iasEntrance, string iasPlacement, string iasCode, string iasMsg);
        //
        // [DllImport("__Internal")]
        // private static extern void reportSubscribe(string asSeq, string iasEntrance, string iasPlacement, string iasSku, string iasOrderId,
        // string iasPrice,
        // string iasCurrency);
        //
        // [DllImport("__Internal")]
        // private static extern void reportSubscribeSuccess(
        // string iasSeq, string iasEntrance, string iasPlacement, string iasSku, string iasOrderId, string iasOriginalOrderId, string iasPrice,
        // string iasCurrency);
        //
        // [DllImport("__Internal")]
        // private static extern void reportSubscribeFail(string iasSeq,string iasEntrance,string iasPlacement,string iasSku,string iasOrderId,
        //     string iasOriginalOrderId,string iasPrice,string iasCurrency,string iasCode,string iasMsg);

        private void _reportToShow(string seq, string placement, string entrance)
        {
            // R_Log.Debug($"_reportToShow seq:@{seq},placement :@{placement} , entrance: @{entrance}");
            // reportIasToShow(seq, entrance, placement);
        }

        private void _reportShowSuccess(string seq, string placement, string entrance)
        {
            // R_Log.Debug($"_reportShowSuccess seq:@{seq},placement :@{placement} , entrance: @{entrance}");
            // reportShowSuccess(seq, entrance, placement);
        }

        private void _reportShowFail(string seq, string placement, string code, string msg, string entrance)
        {
            // R_Log.Debug($"_reportShowFail seq:@{seq},placement :@{placement} , code:@{code}, msg:@{msg}, entrance: @{entrance}");
            // reportShowFail(seq,entrance,placement,code,msg);
        }

        private void _reportSubscribe(string seq, string placement, string sku, string orderId, string price,
        string currency, string entrance)
        {
            // R_Log.Debug(
            //     $"_reportSubscribe seq:@{seq},placement :@{placement} , sku:@{sku}, orderId:@{orderId} ,price:@{price},currency:@{currency},entrance: @{entrance}");
            // reportSubscribe(seq,entrance,placement,sku,orderId,price,currency);
        }

        private void _reportSusbscribeSuccess(string seq, string placement, string sku, string orderId,
        string originalorderId, string price,
        string currency, string entrance)
        {
            // R_Log.Debug(
            //     $"_reportSusbscribeSuccess seq:@{seq},placement :@{placement} , sku:@{sku}, orderId:@{orderId} ,originalorderId:@{originalorderId},price:@{price},currency:@{currency},entrance: @{entrance}");
            // reportSubscribeSuccess(seq,entrance,placement,sku,orderId,originalorderId, price, currency);
        }

        private void _reportSubscribeFail(string seq, string placement, string sku, string orderId,
        string originalorderId, string price,
        string currency, string code, string entrance, string msg)
        {
            // R_Log.Debug(
            //     $"_reportSubscribeFail seq:@{seq},placement :@{placement} , sku:@{sku}, orderId:@{orderId} ,originalorderId:@{originalorderId},price:@{price},currency:@{currency}," +
            //     $"entrance: @{entrance} , code:@{code}, msg:@{msg}");
            // reportSubscribeFail(seq,entrance,placement,sku,orderId,originalorderId,price,currency,code,msg);
        }

        private void _reportSubscribeSuccess(string originalOrderId, string orderId, string sku, double price,
            string currency, Dictionary<string, object> properties)
        {
 
        }
#endif
    }
}