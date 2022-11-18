using System.Collections.Generic;

namespace ROIQuery
{
    public class DTAnalyticsUtils
    {
        public static void trackTimerStart(string eventName)
        {
            AnalyticsUtilsWrapper.Instance.TrackTimerStart(eventName);
        }

        public static void trackTimerPause(string eventName)
        {
            AnalyticsUtilsWrapper.Instance.TrackTimerPause(eventName);
        }


        public static void trackTimerResume(string eventName)
        {
            AnalyticsUtilsWrapper.Instance.TrackTimerResume(eventName);
        }

        public static void trackTimerEnd(string eventName, Dictionary<string, object> properties)
        {
            AnalyticsUtilsWrapper.Instance.TrackTimerEnd(eventName, properties);
        }
    }
}