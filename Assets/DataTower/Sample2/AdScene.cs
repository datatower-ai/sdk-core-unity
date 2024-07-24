using System;
using System.Collections.Generic;
using System.Linq;
using DataTower.Core;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.Double;

namespace DataTower.Sample2
{
    public class AdScene : MonoBehaviour
    {
        private readonly List<string> _allParams = new()
        {
            "Id", "AdType", "AdPlatform", 
            "AdMediation", "AdMediationId", "Seq", 
            "Properties", "Location", "Value", 
            "Currency", "Precision", "Entrance", 
            "Country", "ErrorCode", "ErrorMessage",
            "Duration", "Result"
        };
        private readonly Dictionary<string, List<string>> _apis = new ()
        {
            { "ReportLoadBegin", new List<string> { "Id", "AdType", "AdPlatform", "Seq", "Properties", "AdMediation", "AdMediationId" } },
            { "ReportLoadEnd", new List<string> { "Id", "AdType", "AdPlatform", "Duration", "Result", "Seq", "ErrorCode", "ErrorMessage", "Properties", "AdMediation", "AdMediationId" } },
            { "ReportToShow", new List<string> { "Id", "AdType", "AdPlatform", "Location", "Seq", "Entrance", "Properties", "AdMediation", "AdMediationId" } },
            { "ReportShow", new List<string> { "Id", "AdType", "AdPlatform", "Location", "Seq", "Entrance", "Properties", "AdMediation", "AdMediationId" } },
            { "ReportShowFailed", new List<string> { "Id", "AdType", "AdPlatform", "Location", "Seq", "ErrorCode", "ErrorMessage", "Entrance", "Properties", "AdMediation", "AdMediationId" } },
            { "ReportClose", new List<string> { "Id", "AdType", "AdPlatform", "Location", "Seq", "Entrance", "Properties", "AdMediation", "AdMediationId" } },
            { "ReportClick", new List<string> { "Id", "AdType", "AdPlatform", "Location", "Seq", "Entrance", "Properties", "AdMediation", "AdMediationId" } },
            { "ReportRewarded", new List<string> { "Id", "AdType", "AdPlatform", "Location", "Seq", "Entrance", "Properties", "AdMediation", "AdMediationId" } },
            { "ReportLeftApp", new List<string> { "Id", "AdType", "AdPlatform", "Location", "Seq", "Entrance", "Properties", "AdMediation", "AdMediationId" } },
            { "ReportConversionByClick", new List<string> { "Id", "AdType", "AdPlatform", "Location", "Seq", "Entrance", "Properties", "AdMediation", "AdMediationId" } },
            { "ReportConversionByLeftApp", new List<string> { "Id", "AdType", "AdPlatform", "Location", "Seq", "Entrance", "Properties", "AdMediation", "AdMediationId" } },
            { "ReportConversionByRewarded", new List<string> { "Id", "AdType", "AdPlatform", "Location", "Seq", "Entrance", "Properties", "AdMediation", "AdMediationId" } },
            { "ReportPaid", new List<string> { "Id", "AdType", "AdPlatform", "Location", "Seq", "Value", "Currency", "Precision", "Entrance", "Properties", "AdMediation", "AdMediationId" } },
            { "ReportPaid2", new List<string> { "Id", "AdType", "AdPlatform", "Location", "Seq", "AdMediation", "AdMediationId", "Value", "Precision", "Country", "Properties" } },
        };
        private string _api = "ReportLoadBegin";
        private Dictionary<string, GameObject> _gameObjects = new ();

        private string _id;
        private AdType _adType;
        private AdPlatform _adPlatform;
        private AdMediation _adMediation;
        private string _adMediationId;
        private string _seq;
        private Dictionary<string, object> _properties;
        private string _location;
        private double _value;
        private string _currency;
        private string _precision;
        private string _entrance;
        private string _country;
        private int _errorCode;
        private string _errorMessage;
        private long _duration;
        private bool _result;
        
