using ROIQuery.Utils;
using UnityEngine;
using UnityEngine.UI;
using ROIQuery.CloudConfig;
using UnityEngine.SceneManagement;

public class CloudConfig_Sample : MonoBehaviour
{
    public Button[] buttons1;

    void OnConfigFethedCallback(bool isSuccess, string errorMessage)
    {
        if (isSuccess)
        {
            print("onfigFetched OnSuccess!!!!!");
        }
        else
        {
            print("onfigFetched OnError:" + errorMessage);
        }
    }


    // Start is called before the first frame update
    void Awake()
    {
        print("sample awake====");

        buttons1[0].onClick.AddListener(delegate
        {
            ROIQueryCloudConfig.OnConfigFethed += OnConfigFethedCallback;
            ROIQueryCloudConfig.Fetch();
        });
        buttons1[1].onClick.AddListener(delegate
        {
            int config1 = ROIQueryCloudConfig.GetInt("config1");
            print("GetInt:" + config1);
            R_Log.Debug("GetInt:" + config1);
        });
        buttons1[2].onClick.AddListener(delegate
        {
            //用法相同
            double config3 = ROIQueryCloudConfig.GetDouble("config3");
            print("GetDouble:" + config3);
            R_Log.Debug("GetDouble:" + config3);
        });
        buttons1[3].onClick.AddListener(delegate
        {
            //用法相同
        });
        buttons1[4].onClick.AddListener(delegate
        {
            string key = "config4";
            string config3 = ROIQueryCloudConfig.GetString(key);
            print("GetString:" + config3);
            R_Log.Debug(config3);
        });
        buttons1[5].onClick.AddListener(delegate
        {
            bool config2 = ROIQueryCloudConfig.GetBool("config1");
            print("GetBool:" + config2);
            R_Log.Debug("GetBool:" + config2);
        });


        buttons1[6].onClick.AddListener(delegate { SceneManager.LoadSceneAsync("Sample"); });
    }
}