using System;
using System.Collections.Generic;
using DataTower.Core;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DataTower.Sample2
{
    public static class CommonPropertyHolder
    {
        public static Dictionary<string, object> dynamicProps = null;
        public static Dictionary<string, object> staticProps = null;
    }
    
    public class CommonProperty : MonoBehaviour
    {
        
        private void Start()
        {
            GameObject.Find("Canvas/ButtonBack").GetComponent<Button>()
                .onClick.AddListener(delegate
                {
                    SceneManager.LoadSceneAsync("DataTower/Sample2/Home");
                });
            
            RegisterGroup(
                "DynamicGroup", 
                CommonPropertyHolder.dynamicProps,
                s => CommonPropertyHolder.dynamicProps = (Dictionary<string, object>) Json.Deserialize(s),
                delegate { DTAnalytics.SetDynamicCommonProperties(() => CommonPropertyHolder.dynamicProps); },
                delegate
                {
                    DTAnalytics.ClearDynamicCommonProperties();
                    CommonPropertyHolder.dynamicProps = null;
                }
            );
            
            RegisterGroup(
                "StaticGroup", 
                CommonPropertyHolder.staticProps,
                s => CommonPropertyHolder.staticProps = (Dictionary<string, object>) Json.Deserialize(s),
                delegate { DTAnalytics.SetStaticCommonProperties(CommonPropertyHolder.staticProps); },
                delegate
                {
                    DTAnalytics.ClearStaticCommonProperties();
                    CommonPropertyHolder.staticProps = null;
                }
            );
        }

        private static void RegisterGroup(
            string group, 
            Dictionary<string, object> init, 
            Action<string> onValueUpdate, 
            Action onSet, 
            Action onClear
        ) {
            var inputField = GameObject.Find($"Canvas/{group}/InputField").GetComponent<TMP_InputField>();
            inputField.onValueChanged.AddListener(delegate { onValueUpdate(inputField.text); });
            if (init != null)
            {
                inputField.text = Json.Serialize(init);
            }

            var buttonSet = GameObject.Find($"Canvas/{group}/ButtonSet").GetComponent<Button>();
            buttonSet.onClick.AddListener(delegate { onSet(); });

            var buttonClear = GameObject.Find($"Canvas/{group}/ButtonClear").GetComponent<Button>();
            buttonClear.onClick.AddListener(delegate { onClear(); });
        }
    }
}
