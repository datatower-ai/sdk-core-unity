using System.Collections.Generic;
using DataTower.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IAS_Sample : MonoBehaviour
{
    public Button[] buttons1;


    // Start is called before the first frame update
    private void Awake()
    {
        print("sample awake====");

        buttons1[0].onClick.AddListener(delegate
        {
            print("Track ReportSubscribeSuccess.");
            var dict = new Dictionary<string, object> { { "property_test", "test" } };
            DTIASReport.ReportSubscribeSuccess("originalOrderId123", "orderId123", "sdu123", 10, "rmb", dict);
        });


        buttons1[1].onClick.AddListener(delegate { SceneManager.LoadSceneAsync("Sample"); });
    }
}