using System;
using System.Collections.Generic;
using DataTower.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DataTower.Sample.USER_SET
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
                var dictionary = new Dictionary<string, object>
                {
                    { "country", "中国" },
                    { "course", "history" },
                    { "user_password", "12138" },
                    { "user_null", null }
                };

                if (ConfigMgr.IsReportNullData)
                {
                    DTAnalytics.UserSet(null);
                }
                else
                {
                    DTAnalytics.UserSet(dictionary);
                }
            });
            buttons1[1].onClick.AddListener(delegate
                {
                    print("UserSetOnce---");
                    if (ConfigMgr.IsReportNullData)
                    {
                        DTAnalytics.UserSetOnce(null);
                    }
                    else
                    {
                        var dictionary = new Dictionary<string, object>();
                        dictionary.Add("USER_FIRST_LOGIN", "2021-0908");
                        DTAnalytics.UserSetOnce(dictionary);
                    }
                }
            );
            var timesOfLogin = 0;
            buttons1[2].onClick.AddListener(delegate
            {
                print("UserAdd---");
                if (ConfigMgr.IsReportNullData)
                {
                    DTAnalytics.UserAdd(null);
                }
                else
                {
                    var dictionary = new Dictionary<string, object>();
                    timesOfLogin += 1;
                    dictionary.Add("user_login_times", timesOfLogin);
                    DTAnalytics.UserAdd(dictionary);
                }
            });
            buttons1[3].onClick.AddListener(delegate
            {
                print("UserUnset---");

                if (ConfigMgr.IsReportNullData)
                {
                    DTAnalytics.UserUnset((String)null);
                    DTAnalytics.UserUnset((List<string>)null);
                }
                else
                {
                    DTAnalytics.UserUnset("user_password");
                }
            });

            buttons1[4].onClick.AddListener(delegate
            {
                print("UserDelete---");
                DTAnalytics.UserDelete();
            });

            buttons1[5].onClick.AddListener(delegate
            {
                print("UserAppend---");
                if (ConfigMgr.IsReportNullData)
                {
                    DTAnalytics.UserAppend(null);
                }
                else
                {
                    var dictionary = new Dictionary<string, object>();
                    var lst = new List<string>(1);
                    lst.Add("english");
                    dictionary.Add("course", lst);
                    DTAnalytics.UserAppend(dictionary);
                }
            });

            buttons1[6].onClick.AddListener(delegate
            {
                print("UserUniqAppend---");

                if (ConfigMgr.IsReportNullData)
                {
                    DTAnalytics.UserUniqAppend(null);
                }
                else
                {
                    var dictionary = new Dictionary<string, object>();
                    var lst = new List<string>(2);
                    lst.Add("math");
                    lst.Add("english");
                    dictionary.Add("course", lst);
                    DTAnalytics.UserUniqAppend(dictionary);
                }
            });

            buttons1[7].onClick.AddListener(delegate
            {
                print("Sample---");
                SceneManager.LoadSceneAsync("Sample");
            });
        }
    }
}