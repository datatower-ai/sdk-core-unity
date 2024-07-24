using System;
using DataTower.Core;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DataTower.Sample2
{
    public class Entry : MonoBehaviour
    {
        private string _serverUrl = "";
        private string _appId = "";
        private bool _isDebug = true;
        private bool _manuallyEnableUpload = false;
        
        // Start is called before the first frame update
        private void Start()
        {
            var inputFieldServerUrl = GameObject.Find("Canvas/InputFieldServerUrl").GetComponent<TMP_InputField>();
            inputFieldServerUrl.onValueChanged.AddListener(delegate { _serverUrl = inputFieldServerUrl.text; });
            
            var inputFieldAppId = GameObject.Find("Canvas/InputFieldAppId").GetComponent<TMP_InputField>();
            inputFieldAppId.onValueChanged.AddListener(delegate { _appId = inputFieldAppId.text; });
            
            var toggleIsDebug = GameObject.Find("Canvas/ToggleIsDebug").GetComponent<Toggle>();
            toggleIsDebug.onValueChanged.AddListener(delegate { _isDebug = toggleIsDebug.isOn; });
            
            var toggleManuallyEnableUpload = GameObject.Find("Canvas/ToggleManuallyEnableUpload").GetComponent<Toggle>();
            toggleManuallyEnableUpload.onValueChanged.AddListener(delegate { _manuallyEnableUpload = toggleManuallyEnableUpload.isOn; });

            GameObject.Find("Canvas/ButtonInitialize").GetComponent<Button>()
                .onClick.AddListener(delegate
                {
                    if (_serverUrl.Length != 0 && _appId.Length != 0)
                    {
#if UNITY_ANDROID && !(UNITY_EDITOR)
                        DTAnalytics.Init(_appId, "", _serverUrl, "", DTSDKApi.SDK_VERSION, _isDebug, (int)LogLevel.DEBUG, _manuallyEnableUpload);
                        SceneManager.LoadSceneAsync("DataTower/Sample2/Home");
#elif UNITY_IOS && !(UNITY_EDITOR)
                        DTAnalytics.Init("", _appId, _serverUrl, "", DTSDKApi.SDK_VERSION, _isDebug, (int)LogLevel.DEBUG, _manuallyEnableUpload);
                        SceneManager.LoadSceneAsync("DataTower/Sample2/Home");
#endif
                    }
                });
        }
    }
}
