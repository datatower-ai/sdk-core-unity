using System;
using System.Collections.Generic;
using DataTower.Core;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DataTower.Sample2
{
    public class UserTrack : MonoBehaviour
    {
        public Button buttonBack;
        public TMP_Dropdown dropdownApi;
        public TMP_InputField inputFieldProperties;
        public Toggle toggleProperties;
        public Button buttonTrack;
        
        private List<TMP_Dropdown.OptionData> _options = new()
        {
            new("user_set"),
            new("user_set_once"),
            new("user_unset"),
            new("user_add"),
            new("user_append"),
            new("user_uniq_append"),
            new("user_delete"),
        };
        private string _api = "user_set";
        private Dictionary<string, object> _propDict = null;
        private List<string> _propList = null;
        private string _propStr = null;
    
        void Start()
        {
            buttonBack.onClick.AddListener(delegate
                {
                    SceneManager.LoadSceneAsync("DataTower/Sample2/Home");
                });

            dropdownApi.options = _options;
            dropdownApi.onValueChanged.AddListener(delegate
            {
                _api = _options[dropdownApi.value].text;
            });
        
            inputFieldProperties.onValueChanged.AddListener(delegate
            {
                _propDict = null;
                _propList = null;
                _propStr = null;

                try
                {
                    var value = inputFieldProperties.text;
                    if (_api == "user_unset")
                    {
                        if (value[0] == '[' && value[^1] == ']')
                        {
                            _propList = new List<string>();
                            var substring = value.Substring(1, value.Length - 2);
                            var split = substring.Split(',');

                            foreach (var se in split)
                            {
                                var trim = se.Trim();
                                var single = trim.Substring(1, trim.Length - 2);
                                _propList.Add(single);
                            }
                        }
                        else
                        {
                            _propStr = value;
                        }
                    }
                    else
                    {
                        _propDict = (Dictionary<string, object>)Json.Deserialize(value);
                    }
                } 
                catch (Exception ex)
                {
                    Debug.LogError(ex);
                }

                toggleProperties.isOn = false;
            });
            toggleProperties.onValueChanged.AddListener(isOn =>
            {
                if (!isOn) return;
                _propDict = null;
                _propList = null;
                _propStr = null;
                inputFieldProperties.text = "";
            });
            
            buttonTrack.onClick.AddListener(delegate
                {
                    if (_api == "user_delete")
                    {
                        DTAnalytics.UserDelete();
                    } else if (_api == "user_unset" && _propList != null)
                    {
                        DTAnalytics.UserUnset(_propList);
                    } else if (_api == "user_unset")
                    {
                        DTAnalytics.UserUnset(_propStr);
                    } else if (_api == "user_set")
                    {
                        DTAnalytics.UserSet(_propDict);
                    } else if (_api == "user_set_once")
                    {
                        DTAnalytics.UserSetOnce(_propDict);
                    } else if (_api == "user_add")
                    {
                        DTAnalytics.UserAdd(_propDict);
                    } else if (_api == "user_append")
                    {
                        DTAnalytics.UserAppend(_propDict);
                    } else if (_api == "user_uniq_append")
                    {
                        DTAnalytics.UserUniqAppend(_propDict);
                    }
                });
        }
    }
}
