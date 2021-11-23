

using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using ROIQuery;
using UnityEngine.SceneManagement;

public class Analytics_Sample : MonoBehaviour
{




    public Button[] buttons2;
    

    // Start is called before the first frame update
    void Awake()
    {
        print("sample awake====");

        
        buttons2[0].onClick.AddListener(delegate {
            // DateTime dateTime = DateTime.Now;

            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            dictionary.Add("login_pro_1", "中国");
            // dictionary.Add("login_pro_2", dateTime);

            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            dictionary.Add("list", list);

            print("Track an Event.");
            ROIQueryAnalytics.Track("test",dictionary);

        });
        buttons2[1].onClick.AddListener(delegate {

            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("page_open_pro1", "1");
            dictionary.Add("page_open_pro2", "2");

            print("Track TrackPageOpen Event.");
            ROIQueryAnalytics.TrackPageOpen(dictionary);

        });
        buttons2[2].onClick.AddListener(delegate {

            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("page_close_pro1", "1");
            dictionary.Add("page_close_pro2", "2");

            print("Track TrackPageClose Event.");
            ROIQueryAnalytics.SetAppsFlyerId("afid12344");
            ROIQueryAnalytics.TrackPageClose(dictionary);

        });
        buttons2[3].onClick.AddListener(delegate {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("app_close_pro1", "1");
            dictionary.Add("app_close_pro2", "2");

            print("Track TrackAppClose Event.");
            ROIQueryAnalytics.SetKochavaId("koid43543");
            ROIQueryAnalytics.TrackAppClose(dictionary);

        });
        buttons2[4].onClick.AddListener(delegate {

            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("user_name", "huazai");
            dictionary.Add("user_money", 3200.98);

            print("set user properties Event.");
            ROIQueryAnalytics.SetUserProperties(dictionary);

        });
        buttons2[5].onClick.AddListener(delegate {
            ROIQueryAnalytics.Flush();

        });

        buttons2[6].onClick.AddListener(delegate {
            SceneManager.LoadSceneAsync("Sample");

        });



    }





}
