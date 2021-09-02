
using System.Collections.Generic;
using ROIQuery.Utils;

namespace ROIQuery.CloudConfig.Wrapper
{
    public partial class ROIQueryCloudConfigWrapper
    {

#if UNITY_STANDALONE || UNITY_EDITOR
        private void _init()
        {
            R_Log.Debug("Editor Log: calling init.");
        }



        private void _fetch(AndroidConfigFetchCallback configFetchCallback)
        {
            ROIQueryCloudConfig.OnConfigFethedCallback(true, "");
            R_Log.Debug("Editor Log: calling fetch.");
        }

        private int _getInt(string key, int defaultValue = 0)
        {

            R_Log.Debug("Editor Log: calling getInt.");
            return 0;
        }

        private string _getString(string key, string defaultValue = "")
        {

            R_Log.Debug("Editor Log: calling getString.");
            return "";
        }

        private bool _getBoolean(string key, bool defaultValue = false)
        {

            R_Log.Debug("Editor Log: calling getBoolean.");
            return false;
        }

        private double _getDouble(string key, double defaultValue = 0.0)
        {
            R_Log.Debug("Editor Log: calling getDouble.");
            return 0.0;
        }

        private long _getLong(string key, long defaultValue = 0L)
        {
            R_Log.Debug("Editor Log: calling getLong.");
            return 0L;
        }

#endif
    }
}