        private void Start()
        {
            GameObject.Find("Canvas/ButtonBack").GetComponent<Button>()
                .onClick.AddListener(delegate
                {
                    SceneManager.LoadSceneAsync("DataTower/Sample2/Home");
                });

            RegisterInputField("Id", str => { _id = str; });
            RegisterInputField("AdMediationId", str => { _adMediationId = str; });
            RegisterInputField("Seq", str => { _seq = str; });
            RegisterInputField("Location", str => { _location = str; });
            RegisterInputField("Value", str => { TryParse(str, out _value); });
            RegisterInputField("Currency", str => { _currency = str; });
            RegisterInputField("Precision", str => { _precision = str; });
            RegisterInputField("Entrance", str => { _entrance = str; });
            RegisterInputField("Country", str => { _country = str; });
            RegisterInputField("ErrorCode", str => { int.TryParse(str, out _errorCode); });
            RegisterInputField("ErrorMessage", str => { _errorMessage = str; });
            RegisterInputField("Duration", str => { long.TryParse(str, out _duration); });
            
            GameObject.Find("Canvas/Result/Toggle").GetComponent<Toggle>().onValueChanged.AddListener(isOn =>
            {
                _result = isOn;
            });
            
            RegisterProperties();
            RegisterDropdowns();
            RegisterTrackButton();
            
            ShowGOs("ReportLoadBegin");

            var options = _apis.Keys.Select(key => new TMP_Dropdown.OptionData(key)).ToList();
            var dda = GameObject.Find("Canvas/DropdownAPI").GetComponent<TMP_Dropdown>();
            dda.options = options;
            dda.onValueChanged.AddListener(delegate
            {
                _api = options[dda.value].text;
                ShowGOs(_api);
            });
        }
    
        private void ShowGOs(string api)
        {
            foreach (var param in _allParams)
            {
                if (!_gameObjects.ContainsKey(param))
                {
                    _gameObjects[param] = GameObject.Find($"Canvas/{param}");
                }
                _gameObjects[param].SetActive(false);
            }

            foreach (var param in _apis[api])
            {
                _gameObjects[param].SetActive(true);
            }
        }

