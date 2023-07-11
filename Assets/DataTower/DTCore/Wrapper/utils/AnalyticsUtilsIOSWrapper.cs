using System.Collections.Generic;
using System;
using System.Runtime.InteropServices;

namespace DataTower
{
    public partial class AnalyticsUtilsWrapper
    {
#if UNITY_IOS && !(UNITY_EDITOR)
        [DllImport("__Internal")]
        private static extern void reflectionInvokeWithPlainStr(string clsName, string methodName, string plainStr);
        
         [DllImport("__Internal")]
        private static extern void reflectionInvokeWith2Param(string clsName, string methodName, string plainStr, string jsonStr);
        private static void _trackTimerStart(string eventName)
        {
            reflectionInvokeWithPlainStr("DTAnalyticsUtils", "trackTimerStart:", eventName);
            R_Log.Debug("Editor Log: calling trackTimerStart.");
        }

        private void _trackTimerPause(string eventName)
        {
            reflectionInvokeWithPlainStr("DTAnalyticsUtils", "trackTimerPause:", eventName);
            R_Log.Debug("Editor Log: calling trackTimerPause.");
        }

        private void _trackTimerResume(string eventName)
        {
            reflectionInvokeWithPlainStr("DTAnalyticsUtils", "trackTimerResume:", eventName);
            R_Log.Debug("Editor Log: calling trackTimerResume.");
        }

        private void _trackTimerEnd(string eventName, Dictionary<string, object> properties)
        {
            string jsonStr = R_Utils.Parse2JsonStr(properties);
            reflectionInvokeWith2Param("DTAnalyticsUtils", "trackTimerEnd:properties:", eventName, jsonStr);
            R_Log.Debug("Editor Log: calling trackTimerEnd.");
        }
#endif
    }
}