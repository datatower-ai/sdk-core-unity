using System;
using System.Linq;
using System.Reflection;
using DataTower.Core;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

namespace DataTower.Sample2
{
    public class AllApis : MonoBehaviour
    {
        private void Start()
        {
            GameObject.Find("Canvas/ButtonBack").GetComponent<Button>()
                .onClick.AddListener(delegate
                {
                    SceneManager.LoadSceneAsync("DataTower/Sample2/Home");
                });

            var textContainer = GameObject.Find("Canvas/Scroll View/Viewport/ContentText").GetComponent<TMP_Text>();

            textContainer.text = "DTAnalytics\n";
            textContainer.text += DumpMethodsFrom(typeof(DTAnalytics));
        
            textContainer.text += "\nDTAnalyticsUtils\n";
            textContainer.text += DumpMethodsFrom(typeof(DTAnalyticsUtils));
        
            textContainer.text += "\nDTAdReport\n";
            textContainer.text += DumpMethodsFrom(typeof(DTAdReport));
        
            textContainer.text += "\nDTIAPReport\n";
            textContainer.text += DumpMethodsFrom(typeof(DTIAPReport));
        
            textContainer.text += "\nDTIASReport\n";
            textContainer.text += DumpMethodsFrom(typeof(DTIASReport));
        }

        private string DumpMethodsFrom(Type type)
        {
            Debug.LogWarning($"DumpMethodsFrom, type: {type}");
            var daMethods = type.GetMethods(BindingFlags.Public | BindingFlags.Static);
            Debug.LogWarning($"DumpMethodsFrom, type: {type}, daMethods: {daMethods}");
            return daMethods.Aggregate("", (current, method) => current + $"{method.Name}\n");
        }
    }
}
