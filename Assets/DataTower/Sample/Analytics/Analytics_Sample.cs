using System.Collections.Generic;
using DataTower.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using Button = UnityEngine.UI.Button;

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

            new Test().TestEvent();
        });
        buttons2[1].onClick.AddListener(delegate
        {
            if (ConfigMgr.IsReportNullData)
            {
                DTAnalytics.SetAccountId(null);
            }
            else
            {
                DTAnalytics.SetAccountId("user_account_id_2200");
            }
        });
        buttons2[2].onClick.AddListener(delegate
        {
            if (ConfigMgr.IsReportNullData)
            {
                DTAnalytics.SetFirebaseAppInstanceId(null);
            }
            else
            {
                DTAnalytics.SetFirebaseAppInstanceId("fire_base_id_2200");
            }
        });
        buttons2[3].onClick.AddListener(delegate
        {
            if (ConfigMgr.IsReportNullData)
            {
                DTAnalytics.SetAppsFlyerId(null);
            }
            else
            {
                DTAnalytics.SetAppsFlyerId("appsFlyer_id_2200");
            }
        });
        buttons2[4].onClick.AddListener(delegate
        {
            if (ConfigMgr.IsReportNullData)
            {
                DTAnalytics.SetKochavaId(null);
            }
            else
            {
                DTAnalytics.SetKochavaId("kochava_id_2200");
            }
        });

        buttons2[5].onClick.AddListener(delegate
        {
            print("buttons2[5]====");
            if (ConfigMgr.IsReportNullData)
            {
                DTAnalytics.SetAdjustId(null);
            }
            else
            {
                DTAnalytics.SetAdjustId("adjust_id");
            }
        });

        buttons2[6].onClick.AddListener(delegate { SceneManager.LoadSceneAsync("Sample"); });
    }
}

public class Test
{
    public void TestEvent()
    {
        List<object> lst2 = new List<object>
        {
            new TestOnlyObj
            {
                ID = 1, Name = "test", Value = 1.9
            }.ToDictionary(),
            new TestOnlyObj
            {
                ID = 2, Name = "test 2", Value = 2.8
            }.ToDictionary()
        };
        Dictionary<string, object> dic2 = new Dictionary<string, object>
        {
            { "obj_test", lst2.ToArray() },
            { "another_prop", true },
            { "third_prop", "I'm good" }
        };
        DTAnalytics.Track("TEST_OBJ_DICT", dic2);


        List<object> lst = new List<object>
        {
            new TestOnlyObj
            {
                ID = 1, Name = "test", Value = 1.9
            },
            new TestOnlyObj
            {
                ID = 2, Name = "test 2", Value = 2.8
            }
        };
        Dictionary<string, object> dic = new Dictionary<string, object>
        {
            { "obj_test", lst.ToArray() },
            { "another_prop", true },
            { "third_prop", "I'm good" }
        };
        DTAnalytics.Track("TEST_OBJ", dic);

        DTAnalytics.Track("TEST_OBJ_null", null);

        DTAnalytics.Track(null, null);
    }
}

public class TestOnlyObj
{
    public int ID;
    public string Name;
    public double Value;

    public Dictionary<string, object> ToDictionary()
    {
        return new Dictionary<string, object>{
            { "id", ID },
            { "name", Name },
            { "value", Value }
        };
    }
}