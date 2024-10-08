﻿using DataTower.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Sample : MonoBehaviour
{
    public Button[] buttons1;

    public Toggle _toggle;

    // Start is called before the first frame update
    private void Awake()
    {
        print("sample awake====");

        buttons1[0].onClick.AddListener(delegate { SceneManager.LoadSceneAsync("Analytics_Sample"); });
        buttons1[1].onClick.AddListener(delegate { SceneManager.LoadSceneAsync("IAS_Sample"); });
        buttons1[2].onClick.AddListener(delegate { SceneManager.LoadSceneAsync("Ad_Sample"); });
        buttons1[3].onClick.AddListener(delegate { SceneManager.LoadSceneAsync("IAP_Sample"); });

        buttons1[4].onClick.AddListener(delegate
        {
            SceneManager.LoadSceneAsync("Utils_Sample");
        });
        buttons1[5].onClick.AddListener(delegate { SceneManager.LoadSceneAsync("User_Set_Sample"); });
        buttons1[6].onClick.AddListener(DTAnalytics.EnableUpload);
        
        if (_toggle != null)
        {
            _toggle.onValueChanged.AddListener(delegate
            {
                ConfigMgr.IsReportNullData = _toggle.isOn;
            });

            _toggle.isOn = ConfigMgr.IsReportNullData;
        }
    }

    void OnEnable()
    {
        if (_toggle != null)
        {
            _toggle.isOn = ConfigMgr.IsReportNullData;
        }
    }
}