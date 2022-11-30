namespace DataTower
{
    public partial class ROIQueryAnalyticsWrapper
    {
#if UNITY_IOS && !(UNITY_EDITOR)
        [DllImport("__Internal")]
        private static extern void initSDK(string appId, bool isDebug, int logLevel, string properties);

        [DllImport("__Internal")]
        private static extern void roiTrack(string eventName, string properties);

        [DllImport("__Internal")]
        private static extern void roiFlush();

        [DllImport("__Internal")]
        private static extern void trackPageOpen(string properties);

        [DllImport("__Internal")]
        private static extern void trackPageClose(string properties);

        [DllImport("__Internal")]
        private static extern void trackAppClose(string properties);
        
        [DllImport("__Internal")]
        private static extern string getDataTowerId();

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
        private static extern void userSet(Dictionary<string, object> properties = null);
        
        
        [DllImport("__Internal")]
        private static extern void userSetOnce(Dictionary<string, object> properties = null);
        
        [DllImport("__Internal")]
        private static extern void userUnset(string[] properties);
        
        [DllImport("__Internal")]
        private static extern void userAppend(Dictionary<string, object> properties = null);
        
        [DllImport("__Internal")]
        private static extern void userAdd(Dictionary<string, object> properties = null);
        
        [DllImport("__Internal")]
        private static extern void userDelete();
        
        
        [DllImport("__Internal")]
        private static extern void setIasOriginalOrderID(string id);

        [DllImport("__Internal")]
        private static extern void setAdjustId(string id);
        
        [DllImport("__Internal")]
        private static extern void onAppForeground();

        [DllImport("__Internal")]
        private static extern void onAppBackground();

        private void _init()
        {
            //替换sdk版本信息
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("#sdk_type", "Unity");
            properties.Add("#sdk_version_name", sdkVersion);
            string jsonStr = R_Utils.Parse2JsonStr(properties);

            initSDK(iOSAppId, isDebug, logLevel, jsonStr);
            // ROIQuerySDK.CallStatic("initSDK", currentContext,appId,channel,isDebug,logLevel,jsonObject);
            R_Log.Debug("Editor Log: calling init.");
        }


        private void _track(string eventName, Dictionary<string, object> properties = null)
        {
            string jsonStr = R_Utils.Parse2JsonStr(properties);
            roiTrack(eventName, jsonStr);
            R_Log.Debug("Editor Log: calling track.");
        }

        private void _userSet(Dictionary<string, object> properties)
        {
            userSet(properties);
        }
        private void _userSetOnce(Dictionary<string, object> properties)
        {
            userSetOnce(properties);
        }
        
        private void _userAdd(Dictionary<string, object> properties)
        {
            userAdd(properties);
        }
        
        private static void _userUnset(List<string> properties)
        {
         userUnset(properties.ToArray());  
        }
        
        private void _userDelete()
        {
            userDelete();
        }
        
        private void _userAppend(Dictionary<string, object> properties)
        {
            userAppend(properties);
        }


        private string _getDataTowerId()
        {
            return getDataTowerId();
            R_Log.Debug("Editor Log: calling _setAccountId.");
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
          private void _setAdjustId(string id)
        {
            setAdjustId(id);
            R_Log.Debug("Editor Log: calling _setKochavaId.");
        }


#endif
    }
}