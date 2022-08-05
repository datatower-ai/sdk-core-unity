using System.Collections.Generic;
using UnityEngine;

namespace ROIQuery
{
    public partial class ROIQueryAnalyticsWrapper
    {
#if UNITY_ANDROID && !(UNITY_EDITOR)

        //获取类，通过包名+类名方式
        private static readonly AndroidJavaClass ROIQuerySDK = new AndroidJavaClass("com.roiquery.analytics.ROIQuery");

        private static readonly AndroidJavaClass ROIQueryAnalytics =
            new AndroidJavaClass("com.roiquery.analytics.ROIQueryAnalytics");

        private void _init()
        {
            //固定写法，获取Android context
            AndroidJavaObject currentContext =
                new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");

            //替换sdk版本信息
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("sdk_type", "Unity");
            properties.Add("sdk_version", sdkVersion);
            string jsonStr = R_Utils.Parse2JsonStr(properties);
            AndroidJavaObject jsonObject = R_Utils.Parse2JavaJSONObject(jsonStr);


            //调用静态初始化方法 init
            ROIQuerySDK.CallStatic("initSDK", currentContext, androidAppId, channel, isDebug, logLevel, jsonObject);
        }

        private AndroidJavaObject ToJSONObject(Dictionary<string, object> dic)
        {
            if (dic == null)
            {
                dic = new Dictionary<string, object>();
            }

            string jsonStr = R_Utils.Parse2JsonStr(dic);
            AndroidJavaObject jsonObject = R_Utils.Parse2JavaJSONObject(jsonStr);
            return jsonObject;
        }
        

        private void _track(string eventName, Dictionary<string, object> dic = null)
        {
            ROIQueryAnalytics.CallStatic("track", eventName, ToJSONObject(dic));
        }

        private void _flush()
        {
            ROIQueryAnalytics.CallStatic("flush");
        }

        private void _trackPageOpen(Dictionary<string, object> properties = null)
        {
            ROIQueryAnalytics.CallStatic("trackPageOpen", ToJSONObject(properties));
        }


        private void _trackPageClose(Dictionary<string, object> properties = null)
        {
            ROIQueryAnalytics.CallStatic("trackPageClose", ToJSONObject(properties));
        }


        private void _trackAppClose(Dictionary<string, object> properties = null)
        {
            ROIQueryAnalytics.CallStatic("trackAppClose", ToJSONObject(properties));
        }
        
         
        
        private void _userSet(Dictionary<string, object> properties)
        {
            ROIQueryAnalytics.CallStatic("userSet", ToJSONObject(properties));
        }
        private void _userSetOnce(Dictionary<string, object> properties)
        {
            ROIQueryAnalytics.CallStatic("userSetOnce", ToJSONObject(properties));
        }
        
        private void _userAdd(Dictionary<string, object> properties)
        {
            ROIQueryAnalytics.CallStatic("userAdd", ToJSONObject(properties));

        }
        
        private static void _userUnset(List<string> properties)
        {
            ROIQueryAnalytics.CallStatic("userUnset", properties.ToArray());
        }
        
        private void _userDelete()
        {
            ROIQueryAnalytics.CallStatic("userDelete");
        }
        
        private void _userAppend(Dictionary<string, object> properties)
        {
            ROIQueryAnalytics.CallStatic("userAppend", ToJSONObject(properties));
        }

        
        private string _getROIQueryId()
        {
            return ROIQueryAnalytics.CallStatic<string>("getInstanceId");
        }
        
        private void _setAccountId(string accountId)
        {
            ROIQueryAnalytics.CallStatic("setAccountId", accountId);
        }


        private void _setFirebaseAppInstanceId(string id)
        {
            ROIQueryAnalytics.CallStatic("setFirebaseAppInstanceId", id);
        }

        private void _setFCMToken(string token)
        {
            ROIQueryAnalytics.CallStatic("setFCMToken", token);
        }
        
        private void _setAppsFlyerId(string id)
        {
            ROIQueryAnalytics.CallStatic("setAppsFlyerId", id);
            R_Log.Debug("Editor Log: calling _setAppsFlyerId.");
        }
        private void _setKochavaId(string id)
        {
            ROIQueryAnalytics.CallStatic("setKochavaId", id);
            R_Log.Debug("Editor Log: calling _setKochavaId.");
        }

        private void _setUserProperties(Dictionary<string, object> properties = null)
        {
            ROIQueryAnalytics.CallStatic("setUserProperties", ToJSONObject(properties));
        }


      
        
        private long _getRealTime()
        {
            return ROIQueryAnalytics.CallStatic<long>("getRealTime");
        }
        private void _getServerTimeAsync(ROIQueryAnalytics.AndroidServerTimeCallback callback)
        {
             ROIQueryAnalytics.CallStatic("getServerTimeAsync",callback);
        }
        private long _getServerTimeSync()
        {
            return ROIQueryAnalytics.CallStatic<long>("getServerTimeSync");
        }

#endif
    }
}