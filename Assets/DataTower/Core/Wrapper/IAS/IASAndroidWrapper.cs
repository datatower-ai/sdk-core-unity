using System;
using UnityEngine;
using System.Collections.Generic;
using DataTower.Core;

namespace DataTower.Core.Wrapper
{
    public partial class DTIASReportWrapper
    {
#if UNITY_ANDROID && !(UNITY_EDITOR)
    private static readonly AndroidJavaClass DTIASReport = new AndroidJavaClass("ai.datatower.ias.DTIASReport");

    private void _init()
                {
                    
                }

            private void _reportToShow(string seq, string placement, string entrance)
            {
                R_Log.Debug($"_reportToShow seq:@{seq},placement :@{placement} , entrance: @{entrance}");
                DTIASReport.CallStatic("reportToShow",seq,entrance,placement);
            }

            private void _reportShowSuccess(string seq, string placement, string entrance)
            {
                R_Log.Debug($"_reportShowSuccess seq:@{seq},placement :@{placement} , entrance: @{entrance}");
                DTIASReport.CallStatic("reportShowSuccess",seq,entrance,placement);
            }

            private void _reportShowFail(string seq, string placement, string code, string msg, string entrance)
            {
                R_Log.Debug($"_reportShowFail seq:@{seq},placement :@{placement} , code:@{code}, msg:@{msg}, entrance: @{entrance}");
                DTIASReport.CallStatic("reportShowFail",seq,entrance,placement,code,msg);
            }

            private void _reportSubscribe(string seq, string placement, string sku, string orderId, string price,
            string currency, string entrance)
            {
                R_Log.Debug(
                    $"_reportSubscribe seq:@{seq},placement :@{placement} , sku:@{sku}, orderId:@{orderId} ,price:@{price},currency:@{currency},entrance: @{entrance}");
                DTIASReport.CallStatic("reportSubscribe",seq,entrance,placement,sku,orderId,price,currency);
            }

            private void _reportSusbscribeSuccess(string seq, string placement, string sku, string orderId,
            string originalorderId, string price,
            string currency, string entrance)
            {
                R_Log.Debug(
                    $"_reportSusbscribeSuccess seq:@{seq},placement :@{placement} , sku:@{sku}, orderId:@{orderId} ,originalorderId:@{originalorderId},price:@{price},currency:@{currency},entrance: @{entrance}");
                DTIASReport.CallStatic("reportSubscribeSuccess",seq,entrance,placement,sku,orderId,originalorderId,price,currency);
            }

            private void _reportSubscribeFail(string seq, string placement, string sku, string orderId,
            string originalorderId, string price,
            string currency, string code, string entrance, string msg)
            {
                R_Log.Debug(
                    $"_reportSubscribeFail seq:@{seq},placement :@{placement} , sku:@{sku}, orderId:@{orderId} ,originalorderId:@{originalorderId},price:@{price},currency:@{currency}," +
                    $"entrance: @{entrance} , code:@{code}, msg:@{msg}");
                DTIASReport.CallStatic("reportSubscribeFail",seq,entrance,placement,sku,orderId,originalorderId,price,currency,code,msg);
            }
        
        private void _reportSubscribeSuccess(string originalOrderId, string orderId, string sku, double price,
            string currency, Dictionary<string, object> properties)
        {
            R_Log.Debug(
                $"_reportSubscribeSuccess originalOrderId:@{originalOrderId}, orderId:@{orderId}, sku:@{sku}, price:@{price}, currency:@{currency}, properties:@{properties}");
            DTIASReport.CallStatic("reportSubscribeSuccess", originalOrderId, orderId, sku, price, currency, R_Utils.ParseDic2Map(properties));
        }
#endif
    }
}