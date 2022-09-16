
using System;
using System.Collections.Generic;
using UnityEngine;


namespace ROIQuery
{
      
   
    public class ROIQueryAnalytics
    {
        
        public class AndroidServerTimeCallback : AndroidJavaProxy
        {
            public AndroidServerTimeCallback() : base("com.roiquery.analytics.api.ServerTimeListener")
            {
            }

            void onFinished(long time, string msg)
            {
                var v = onFinishedAction;
                v?.Invoke(time,msg);
            }
        }

        private static Action<long, string> onFinishedAction;

        private static AndroidServerTimeCallback _androidServerTimeCallback = new AndroidServerTimeCallback();

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
        /// 设置一般的用户属性，多次调用属性值会覆盖
        /// </summary>
        /// <param name="properties">用户属性</param>
        public static void UserSet(Dictionary<string, object> properties)
        {
            ROIQueryAnalyticsWrapper.Instance.UserSet(properties);
        }

        /// <summary>
        /// 设置只要设置一次的用户属性，多次调用属性值不会覆盖
        /// </summary>
        /// <param name="properties">用户属性</param>
        public static void UserSetOnce(Dictionary<string, object> properties)
        {
            ROIQueryAnalyticsWrapper.Instance.UserSetOnce(properties);
        }

        /// <summary>
        /// 设置可累加的用户属性，多次调用，属性值会在前一个值得基础上累加，如个人金币
        /// </summary>
        /// <param name="properties">用户属性</param>
        public static void UserAdd(Dictionary<string, object> properties)
        {
            ROIQueryAnalyticsWrapper.Instance.UserAdd(properties);
        }
        
        /// <summary>
        /// 重置一个用户属性.
        /// </summary>
        /// <param name="property">用户属性名称</param>
        public  static void UserUnset(string property)
        {
            ROIQueryAnalyticsWrapper.Instance.UserUnset(property);
        }


        /// <summary>
        /// 重置一组用户属性
        /// </summary>
        /// <param name="properties">用户属性列表</param>
        public static void UserUnset(List<string> properties)
        {
            ROIQueryAnalyticsWrapper.Instance.UserUnset(properties);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        public static void UserDelete()
        {
            ROIQueryAnalyticsWrapper.Instance.UserDelete();
        }

        /// <summary>
        /// 对 JSONArray 类型的用户属性进追加操作
        /// </summary>
        /// <param name="properties">用户属性</param>
        public static void UserAppend(Dictionary<string, object> properties)
        {
            ROIQueryAnalyticsWrapper.Instance.UserAppend(properties);
        }


        /// <summary>
        /// 获取 DataTower instance id
        /// </summary>
        public static string GetInstanceId()
        {
            return ROIQueryAnalyticsWrapper.Instance.GetROIQueryId();
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
        /// <param name="id">AppsFlyer id</param>
        public static void SetAppsFlyerId(string id)
        {
            ROIQueryAnalyticsWrapper.Instance.SetAppsFlyerId(id);
        }

        /// <summary>
        /// 设置 Firebase Cloud Message Token
        /// </summary>
        /// <param name="token">Firebase Cloud Message Token</param>
        public static void setFCMToken(string token)
        {
            ROIQueryAnalyticsWrapper.Instance.SetFCMToken(token);
        }

        /// <summary>
        /// 设置Kochava id
        /// </summary>
        /// <param name="id">Kochava id</param>
        public static void SetKochavaId(string id)
        {
            ROIQueryAnalyticsWrapper.Instance.SetKochavaId(id);
        }



        /// <summary>
        /// 获取当前时间，如果没有校准，则返回系统时间
        /// </summary>
        public static long GetRealTime()
        {
           return ROIQueryAnalyticsWrapper.Instance.GetRealTime();
        }
        
        
        /// <summary>
        /// 异步获取服务器时间
        /// </summary>
        public static void GetServerTimeAsync(Action<long, string> onFinished)
        {
            onFinishedAction = onFinished;
            ROIQueryAnalyticsWrapper.Instance.GetServerTimeAsync(_androidServerTimeCallback);
        }

        
        
        /// <summary>
        /// 同步获取服务器时间
        /// </summary>
        public static long GetServerTimeSync()
        {
            return ROIQueryAnalyticsWrapper.Instance.GetServerTimeSync();
        }
        
        /// <summary>
        /// 设置用户属性
        /// </summary>
        /// <param name="properties">用户属性</param>
        public static void SetUserProperties(Dictionary<string, object> properties = null)
        {
            UserSet(properties);
        }


    }

}

