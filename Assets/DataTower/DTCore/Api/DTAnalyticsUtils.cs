using System.Collections.Generic;

namespace DataTower
{
    public class DTAnalyticsUtils
    {
        public static void trackTimerStart(string eventName)
        {
            DTAnalyticsUtilsWrapper.Instance.TrackTimerStart(eventName);
        }

        public static void trackTimerPause(string eventName)
        {
            DTAnalyticsUtilsWrapper.Instance.TrackTimerPause(eventName);
        }


        public static void trackTimerResume(string eventName)
        {
            DTAnalyticsUtilsWrapper.Instance.TrackTimerResume(eventName);
        }

        public static void trackTimerEnd(string eventName, Dictionary<string, object> properties)
        {
            DTAnalyticsUtilsWrapper.Instance.TrackTimerEnd(eventName, properties);
        }
    }
}