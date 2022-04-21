

using System;
using UnityEngine;

namespace ROIQuery
{
    public partial class ROIQueryCloudConfigWrapper
    {

        private ROIQueryCloudConfigWrapper() {
            _init();
        }

        public static ROIQueryCloudConfigWrapper Instance { get { return Nested.instance; } }

        private class Nested
        {
            static Nested() { }
           
            internal static readonly ROIQueryCloudConfigWrapper instance = new ROIQueryCloudConfigWrapper();
        }


        public void Fetch(AndroidConfigFetchCallback callback)
        {
            _fetch(callback);

        }


        public int GetInt(string key, int defaultValue = 0)
        {

            return _getInt(key, defaultValue);
        }

        public string GetString(string key, string defaultValue = "")
        {
            return _getString(key,defaultValue);
        }

        public bool GetBoolean(string key, bool defaultValue = false)
        {
            return _getBoolean(key,defaultValue);
        }

        public double GetDouble(string key, double defaultValue = 0.0)
        {
            return _getDouble(key,defaultValue);
        }

        public long GetLong(string key, long defaultValue = 0L)
        {
            return _getLong(key,defaultValue);
        }
        // TODO getJsonObject 

    }
}