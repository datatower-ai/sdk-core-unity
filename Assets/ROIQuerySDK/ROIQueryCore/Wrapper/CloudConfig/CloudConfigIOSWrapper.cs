
using System.Collections.Generic;
using ROIQuery.Utils;
using UnityEngine;
using System.Runtime.InteropServices;
using AOT;

namespace ROIQuery.CloudConfig.Wrapper
{
    public partial class ROIQueryCloudConfigWrapper
    {
#if UNITY_IOS && !(UNITY_EDITOR)

        
        [DllImport ("__Internal")]
        static extern void fetchWithCallback (ROIQueryCloudConfig.ConfigCallback callback);
        [DllImport("__Internal")]
        private static extern int getInt(string key, int defaultValue);
        [DllImport("__Internal")]
        private static extern double getDouble(string key, double defaultValue);
        [DllImport("__Internal")]
        private static extern long getLong(string key, long defaultValue);
        [DllImport("__Internal")]
        private static extern string getString(string key, string defaultValue);
        [DllImport("__Internal")]
        private static extern bool getBoolean(string key, bool defaultValue);
         private void _init()
        {
            R_Log.Debug("Editor Log: calling init.");
        }



        private void _fetch(AndroidConfigFetchCallback configFetchCallback)
        {
            fetchWithCallback(ROIQueryCloudConfig.OnConfigCallback);
            R_Log.Debug("Editor Log: calling fetch.");
        }

        private int _getInt(string key, int defaultValue = 0)
        {
            R_Log.Debug("Editor Log: calling getInt.");
            return getInt(key,defaultValue);
        }

        private string _getString(string key, string defaultValue = "")
        {
            R_Log.Debug("Editor Log: calling getString.");
            return getString(key,defaultValue);
        }

        private bool _getBoolean(string key, bool defaultValue = false)
        {
            R_Log.Debug("Editor Log: calling getBoolean.");
            return getBoolean(key,defaultValue);
        }

        private double _getDouble(string key, double defaultValue = 0.0)
        {
            R_Log.Debug("Editor Log: calling getDouble.");
            return getDouble(key,defaultValue);
        }

        private long _getLong(string key, long defaultValue = 0L)
        {
            R_Log.Debug("Editor Log: calling getLong.");
            return getLong(key,defaultValue);
        }
#endif

    }
}
