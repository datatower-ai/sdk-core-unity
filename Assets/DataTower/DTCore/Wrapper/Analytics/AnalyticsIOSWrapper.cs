using System.Collections.Generic;
using System.Runtime.InteropServices;
using System;

namespace DataTower
{
    public partial class ROIQueryAnalyticsWrapper
    {
#if UNITY_IOS && !(UNITY_EDITOR)
        [DllImport("__Internal")]
        private static extern void initSDK(string appId, string serverUrl, bool isDebug, int logLevel, string properties);

        [DllImport("__Internal")]
        private static extern string reflectionInvokeWithReturn(string clsName, string methodName);

        [DllImport("__Internal")]
        private static extern void reflectionInvoke(string clsName, string methodName);
        
        [DllImport("__Internal")]
        private static extern void reflectionInvokeWithJsonStr(string clsName, string methodName, string jsonStr);

        [DllImport("__Internal")]
        private static extern void reflectionInvokeWithPlainStr(string clsName, string methodName, string plainStr);

        [DllImport("__Internal")]
        private static extern void reflectionInvokeWith2Param(string clsName, string methodName, string plainStr, string jsonStr);
   
        private void _init()
        {
            //替换sdk版本信息
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("#sdk_type", "Unity");
            properties.Add("#sdk_version_name", sdkVersion);
            string jsonStr = R_Utils.Parse2JsonStr(properties);

            initSDK(iOSAppId, serverUrl, isDebug, logLevel, jsonStr);
     
            R_Log.Debug("Editor Log: calling init.");
        }


        private void _track(string eventName, Dictionary<string, object> properties = null)
        {
            string jsonStr = R_Utils.Parse2JsonStr(properties);
            reflectionInvokeWith2Param("DTAnalytics", "trackEventName:properties:", eventName, jsonStr);
        }

        private void _userSet(Dictionary<string, object> properties)
        {
            string jsonStr = R_Utils.Parse2JsonStr(properties);
            reflectionInvokeWithJsonStr("DTAnalytics", "userSet:", jsonStr);
        }

        private void _userSetOnce(Dictionary<string, object> properties)
        {
            string jsonStr = R_Utils.Parse2JsonStr(properties);
            reflectionInvokeWithJsonStr("DTAnalytics", "userSetOnce:", jsonStr);
        }
        
        private void _userAdd(Dictionary<string, object> properties)
        {
            string jsonStr = R_Utils.Parse2JsonStr(properties);
            reflectionInvokeWithJsonStr("DTAnalytics", "userAdd:", jsonStr);
        }
        
        private static void _userUnset(List<string> properties)
        {
         // userUnset(properties.ToArray());  
        }
        
        private void _userDelete()
        {
            reflectionInvoke("DTAnalytics", "userDelete:");
        }
        
        private void _userAppend(Dictionary<string, object> properties)
        {
            string jsonStr = R_Utils.Parse2JsonStr(properties);
            reflectionInvokeWithJsonStr("DTAnalytics", "userAppend:", jsonStr);
        }

        private void _userUniqAppend(Dictionary<string, object> properties)
        {
            string jsonStr = R_Utils.Parse2JsonStr(properties);
            reflectionInvokeWithJsonStr("DTAnalytics", "userUniqAppend:", jsonStr);
        }

        private void _getDataTowerId(Action<string> callback)
        {
            string ret = reflectionInvokeWithReturn("DTAnalytics", "getDataTowerId");
            if (callback != null) 
            {
                callback(ret);
            }
        }
        
        private void _setAccountId(string accountId)
        {
            reflectionInvokeWithPlainStr("DTAnalytics", "setAccountId:", accountId);
            R_Log.Debug("Editor Log: calling _setAccountId.");
        }

        private void _setFirebaseAppInstanceId(string id)
        {
            reflectionInvokeWithPlainStr("DTAnalytics", "setFirebaseAppInstanceId:", id);
            R_Log.Debug("Editor Log: calling setFirebaseAppInstanceId.");
        }

        private void _setAppsFlyerId(string id)
        {
            reflectionInvokeWithPlainStr("DTAnalytics", "setAppsFlyerId:", id);
            R_Log.Debug("Editor Log: calling _setApps  FlyerId.");
        }
        private void _setKochavaId(string id)
        {
            reflectionInvokeWithPlainStr("DTAnalytics", "setKochavaId:", id);
            R_Log.Debug("Editor Log: calling _setKochavaId.");
        }
          private void _setAdjustId(string id)
        {
            reflectionInvokeWithPlainStr("DTAnalytics", "setAdjustId:", id);
            R_Log.Debug("Editor Log: calling _setKochavaId.");
        }
#endif
    }
}