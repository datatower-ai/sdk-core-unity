using UnityEngine;

namespace DataTower.Core
{
    public enum LogLevel
    {
        DEBUG = 3,
        INFO = 4,
        WARN = 5,
        ERROR = 6,
        ASSERT = 7
    }


    public class DTSDKApi : MonoBehaviour
    {
        /// <summary>
        ///     当前 DT Core (Unity) 版本
        /// </summary>
        public static readonly string SDK_VERSION = "3.0.1";

        [Header("DTSDK-v3.0.1")]
        [Tooltip("应用id, 由后台分配")]
        public string androidAppId = "";

        [Tooltip("由后台分配")] public string iOSAppId = "";

        [Tooltip("服务器地址, 由后台分配")]
        public string serverUrl = "";

        [Tooltip("渠道(只有Android平台生效)")] public string channel = "";

        [Tooltip("是否开启调试，开启将会打印log")] public bool isDebug = false;

        [Tooltip("log 级别，默认为 DEBUG，仅在 isDebug = true 有效")] public LogLevel logLevel = LogLevel.DEBUG;

        [Tooltip("是否自行手动开启上传，开启后需自行调用 DTAnalytics.EnableUpload() 来开始上传")] public bool manualEnableUpload = false;

        #region internal use

        private static DTSDKApi _raInstance;


        private void Awake()
        {
            R_Log.Debug("DT Report API awake.");
            if (_raInstance == null)
            {
                DontDestroyOnLoad(gameObject);
                _raInstance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            DTAnalytics.Init(androidAppId, iOSAppId, serverUrl, channel, SDK_VERSION, isDebug, (int)logLevel, manualEnableUpload);
        }

        #endregion
    }
}