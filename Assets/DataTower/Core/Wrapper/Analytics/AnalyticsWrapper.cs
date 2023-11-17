using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace DataTower.Core
{
    class DTIdCallback : AndroidJavaProxy
    {
        [CanBeNull] private readonly Action<string> _action;
        public DTIdCallback(Action<string> action) : base("ai.datatower.analytics.OnDataTowerIdListener")
        {
            _action = action;
        }
        public void onDataTowerIdCompleted(string dataTowerId)
        {
            _action?.Invoke(dataTowerId);
        }
    }

    public partial class DTAnalyticsWrapper
    {
        public string androidAppId = "";
        public string channel = "";
        public string iOSAppId = "";
        public string serverUrl = "";
        public bool isDebug = true;
        private bool isInitialized;
        public int logLevel = 2;
        public string sdkVersion = "";

        private DTAnalyticsWrapper()
        {
        }

        public static DTAnalyticsWrapper Instance => Nested.instance;


        public void Init(string androidAppId, string iOSAppId, string serverUrl, string channel, string sdkVersion, bool isDebug, int logLevel)
        {
            if (!isInitialized)
            {
                this.androidAppId = androidAppId;
                this.iOSAppId = iOSAppId;
                this.serverUrl = serverUrl;
                this.channel = channel;
                this.sdkVersion = sdkVersion;
                this.isDebug = isDebug;
                this.logLevel = logLevel;
                R_Log.IsLogEnalbe(isDebug);
                _init();
                R_Log.Debug(" DT Report  init,  androidAppId:" + androidAppId + ",iOSAppId" + iOSAppId +
                            ",serverUrl" + serverUrl + ",channel" + channel + ",sdkVersion" + sdkVersion + ",isDebug" + isDebug + ",logLevel" +
                                                    logLevel);

                isInitialized = true;
            }
        }

        public void Track(string eventName, Dictionary<string, object> properties = null)
        {
            _track(eventName, properties);
        }


        public void UserSet(Dictionary<string, object> properties)
        {
            _userSet(properties);
        }

        public void UserSetOnce(Dictionary<string, object> properties)
        {
            _userSetOnce(properties);
        }

        public void UserAdd(Dictionary<string, object> properties)
        {
            _userAdd(properties);
        }

        /// <summary>
        ///     重置一个用户属性.
        /// </summary>
        /// <param name="property">用户属性名称</param>
        public void UserUnset(string property)
        {
            var properties = new List<string> { property };
            _userUnset(properties);
        }


        /// <summary>
        ///     重置一组用户属性
        /// </summary>
        /// <param name="properties">用户属性列表</param>
        public void UserUnset(List<string> properties)
        {
            _userUnset(properties);
        }

        public void UserDelete()
        {
            _userDelete();
        }

        public void UserAppend(Dictionary<string, object> properties)
        {
            _userAppend(properties);
        }

        public void UserUniqAppend(Dictionary<string, object> properties)
        {
            _userUniqAppend(properties);
        }

        public void GetDataTowerQueryId(Action<string> callback)
        {
#if UNITY_STANDALONE || UNITY_EDITOR
            _getDataTowerId(callback);
#endif
#if UNITY_ANDROID && !(UNITY_EDITOR)
            _getDataTowerId(new DTIdCallback(callback));
#endif
#if UNITY_IOS && !(UNITY_EDITOR)
            _getDataTowerId(callback);
#endif
        }

        public void SetAccountId(string accountId)
        {
            _setAccountId(accountId);
        }


        public void SetFirebaseAppInstanceId(string id)
        {
            _setFirebaseAppInstanceId(id);
        }


        public void SetAppsFlyerId(string id)
        {
            _setAppsFlyerId(id);
        }

        public void SetKochavaId(string id)
        {
            _setKochavaId(id);
        }


        public void SetAdjustId(string adjustId)
        {
            _setAdjustId(adjustId);
        }

        private class Nested
        {
            internal static readonly DTAnalyticsWrapper instance = new DTAnalyticsWrapper();

            //Explicit static constructor to tell C# compiler
            //not to mark type as beforefieldinit
            static Nested()
            {
            }
        }
    }
}