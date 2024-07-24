using System;
using System.Collections.Generic;
using System.Linq;
using DataTower.Core;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DataTower.Sample2
{
    public class IapScene : MonoBehaviour
    {
        private readonly List<string> _allParams = new()
        {
            "Order", "Sku", "Price", "Currency", "Properties"
        };
        private readonly Dictionary<string, List<string>> _apis = new ()
        {
            { "ReportPurchaseSuccess", new List<string> { "Order", "Sku", "Price", "Currency", "Properties" } }
        };
        private string _api = "ReportPurchaseSuccess";
        private Dictionary<string, GameObject> _gameObjects = new ();

        private string _order;
        private string _sku;
        private double _price;
        private string _currency;
        private Dictionary<string, object> _properties;
        
        private void Start()
        {
            GameObject.Find("Canvas/ButtonBack").GetComponent<Button>()
                .onClick.AddListener(delegate
                {
                    SceneManager.LoadSceneAsync("DataTower/Sample2/Home");
                });
            
            RegisterInputField("Order", it => { _order = it; });
            RegisterInputField("Sku", it => { _sku = it; });
            RegisterInputField("Price", it => { double.TryParse(it, out _price); });
            RegisterInputField("Currency", it => { _currency = it; });
            
            RegisterProperties();
            RegisterTrackButton();
            
            ShowGOs(_api);
            
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

        private void RegisterTrackButton()
        {
            GameObject.Find("Canvas/ButtonTrack").GetComponent<Button>().onClick.AddListener(delegate
            {
                switch (_api)
                {
                    case "ReportPurchaseSuccess": 
                        DTIAPReport.ReportPurchaseSuccess(_order, _sku, _price, _currency, _properties);
                        break;
                }
            });
        }
    }
}
