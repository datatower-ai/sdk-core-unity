
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

        public static ROIQueryAnalyticsWrapper Instance { get { return Nested.instance; } }

        private class Nested
        {
            //Explicit static constructor to tell C# compiler
            //not to mark type as beforefieldinit
            static Nested()
            {

            }

            internal static readonly ROIQueryAnalyticsWrapper instance = new ROIQueryAnalyticsWrapper();
        }


        public void Init(string androidAppId, string iOSAppId, string channel, string sdkVersion, bool isDebug, int logLevel)
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
                R_Log.Debug(" RoiqueryReport  init,  androidAppId:" + androidAppId + ",iOSAppId" + iOSAppId+",channel" +channel+ ",sdkVersion" + sdkVersion + ",isDebug" + isDebug + ",logLevel" + logLevel);
              
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