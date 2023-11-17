using System.Collections.Generic;

namespace DataTower.Core
{
    public class DTAnalyticsUtils
    {
        public static void TrackTimerStart(string eventName)
        {
            DTAnalyticsUtilsWrapper.Instance.TrackTimerStart(eventName);
        }

        public static void TrackTimerPause(string eventName)
        {
            DTAnalyticsUtilsWrapper.Instance.TrackTimerPause(eventName);
        }


        public static void TrackTimerResume(string eventName)
        {
            DTAnalyticsUtilsWrapper.Instance.TrackTimerResume(eventName);
        }

        public static void TrackTimerEnd(string eventName, Dictionary<string, object> properties)
        {
            DTAnalyticsUtilsWrapper.Instance.TrackTimerEnd(eventName, properties);
        }
    }
}