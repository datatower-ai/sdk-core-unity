using System.Collections.Generic;

namespace DataTower
{
    public partial class AnalyticsUtilsWrapper
    {
#if UNITY_IOS && !(UNITY_EDITOR)
        // [DllImport("__Internal")]
        // private static extern void trackTimerStart(string eventName);
        //
        // [DllImport("__Internal")]
        // private static extern void trackTimerPause(string eventName);
        //
        // [DllImport("__Internal")]
        // private static extern void trackTimerResume(string eventName);
        //
        // [DllImport("__Internal")]
        // private static extern void trackTimerEnd(string eventName,string properties = null);
      
        private static void _trackTimerStart(string eventName)
        {
            // trackTimerStart(eventName);
            // R_Log.Debug("Editor Log: calling trackTimerStart.");
        }

        private void _trackTimerPause(string eventName)
        {
            // trackTimerPause(eventName);
            // R_Log.Debug("Editor Log: calling trackTimerPause.");
        }

        private void _trackTimerResume(string eventName)
        {
            // trackTimerResume(eventName);
            // R_Log.Debug("Editor Log: calling trackTimerResume.");
        }

        private void _trackTimerEnd(string eventName, Dictionary<string, object> properties)
        {
            // string jsonStr = R_Utils.Parse2JsonStr(properties);
            // trackTimerEnd(eventName,jsonStr);
            // R_Log.Debug("Editor Log: calling trackTimerEnd.");
        }
#endif
    }
}