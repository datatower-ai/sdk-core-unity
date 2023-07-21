using System.Collections.Generic;
using DataTower;
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

        var seq = "12138";
        var placement = "ias_placement";
        var entrance = "ias_entrance";
        var errorCode = "2";
        var errorMsg = "test for ias  error msg";
        var sku = "sku for ias";
        var orderId = "ias_orderId_12";
        var price = "233";
        var currency = "$";
        var originalOrderId = "original_orderId_12";
        
        buttons1[0].onClick.AddListener(delegate
        {
            print("Track ReportSubscribeSuccess.");
            var dict = new Dictionary<string, object>();
            dict.Add("property_test", "test");
            DTIASReport.ReportSubscribeSuccess("originalOrderId123", "orderId123", "sdu123", 10, "rmb", dict);
        });


        buttons1[1].onClick.AddListener(delegate { SceneManager.LoadSceneAsync("Sample"); });
    }

    private void OnConfigFethedCallback(bool isSuccess, string errorMessage)
    {
        if (isSuccess)
            print("onfigFetched OnSuccess!!!!!");
        else
            print("onfigFetched OnError:" + errorMessage);
    }
}