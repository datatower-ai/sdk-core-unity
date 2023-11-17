using System.Collections.Generic;
using DataTower.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Utils_Sample : MonoBehaviour
{
    public Button[] buttons1;


    // Start is called before the first frame update
    private void Awake()
    {
        print("sample awake====");


        const string eventName = "test_for_timer";
        var dictionary = new Dictionary<string, object> { { "country", "中国" } };

        DTAnalytics.GetDataTowerId(id =>
        {
            dictionary.Add("roq_id", id);
        });
        buttons1[0].onClick.AddListener(delegate
        {
            print("trackTimerStart====");
            DTAnalyticsUtils.TrackTimerStart(eventName);
        });
        buttons1[1].onClick.AddListener(delegate { DTAnalyticsUtils.TrackTimerPause(eventName); });
        buttons1[2].onClick.AddListener(delegate { DTAnalyticsUtils.TrackTimerResume(eventName); });
        buttons1[3].onClick.AddListener(delegate { DTAnalyticsUtils.TrackTimerEnd(eventName, dictionary); });

        buttons1[4].onClick.AddListener(delegate { SceneManager.LoadSceneAsync("Sample"); });
    }
}