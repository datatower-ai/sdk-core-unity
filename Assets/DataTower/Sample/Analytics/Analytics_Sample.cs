using System.Collections.Generic;
using DataTower.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using Button = UnityEngine.UI.Button;

public class Analytics_Sample : MonoBehaviour
{
    public Button[] buttons2;

    private static Dictionary<string, object> _dynamicCommonProps = new Dictionary<string, object>
    {
        { "dynamic_props_number", 0 },
        { "dynamic_props_text", "dynamic!" }
    };


    // Start is called before the first frame update
    private void Awake()
    {
        print("sample awake====");


        buttons2[0].onClick.AddListener(delegate
        {
            DTAnalytics.GetDataTowerId(
                id =>
                {
                    var dictionary = new Dictionary<string, object>
                    {
                        { "login_pro_1", "中国" },
                        { "roq_id", id }
                    };

                    var list = new List<int>
                    {
                        1,
                        2,
                        3
                    };
                    dictionary.Add("list", list);
                    dictionary.Add("number", 1);

                    print("Track an Event. (after GetDataTowerId)");
                    DTAnalytics.Track("test", dictionary);
                }
                );

            var dictionary = new Dictionary<string, object> { { "login_pro_1", "中国" } };
            var list = new List<int>
            {
                1,
                2,
                3
            };
            dictionary.Add("list", list);
            print("Track an Event.");
            DTAnalytics.Track("test2", dictionary);
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
        
        buttons2[6].onClick.AddListener(delegate { 
            DTAnalytics.SetDistinctId("distinct_id_2222"); 
        });
        buttons2[7].onClick.AddListener(delegate { 
            var props = new Dictionary<string, object>
            {
                { "static_props_1", "Book" },
                { "static_props_2", 123 },
                { "static_props_3", 20.1 },
                { "static_props_4", new Dictionary<string, object>{{ "static_props_4_sub", 1001 }} },
                { "static_props_5", new List<string>{ "1_ssp5", "2_ssp6", "3_sss8" } },
            };
            DTAnalytics.SetStaticCommonProperties(props); 
        });
        buttons2[8].onClick.AddListener(DTAnalytics.ClearStaticCommonProperties);
        buttons2[9].onClick.AddListener(delegate { 
            DTAnalytics.SetDynamicCommonProperties(() => _dynamicCommonProps); 
        });
        buttons2[10].onClick.AddListener(DTAnalytics.ClearDynamicCommonProperties);
        buttons2[11].onClick.AddListener(delegate
        {
            object number = _dynamicCommonProps["dynamic_props_number"];
            if (number is int num)
            {
                _dynamicCommonProps["dynamic_props_number"] = num + 1;
            }
        });
        buttons2[12].onClick.AddListener(delegate { 
            object number = _dynamicCommonProps["dynamic_props_number"];
            if (number is int num)
            {
                _dynamicCommonProps["dynamic_props_number"] = num - 1;
            }
        });

        buttons2[13].onClick.AddListener(delegate { SceneManager.LoadSceneAsync("Sample"); });
    }
}