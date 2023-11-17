using System.Collections.Generic;
using DataTower.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IAP_Sample : MonoBehaviour
{
    public Button[] buttons2;
    private const string Order = "7345062sdf";

    // Start is called before the first frame update
    private void Awake()
    {
        print("sample awake====");
        
        buttons2[0].onClick.AddListener(delegate
        {
            var dict = new Dictionary<string, object> { { "test_properties", "property value" } };
            DTIAPReport.ReportPurchaseSuccess(Order, "sdk123", 3.32, "rmb", dict); 
        }
        );

        buttons2[1].onClick.AddListener(delegate { SceneManager.LoadSceneAsync("Sample"); });
    }
}