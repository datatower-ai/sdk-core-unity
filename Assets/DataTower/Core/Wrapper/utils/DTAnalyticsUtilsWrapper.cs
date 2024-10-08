using System.Collections.Generic;

namespace DataTower.Core.Wrapper
{
    public partial class DTAnalyticsUtilsWrapper
    {
        private DTAnalyticsUtilsWrapper()
        {
        }

        public static DTAnalyticsUtilsWrapper Instance => Nested.Instance;

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
            Dictionary<string, object> injectedProps = DT_CommonProps.InsertDynamicProperties(properties);
            _trackTimerEnd(eventName, injectedProps);
        }

        private class Nested
        {
            internal static readonly DTAnalyticsUtilsWrapper Instance = new DTAnalyticsUtilsWrapper();

            //Explicit static constructor to tell C# compiler
            //not to mark type as beforefieldinit
            static Nested()
            {
            }
        }
    }
}