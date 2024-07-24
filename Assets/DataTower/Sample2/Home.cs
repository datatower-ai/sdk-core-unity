using System;
using System.Collections.Generic;
using DataTower.Core;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DataTower.Sample2
{
    public class Home : MonoBehaviour
    {
        private TMP_Text _textDtId;
        private String _dtId;
        
        private void Start()
        {
            RegisterGetDtId();
            RegisterUserPropsGroup();
            RegisterEventTracking();
            RegisterUserTracking();
            RegisterOthers();
        }

        private void Update()
        {
            if (_dtId != null)
            {
                _textDtId.text = $"dt_id: {_dtId}";
            }
        }

        private void RegisterGetDtId()
        {
            var buttonGetDtId = GameObject.Find("Canvas/DtIdGroup/ButtonGetDtId").GetComponent<Button>();
            buttonGetDtId.onClick.AddListener(delegate
            {
                DTAnalytics.GetDataTowerId(id =>
                {
                    _dtId = id;
                });
            });

            _textDtId = GameObject.Find("Canvas/DtIdGroup/TextDtId").GetComponent<TMP_Text>();
        }

        private string _acid;
        private string _firebaseIId;
        private string _appsflyerId;
        private string _kochavaId;
        private string _adjustId;
        private void RegisterUserPropsGroup()
        {
            RegisterUserProps(
                "AcidGroup",
                value => { _acid = value; },
                delegate { DTAnalytics.SetAccountId(_acid); },
                delegate { DTAnalytics.SetAccountId(null); }
            );
            
            RegisterUserProps(
                "FirebaseGroup",
                value => { _firebaseIId = value; },
                delegate { DTAnalytics.SetFirebaseAppInstanceId(_firebaseIId); },
                delegate { DTAnalytics.SetFirebaseAppInstanceId(null); }
            );
            
            RegisterUserProps(
                "AppsflyerGroup",
                value => { _appsflyerId = value; },
                delegate { DTAnalytics.SetAppsFlyerId(_appsflyerId); },
                delegate { DTAnalytics.SetAppsFlyerId(null); }
            );
            
            RegisterUserProps(
                "KochavaGroup",
                value => { _kochavaId = value; },
                delegate { DTAnalytics.SetKochavaId(_kochavaId); },
                delegate { DTAnalytics.SetKochavaId(null); }
            );
            
            RegisterUserProps(
                "AdjustGroup",
                value => { _adjustId = value; },
                delegate { DTAnalytics.SetAdjustId(_adjustId); },
                delegate { DTAnalytics.SetAdjustId(null); }
            );
        }

        private static void RegisterUserProps(string group, Action<string> onValueUpdate, Action onSet, Action onClear)
        {
            var inputField = GameObject.Find($"Canvas/UserPropertiesGroup/{group}/InputField").GetComponent<TMP_InputField>();
            inputField.onValueChanged.AddListener(delegate { onValueUpdate(inputField.text); });

            var buttonSet = GameObject.Find($"Canvas/UserPropertiesGroup/{group}/ButtonSet").GetComponent<Button>();
            buttonSet.onClick.AddListener(delegate { onSet(); });

            var buttonClear = GameObject.Find($"Canvas/UserPropertiesGroup/{group}/ButtonClear").GetComponent<Button>();
            buttonClear.onClick.AddListener(delegate { onClear(); });
        } 
        
        private static void RegisterEventTracking()
        {
            GameObject.Find("Canvas/EventTrackingGroup/ButtonTrackSimpleEvent").GetComponent<Button>()
                .onClick.AddListener(delegate
                {
                    DTAnalytics.Track(
                        "dt_track_simple", 
                        new Dictionary<string, object>() 
                        {
                            { 
                                "property_object", 
                                new Dictionary<string, object>()
                                {
                                    { "hero_name", "刘备" },
                                    { "hero_level", 22 },
                                    { "hero_if_support", false },
                                    {
                                        "hero_equipment", 
                                        new List<string>() { "雌雄双股剑", "的卢" }
                                    },
                                    {
                                        "hero_sub_obj", 
                                        new Dictionary<string, object>()
                                        {
                                            { "hero_name", "刘备" },
                                            { "hero_level", 22 },
                                            { "hero_if_support", false },
                                            {
                                                "hero_equipment", 
                                                new List<string>() { "雌雄双股剑", "的卢" }
                                            },
                                            { "res_gold", 100.5 }
                                        }
                                    }
                                }
                                
                            }
                        }
                    );
                });

            GameObject.Find("Canvas/EventTrackingGroup/ButtonTrackEvent").GetComponent<Button>()
                .onClick.AddListener(delegate
                {
                    SceneManager.LoadSceneAsync("DataTower/Sample2/EventTrack");
                });
            
            GameObject.Find("Canvas/EventTrackingGroup/ButtonTrackTimedEvent").GetComponent<Button>()
                .onClick.AddListener(delegate
                {
                    SceneManager.LoadSceneAsync("DataTower/Sample2/TimedEventTrack");
                });
            
            GameObject.Find("Canvas/EventTrackingGroup/ButtonTrackAd").GetComponent<Button>()
                .onClick.AddListener(delegate
                {
                    SceneManager.LoadSceneAsync("DataTower/Sample2/AdScene");
                });
            
            GameObject.Find("Canvas/EventTrackingGroup/ButtonTrackIAP").GetComponent<Button>()
                .onClick.AddListener(delegate
                {
                    SceneManager.LoadSceneAsync("DataTower/Sample2/IapScene");
                });
            
            GameObject.Find("Canvas/EventTrackingGroup/ButtonTrackIAS").GetComponent<Button>()
                .onClick.AddListener(delegate
                {
                    SceneManager.LoadSceneAsync("DataTower/Sample2/IasScene");
                });
        }

        private static void RegisterUserTracking()
        {
            GameObject.Find("Canvas/UserTrackingGroup/ButtonTrackUser").GetComponent<Button>()
                .onClick.AddListener(delegate
                {
                    SceneManager.LoadSceneAsync("DataTower/Sample2/UserTrack");
                });
        }

        private static void RegisterOthers()
        {
            GameObject.Find("Canvas/OthersGroup/ButtonCommonProperties").GetComponent<Button>()
                .onClick.AddListener(delegate
                {
                    SceneManager.LoadSceneAsync("DataTower/Sample2/CommonProperty");
                });
            
            GameObject.Find("Canvas/OthersGroup/ButtonEnableUpload").GetComponent<Button>()
                .onClick.AddListener(DTAnalytics.EnableUpload);
            
            GameObject.Find("Canvas/OthersGroup/ButtonAllApis").GetComponent<Button>()
                .onClick.AddListener(delegate
                {
                    SceneManager.LoadSceneAsync("DataTower/Sample2/AllApis");
                });
        }
    }
}
