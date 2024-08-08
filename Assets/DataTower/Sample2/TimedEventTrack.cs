using System;
using System.Collections.Generic;
using DataTower.Core;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DataTower.Sample2
{
    public class TimedEventTrack : MonoBehaviour
    {
        public Button buttonBack;
        public TMP_InputField inputFieldEventName;
        public TMP_InputField inputFieldProperties;
        public Toggle toggleProperties;
        public Button buttonStart;
        public Button buttonPause;
        public Button buttonResume;
        public Button buttonEnd;

        public RectTransform Bg;
        
        
        private string _eventName = "";
        private Dictionary<string, object> _properties = null;
    
        void Start()
        {
            AdaptiveUtil.UpdateSceneScale(Bg);
            
            buttonBack.onClick.AddListener(delegate
                {
                    SceneManager.LoadSceneAsync("DataTower/Sample2/Home");
                });
            
            inputFieldEventName.onValueChanged.AddListener(delegate { _eventName = inputFieldEventName.text; });
            
            inputFieldProperties.onValueChanged.AddListener(delegate
            {
                try
                {
                    _properties = (Dictionary<string, object>)Json.Deserialize(inputFieldProperties.text);
                } catch (Exception ex)
                {
                    Debug.LogError(ex);
                }
                toggleProperties.isOn = false;
            });
            toggleProperties.onValueChanged.AddListener(isOn =>
            {
                if (!isOn) return;
                _properties = null;
                inputFieldProperties.text = "";
            });
            
            buttonStart.onClick.AddListener(delegate
                {
                    DTAnalyticsUtils.TrackTimerStart(_eventName);
                });
            
            buttonPause.onClick.AddListener(delegate
                {
                    DTAnalyticsUtils.TrackTimerPause(_eventName);
                });
            
            buttonResume.onClick.AddListener(delegate
                {
                    DTAnalyticsUtils.TrackTimerResume(_eventName);
                });
            
            buttonEnd.onClick.AddListener(delegate
                {
                    DTAnalyticsUtils.TrackTimerEnd(_eventName, _properties);
                });
        }
    }
}
