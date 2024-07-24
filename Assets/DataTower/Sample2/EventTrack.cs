using System.Collections.Generic;
using DataTower.Core;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DataTower.Sample2
{
    public class EventTrack : MonoBehaviour
    {
        private string _eventName = "";
        private Dictionary<string, object> _properties = null;
        
        private void Start()
        {
            GameObject.Find("Canvas/ButtonBack").GetComponent<Button>()
                .onClick.AddListener(delegate
                {
                    SceneManager.LoadSceneAsync("DataTower/Sample2/Home");
                });
            
            var inputFieldEventName = GameObject.Find($"Canvas/InputFieldEventName").GetComponent<TMP_InputField>();
            inputFieldEventName.onValueChanged.AddListener(delegate { _eventName = inputFieldEventName.text; });
            
            var inputFieldProperties = GameObject.Find($"Canvas/InputFieldProperties").GetComponent<TMP_InputField>();
            inputFieldProperties.onValueChanged.AddListener(delegate
            {
                _properties = (Dictionary<string, object>) Json.Deserialize(inputFieldProperties.text);
            });
            
            GameObject.Find("Canvas/ButtonTrack").GetComponent<Button>()
                .onClick.AddListener(delegate
                {
                    DTAnalytics.Track(_eventName, _properties);
                });
        }
    }
}
