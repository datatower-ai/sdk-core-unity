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

namespace DataTower.Sample2
{
    public class IasScene : MonoBehaviour
    {
        public Button buttonBack;
        public TMP_Dropdown dropdownApi;
        public Button buttonTrack;
        
        public TMP_InputField inputFieldProperties;
        public Toggle toggleProperties;
        public TMP_InputField inputFieldOriginalOrderId;
        public TMP_InputField inputFieldOrderId;
        public TMP_InputField inputFieldSku;
        public TMP_InputField inputPrice;
        public TMP_InputField inputCurrency;

        private List<UIBehaviour> _allParams()
        {
            return new()
            {
                inputFieldOriginalOrderId, inputFieldOrderId, inputFieldSku, inputPrice, inputCurrency, inputFieldProperties, toggleProperties
            };
        }

        private Dictionary<string, List<UIBehaviour>> _apis()
        {
            return new()
            {
                {
                    "ReportSubscribeSuccess",
                    new List<UIBehaviour> { inputFieldOriginalOrderId, inputFieldOrderId, inputFieldSku, inputPrice, inputCurrency, inputFieldProperties, toggleProperties }
                }
            };
        }

        private string _api = "ReportSubscribeSuccess";

        private string _originalOrderId;
        private string _orderId;
        private string _sku;
        private double _price;
        private string _currency;
        private Dictionary<string, object> _properties;
        
        private void Start()
        {
            buttonBack.onClick.AddListener(delegate
                {
                    SceneManager.LoadSceneAsync("DataTower/Sample2/Home");
                });
            
            RegisterInputField(inputFieldOriginalOrderId, it => { _originalOrderId = it; });
            RegisterInputField(inputFieldOrderId, it => { _orderId = it; });
            RegisterInputField(inputFieldSku, it => { _sku = it; });
            RegisterInputField(inputPrice, it => { double.TryParse(it, out _price); });
            RegisterInputField(inputCurrency, it => { _currency = it; });
            
            RegisterProperties();
            RegisterTrackButton();
            
            ShowGOs(_api);
            
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

        private void RegisterTrackButton()
        {
            buttonTrack.onClick.AddListener(delegate
            {
                switch (_api)
                {
                    case "ReportSubscribeSuccess": 
                        DTIASReport.ReportSubscribeSuccess(_originalOrderId, _orderId, _sku, _price, _currency, _properties);
                        break;
                }
            });
        }
    }
}
