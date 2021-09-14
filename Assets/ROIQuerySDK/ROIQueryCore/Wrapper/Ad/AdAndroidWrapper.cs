
using System.Collections.Generic;
using ROIQuery.Utils;
using UnityEngine;

namespace ROIQuery.AdReport.Wrapper
{
    public partial class ROIQueryAdReportWrapper
    {
#if UNITY_ANDROID && !(UNITY_EDITOR)

        //获取类，通过包名+类名方式
        private static readonly AndroidJavaClass ROIQueryAdReport = new AndroidJavaClass("com.roiquery.ad.ROIQueryAdReport");
        
        private void _init()
        {
        }

        private AndroidJavaObject ToJSONObject(Dictionary<string, object> dic) {

            AndroidJavaObject jsonObject = null;
            if (dic != null)
            {
                string jsonStr = R_Utils.Parse2JsonStr(dic);
                jsonObject = R_Utils.Parse2JavaJSONObject(jsonStr);
            }
            return jsonObject;
        }

        private AndroidJavaObject GetType(AdType type)
        {
            return GetAndroidEnum("com.roiquery.ad.AdType",type.ToString());
        }
        
        
        private AndroidJavaObject GetPlatform(AdPlatform platform)
        {
            return GetAndroidEnum("com.roiquery.ad.AdPlatform",platform.ToString());;
        }
        
          
        private AndroidJavaObject GetMediation(AdMediation mediation)
        {
            return GetAndroidEnum("com.roiquery.ad.AdMediation",mediation.ToString());
        }    
        private AndroidJavaObject GetAndroidEnum(string pkg, string name)
        {
            AndroidJavaClass enumClass = new AndroidJavaClass(pkg);
            return enumClass.GetStatic<AndroidJavaObject>(name);
        }

        private void _reportEntrance(string id,AdType type, AdPlatform platform,string location,string seq,string entrance = "",Dictionary<string, object> properties = null)
        {
            ROIQueryAdReport.CallStatic("reportEntrance", id, GetType(type), GetPlatform(platform), location, seq, properties, entrance);
        }

        private void _reportToShow(string id, AdType type, AdPlatform platform, string location, string seq, string entrance = "",Dictionary<string, object> properties = null)
        {
            ROIQueryAdReport.CallStatic("reportToShow", id, GetType(type), GetPlatform(platform), location, seq, properties, entrance);
        }

         private void _reportImpression(string id, AdType type, AdPlatform platform, string location, string seq, string entrance = "",Dictionary<string, object> properties = null)
        {
            ROIQueryAdReport.CallStatic("reportImpression", id, GetType(type), GetPlatform(platform), location, seq, properties,entrance);
        }

        private void _reportShow(string id, AdType type, AdPlatform platform, string location, string seq, string entrance = "",Dictionary<string, object> properties = null)
        {
            ROIQueryAdReport.CallStatic("reportShow", id, GetType(type), GetPlatform(platform), location, seq, properties, entrance);
        }

        private void _reportClose(string id, AdType type, AdPlatform platform, string location, string seq, string entrance = "",Dictionary<string, object> properties = null)
        {
            ROIQueryAdReport.CallStatic("reportClose", id, GetType(type), GetPlatform(platform), location, seq, properties, entrance);
        }

        private void _reportClick(string id, AdType type, AdPlatform platform, string location, string seq, string entrance = "",Dictionary<string, object> properties = null)
        {
            ROIQueryAdReport.CallStatic("reportClick", id, GetType(type), GetPlatform(platform), location, seq,properties, entrance);
        }

        private void _reportRewarded(string id, AdType type, AdPlatform platform, string location, string seq, string entrance = "",Dictionary<string, object> properties = null)
        {
            ROIQueryAdReport.CallStatic("reportRewarded", id, GetType(type), GetPlatform(platform), location, seq, properties, entrance);
        }

        private void _reportLeftApp(string id, AdType type, AdPlatform platform, string location, string seq, string entrance = "",Dictionary<string, object> properties = null)
        {
            ROIQueryAdReport.CallStatic("reportLeftApp", id, GetType(type), GetPlatform(platform), location, seq,properties, entrance);
        }

        private void _reportConversionByClick(string id, AdType type, AdPlatform platform, string location, string seq, string entrance = "",Dictionary<string, object> properties = null)
        {
            ROIQueryAdReport.CallStatic("reportConversionByClick", id, GetType(type), GetPlatform(platform), location, seq,properties, entrance);
        }

        private void _reportConversionByLeftApp(string id, AdType type, AdPlatform platform, string location, string seq, string entrance = "",Dictionary<string, object> properties = null)
        {
            ROIQueryAdReport.CallStatic("reportConversionByLeftApp", id, GetType(type), GetPlatform(platform), location, seq,properties, entrance);
        }

        private void _reportConversionByImpression(string id, AdType type, AdPlatform platform, string location, string seq, string entrance = "",Dictionary<string, object> properties = null)
        {
            ROIQueryAdReport.CallStatic("reportConversionByImpression", id, GetType(type), GetPlatform(platform), location, seq,properties, entrance);
        }

        private void _reportConversionByRewarded(string id, AdType type, AdPlatform platform, string location, string seq, string entrance = "",Dictionary<string, object> properties = null)
        {
            ROIQueryAdReport.CallStatic("reportConversionByRewarded", id, GetType(type), GetPlatform(platform), location, seq, properties, entrance);
        }

        private void _reportPaid(string id,AdType type, AdPlatform platform, string location, string seq, string value, string currency, string precision, string entrance = "",Dictionary<string, object> properties = null)
        {
            ROIQueryAdReport.CallStatic("reportPaid", id, GetType(type), GetPlatform(platform), location, seq,value,currency,precision, properties, entrance);
        }


        private void _reportPaid(string id, AdType type, string platform, string location, string seq, AdMediation mediation, string mediationId, string value, string currency, string precision, 
                                string country, string entrance = "",Dictionary<string, object> properties = null)
        {
            ROIQueryAdReport.CallStatic("reportPaid", id,  GetType(type), platform, location, seq, GetMediation(mediation), mediationId, value, currency, precision, country, properties, entrance);
        }


        private string _generateUUID()
        {
           return ROIQueryAdReport.CallStatic<string>("generateUUID");
        }
#endif
    }
}
