using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using DataTower;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
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
                    var dictionary = new Dictionary<string, object>();

                    dictionary.Add("login_pro_1", "中国");
                    dictionary.Add("roq_id", id);

                    var list = new List<int>();
                    list.Add(1);
                    list.Add(2);
                    list.Add(3);
                    dictionary.Add("list", list);
                    dictionary.Add("number", 1);

                    print("Track an Event. (after GetDataTowerId)");
                    DTAnalytics.Track("test", dictionary);
                }
                );

            var dictionary = new Dictionary<string, object>();
            dictionary.Add("login_pro_1", "中国");
            var list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            dictionary.Add("list", list);
            print("Track an Event.");
            DTAnalytics.Track("test2", dictionary);

            new Test().TestEvent();
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

public class Test
{
    public void TestEvent()
    {
        List<object> lst = new List<object>();
        lst.Add(new TestOnlyObj()
        {
            id = 1, name = "test", value = 1.9
        });
        lst.Add(new TestOnlyObj()
        {
            id = 2, name = "test 2", value = 2.8
        });
        Dictionary<string, object> dic = new Dictionary<string, object>();
        dic.Add("obj_test", lst.ToArray());
        dic.Add("another_prop", true);
        dic.Add("third_prop", "I'm good");
        DTAnalytics.Track("TEST_OBJ", dic);
        
        List<object> lst2 = new List<object>();
        lst2.Add(new TestOnlyObj()
        {
            id = 1, name = "test", value = 1.9
        }.ToDictionary());
        lst2.Add(new TestOnlyObj()
        {
            id = 2, name = "test 2", value = 2.8
        }.ToDictionary());
        Dictionary<string, object> dic2 = new Dictionary<string, object>();
        dic2.Add("obj_test", lst2.ToArray());
        dic2.Add("another_prop", true);
        dic2.Add("third_prop", "I'm good");
        DTAnalytics.Track("TEST_OBJ_DICT", dic2);
    }
}

public class TestOnlyObj
{
    public int id;
    public string name;
    public double value;

    public Dictionary<string, object> ToDictionary()
    {
        return new Dictionary<string, object>(){
            { "id", id },
            { "name", name },
            { "value", value }
        };
    }
}