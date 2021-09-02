using System.Collections.Generic;
using ROIQuery.Utils;
using UnityEngine;
using System.Runtime.InteropServices;

namespace ROIQuery.Analytics.Wrapper
{
    public partial class ROIQueryAnalyticsWrapper
    {
#if UNITY_IOS && !(UNITY_EDITOR)
        [DllImport("__Internal")]
        private static extern void initSDK(string appId, bool isDebug, int logLevel, string properties);

        [DllImport("__Internal")]
        private static extern void track(string eventName, string properties);

        [DllImport("__Internal")]
        private static extern void flush();

        [DllImport("__Internal")]
        private static extern void trackPageOpen(string properties);

        [DllImport("__Internal")]
        private static extern void trackPageClose(string properties);

        [DllImport("__Internal")]
        private static extern void trackAppClose(string properties);

        [DllImport("__Internal")]
        private static extern void setAccountId(string id);

        [DllImport("__Internal")]
        private static extern void setFirebaseAppInstanceId(string id);
        
        [DllImport("__Internal")]
        private static extern void setKochavaId(string id);

        [DllImport("__Internal")]
        private static extern void setAppsFlyerId(string id);

        [DllImport("__Internal")]
        private static extern void setUserProperties(string properties);

        [DllImport("__Internal")]
        private static extern void onAppForeground();

        [DllImport("__Internal")]
        private static extern void onAppBackground();

        private void _init()
        {
            //替换sdk版本信息
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("#sdk_type", "Unity");
            properties.Add("#sdk_version", sdkVersion);
            string jsonStr = R_Utils.Parse2JsonStr(properties);

            initSDK(iOSAppId, isDebug, logLevel, jsonStr);
            // ROIQuerySDK.CallStatic("initSDK", currentContext,appId,channel,isDebug,logLevel,jsonObject);
            R_Log.Debug("Editor Log: calling init.");
        }


        private void _track(string eventName, Dictionary<string, object> properties = null)
        {
            string jsonStr = R_Utils.Parse2JsonStr(properties);
            track(eventName, jsonStr);
            R_Log.Debug("Editor Log: calling track.");
        }

        private void _flush()
        {
            flush();
            R_Log.Debug("Editor Log: calling flush.");
        }


        private void _trackPageOpen(Dictionary<string, object> properties = null)
        {
            trackPageOpen(R_Utils.Parse2JsonStr(properties));
            R_Log.Debug("Editor Log: calling trackPageOpen.");
        }


        private void _trackPageClose(Dictionary<string, object> properties = null)
        {
            trackPageClose(R_Utils.Parse2JsonStr(properties));
            R_Log.Debug("Editor Log: calling trackPageClose.");
        }


        private void _trackAppClose(Dictionary<string, object> properties = null)
        {
            trackAppClose(R_Utils.Parse2JsonStr(properties));
            R_Log.Debug("Editor Log: calling trackAppClose.");
        }

        private void _setAccountId(string accountId)
        {
            setAccountId(accountId);
            R_Log.Debug("Editor Log: calling _setAccountId.");
        }

        private void _setFirebaseAppInstanceId(string id)
        {
            setFirebaseAppInstanceId(id);
            R_Log.Debug("Editor Log: calling _setFirebaseAppInstanceId.");
        }

        private void _setAppsFlyerId(string id)
        {
            setAppsFlyerId(id);
            R_Log.Debug("Editor Log: calling _setApps  FlyerId.");
        }
        private void _setKochavaId(string id)
        {
            setKochavaId(id);
            R_Log.Debug("Editor Log: calling _setKochavaId.");
        }

        private void _setUserProperties(Dictionary<string, object> properties = null)
        {
            setUserProperties(R_Utils.Parse2JsonStr(properties));
            R_Log.Debug("Editor Log: calling _setUserProperties.");
        }


        private void _onAppForeground()
        {
            onAppForeground();
            R_Log.Debug("Editor Log: calling _onAppForegrounded.");
        }


        private void _onAppBackground()
        {
            onAppBackground();
            R_Log.Debug("Editor Log: calling _onAppBackgrounded.");
        }

#endif
    }
}