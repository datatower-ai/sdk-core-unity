/*
using AOT;
using UnityEngine;

namespace ROIQuery
{

    public delegate void OnConfigFethedDelegate(bool Success, string errorMessage);

    public class AndroidConfigFetchCallback : AndroidJavaProxy
    {


        public AndroidConfigFetchCallback() : base("com.roiquery.cloudconfig.core.ConfigFetchListener")
        {
        }

        public void onSuccess()
        {
            ROIQueryCloudConfig.OnConfigFethedCallback(true, "");

        }
        public void onError(string errorMessage)
        {
            ROIQueryCloudConfig.OnConfigFethedCallback(false, errorMessage);
        }
    }



    public class ROIQueryCloudConfig
    {


        public static event OnConfigFethedDelegate OnConfigFethed;

        private static AndroidConfigFetchCallback androidConfigFetchCallback = new AndroidConfigFetchCallback();

        //android
        public static void OnConfigFethedCallback(bool isSuccess, string errorMsg)
        {
            OnConfigFethed?.Invoke(isSuccess, errorMsg);
        }
        
        //ios
        public delegate void ConfigCallback (bool isSuccess,string msg); //声明Callback类型
        //Window系统去掉关键词前缀[MonoPInvokeCallback (typeof (DebugTest))]，ios必须此关键词。
        [MonoPInvokeCallback (typeof (ConfigCallback))] 
        public static void OnConfigCallback (bool isSuccess, string errorMsg)
        {
            OnConfigFethed?.Invoke(isSuccess, errorMsg);
        }

        /// <summary>
        /// 拉取配置
        /// </summary>
        /// <param name="configFetchCallback">拉取配置回调</param>

        public static void Fetch()
        {
            ROIQueryCloudConfigWrapper.Instance.Fetch(androidConfigFetchCallback);
        }
        
        /// <summary>
        /// 获取int 
        /// </summary>
        /// <param name="key">键名</param>
        /// <param name="defaultValue">默认值</param>
        public static int GetInt(string key, int defaultValue = 0)
        {

            return ROIQueryCloudConfigWrapper.Instance.GetInt(key, defaultValue);
        }
        /// <summary>
        /// 获取string
        /// </summary>
        /// <param name="key">键名</param>
        /// <param name="defaultValue">默认值</param>
        public static string GetString(string key, string defaultValue = "")
        {
            return ROIQueryCloudConfigWrapper.Instance.GetString(key, defaultValue);
        }
        /// <summary>
        /// 获取bool
        /// </summary>
        /// <param name="key">键名</param>
        /// <param name="defaultValue">默认值</param>
        public static bool GetBool(string key, bool defaultValue = false)
        {
            return ROIQueryCloudConfigWrapper.Instance.GetBoolean(key, defaultValue);
        }
        /// <summary>
        /// 获取double
        /// </summary>
        /// <param name="key">键名</param>
        /// <param name="defaultValue">默认值</param>
        public static double GetDouble(string key, double defaultValue = 0.0)
        {
            return ROIQueryCloudConfigWrapper.Instance.GetDouble(key, defaultValue);
        }
        /// <summary>
        /// 获取long
        /// </summary>
        /// <param name="key">键名</param>
        /// <param name="defaultValue">默认值</param>
        public static long GetLong(string key, long defaultValue = 0L)
        {
            return ROIQueryCloudConfigWrapper.Instance.GetLong(key, defaultValue);
        }


    }

}
*/

