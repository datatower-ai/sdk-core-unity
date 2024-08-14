using System.Collections.Generic;
using System.Runtime.InteropServices;
using System;

namespace DataTower.Core.Wrapper
{
    public partial class DTAnalyticsWrapper
    {
#if UNITY_IOS && !(UNITY_EDITOR)
        [DllImport("__Internal")]
        private static extern void initSDK(string appId, string serverUrl, bool isDebug, int logLevel, string properties, bool enableUpload);

       [DllImport("__Internal")]
        private static extern void enableUpload(bool enable);

        [DllImport("__Internal")]
        private static extern string getDataTowerId();

        [DllImport("__Internal")]
        private static extern void userDelete();
        
       [DllImport("__Internal")]
        private static extern void userUniqAppend(string jsonStr);
        
        [DllImport("__Internal")]
        private static extern void userSet(string jsonStr);

        [DllImport("__Internal")]
        private static extern void userAdd(string jsonStr);

        [DllImport("__Internal")]
        private static extern void userSetOnce(string jsonStr);

       [DllImport("__Internal")]
        private static extern void userUnset(string jsonStr);

        [DllImport("__Internal")]
        private static extern void userAppend(string jsonStr);
        
        [DllImport("__Internal")]
        private static extern void setAccountId(string plainStr);

        [DllImport("__Internal")]
        private static extern void setFirebaseAppInstanceId(string plainStr);

        [DllImport("__Internal")]
        private static extern void setAppsFlyerId(string plainStr);

        [DllImport("__Internal")]
        private static extern void setKochavaId(string plainStr);

        [DllImport("__Internal")]
        private static extern void setAdjustId(string plainStr);

        [DllImport("__Internal")]
        private static extern void setTenjinId(string plainStr);
        
        [DllImport("__Internal")]
        private static extern void trackEvent(string eventName, string jsonStr);

        [DllImport("__Internal")]
        private static extern void setSuperProperties(string jsonStr);
   
        private void _init()
        {
            //替换sdk版本信息
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("#sdk_type", "Unity");
            properties.Add("#sdk_version_name", sdkVersion);
            string jsonStr = R_Utils.Parse2JsonStr(properties);

            var enableUpload = !manualEnableUpload;

            initSDK(iOSAppId, serverUrl, isDebug, logLevel, jsonStr, enableUpload);
        }

        private void _enableUpload()
        {
            enableUpload(true);
        }

        private void _track(string eventName, Dictionary<string, object> properties = null)
        {
            string jsonStr = R_Utils.Parse2JsonStr(properties);
            trackEvent(eventName, jsonStr);
        }

        private void _userSet(Dictionary<string, object> properties)
        {
            string jsonStr = R_Utils.Parse2JsonStr(properties);
            userSet(jsonStr);
        }

        private void _userSetOnce(Dictionary<string, object> properties)
        {
            string jsonStr = R_Utils.Parse2JsonStr(properties);
            userSetOnce(jsonStr);
        }
        
        private void _userAdd(Dictionary<string, object> properties)
        {
            string jsonStr = R_Utils.Parse2JsonStr(properties);
            userAdd(jsonStr);
        }
        
        private static void _userUnset(List<string> properties)
        {
            string jsonStr = R_Utils.ParseList2JsonStr(properties);
            userUnset(jsonStr);
        }
        
        private void _userDelete()
        {
            userDelete();
        }
        
        private void _userAppend(Dictionary<string, object> properties)
        {
            string jsonStr = R_Utils.Parse2JsonStr(properties);
            userAppend(jsonStr);
        }

        private void _userUniqAppend(Dictionary<string, object> properties)
        {
            string jsonStr = R_Utils.Parse2JsonStr(properties);
            userUniqAppend(jsonStr);
        }

        private void _getDataTowerId(Action<string> callback)
        {
            string ret = getDataTowerId();
            if (callback != null) 
            {
                callback(ret);
            }
        }
        
        private void _setAccountId(string accountId)
        {
            setAccountId(accountId);
        }

        private void _setFirebaseAppInstanceId(string id)
        {
            setFirebaseAppInstanceId(id);
        }

        private void _setAppsFlyerId(string id)
        {
            setAppsFlyerId(id);
        }
        private void _setKochavaId(string id)
        {
            setKochavaId(id);
        }
        private void _setAdjustId(string id)
        {
            setAdjustId(id);
        }
        private void _setTenjinId(string id)
        {
            setTenjinId(id);
        }

        private void _setStaticCommonProperties(Dictionary<string, object> properties)
        {
            setSuperProperties(R_Utils.Parse2JsonStr(properties));
        }

        private void _clearStaticCommonProperties()
        {
            setSuperProperties(null);
        }

#endif
    }
}