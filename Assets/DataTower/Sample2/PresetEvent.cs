using System.Collections;
using System.Collections.Generic;
using DataTower.Core;
using DataTower.Sample2;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PresetEvent : MonoBehaviour
{

    public Button buttonBack;
    public RectTransform Bg;
        
    public Toggle toggleAppInstall;
        
    public Toggle toggleSessionStart;
        
    public Toggle toggleSessionEnd;

    public static bool isAppInstallEnabled = true; 
    public static bool isSessionStartEnabled = true; 
    public static bool isSessionEndEnabled = true; 
    
    // Start is called before the first frame update
    void Start()
    {
        AdaptiveUtil.UpdateSceneScale(Bg);

        buttonBack.onClick.AddListener(delegate
        {
            SceneManager.LoadSceneAsync("DataTower/Sample2/Home");
        });

        toggleAppInstall.isOn = isAppInstallEnabled;
        toggleAppInstall.onValueChanged.AddListener(delegate {
            isAppInstallEnabled = toggleAppInstall.isOn;
            if (toggleAppInstall.isOn)
            {
                DTAnalytics.EnableAutoTrack(DTPresetEvent.Install);
            }
            else
            {
                DTAnalytics.DisableAutoTrack(DTPresetEvent.Install);
            }
        });

        toggleSessionStart.isOn = isSessionStartEnabled;
        toggleSessionStart.onValueChanged.AddListener(delegate
        {
            isSessionStartEnabled = toggleSessionStart.isOn;
            if (toggleSessionStart.isOn)
            {
                DTAnalytics.EnableAutoTrack(DTPresetEvent.SessionStart);
            }
            else
            {
                DTAnalytics.DisableAutoTrack(DTPresetEvent.SessionStart);
            }
        });

        toggleSessionEnd.isOn = isSessionEndEnabled;
        toggleSessionEnd.onValueChanged.AddListener(delegate { 
            isSessionEndEnabled = toggleSessionEnd.isOn;
            if (toggleSessionEnd.isOn)
            {
                DTAnalytics.EnableAutoTrack(DTPresetEvent.SessionEnd);
            }
            else
            {
                DTAnalytics.DisableAutoTrack(DTPresetEvent.SessionEnd);
            }
        });
    }
}
