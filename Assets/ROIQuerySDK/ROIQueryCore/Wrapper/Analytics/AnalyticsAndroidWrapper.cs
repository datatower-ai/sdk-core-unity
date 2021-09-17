using System.Collections.Generic;
using ROIQuery.Utils;
using UnityEngine;

namespace ROIQuery.Analytics.Wrapper
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
            properties.Add("#sdk_type", "Unity");
            properties.Add("#sdk_version", sdkVersion);
            string jsonStr = R_Utils.Parse2JsonStr(properties);
            AndroidJavaObject jsonObject = R_Utils.Parse2JavaJSONObject(jsonStr);


            //调用静态初始化方法 init
            ROIQuerySDK.CallStatic("initSDK", currentContext, androidAppId, channel, isDebug, logLevel, jsonObject);
        }

        private void _track(string eventName, Dictionary<string, object> dic = null)
        {
            ROIQueryAnalytics.CallStatic("track", eventName, R_Utils.DicToAndroidMap(dic));
        }

        private void _flush()
        {
            ROIQueryAnalytics.CallStatic("flush");
        }

        private void _trackPageOpen(Dictionary<string, object> properties = null)
        {
            ROIQueryAnalytics.CallStatic("trackPageOpen", R_Utils.DicToAndroidMap(properties));
        }


        private void _trackPageClose(Dictionary<string, object> properties = null)
        {
            ROIQueryAnalytics.CallStatic("trackPageClose", R_Utils.DicToAndroidMap(properties));
        }


        private void _trackAppClose(Dictionary<string, object> properties = null)
        {
            ROIQueryAnalytics.CallStatic("trackAppClose", R_Utils.DicToAndroidMap(properties));
        }

        private void _setAccountId(string accountId)
        {
            ROIQueryAnalytics.CallStatic("setAccountId", accountId);
        }


        private void _setFirebaseAppInstanceId(string id)
        {
            ROIQueryAnalytics.CallStatic("setFirebaseAppInstanceId", id);
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
            ROIQueryAnalytics.CallStatic("setUserProperties", R_Utils.DicToAndroidMap(properties));
        }


        private void _onAppForeground()
        {
            ROIQueryAnalytics.CallStatic("onAppForeground");
        }


        private void _onAppBackground()
        {
            ROIQueryAnalytics.CallStatic("onAppBackground");
        }

#endif
    }
}