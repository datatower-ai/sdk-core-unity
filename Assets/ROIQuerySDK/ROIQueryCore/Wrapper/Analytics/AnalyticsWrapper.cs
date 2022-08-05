using System.Collections.Generic;

namespace ROIQuery
{
    public partial class ROIQueryAnalyticsWrapper
    {
        public string androidAppId = "";
        public string iOSAppId = "";
        public string sdkVersion = "";
        public string channel = "";
        public bool isDebug = true;
        public int logLevel = 2;
        private bool isInitialized = false;

        private ROIQueryAnalyticsWrapper()
        {
        }

        public static ROIQueryAnalyticsWrapper Instance
        {
            get { return Nested.instance; }
        }

        private class Nested
        {
            //Explicit static constructor to tell C# compiler
            //not to mark type as beforefieldinit
            static Nested()
            {
            }

            internal static readonly ROIQueryAnalyticsWrapper instance = new ROIQueryAnalyticsWrapper();
        }


        public void Init(string androidAppId, string iOSAppId, string channel, string sdkVersion, bool isDebug,
            int logLevel)
        {
            if (!isInitialized)
            {
                this.androidAppId = androidAppId;
                this.iOSAppId = iOSAppId;
                this.channel = channel;
                this.sdkVersion = sdkVersion;
                this.isDebug = isDebug;
                this.logLevel = logLevel;
                R_Log.IsLogEnalbe(isDebug);
                _init();
                R_Log.Debug(" RoiqueryReport  init,  androidAppId:" + androidAppId + ",iOSAppId" + iOSAppId +
                            ",channel" + channel + ",sdkVersion" + sdkVersion + ",isDebug" + isDebug + ",logLevel" +
                            logLevel);

                isInitialized = true;
            }
        }

        public void Track(string eventName, Dictionary<string, object> properties = null)
        {
            _track(eventName, properties);
        }


        public void Flush()
        {
            _flush();
        }


        public void TrackPageOpen(Dictionary<string, object> properties = null)
        {
            _trackPageOpen(properties);
        }


        public void TrackPageClose(Dictionary<string, object> properties = null)
        {
            _trackPageClose(properties);
        }


        public void TrackAppClose(Dictionary<string, object> properties = null)
        {
            _trackAppClose(properties);
        }


        public void UserSet(Dictionary<string, object> properties)
        {
            _userSet(properties);
        }

        public void UserSetOnce(Dictionary<string, object> properties)
        {
            _userSetOnce(properties);
        }

        public void UserAdd(Dictionary<string, object> properties)
        {
            _userAdd(properties);
        }

        /// <summary>
        /// 重置一个用户属性.
        /// </summary>
        /// <param name="property">用户属性名称</param>
        public void UserUnset(string property)
        {
            List<string> properties = new List<string>();
            properties.Add(property);
            _userUnset(properties);
        }


        /// <summary>
        /// 重置一组用户属性
        /// </summary>
        /// <param name="properties">用户属性列表</param>
        public void UserUnset(List<string> properties)
        {
            _userUnset(properties);
        }

        public void UserDelete()
        {
            _userDelete();
        }

        public void UserAppend(Dictionary<string, object> properties)
        {
            _userAppend(properties);
        }

        public string GetROIQueryId()
        {
            return _getROIQueryId();
        }


        public void SetAccountId(string accountId)
        {
            _setAccountId(accountId);
        }


        public void SetFirebaseAppInstanceId(string id)
        {
            _setFirebaseAppInstanceId(id);
        }

        public void SetFCMToken(string token)
        {
#if UNITY_ANDROID
            _setFCMToken(token);
#endif
        }

        public void SetAppsFlyerId(string id)
        {
            _setAppsFlyerId(id);
        }

        public void SetKochavaId(string id)
        {
            _setKochavaId(id);
        }

        public long GetRealTime()
        {
            return _getRealTime();
        }

        public void GetServerTimeAsync(ROIQueryAnalytics.AndroidServerTimeCallback callback)
        {
            _getServerTimeAsync(callback);
        }

        public long GetServerTimeSync()
        {
            return _getServerTimeSync();
        }
        
        public void SetUserProperties(Dictionary<string, object> properties = null)
        {

            _setUserProperties(properties);
        }


       
    }
}