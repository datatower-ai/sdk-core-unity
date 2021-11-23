
using System.Collections.Generic;


namespace ROIQuery
{
   
    public class ROIQueryAnalytics
    {
        
    
        public static void Init(string androidAppId, string iOSAppId, string channel, string sdkVersion, bool isDebug, int logLeve)
        {
            ROIQueryAnalyticsWrapper.Instance.Init(androidAppId,iOSAppId, channel, sdkVersion, isDebug, logLeve);
        }

        /// <summary>
        /// 采集一条事件
        /// </summary>
        /// <param name="eventName">事件名</param>
        /// <param name="properties">事件属性</param>
        public static void Track(string eventName, Dictionary<string, object> properties = null)
        {
            ROIQueryAnalyticsWrapper.Instance.Track(eventName, properties);
        }

        /// <summary>
        /// 触发一次数据上报逻辑，会将缓存中的数据发往服务端
        /// </summary>
        public static void Flush()
        {
            ROIQueryAnalyticsWrapper.Instance.Flush();
        }

        /// <summary>
        /// 采集页面打开事件
        /// </summary>
        /// <param name="properties">事件属性</param>
        public static void TrackPageOpen(Dictionary<string, object> properties = null)
        {
            ROIQueryAnalyticsWrapper.Instance.TrackPageOpen(properties);
        }

        /// <summary>
        /// 采集页面关闭事件
        /// </summary>
        /// <param name="properties">事件属性</param>
        public static void TrackPageClose(Dictionary<string, object> properties = null)
        {
            ROIQueryAnalyticsWrapper.Instance.TrackPageClose(properties);
        }

        /// <summary>
        /// 采集应用关闭事件
        /// </summary>
        /// <param name="properties">事件属性</param>
        public static void TrackAppClose(Dictionary<string, object> properties = null)
        {
            ROIQueryAnalyticsWrapper.Instance.TrackAppClose(properties);
        }


        /// <summary>
        /// 设置自有用户id
        /// </summary>
        /// <param name="accountId">用户id</param>
        public static void SetAccountId(string accountId)
        {
            ROIQueryAnalyticsWrapper.Instance.SetAccountId(accountId);
        }


        /// <summary>
        /// 设置Firebase的app_instance_id
        /// </summary>
        /// <param name="id">app_instance_id</param>
        public static void SetFirebaseAppInstanceId(string id)
        {
            ROIQueryAnalyticsWrapper.Instance.SetFirebaseAppInstanceId(id);
        }
        /// <summary>
        /// 设置AppsFlyer id
        /// </summary>
        /// <param name="id">app_instance_id</param>
        public static void SetAppsFlyerId(string id)
        {
            ROIQueryAnalyticsWrapper.Instance.SetAppsFlyerId(id);
        }
        /// <summary>
        /// 设置Kochava id
        /// </summary>
        /// <param name="id">app_instance_id</param>
        public static void SetKochavaId(string id)
        {
            ROIQueryAnalyticsWrapper.Instance.SetKochavaId(id);
        }

        /// <summary>
        /// 设置用户属性
        /// </summary>
        /// <param name="properties">用户属性</param>
        public static void SetUserProperties(Dictionary<string, object> properties = null)
        {
            ROIQueryAnalyticsWrapper.Instance.SetUserProperties(properties);
        }

        /// <summary>
        /// app 进入后台
        /// </summary>
        internal static void OnAppBackground()
        {
            ROIQueryAnalyticsWrapper.Instance.OnAppBackground();
        }

        /// <summary>
        /// app 进入前台
        /// </summary>
        internal static void OnAppForeground()
        {
            ROIQueryAnalyticsWrapper.Instance.OnAppForeground();
        }

    }

}

