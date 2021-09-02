

using UnityEngine;

namespace ROIQuery.CloudConfig.Wrapper
{
    public partial class ROIQueryCloudConfigWrapper
    {
#if UNITY_ANDROID && !(UNITY_EDITOR)

        //获取类，通过包名+类名方式
        private static readonly AndroidJavaClass ROIQueryCloudConfig = new AndroidJavaClass("com.roiquery.cloudconfig.ROIQueryCloudConfig");
        

        private void _init()
        {
            
        }

        private void _fetch(AndroidConfigFetchCallback configFetchCallback)
        {
            ROIQueryCloudConfig.CallStatic("fetch",configFetchCallback);
        }

        private int _getInt(string key, int defaultValue = 0)
        {
           return ROIQueryCloudConfig.CallStatic<int>("getInt",key,defaultValue);
        }

        private string _getString(string key, string defaultValue = "")
        {
            return ROIQueryCloudConfig.CallStatic<string>("getString", key, defaultValue);
        }

        private bool _getBoolean(string key, bool defaultValue = false)
        {
            return ROIQueryCloudConfig.CallStatic<bool>("getBoolean", key, defaultValue);
        }

        private double _getDouble(string key, double defaultValue = 0.0)
        {
            return ROIQueryCloudConfig.CallStatic<double>("getDouble", key, defaultValue);
        }

        private long _getLong(string key, long defaultValue = 0L)
        {
           return ROIQueryCloudConfig.CallStatic<long>("getLong",key,defaultValue);
        }
#endif
    }
}
