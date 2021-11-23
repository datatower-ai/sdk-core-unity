
using ROIQuery;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Sample : MonoBehaviour
{
    private void OnAdIsEnable(bool enable)
    {
        R_Log.Debug("ROIQueryRewarded OnAdIsEnable--Sample" + enable);
    }

    private void OnAdRewarded(string placement)
    {
        R_Log.Debug("ROIQueryRewarded OnAdRewarded--Sample,placement" + placement);
    }

    public Button[] buttons1;

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }

    // Start is called before the first frame update
    void Awake()
    {
       
        print("sample awake====");

        buttons1[0].onClick.AddListener(delegate {
            SceneManager.LoadSceneAsync("Analytics_Sample");

        });
        buttons1[1].onClick.AddListener(delegate {
            SceneManager.LoadSceneAsync("CloudConfig_Sample");

        });
        buttons1[2].onClick.AddListener(delegate {
            SceneManager.LoadSceneAsync("Ad_Sample");

        });
        buttons1[3].onClick.AddListener(delegate {
            SceneManager.LoadSceneAsync("IAP_Sample");
        });
        


    }




}
