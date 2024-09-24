using DataTower.Core;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DataTower.Sample2
{
    public class Entry : MonoBehaviour
    {
        private string _serverUrl = "https://test.roiquery.com";
        private string _appId = "dt_d4f13c5e2a7c804c";
        private bool _isDebug = true;
        private bool _manuallyEnableUpload = false;

        public TMP_InputField inputFieldServerUrl;

        public TMP_InputField inputFieldAppId;
        
        public Toggle toggleIsDebug;
        
        public Toggle toggleManuallyEnableUpload;

        public Button buttonInitialize;

        public RectTransform Bg;
        
        public Toggle toggleAppInstall;
        
        public Toggle toggleSessionStart;
        
        public Toggle toggleSessionEnd;


        // Start is called before the first frame update
        private void Start()
        {
            AdaptiveUtil.UpdateSceneScale(Bg);
            
            inputFieldServerUrl.onValueChanged.AddListener(delegate { _serverUrl = inputFieldServerUrl.text; });
            inputFieldServerUrl.text = _serverUrl;

            inputFieldAppId.onValueChanged.AddListener(delegate { _appId = inputFieldAppId.text; });
            inputFieldAppId.text = _appId;

            toggleIsDebug.onValueChanged.AddListener(delegate { _isDebug = toggleIsDebug.isOn; });

            toggleManuallyEnableUpload.onValueChanged.AddListener(delegate { _manuallyEnableUpload = toggleManuallyEnableUpload.isOn; });

            toggleAppInstall.onValueChanged.AddListener(delegate
            {
                PresetEvent.isAppInstallEnabled = toggleAppInstall.isOn;
                if (toggleAppInstall.isOn)
                {
                    DTAnalytics.EnableAutoTrack(DTPresetEvent.Install);
                }
                else
                {
                    DTAnalytics.DisableAutoTrack(DTPresetEvent.Install);
                }
            });

            toggleSessionStart.onValueChanged.AddListener(delegate { 
                PresetEvent.isSessionStartEnabled = toggleSessionStart.isOn;
                if (toggleSessionStart.isOn)
                {
                    DTAnalytics.EnableAutoTrack(DTPresetEvent.SessionStart);
                }
                else
                {
                    DTAnalytics.DisableAutoTrack(DTPresetEvent.SessionStart);
                }
            });

            toggleSessionEnd.onValueChanged.AddListener(delegate { 
                PresetEvent.isSessionEndEnabled = toggleSessionEnd.isOn;
                if (toggleSessionEnd.isOn)
                {
                    DTAnalytics.EnableAutoTrack(DTPresetEvent.SessionEnd);
                }
                else
                {
                    DTAnalytics.DisableAutoTrack(DTPresetEvent.SessionEnd);
                }
            });

            buttonInitialize.onClick.AddListener(delegate
                {
                    if (_serverUrl.Length == 0 || _appId.Length == 0) return;
                    
#if UNITY_ANDROID && !(UNITY_EDITOR)
                    DTAnalytics.Init(_appId, "", _serverUrl, "", DTSDKApi.SDK_VERSION, _isDebug, (int)LogLevel.DEBUG, _manuallyEnableUpload);
                    SceneManager.LoadSceneAsync("DataTower/Sample2/Home");
#elif UNITY_IOS && !(UNITY_EDITOR)
                    DTAnalytics.Init("", _appId, _serverUrl, "", DTSDKApi.SDK_VERSION, _isDebug, (int)LogLevel.DEBUG, _manuallyEnableUpload);
                    SceneManager.LoadSceneAsync("DataTower/Sample2/Home");
#else
                    DTAnalytics.Init(_appId, _appId, _serverUrl, "", DTSDKApi.SDK_VERSION, _isDebug, (int)LogLevel.DEBUG, _manuallyEnableUpload);
                    SceneManager.LoadSceneAsync("DataTower/Sample2/Home");
#endif
                });
        }
    }
}
