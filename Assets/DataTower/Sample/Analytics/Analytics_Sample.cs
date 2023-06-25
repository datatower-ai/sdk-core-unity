using System.Collections.Generic;
using DataTower;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Analytics_Sample : MonoBehaviour
{
    public Button[] buttons2;


    // Start is called before the first frame update
    private void Awake()
    {
        print("sample awake====");


        buttons2[0].onClick.AddListener(delegate
        {
            DTAnalytics.GetDataTowerId(
                id =>
                {
                    var dictionary = new Dictionary<string, object>();

                    dictionary.Add("login_pro_1", "中国");
                    dictionary.Add("roq_id", id);

                    var list = new List<int>();
                    list.Add(1);
                    list.Add(2);
                    list.Add(3);
                    dictionary.Add("list", list);

                    print("Track an Event.");
                    DTAnalytics.Track("test", dictionary);
                }
                );

        });
        buttons2[1].onClick.AddListener(delegate { DTAnalytics.SetAccountId("user_account_id_2200"); });
        buttons2[2].onClick.AddListener(delegate { DTAnalytics.SetFirebaseAppInstanceId("fire_base_id_2200"); });
        buttons2[3].onClick.AddListener(delegate { DTAnalytics.SetAppsFlyerId("appsFlyer_id_2200"); });
        buttons2[4].onClick.AddListener(delegate { DTAnalytics.SetKochavaId("kochava_id_2200"); });
        buttons2[5].onClick.AddListener(delegate
        {
            print("buttons2[5]====");
            DTAnalytics.SetAdjustId("adjust_id");
        });

        buttons2[6].onClick.AddListener(delegate { SceneManager.LoadSceneAsync("Sample"); });
    }
}