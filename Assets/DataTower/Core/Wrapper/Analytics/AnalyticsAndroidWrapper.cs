using System.Collections.Generic;
using UnityEngine;

namespace DataTower.Core.Wrapper
{
    public partial class DTAnalyticsWrapper
    {
#if UNITY_ANDROID && !(UNITY_EDITOR)
        //获取类，通过包名+类名方式
        private static readonly AndroidJavaClass DT = new AndroidJavaClass("ai.datatower.analytics.DT");

        private static readonly AndroidJavaClass DTAnalytics =
            new AndroidJavaClass("ai.datatower.analytics.DTAnalytics");

        private void _init()
        {
            //固定写法，获取Android context
            AndroidJavaObject currentContext =
                new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");

            //替换sdk版本信息
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("#sdk_type", "Unity");
            properties.Add("#sdk_version_name", sdkVersion);
            string jsonStr = R_Utils.Parse2JsonStr(properties);
            AndroidJavaObject jsonObject = R_Utils.Parse2JavaJSONObject(jsonStr);
            R_Log.Debug(serverUrl);

            //调用静态初始化方法 init
            DT.CallStatic("initSDK", currentContext, androidAppId, serverUrl, channel, isDebug, logLevel, manualEnableUpload, jsonObject);
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

        private void _enableUpload() {
            DT.CallStatic("enableUpload");
        }        

        private void _track(string eventName, Dictionary<string, object> dic = null)
        {
            DTAnalytics.CallStatic("track", eventName, ToJSONObject(dic));
        }
        
        private void _userSet(Dictionary<string, object> properties)
        {
            DTAnalytics.CallStatic("userSet", ToJSONObject(properties));
        }
        private void _userSetOnce(Dictionary<string, object> properties)
        {
            DTAnalytics.CallStatic("userSetOnce", ToJSONObject(properties));
        }
        
        private void _userAdd(Dictionary<string, object> properties)
        {
            DTAnalytics.CallStatic("userAdd", ToJSONObject(properties));

        }
        
        private static void _userUnset(List<string> properties)
        {
            DTAnalytics.CallStatic("userUnset", properties.ToArray());
        }
        
        private void _userDelete()
        {
            DTAnalytics.CallStatic("userDelete");
        }
        
        private void _userAppend(Dictionary<string, object> properties)
        {
            DTAnalytics.CallStatic("userAppend", ToJSONObject(properties));
        }

        private void _userUniqAppend(Dictionary<string, object> properties)
        {
            DTAnalytics.CallStatic("userUniqAppend", ToJSONObject(properties));
        }
        
        private void _getDataTowerId(AndroidJavaProxy callbackJavaProxy)
        {
             DTAnalytics.CallStatic("getDataTowerId",callbackJavaProxy);
        }
        
        private void _setAccountId(string accountId)
        {
            DTAnalytics.CallStatic("setAccountId", accountId);
        }

        private void _setDistinctId(string distinctId)
        {
            DTAnalytics.CallStatic("setDistinctId", distinctId);
        }


        private void _setFirebaseAppInstanceId(string id)
        {
            DTAnalytics.CallStatic("setFirebaseAppInstanceId", id);
        }

     
        
        private void _setAppsFlyerId(string id)
        {
            DTAnalytics.CallStatic("setAppsFlyerId", id);
            R_Log.Debug("Editor Log: calling _setAppsFlyerId.");
        }
        private void _setKochavaId(string id)
        {
            DTAnalytics.CallStatic("setKochavaId", id);
            R_Log.Debug("Editor Log: calling _setKochavaId.");
        }
        
        private void _setAdjustId(string adjustId)
        {
            DTAnalytics.CallStatic("setAdjustId", adjustId);
            R_Log.Debug("Editor Log: calling _setAdjustId.");
        }

        private void _setStaticCommonProperties(Dictionary<string, object> properties)
        {
            DTAnalytics.CallStatic("setStaticCommonProperties", ToJSONObject(properties));
        }

        private void _clearStaticCommonProperties()
        {
            DTAnalytics.CallStatic("clearStaticCommonProperties");
        }

#endif
    }
}