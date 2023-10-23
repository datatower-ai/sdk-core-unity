using System.Collections.Generic;

namespace DataTower
{
    public partial class AnalyticsUtilsWrapper
    {
#if UNITY_STANDALONE || UNITY_EDITOR

        private static void _trackTimerStart(string eventName)
        {
            R_Log.Debug("Editor Log: calling trackTimerStart.");
        }

        private void _trackTimerPause(string eventName)
        {
            R_Log.Debug("Editor Log: calling trackTimerPause.");
        }

        private void _trackTimerResume(string eventName)
        {
            R_Log.Debug("Editor Log: calling trackTimerResume.");
        }

        private void _trackTimerEnd(string eventName, Dictionary<string, object> properties)
        {
            R_Log.Debug("Editor Log: calling trackTimerEnd.");
            R_Utils.ValidateJsonDictionary(properties);
        }

#endif
    }
}