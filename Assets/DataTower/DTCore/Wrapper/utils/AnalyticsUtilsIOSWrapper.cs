using System.Collections.Generic;
using System;
using System.Runtime.InteropServices;

namespace DataTower
{
    public partial class DTAnalyticsUtilsWrapper
    {
#if UNITY_IOS && !(UNITY_EDITOR)
        [DllImport("__Internal")]
        private static extern void trackTimerStart(string plainStr);

        [DllImport("__Internal")]
        private static extern void trackTimerPause(string plainStr);

        [DllImport("__Internal")]
        private static extern void trackTimerResume(string plainStr);
        
         [DllImport("__Internal")]
        private static extern void trackTimerEnd(string plainStr, string jsonStr);
        private static void _trackTimerStart(string eventName)
        {
            trackTimerStart(eventName);
        }

        private void _trackTimerPause(string eventName)
        {
            trackTimerPause(eventName);
        }

        private void _trackTimerResume(string eventName)
        {
            trackTimerResume(eventName);
        }

        private void _trackTimerEnd(string eventName, Dictionary<string, object> properties)
        {
            string jsonStr = R_Utils.Parse2JsonStr(properties);
            trackTimerEnd(eventName, jsonStr);
        }
#endif
    }
}