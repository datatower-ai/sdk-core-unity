using System.Collections;
using System.Collections.Generic;
using DataTower.Core;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UserTrack : MonoBehaviour
{
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
        GameObject.Find("Canvas/ButtonBack").GetComponent<Button>()
            .onClick.AddListener(delegate
            {
                SceneManager.LoadSceneAsync("DataTower/Sample2/Home");
            });

        var dda = GameObject.Find("Canvas/DropdownAPI").GetComponent<TMP_Dropdown>();
        dda.options = _options;
        dda.onValueChanged.AddListener(delegate
        {
            _api = _options[dda.value].text;
        });
        
        var inputFieldProperties = GameObject.Find($"Canvas/InputFieldProperties").GetComponent<TMP_InputField>();
        inputFieldProperties.onValueChanged.AddListener(delegate
        {
            _propDict = null;
            _propList = null;
            _propStr = null;

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
        });
            
        GameObject.Find("Canvas/ButtonTrack").GetComponent<Button>()
            .onClick.AddListener(delegate
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
