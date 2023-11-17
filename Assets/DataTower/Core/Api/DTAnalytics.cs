using System;
using System.Collections.Generic;
using DataTower.Core.Wrapper;

namespace DataTower.Core
{
    public class DTAnalytics
    {
        private static Action<long, string> onFinishedAction;

        public static void Init(string androidAppId, string iOSAppId, string serverUrl, string channel, string sdkVersion, bool isDebug,
            int logLeve)
        {
            DTAnalyticsWrapper.Instance.Init(androidAppId, iOSAppId, serverUrl, channel, sdkVersion, isDebug, logLeve);
        }

        /// <summary>
        ///     采集一条事件
        /// </summary>
        /// <param name="eventName">事件名</param>
        /// <param name="properties">事件属性</param>
        public static void Track(string eventName, Dictionary<string, object> properties = null)
        {
            DTAnalyticsWrapper.Instance.Track(eventName, properties);
        }


        /// <summary>
        ///     设置一般的用户属性，多次调用属性值会覆盖
        /// </summary>
        /// <param name="properties">用户属性</param>
        public static void UserSet(Dictionary<string, object> properties)
        {
            DTAnalyticsWrapper.Instance.UserSet(properties);
        }

        /// <summary>
        ///     设置只要设置一次的用户属性，多次调用属性值不会覆盖
        /// </summary>
        /// <param name="properties">用户属性</param>
        public static void UserSetOnce(Dictionary<string, object> properties)
        {
            DTAnalyticsWrapper.Instance.UserSetOnce(properties);
        }

        /// <summary>
        ///     设置可累加的用户属性，多次调用，属性值会在前一个值得基础上累加，如个人金币
        /// </summary>
        /// <param name="properties">用户属性</param>
        public static void UserAdd(Dictionary<string, object> properties)
        {
            DTAnalyticsWrapper.Instance.UserAdd(properties);
        }

        /// <summary>
        ///     重置一个用户属性.
        /// </summary>
        /// <param name="property">用户属性名称</param>
        public static void UserUnset(string property)
        {
            DTAnalyticsWrapper.Instance.UserUnset(property);
        }


        /// <summary>
        ///     重置一组用户属性
        /// </summary>
        /// <param name="properties">用户属性列表</param>
        public static void UserUnset(List<string> properties)
        {
            DTAnalyticsWrapper.Instance.UserUnset(properties);
        }

        /// <summary>
        ///     删除用户
        /// </summary>
        public static void UserDelete()
        {
            DTAnalyticsWrapper.Instance.UserDelete();
        }

        /// <summary>
        ///     对 JSONArray 类型的用户属性进追加操作
        /// </summary>
        /// <param name="properties">用户属性</param>
        public static void UserAppend(Dictionary<string, object> properties)
        {
            DTAnalyticsWrapper.Instance.UserAppend(properties);
        }
        
        /// <summary>
        ///     对 JSONArray 类型的用户属性进追加操作（会去重）
        /// </summary>
        /// <param name="properties">用户属性</param>
        public static void UserUniqAppend(Dictionary<string, object> properties)
        {
            DTAnalyticsWrapper.Instance.UserUniqAppend(properties);
        }

        /// <summary>
        ///     获取 DataTower instance id
        /// </summary>
        public static void GetDataTowerId(Action<string> dataTowerIDCallback)
        {
            DTAnalyticsWrapper.Instance.GetDataTowerQueryId(dataTowerIDCallback);
        }

        /// <summary>
        ///     设置自有用户id
        /// </summary>
        /// <param name="accountId">用户id</param>
        public static void SetAccountId(string accountId)
        {
            DTAnalyticsWrapper.Instance.SetAccountId(accountId);
        }


        /// <summary>
        ///     设置Firebase的app_instance_id
        /// </summary>
        /// <param name="id">app_instance_id</param>
        public static void SetFirebaseAppInstanceId(string id)
        {
            DTAnalyticsWrapper.Instance.SetFirebaseAppInstanceId(id);
        }


        /// <summary>
        ///     设置AppsFlyer id
        /// </summary>
        /// <param name="id">AppsFlyer id</param>
        public static void SetAppsFlyerId(string id)
        {
            DTAnalyticsWrapper.Instance.SetAppsFlyerId(id);
        }


        /// <summary>
        ///     设置Kochava id
        /// </summary>
        /// <param name="id">Kochava id</param>
        public static void SetKochavaId(string id)
        {
            DTAnalyticsWrapper.Instance.SetKochavaId(id);
        }

        /// <summary>
        ///     设置自有用户id
        /// </summary>
        /// <param name="adjustId">用户id</param>
        public static void SetAdjustId(string adjustId)
        {
            DTAnalyticsWrapper.Instance.SetAdjustId(adjustId);
        }
        
        
        
    }
}