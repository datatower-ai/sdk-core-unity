using System;
using System.Collections.Generic;
using System.Linq;
using DataTower.Core;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.Double;

namespace DataTower.Sample2
{
    public class AdScene : MonoBehaviour
    {
        public Button buttonBack;
        public TMP_Dropdown dropdownApi;
        public TMP_InputField inputFieldId;
        public TMP_InputField inputFieldAdMediationId;
        public TMP_InputField inputFieldSeq;
        public TMP_InputField inputFieldLocation;
        public TMP_InputField inputFieldValue;
        public TMP_InputField inputFieldCurrency;
        public TMP_InputField inputFieldPrecision;
        public TMP_InputField inputFieldEntrance;
        public TMP_InputField inputFieldCountry;
        public TMP_InputField inputFieldErrorCode;
        public TMP_InputField inputFieldErrorMessage;
        public TMP_InputField inputFieldDuration;
        public TMP_InputField inputFieldProperties;
        public Toggle toggleProperties;
        public TMP_Dropdown adTypeDropdown;
        public TMP_Dropdown adPlatformDropdown;
        public TMP_Dropdown adMediationDropdown;
        public Toggle toggleResult;
        public Button buttonTrack;

        public RectTransform Bg;
        
        private List<UIBehaviour> _allParams()
        {
            return new()
            {
                inputFieldId,
                inputFieldAdMediationId,
                inputFieldSeq,
                inputFieldLocation,
                inputFieldValue,
                inputFieldCurrency,
                inputFieldPrecision,
                inputFieldEntrance,
                inputFieldCountry,
                inputFieldErrorCode,
                inputFieldErrorMessage,
                inputFieldDuration,
                inputFieldProperties,
                toggleProperties,
                adTypeDropdown,
                adPlatformDropdown,
                adMediationDropdown,
                toggleResult,
            };
        }

        private Dictionary<string, List<UIBehaviour>> _apis()
        {
            return new() {
                { "ReportLoadBegin", new List<UIBehaviour> { inputFieldId, adTypeDropdown, adPlatformDropdown, inputFieldSeq, inputFieldProperties, toggleProperties, adMediationDropdown, inputFieldAdMediationId } },
                { "ReportLoadEnd", new List<UIBehaviour> { inputFieldId, adTypeDropdown, adPlatformDropdown, inputFieldDuration, toggleResult, inputFieldSeq, inputFieldErrorCode, inputFieldErrorMessage, inputFieldProperties, toggleProperties, adMediationDropdown, inputFieldAdMediationId } },
                { "ReportToShow", new List<UIBehaviour> { inputFieldId, adTypeDropdown, adPlatformDropdown, inputFieldLocation, inputFieldSeq, inputFieldEntrance, inputFieldProperties, toggleProperties, adMediationDropdown, inputFieldAdMediationId } },
                { "ReportShow", new List<UIBehaviour> { inputFieldId, adTypeDropdown, adPlatformDropdown, inputFieldLocation, inputFieldSeq, inputFieldEntrance, inputFieldProperties, toggleProperties, adMediationDropdown, inputFieldAdMediationId } },
                { "ReportShowFailed", new List<UIBehaviour> { inputFieldId, adTypeDropdown, adPlatformDropdown, inputFieldLocation, inputFieldSeq, inputFieldErrorCode, inputFieldErrorMessage, inputFieldEntrance, inputFieldProperties, toggleProperties, adMediationDropdown, inputFieldAdMediationId } },
                { "ReportClose", new List<UIBehaviour> { inputFieldId, adTypeDropdown, adPlatformDropdown, inputFieldLocation, inputFieldSeq, inputFieldEntrance, inputFieldProperties, toggleProperties, adMediationDropdown, inputFieldAdMediationId } },
                { "ReportClick", new List<UIBehaviour> { inputFieldId, adTypeDropdown, adPlatformDropdown, inputFieldLocation, inputFieldSeq, inputFieldEntrance, inputFieldProperties, toggleProperties, adMediationDropdown, inputFieldAdMediationId } },
                { "ReportRewarded", new List<UIBehaviour> { inputFieldId, adTypeDropdown, adPlatformDropdown, inputFieldLocation, inputFieldSeq, inputFieldEntrance, inputFieldProperties, toggleProperties, adMediationDropdown, inputFieldAdMediationId } },
                { "ReportLeftApp", new List<UIBehaviour> { inputFieldId, adTypeDropdown, adPlatformDropdown, inputFieldLocation, inputFieldSeq, inputFieldEntrance, inputFieldProperties, toggleProperties, adMediationDropdown, inputFieldAdMediationId } },
                { "ReportConversionByClick", new List<UIBehaviour> { inputFieldId, adTypeDropdown, adPlatformDropdown, inputFieldLocation, inputFieldSeq, inputFieldEntrance, inputFieldProperties, toggleProperties, adMediationDropdown, inputFieldAdMediationId } },
                { "ReportConversionByLeftApp", new List<UIBehaviour> { inputFieldId, adTypeDropdown, adPlatformDropdown, inputFieldLocation, inputFieldSeq, inputFieldEntrance, inputFieldProperties, toggleProperties, adMediationDropdown, inputFieldAdMediationId } },
                { "ReportConversionByRewarded", new List<UIBehaviour> { inputFieldId, adTypeDropdown, adPlatformDropdown, inputFieldLocation, inputFieldSeq, inputFieldEntrance, inputFieldProperties, toggleProperties, adMediationDropdown, inputFieldAdMediationId } },
                { "ReportPaid", new List<UIBehaviour> { inputFieldId, adTypeDropdown, adPlatformDropdown, inputFieldLocation, inputFieldSeq, inputFieldValue, inputFieldCurrency, inputFieldPrecision, inputFieldEntrance, inputFieldProperties, toggleProperties, adMediationDropdown, inputFieldAdMediationId } },
                { "ReportPaid2", new List<UIBehaviour> { inputFieldId, adTypeDropdown, adPlatformDropdown, inputFieldLocation, inputFieldSeq, adMediationDropdown, inputFieldAdMediationId, inputFieldValue, inputFieldPrecision, inputFieldCountry, inputFieldProperties, toggleProperties } },
            };
        }
        
