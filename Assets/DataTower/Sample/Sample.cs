using DataTower;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Sample : MonoBehaviour
{
    public Button[] buttons1;

    // Start is called before the first frame update
    private void Awake()
    {
        print("sample awake====");

        buttons1[0].onClick.AddListener(delegate { SceneManager.LoadSceneAsync("Analytics_Sample"); });
        buttons1[1].onClick.AddListener(delegate { SceneManager.LoadSceneAsync("IAS_Sample"); });
        buttons1[2].onClick.AddListener(delegate { SceneManager.LoadSceneAsync("Ad_Sample"); });
        buttons1[3].onClick.AddListener(delegate { SceneManager.LoadSceneAsync("IAP_Sample"); });

        buttons1[4].onClick.AddListener(delegate { SceneManager.LoadSceneAsync("Utils_Sample"); });
        buttons1[5].onClick.AddListener(delegate { SceneManager.LoadSceneAsync("User_Set_Sample"); });
    }

    private void OnEnable()
    {
    }

    private void OnDisable()
    {
    }

    private void OnAdIsEnable(bool enable)
    {
        R_Log.Debug("ROIQueryRewarded OnAdIsEnable--Sample" + enable);
    }

    private void OnAdRewarded(string placement)
    {
        R_Log.Debug("ROIQueryRewarded OnAdRewarded--Sample,placement" + placement);
    }
}