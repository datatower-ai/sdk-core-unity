using UnityEngine;

namespace DataTower
{
    public enum LogLevel
    {
        DEFAULT = 2,
        VERBOSE = 2,
        DEBUG = 3,
        INFO = 4,
        WARN = 5,
        ERROR = 6,
        ASSERT = 7
    }


    public class DTSDKApi : MonoBehaviour
    {
        /// <summary>
        ///     当前 Unity SDK 版本
        /// </summary>
        public static readonly string SDK_VERSION = "2.0.0";

        [Header("DTSDK-v2.0.0")] 
        [Tooltip("应用id, 由后台分配")]
        public string androidAppId = ""; 
       
        [Tooltip("由后台分配")] public string iOSAppId = "";
        
        [Tooltip("服务器地址, 由后台分配")]
        public string serverUrl = "";

        [Tooltip("渠道(只有Android平台生效)")] public string channel = "";

        [Tooltip("是否开启调试，开启将会打印log")] public bool isDebug = true;

        [Tooltip("log 级别，默认为 VERBOSE，仅在 isDebug = true 有效")] public LogLevel logLevel = LogLevel.DEFAULT;
        
        #region internal use

        private static DTSDKApi raInstance;

        //private static RoiqueryReportWrapper reportWrapper;


        private void Awake()
        {
            R_Log.Debug("RoiqueryReportAPI awake.");
            if (raInstance == null)
            {
                DontDestroyOnLoad(gameObject);
                raInstance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            DTAnalytics.Init(androidAppId, iOSAppId, serverUrl, channel, SDK_VERSION, isDebug, (int) logLevel);
        }

        #endregion
    }
}