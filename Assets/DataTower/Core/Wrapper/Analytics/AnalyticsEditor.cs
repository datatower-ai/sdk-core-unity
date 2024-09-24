using System;
using System.Collections.Generic;

namespace DataTower.Core.Wrapper
{
    public partial class DTAnalyticsWrapper
    {
#if UNITY_STANDALONE || UNITY_EDITOR
        private void _init()
        {
            R_Log.Debug("Editor Log: calling init.");
        }

        private void _enableUpload()
        {
            R_Log.Debug("Editor Log: calling enableUpload.");
        }

        private void _enableAutoTrack(DTPresetEvent presetEvent) {
            R_Log.Debug($"Editor Log: calling EnableAutoTrack: {presetEvent}");
        }    

        private void _disableAutoTrack(DTPresetEvent presetEvent) {
            R_Log.Debug($"Editor Log: calling DisableAutoTrack: {presetEvent}");
        }

        private void _track(string eventName, Dictionary<string, object> properties = null)
        {
            R_Log.Debug("Editor Log: calling track.");
            R_Utils.ValidateJsonDictionary(properties);
        }


        private void _userSet(Dictionary<string, object> properties)
        {
            R_Log.Debug("Editor Log: calling _userSet.");
            R_Utils.ValidateJsonDictionary(properties);
        }

        private void _userSetOnce(Dictionary<string, object> properties)
        {
            R_Log.Debug("Editor Log: calling _userSetOnce.");
            R_Utils.ValidateJsonDictionary(properties);
        }

        private void _userAdd(Dictionary<string, object> properties)
        {
            R_Log.Debug("Editor Log: calling _userAdd.");
            R_Utils.ValidateJsonDictionary(properties);
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
            R_Utils.ValidateListOnlyProp(properties);
        }
        
        private void _userUniqAppend(Dictionary<string, object> properties)
        {
            R_Log.Debug("Editor Log: calling _userUniqAppend.");
            R_Utils.ValidateListOnlyProp(properties);
        }

        private void _getDataTowerId(Action<string> callback)
        {
            callback("testDtId");
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

        private void _setTenjinId(string id)
        {
            R_Log.Debug("Editor Log: calling _setTenjinId");
        }

        private void _setStaticCommonProperties(Dictionary<string, object> properties)
        {
            R_Log.Debug("Editor Log: calling setStaticCommonProperties.");
        }

        private void _clearStaticCommonProperties()
        {
            R_Log.Debug("Editor Log: calling clearStaticCommonProperties.");
        }

#endif
    }
}