using System.Collections.Generic;
using DataTower.Core;

namespace DataTower.Core.Wrapper
{
    public partial class DTIASReportWrapper
    {
#if UNITY_STANDALONE || UNITY_EDITOR
        private void _reportToShow(string seq, string placement, string entrance)
        {
            R_Log.Debug($"_reportToShow seq:@{seq},placement :@{placement} , entrance: @{entrance}");
        }

        private void _reportShowSuccess(string seq, string placement, string entrance)
        {
            R_Log.Debug($"_reportShowSuccess seq:@{seq},placement :@{placement} , entrance: @{entrance}");
        }

        private void _reportShowFail(string seq, string placement, string code, string msg, string entrance)
        {
            R_Log.Debug(
                $"_reportShowFail seq:@{seq},placement :@{placement} , code:@{code}, msg:@{msg}, entrance: @{entrance}");
        }

        private void _reportSubscribe(string seq, string placement, string sku, string orderId, string price,
            string currency, string entrance)
        {
            R_Log.Debug(
                $"_reportSubscribe seq:@{seq},placement :@{placement} , sku:@{sku}, orderId:@{orderId} ,price:@{price},currency:@{currency},entrance: @{entrance}");
        }

        private void _reportSusbscribeSuccess(string seq, string placement, string sku, string orderId,
            string originalorderId, string price,
            string currency, string entrance)
        {
            R_Log.Debug(
                $"_reportSusbscribeSuccess seq:@{seq},placement :@{placement} , sku:@{sku}, orderId:@{orderId} ,originalorderId:@{originalorderId},price:@{price},currency:@{currency},entrance: @{entrance}");
        }

        private void _reportSubscribeFail(string seq, string placement, string sku, string orderId,
            string originalorderId, string price,
            string currency, string code, string entrance, string msg)
        {
            R_Log.Debug(
                $"_reportSubscribeFail seq:@{seq},placement :@{placement} , sku:@{sku}, orderId:@{orderId} ,originalorderId:@{originalorderId},price:@{price},currency:@{currency}," +
                $"entrance: @{entrance} , code:@{code}, msg:@{msg}");
        }

        private void _reportSubscribeSuccess(string originalOrderId, string orderId, string sku, double price,
            string currency, Dictionary<string, object> properties)
        {
            R_Log.Debug(
                $"_reportSubscribeSuccess originalOrderId:@{originalOrderId}, orderId:@{orderId}, sku:@{sku}, price:@{price}, currency:@{currency}, properties:@{properties}");
            R_Utils.ValidateJsonDictionary(properties);
        }
#endif
    }
}