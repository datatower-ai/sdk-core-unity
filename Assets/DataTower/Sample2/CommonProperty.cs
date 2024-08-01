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
        public Button buttonBack;
        public TMP_InputField inputFieldDynProperties;
        public Button buttonDynSet;
        public Button buttonDynClear;
        public TMP_InputField inputFieldStaProperties;
        public Button buttonStaSet;
        public Button buttonStaClear;
        
        private void Start()
        {
            buttonBack.onClick.AddListener(delegate
                {
                    SceneManager.LoadSceneAsync("DataTower/Sample2/Home");
                });
            
            RegisterGroup(
                inputFieldDynProperties, buttonDynSet, buttonDynClear, 
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
                inputFieldStaProperties, buttonStaSet, buttonStaClear, 
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
            TMP_InputField inputField,
            Button buttonSet,
            Button buttonClear,
            Dictionary<string, object> init, 
            Action<string> onValueUpdate, 
            Action onSet, 
            Action onClear
        ) {
            inputField.onValueChanged.AddListener(delegate { onValueUpdate(inputField.text); });
            if (init != null)
            {
                inputField.text = Json.Serialize(init);
            }

            buttonSet.onClick.AddListener(delegate { onSet(); });

            buttonClear.onClick.AddListener(delegate { onClear(); });
        }
    }
}
