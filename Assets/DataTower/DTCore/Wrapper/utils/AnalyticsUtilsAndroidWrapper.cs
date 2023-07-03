using System.Collections.Generic;
using UnityEngine;

namespace DataTower
{
    public partial class AnalyticsUtilsWrapper
    {
#if UNITY_ANDROID && !(UNITY_EDITOR)
        //获取类，通过包名+类名方式
        private static readonly AndroidJavaClass DTAnalyticsUtils =
            new AndroidJavaClass("com.roiquery.analytics.DTAnalyticsUtils");


        private static void _trackTimerStart(string eventName)
        {
            DTAnalyticsUtils.CallStatic("trackTimerStart", eventName);
        }

        private void _trackTimerPause(string eventName)
        {
            DTAnalyticsUtils.CallStatic("trackTimerPause", eventName);
        }

        private void _trackTimerResume(string eventName)
        {
            DTAnalyticsUtils.CallStatic("trackTimerResume", eventName);
        }

        private void _trackTimerEnd(string eventName, Dictionary<string, object> properties)
        {
            string jsonStr = R_Utils.Parse2JsonStr(properties);
            AndroidJavaObject jsonObject = R_Utils.Parse2JavaJSONObject(jsonStr);
            DTAnalyticsUtils.CallStatic("trackTimerEnd:properties:", eventName, jsonObject);
        }

#endif
    }
}