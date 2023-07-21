using System.Collections.Generic;
using DataTower;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IAP_Sample : MonoBehaviour
{
    public Button[] buttons2;
    private readonly string order = "7345062sdf";
    private readonly string seq = "123456";

    // Start is called before the first frame update
    private void Awake()
    {
        print("sample awake====");
        
        buttons2[0].onClick.AddListener(delegate
        {
            var dict = new Dictionary<string, object>();
            dict.Add("test_properties", "property value");
            DTIAPReport.ReportPurchaseSuccess(order, "sdk123", 3.32, "rmb", dict); 
        }
        );

        buttons2[1].onClick.AddListener(delegate { SceneManager.LoadSceneAsync("Sample"); });
    }


    private void Start()
    {
    }
}