using System.Collections.Generic;
using ROIQuery;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ROIQuerySDK.Sample.USER_SET
{
    public class User_Set_Sample : MonoBehaviour
    {
        public Button[] buttons1;


        // Start is called before the first frame update
        private void Awake()
        {
            print("sample awake====");

            buttons1[0].onClick.AddListener(delegate
            {
                print("UserSet---");
                var dictionary = new Dictionary<string, object>();

                dictionary.Add("country", "中国");
                dictionary.Add("course", "history");
                dictionary.Add("user_password", "12138");
                ROIQueryAnalytics.UserSet(dictionary);
            });
            buttons1[1].onClick.AddListener(delegate
                {
                    print("UserSetOnce---");
                    var dictionary = new Dictionary<string, object>();
                    dictionary.Add("USER_FIRST_LOGIN", "2021-0908");
                    ROIQueryAnalytics.UserSetOnce(dictionary);
                }
            );
            var timesOfLogin = 0;
            buttons1[2].onClick.AddListener(delegate
            {
                print("UserAdd---");
                var dictionary = new Dictionary<string, object>();
                timesOfLogin += 1;
                dictionary.Add("user_login_times", timesOfLogin);
                ROIQueryAnalytics.UserAdd(dictionary);
            });
            buttons1[3].onClick.AddListener(delegate
            {
                print("UserUnset---");
                ROIQueryAnalytics.UserUnset("user_password");
            });

            buttons1[4].onClick.AddListener(delegate
            {
                print("UserDelete---");
                ROIQueryAnalytics.UserDelete();
            });

            buttons1[5].onClick.AddListener(delegate
            {
                print("UserAppend---");
                var dictionary = new Dictionary<string, object>();

                dictionary.Add("course", "english");
                ROIQueryAnalytics.UserAppend(dictionary);
            });

            buttons1[6].onClick.AddListener(delegate
            {
                print("Sample---");
                SceneManager.LoadSceneAsync("Sample");
            });
        }
    }
}