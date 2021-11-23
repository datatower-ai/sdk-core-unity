﻿
using System;

namespace ROIQuery
{
    /// <summary>
    /// RoiqueryAnalytics Log Class
    /// </summary>
    public class R_Log
    {
        private static bool isLogEnable = false;
        public static void IsLogEnalbe(bool isEnable)
        {
            isLogEnable = isEnable;
        }

        public static void Debug(string logMessage)
        {
            if (isLogEnable) UnityEngine.Debug.Log(logMessage);
        }

        public static void Warn(string logMessage)
        {
            if (isLogEnable) UnityEngine.Debug.LogWarning(logMessage);
        }

        public static void Error(string logMessage)
        {
            if (isLogEnable) UnityEngine.Debug.LogError(logMessage);
        }

        public static void Exception(Exception exception)
        {
            if (isLogEnable) UnityEngine.Debug.LogException(exception);
        }

    }

}
