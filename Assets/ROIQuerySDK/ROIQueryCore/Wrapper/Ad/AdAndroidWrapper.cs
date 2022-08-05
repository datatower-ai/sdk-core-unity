﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace ROIQuery
{
    public partial class ROIQueryAdReportWrapper
    {
#if UNITY_ANDROID && !(UNITY_EDITOR)

        //获取类，通过包名+类名方式
        private static readonly AndroidJavaClass ROIQueryAdReport = new AndroidJavaClass("com.roiquery.ad.ROIQueryAdReport");
            

        private void _init()
        {
        }

        private AndroidJavaObject ToJSONObject(Dictionary<string, object> dic)
        {
            AndroidJavaObject jsonObject = null;
            if (dic != null)
            {
                string jsonStr = R_Utils.Parse2JsonStr(dic);
                jsonObject = R_Utils.Parse2JavaJSONObject(jsonStr);
            }

            return jsonObject;
        }

        private AdPlatform ParseToAdPlatform(AndroidJavaObject platform)
        {
            var code = platform.Call<int>("getValue");
            return Enum.TryParse(code.ToString(), out AdPlatform adPlatform) ? adPlatform : AdPlatform.IDLE;
        }

        public static AndroidJavaObject dicToMap(Dictionary<string, object> dictionary)
        {
            if (dictionary == null)
            {
                return new AndroidJavaObject("java.util.HashMap");
            }

            AndroidJavaObject map = new AndroidJavaObject("java.util.HashMap");
            foreach (KeyValuePair<string, object> pair in dictionary)
            {
                map.Call<string>("put", pair.Key, pair.Value);
            }

            return map;
        }

        private AndroidJavaObject GetType(AdType type)
        {
            return GetAndroidEnum("com.roiquery.ad.AdType", type.ToString());
        }


        private AndroidJavaObject GetPlatform(AdPlatform platform)
        {
            return GetAndroidEnum("com.roiquery.ad.AdPlatform", platform.ToString());
        }


        private AndroidJavaObject GetMediation(AdMediation mediation)
        {
            return GetAndroidEnum("com.roiquery.ad.AdMediation", mediation.ToString());
        }

        private AndroidJavaObject GetAndroidEnum(string pkg, string name)
        {
            AndroidJavaClass enumClass = new AndroidJavaClass(pkg);
            return enumClass.GetStatic<AndroidJavaObject>(name);
        }


        private void _reportLoadBegin(string id, AdType type, AdPlatform platform, string seq, Dictionary<string, object> properties = null)

        {
            ROIQueryAdReport.CallStatic("reportLoadBegin", id, GetType(type), GetPlatform(platform), seq, dicToMap(properties));
        }


        private void _reportLoadEnd(string id, AdType type, AdPlatform platform, long duration, bool result, string seq, int errorCode = 0, string errorMessage = "",
          Dictionary<string, object> properties = null)
        {
            ROIQueryAdReport.CallStatic("reportLoadEnd", id, GetType(type), GetPlatform(platform),duration,result, seq, errorCode, errorMessage, dicToMap(properties));
        }

        private void _reportShowFailed(string id, AdType type, AdPlatform platform, string location, string seq, int errorCode, string errorMessage, string entrance = "", Dictionary<string, object> properties = null)

        {
            ROIQueryAdReport.CallStatic("reportShowFailed", id, GetType(type), GetPlatform(platform), location, seq, errorCode, errorMessage, dicToMap(properties), entrance);
        }

        private void _reportEntrance(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "", Dictionary<string, object> properties = null)
        {
            ROIQueryAdReport.CallStatic("reportEntrance", id, GetType(type), GetPlatform(platform), location, seq,
                dicToMap(properties), entrance);
        }

        private void _reportToShow(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "", Dictionary<string, object> properties = null)
        {
            ROIQueryAdReport.CallStatic("reportToShow", id, GetType(type), GetPlatform(platform), location, seq,
                dicToMap(properties), entrance);
        }

        private void _reportImpression(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "", Dictionary<string, object> properties = null)
        {
            ROIQueryAdReport.CallStatic("reportImpression", id, GetType(type), GetPlatform(platform), location, seq,
                dicToMap(properties), entrance);
        }

        private void _reportShow(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "", Dictionary<string, object> properties = null)
        {
            ROIQueryAdReport.CallStatic("reportShow", id, GetType(type), GetPlatform(platform), location, seq,
                dicToMap(properties), entrance);
        }

        private void _reportClose(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "", Dictionary<string, object> properties = null)
        {
            ROIQueryAdReport.CallStatic("reportClose", id, GetType(type), GetPlatform(platform), location, seq,
                dicToMap(properties), entrance);
        }

        private void _reportClick(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "", Dictionary<string, object> properties = null)
        {
            ROIQueryAdReport.CallStatic("reportClick", id, GetType(type), GetPlatform(platform), location, seq,
                dicToMap(properties), entrance);
        }

        private void _reportRewarded(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "", Dictionary<string, object> properties = null)
        {
            ROIQueryAdReport.CallStatic("reportRewarded", id, GetType(type), GetPlatform(platform), location, seq,
                dicToMap(properties), entrance);
        }

        private void _reportLeftApp(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "", Dictionary<string, object> properties = null)
        {
            ROIQueryAdReport.CallStatic("reportLeftApp", id, GetType(type), GetPlatform(platform), location, seq,
                dicToMap(properties), entrance);
        }

        private void _reportConversionByClick(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "", Dictionary<string, object> properties = null)
        {
            ROIQueryAdReport.CallStatic("reportConversionByClick", id, GetType(type), GetPlatform(platform), location,
                seq, dicToMap(properties), entrance);
        }

        private void _reportConversionByLeftApp(string id, AdType type, AdPlatform platform, string location,
            string seq, string entrance = "", Dictionary<string, object> properties = null)
        {
            ROIQueryAdReport.CallStatic("reportConversionByLeftApp", id, GetType(type), GetPlatform(platform), location,
                seq, dicToMap(properties), entrance);
        }

        private void _reportConversionByImpression(string id, AdType type, AdPlatform platform, string location,
            string seq, string entrance = "", Dictionary<string, object> properties = null)
        {
            ROIQueryAdReport.CallStatic("reportConversionByImpression", id, GetType(type), GetPlatform(platform),
                location, seq, dicToMap(properties), entrance);
        }

        private void _reportConversionByRewarded(string id, AdType type, AdPlatform platform, string location,
            string seq, string entrance = "", Dictionary<string, object> properties = null)
        {
            ROIQueryAdReport.CallStatic("reportConversionByRewarded", id, GetType(type), GetPlatform(platform),
                location, seq, dicToMap(properties), entrance);
        }

        private void _reportPaid(string id, AdType type, AdPlatform platform, string location, string seq, string value,
            string currency, string precision, string entrance = "", Dictionary<string, object> properties = null)
        {
            ROIQueryAdReport.CallStatic("reportPaid", id, GetType(type), GetPlatform(platform), location, seq, value,
                currency, precision, dicToMap(properties), entrance);
        }


        private void _reportPaid(string id, AdType type, string platform, string adgroupName,string adgroupType, string location, string seq,
            AdMediation mediation, string mediationId, string value, string currency, string precision,
            string country, string entrance = "", Dictionary<string, object> properties = null)
        {
            ROIQueryAdReport.CallStatic("reportPaid", id, GetType(type), platform,adgroupName, adgroupType, location, seq,
                GetMediation(mediation), mediationId, value, currency, precision, country, dicToMap(properties),
                entrance);
        }

         private void _reportPaid(string id, AdType type, AdPlatform platform, string location, string seq,AdMediation mediation, string mediationId,  string value,
            string precision, string country, Dictionary<string, object> properties = null)
        {
            ROIQueryAdReport.CallStatic("reportPaid", id, GetType(type), GetPlatform(platform), location, seq,GetMediation(mediation), mediationId,value,
                 precision,country);
        }

        private string _generateUUID()
        {
            return ROIQueryAdReport.CallStatic<string>("generateUUID");
        }

        private AdPlatform _getPlatform(AdMediation mediation, string networkName, string networkPlacementId, string adgroupName, string  adgroupType)
        {
            AndroidJavaObject adPlatform =  ROIQueryAdReport.CallStatic<AndroidJavaObject>("getPlatform",(int)mediation, networkName, networkPlacementId, adgroupName,adgroupType);
            return ParseToAdPlatform(adPlatform);
        }
#endif
    }
}