        private string _api = "ReportLoadBegin";

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
            AdaptiveUtil.UpdateSceneScale(Bg);
                
            buttonBack.onClick.AddListener(delegate
                {
                    SceneManager.LoadSceneAsync("DataTower/Sample2/Home");
                });

            RegisterInputField(inputFieldId, str => { _id = str; });
            RegisterInputField(inputFieldAdMediationId, str => { _adMediationId = str; });
            inputFieldAdMediationId.text = "";
            _adMediationId = "";
            RegisterInputField(inputFieldSeq, str => { _seq = str; });
            RegisterInputField(inputFieldLocation, str => { _location = str; });
            RegisterInputField(inputFieldValue, str => { TryParse(str, out _value); });
            RegisterInputField(inputFieldCurrency, str => { _currency = str; });
            RegisterInputField(inputFieldPrecision, str => { _precision = str; });
            RegisterInputField(inputFieldEntrance, str => { _entrance = str; });
            inputFieldEntrance.text = "";
            _entrance = "";
            RegisterInputField(inputFieldCountry, str => { _country = str; });
            RegisterInputField(inputFieldErrorCode, str => { int.TryParse(str, out _errorCode); });
            inputFieldErrorCode.text = "0";
            _errorCode = 0;
            RegisterInputField(inputFieldErrorMessage, str => { _errorMessage = str; });
            inputFieldErrorMessage.text = "";
            _errorMessage = "";
            RegisterInputField(inputFieldDuration, str => { long.TryParse(str, out _duration); });
            
            toggleResult.onValueChanged.AddListener(isOn =>
            {
                _result = isOn;
            });
            
            RegisterProperties();
            RegisterDropdowns();
            RegisterTrackButton();
            
            ShowGOs("ReportLoadBegin");

            var options = _apis().Keys.Select(key => new TMP_Dropdown.OptionData(key)).ToList();
            dropdownApi.options = options;
            dropdownApi.onValueChanged.AddListener(delegate
            {
                _api = options[dropdownApi.value].text;
                ShowGOs(_api);
            });
        }
    
        private void ShowGOs(string api)
        {
            foreach (var ui in _allParams())
            {
                ui.enabled = false;
            }

            foreach (var ui in _apis()[api])
            {
                ui.enabled = true;
            }
        }

        private static void RegisterInputField(TMP_InputField inputField, UnityAction<string> onChanged)
        {
            try
            {
                inputField.onValueChanged.AddListener(onChanged);
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }

        private void RegisterProperties()
        {
            inputFieldProperties.onValueChanged.AddListener(str =>
            {
                if (str.Length == 0) return;
                try
                {
                    _properties = (Dictionary<string, object>)Json.Deserialize(str);
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
        }

        private void RegisterDropdowns()
        {
            var adTypes = Enum.GetValues(typeof(AdType)).Cast<AdType>().ToList();
            var adTypesOptions = adTypes.Select(adType => new TMP_Dropdown.OptionData(adType.ToString())).ToList();
            adTypeDropdown.options = adTypesOptions;
            adTypeDropdown.value = 0;
            _adType = adTypes[0];
            adTypeDropdown.onValueChanged.AddListener(v =>
            {
                _adType = adTypes[v];
            });  

            var adPlatforms = Enum.GetValues(typeof(AdPlatform)).Cast<AdPlatform>().ToList();
            var adPlatformOptions = adPlatforms.Select(it => new TMP_Dropdown.OptionData(it.ToString())).ToList();
            adPlatformDropdown.options = adPlatformOptions;
            adPlatformDropdown.value = 0;
            _adPlatform = adPlatforms[0];
            adPlatformDropdown.onValueChanged.AddListener(v =>
            {
                _adPlatform = adPlatforms[v];
            });  

            var adMediations = Enum.GetValues(typeof(AdMediation)).Cast<AdMediation>().ToList();
            var adMediationOptions = adMediations.Select(it => new TMP_Dropdown.OptionData(it.ToString())).ToList();
            adMediationDropdown.options = adMediationOptions;
            var idx = adMediations.IndexOf(AdMediation.IDLE);
            adMediationDropdown.value = idx;
            _adMediation = adMediations[idx];
            adMediationDropdown.onValueChanged.AddListener(v =>
            {
                _adMediation = adMediations[v];
            });
        }

        private void RegisterTrackButton()
        {
            buttonTrack.onClick.AddListener(delegate
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
