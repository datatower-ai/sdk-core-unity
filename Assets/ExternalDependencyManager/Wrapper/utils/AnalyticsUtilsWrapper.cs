using System.Collections.Generic;

namespace ROIQuery
{
    public partial class AnalyticsUtilsWrapper
    {
        private AnalyticsUtilsWrapper()
        {
        }

        public static AnalyticsUtilsWrapper Instance => Nested.instance;

        public void TrackTimerStart(string eventName)
        {
            _trackTimerStart(eventName);
        }

        public void TrackTimerPause(string eventName)
        {
            _trackTimerPause(eventName);
        }


        public void TrackTimerResume(string eventName)
        {
            _trackTimerResume(eventName);
        }

        public void TrackTimerEnd(string eventName, Dictionary<string, object> properties)
        {
            _trackTimerEnd(eventName, properties);
        }

        private class Nested
        {
            internal static readonly AnalyticsUtilsWrapper instance = new AnalyticsUtilsWrapper();

            //Explicit static constructor to tell C# compiler
            //not to mark type as beforefieldinit
            static Nested()
            {
            }
        }
    }
}