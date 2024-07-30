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
        private string _eventName = "";
        private Dictionary<string, object> _properties = null;
    
        void Start()
        {
            GameObject.Find("Canvas/ButtonBack").GetComponent<Button>()
                .onClick.AddListener(delegate
                {
                    SceneManager.LoadSceneAsync("DataTower/Sample2/Home");
                });
            
            var inputFieldEventName = GameObject.Find($"Canvas/InputFieldEventName").GetComponent<TMP_InputField>();
            inputFieldEventName.onValueChanged.AddListener(delegate { _eventName = inputFieldEventName.text; });
            
            var inputFieldProperties = GameObject.Find($"Canvas/InputFieldProperties").GetComponent<TMP_InputField>();
            var toggleProperties = GameObject.Find("Canvas/ToggleProperties").GetComponent<Toggle>();
            inputFieldProperties.onValueChanged.AddListener(delegate
            {
                _properties = (Dictionary<string, object>) Json.Deserialize(inputFieldProperties.text);
                toggleProperties.isOn = false;
            });
            toggleProperties.onValueChanged.AddListener(isOn =>
            {
                if (!isOn) return;
                _properties = null;
                inputFieldProperties.text = "";
            });
            
            GameObject.Find("Canvas/ButtonTrackStart").GetComponent<Button>()
                .onClick.AddListener(delegate
                {
                    DTAnalyticsUtils.TrackTimerStart(_eventName);
                });
            
            GameObject.Find("Canvas/ButtonTrackPause").GetComponent<Button>()
                .onClick.AddListener(delegate
                {
                    DTAnalyticsUtils.TrackTimerPause(_eventName);
                });
            
            GameObject.Find("Canvas/ButtonTrackResume").GetComponent<Button>()
                .onClick.AddListener(delegate
                {
                    DTAnalyticsUtils.TrackTimerResume(_eventName);
                });
            
            GameObject.Find("Canvas/ButtonTrackStop").GetComponent<Button>()
                .onClick.AddListener(delegate
                {
                    DTAnalyticsUtils.TrackTimerEnd(_eventName, _properties);
                });
        }
    }
}
