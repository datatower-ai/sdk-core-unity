using System.Collections.Generic;
using UnityEngine;

namespace DataTower
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


        private void _userSet(Dictionary<string, object> properties)
        {
            R_Log.Debug("Editor Log: calling _userSet.");
        }

        private void _userSetOnce(Dictionary<string, object> properties)
        {
            R_Log.Debug("Editor Log: calling _userSetOnce.");
        }

        private void _userAdd(Dictionary<string, object> properties)
        {
            R_Log.Debug("Editor Log: calling _userAdd.");
        }

        private static void _userUnset(List<string> properties)
        {
            R_Log.Debug("Editor Log: calling _userUnset.");
        }

        private void _userDelete()
        {
            R_Log.Debug("Editor Log: calling _userDelete.");
        }

        private void _userAppend(Dictionary<string, object> properties)
        {
            R_Log.Debug("Editor Log: calling _userAppend.");
        }

        private void _getDataTowerId(AndroidJavaProxy callbackJavaProxy)
        {
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

        private void _setAdjustId(string adjustId)
        {
            R_Log.Debug("Editor Log: calling _setAdjustId.");
        }

#endif
    }
}