        private static void RegisterInputField(string group, UnityAction<string> onChanged)
        {
            Debug.LogWarning($"group: {group}");
            try
            {
                GameObject.Find($"Canvas/{group}/InputField").GetComponent<TMP_InputField>()
                    .onValueChanged.AddListener(onChanged);
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }

        private void RegisterProperties()
        {
            Debug.LogWarning("Canvas/Properties/InputField");
            var inputFieldProperties = GameObject.Find("Canvas/Properties/InputField").GetComponent<TMP_InputField>();
            Debug.LogWarning("Canvas/Properties/Toggle");
            var toggleProperties = GameObject.Find("Canvas/Properties/Toggle").GetComponent<Toggle>();
            inputFieldProperties.onValueChanged.AddListener(str =>
            {
                if (str.Length == 0) return;
                _properties = (Dictionary<string, object>)Json.Deserialize(str);
                toggleProperties.isOn = false;
            });
            toggleProperties.onValueChanged.AddListener(isOn =>
            {
                if (!isOn) return;
                _properties = null;
                inputFieldProperties.text = "";
            });
        }

        private void RegisterDropdowns()
        {
            var adTypes = Enum.GetValues(typeof(AdType)).Cast<AdType>().ToList();
            var adTypesOptions = adTypes.Select(adType => new TMP_Dropdown.OptionData(adType.ToString())).ToList();
            Debug.LogWarning($"Canvas/AdType/Dropdown, {adTypes}");
            var adTypeDropdown = GameObject.Find("Canvas/AdType/Dropdown").GetComponent<TMP_Dropdown>();
            adTypeDropdown.options = adTypesOptions;
            adTypeDropdown.value = 0;
            _adType = adTypes[0];
            adTypeDropdown.onValueChanged.AddListener(v =>
            {
                _adType = adTypes[v];
            });  

            var adPlatforms = Enum.GetValues(typeof(AdPlatform)).Cast<AdPlatform>().ToList();
            var adPlatformOptions = adPlatforms.Select(it => new TMP_Dropdown.OptionData(it.ToString())).ToList();
            Debug.LogWarning($"Canvas/AdPlatform/Dropdown, {adPlatforms}");
            var adPlatformDropdown = GameObject.Find("Canvas/AdPlatform/Dropdown").GetComponent<TMP_Dropdown>();
            adPlatformDropdown.options = adPlatformOptions;
            adPlatformDropdown.value = 0;
            _adPlatform = adPlatforms[0];
            adPlatformDropdown.onValueChanged.AddListener(v =>
            {
                _adPlatform = adPlatforms[v];
            });  

            var adMediations = Enum.GetValues(typeof(AdMediation)).Cast<AdMediation>().ToList();
            var adMediationOptions = adMediations.Select(it => new TMP_Dropdown.OptionData(it.ToString())).ToList();
            Debug.LogWarning($"Canvas/AdMediation/Dropdown, {adMediations}");
            var adMediationDropdown = GameObject.Find("Canvas/AdMediation/Dropdown").GetComponent<TMP_Dropdown>();
            adMediationDropdown.options = adMediationOptions;
            adMediationDropdown.value = 0;
            _adMediation = adMediations[0];
            adMediationDropdown.onValueChanged.AddListener(v =>
            {
                _adMediation = adMediations[v];
            });
        }

        private void RegisterTrackButton()
        {
            GameObject.Find("Canvas/ButtonTrack").GetComponent<Button>().onClick.AddListener(delegate
            {
                switch (_api)
                {
                    case "ReportLoadBegin": 
                        DTAdReport.ReportLoadBegin(_id, _adType, _adPlatform, _seq, _properties, _adMediation, _adMediationId);
                        break;
                    case "ReportLoadEnd": 
                        DTAdReport.ReportLoadEnd(_id, _adType, _adPlatform, _duration, _result, _seq, _errorCode, _errorMessage, _properties, _adMediation, _adMediationId);
                        break;
                    case "ReportToShow":
                        DTAdReport.ReportToShow(_id, _adType, _adPlatform, _location, _seq, _entrance, _properties, _adMediation, _adMediationId);
                        break;
                    case "ReportShow":
                        DTAdReport.ReportShow(_id, _adType, _adPlatform, _location, _seq, _entrance, _properties, _adMediation, _adMediationId);
                        break;
                    case "ReportShowFailed":
                        DTAdReport.ReportShowFailed(_id, _adType, _adPlatform, _location, _seq, _errorCode, _errorMessage, _entrance, _properties, _adMediation, _adMediationId);
                        break;
                    case "ReportClose":
                        DTAdReport.ReportClose(_id, _adType, _adPlatform, _location, _seq, _entrance, _properties, _adMediation, _adMediationId);
                        break;
                    case "ReportClick":
                        DTAdReport.ReportClick(_id, _adType, _adPlatform, _location, _seq, _entrance, _properties, _adMediation, _adMediationId);
                        break;
                    case "ReportRewarded":
                        DTAdReport.ReportRewarded(_id, _adType, _adPlatform, _location, _seq, _entrance, _properties, _adMediation, _adMediationId);
                        break;
                    case "ReportLeftApp":
                        DTAdReport.ReportLeftApp(_id, _adType, _adPlatform, _location, _seq, _entrance, _properties, _adMediation, _adMediationId);
                        break;
                    case "ReportConversionByClick":
                        DTAdReport.ReportConversionByClick(_id, _adType, _adPlatform, _location, _seq, _entrance, _properties, _adMediation, _adMediationId);
                        break;
                    case "ReportConversionByLeftApp":
                        DTAdReport.ReportConversionByLeftApp(_id, _adType, _adPlatform, _location, _seq, _entrance, _properties, _adMediation, _adMediationId);
                        break;
                    case "ReportConversionByRewarded":
                        DTAdReport.ReportConversionByRewarded(_id, _adType, _adPlatform, _location, _seq, _entrance, _properties, _adMediation, _adMediationId);
                        break;
                    case "ReportPaid":
                         DTAdReport.ReportPaid(_id, _adType, _adPlatform, _location, _seq, _value, _currency, _precision, _entrance, _properties, _adMediation, _adMediationId);
                        break;
                    case "ReportPaid2":
                        DTAdReport.ReportPaid(_id, _adType, _adPlatform, _location, _seq, _adMediation, _adMediationId, _value, _precision, _country, _properties);
                        break;
                }
            });
        }
    }
}
