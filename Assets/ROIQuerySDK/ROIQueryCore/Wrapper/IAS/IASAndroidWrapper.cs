using System;
using UnityEngine;

namespace ROIQuery.Wrapper.IAS
{
    public partial class ROIQueryIASReportWrapper
    {
#if UNITY_ANDROID && !(UNITY_EDITOR)

    private static readonly AndroidJavaClass ROIQueryIasReport = new AndroidJavaClass("com.roiquery.ias.ROIQueryIasReport");

    private void _init()
                {
                    
                }

            private void _reportToShow(string seq, string placement, string entrance)
            {
                R_Log.Debug($"_reportToShow seq:@{seq},placement :@{placement} , entrance: @{entrance}");
                ROIQueryIasReport.CallStatic("reportToShow",seq,entrance,placement);
            }

            private void _reportShowSuccess(string seq, string placement, string entrance)
            {
                R_Log.Debug($"_reportShowSuccess seq:@{seq},placement :@{placement} , entrance: @{entrance}");
                ROIQueryIasReport.CallStatic("reportShowSuccess",seq,entrance,placement);
            }

            private void _reportShowFail(string seq, string placement, string code, string msg, string entrance)
            {
                R_Log.Debug($"_reportShowFail seq:@{seq},placement :@{placement} , code:@{code}, msg:@{msg}, entrance: @{entrance}");
                ROIQueryIasReport.CallStatic("reportShowFail",seq,entrance,placement,code,msg);
            }

            private void _reportSubscribe(string seq, string placement, string sku, string orderId, string price,
            string currency, string entrance)
            {
                R_Log.Debug(
                    $"_reportSubscribe seq:@{seq},placement :@{placement} , sku:@{sku}, orderId:@{orderId} ,price:@{price},currency:@{currency},entrance: @{entrance}");
                ROIQueryIasReport.CallStatic("reportSubscribe",seq,entrance,placement,sku,orderId,price,currency);
            }

            private void _reportSusbscribeSuccess(string seq, string placement, string sku, string orderId,
            string originalorderId, string price,
            string currency, string entrance)
            {
                R_Log.Debug(
                    $"_reportSusbscribeSuccess seq:@{seq},placement :@{placement} , sku:@{sku}, orderId:@{orderId} ,originalorderId:@{originalorderId},price:@{price},currency:@{currency},entrance: @{entrance}");
                ROIQueryIasReport.CallStatic("reportSubscribeSuccess",seq,entrance,placement,sku,orderId,originalorderId,price,currency);
            }

            private void _reportSubscribeFail(string seq, string placement, string sku, string orderId,
            string originalorderId, string price,
            string currency, string code, string entrance, string msg)
            {
                R_Log.Debug(
                    $"_reportSubscribeFail seq:@{seq},placement :@{placement} , sku:@{sku}, orderId:@{orderId} ,originalorderId:@{originalorderId},price:@{price},currency:@{currency}," +
                    $"entrance: @{entrance} , code:@{code}, msg:@{msg}");
                ROIQueryIasReport.CallStatic("reportSubscribeFail",seq,entrance,placement,sku,orderId,originalorderId,price,currency,code,msg);
            }
#endif
    }
}