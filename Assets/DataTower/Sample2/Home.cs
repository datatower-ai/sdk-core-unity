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
        public Button buttonGetDtId;
        public TMP_Text textDtId;
        public TMP_InputField inputFieldAcid;
        public Button buttonAcidSet;
        public Button buttonAcidClear;
        public TMP_InputField inputFieldFirebaseiid;
        public Button buttonFirebaseiidSet;
        public Button buttonFirebaseiidClear;
        public TMP_InputField inputFieldAppflyerId;
        public Button buttonAppflyerIdSet;
        public Button buttonAppflyerIdClear;
        public TMP_InputField inputFieldKochavaId;
        public Button buttonKochavaIdSet;
        public Button buttonKochavaIdClear;
        public TMP_InputField inputFieldAdjustId;
        public Button buttonAdjustIdSet;
        public Button buttonAdjustIdClear;

        public Button buttonTrackSimpleEvent;
        public Button buttonTrackEvent;
        public Button buttonTrackTimedEvent;
        public Button buttonTrackAd;
        public Button buttonTrackIap;
        public Button buttonTrackIas;
        public Button buttonTrackUser;
        public Button buttonCommonProperties;
        public Button buttonEnableUpload;
        public Button buttonAllApis;

        public RectTransform Bg;

        public CanvasScaler BgScale;

        private String _dtId;

        private void Start()
        {
            AdaptiveUtil.UpdateSceneScale(Bg);

            AdaptiveUtil.UpdateCanvasScale(BgScale);

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
                textDtId.text = $"dt_id: {_dtId}";
            }
        }

        private void RegisterGetDtId()
        {
            buttonGetDtId.onClick.AddListener(delegate
            {
                DTAnalytics.GetDataTowerId(id =>
                {
                    _dtId = id;
                });
            });
        }

        private string _acid;
        private string _firebaseIId;
        private string _appsflyerId;
        private string _kochavaId;
        private string _adjustId;
        private void RegisterUserPropsGroup()
        {
            RegisterUserProps(
                inputFieldAcid, buttonAcidSet, buttonAcidClear,
                value => { _acid = value; },
                delegate { DTAnalytics.SetAccountId(_acid); },
                delegate { DTAnalytics.SetAccountId(null); }
            );

            RegisterUserProps(
                inputFieldFirebaseiid, buttonFirebaseiidSet, buttonFirebaseiidClear,
                value => { _firebaseIId = value; },
                delegate { DTAnalytics.SetFirebaseAppInstanceId(_firebaseIId); },
                delegate { DTAnalytics.SetFirebaseAppInstanceId(null); }
            );

            RegisterUserProps(
                inputFieldAppflyerId, buttonAppflyerIdSet, buttonAppflyerIdClear,
                value => { _appsflyerId = value; },
                delegate { DTAnalytics.SetAppsFlyerId(_appsflyerId); },
                delegate { DTAnalytics.SetAppsFlyerId(null); }
            );

            RegisterUserProps(
                inputFieldKochavaId, buttonKochavaIdSet, buttonKochavaIdClear,
                value => { _kochavaId = value; },
                delegate { DTAnalytics.SetKochavaId(_kochavaId); },
                delegate { DTAnalytics.SetKochavaId(null); }
            );

            RegisterUserProps(
                inputFieldAdjustId, buttonAdjustIdSet, buttonAdjustIdClear,
                value => { _adjustId = value; },
                delegate { DTAnalytics.SetAdjustId(_adjustId); },
                delegate { DTAnalytics.SetAdjustId(null); }
            );
        }

        private void RegisterUserProps(TMP_InputField inputField, Button buttonSet, Button buttonClear, Action<string> onValueUpdate, Action onSet, Action onClear)
        {
            inputField.onValueChanged.AddListener(delegate { onValueUpdate(inputField.text); });
            buttonSet.onClick.AddListener(delegate { onSet(); });
            buttonClear.onClick.AddListener(delegate { onClear(); });
        }

        private void RegisterEventTracking()
        {
            buttonTrackSimpleEvent.onClick.AddListener(delegate
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

            buttonTrackEvent.onClick.AddListener(delegate
                {
                    SceneManager.LoadSceneAsync("DataTower/Sample2/EventTrack");
                });

            buttonTrackTimedEvent.onClick.AddListener(delegate
                {
                    SceneManager.LoadSceneAsync("DataTower/Sample2/TimedEventTrack");
                });

            buttonTrackAd.onClick.AddListener(delegate
                {
                    SceneManager.LoadSceneAsync("DataTower/Sample2/AdScene");
                });

            buttonTrackIap.onClick.AddListener(delegate
                {
                    SceneManager.LoadSceneAsync("DataTower/Sample2/IapScene");
                });

            buttonTrackIas.onClick.AddListener(delegate
                {
                    SceneManager.LoadSceneAsync("DataTower/Sample2/IasScene");
                });
        }

        private void RegisterUserTracking()
        {
            buttonTrackUser.onClick.AddListener(delegate
                {
                    SceneManager.LoadSceneAsync("DataTower/Sample2/UserTrack");
                });
        }

        private void RegisterOthers()
        {
            buttonCommonProperties.onClick.AddListener(delegate
                {
                    SceneManager.LoadSceneAsync("DataTower/Sample2/CommonProperty");
                });

            buttonEnableUpload.onClick.AddListener(DTAnalytics.EnableUpload);

            buttonAllApis.onClick.AddListener(delegate
                {
                    SceneManager.LoadSceneAsync("DataTower/Sample2/AllApis");
                });
        }
    }
}
