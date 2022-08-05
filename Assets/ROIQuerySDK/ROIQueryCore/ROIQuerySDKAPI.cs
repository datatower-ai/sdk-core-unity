using System;
using UnityEngine;
using UnityEngine.Events;

namespace ROIQuery
{
    public enum LogLevel : int
    {
        DEFAULT = 2,
        VERBOSE = 2,
        DEBUG = 3,
        INFO = 4,
        WARN = 5,
        ERROR = 6,
        ASSERT = 7
    }


    public class ROIQuerySDKAPI : MonoBehaviour
    {
        /// <summary>
        /// 当前 Unity SDK 版本
        /// </summary>
        public readonly static string SDK_VERSION = "1.2.3";

        [Header("ROIQuerySDK-v1.2.3")]
        
        [Tooltip("由后台分配")] public string androidAppId = "";
        
        [Tooltip("由后台分配")] public string iOSAppId = "";

        [Tooltip("渠道(只有Android平台生效)")] public string channel = "";

        [Tooltip("是否开启调试，开启将会打印log")] public bool isDebug = false;

        [Tooltip("设置log 级别")] public LogLevel logLevel = LogLevel.DEFAULT;
        

        #region internal use

        private static ROIQuerySDKAPI raInstance;

        //private static RoiqueryReportWrapper reportWrapper;


        void Awake()
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

            ROIQueryAnalytics.Init(androidAppId, iOSAppId, channel, SDK_VERSION, isDebug, (int) logLevel);
        }

        #endregion
        
    }
}