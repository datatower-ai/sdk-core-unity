
using System.Collections.Generic;

namespace ROIQuery
{
    public partial class ROIQueryAnalyticsWrapper
    {

#if UNITY_STANDALONE || UNITY_EDITOR
        private void _init()
        {
            R_Log.Debug("Editor Log: calling init.");
        }


        private void _track(string eventName, Dictionary<string, object> properties = null)
        {
            R_Log.Debug("Editor Log: calling track.");
        
        }

        private void _flush()
        {
            R_Log.Debug("Editor Log: calling flush.");
        }



        private void _trackPageOpen(Dictionary<string, object> properties = null)
        {

            R_Log.Debug("Editor Log: calling trackPageOpen.");
        }


        private void _trackPageClose(Dictionary<string, object> properties = null)
        {

            R_Log.Debug("Editor Log: calling trackPageClose.");
        }


        private void _trackAppClose(Dictionary<string, object> properties = null)
        {

            R_Log.Debug("Editor Log: calling trackAppClose.");
        }

        private void _setAccountId(string accountId)
        {

            R_Log.Debug("Editor Log: calling _setAccountId.");
        }

        private void _setFirebaseAppInstanceId(string id)
        {
            R_Log.Debug("Editor Log: calling _setFirebaseAppInstanceId.");
        }
        private void _setAppsFlyerId(string id)
        {
            R_Log.Debug("Editor Log: calling _setAppsFlyerId.");
        }
        private void _setKochavaId(string id)
        {
            R_Log.Debug("Editor Log: calling _setKochavaId.");
        }

        private void _setUserProperties(Dictionary<string, object> properties = null)
        {

            R_Log.Debug("Editor Log: calling _setUserProperties.");
        }


        private void _onAppForeground()
        {
            R_Log.Debug("Editor Log: calling _onAppForegrounded.");
        }


        private void _onAppBackground()
        {
            R_Log.Debug("Editor Log: calling _onAppBackgrounded.");
        }

        


#endif
    }
}