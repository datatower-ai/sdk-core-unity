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


        buttons1[0].onClick.AddListener(delegate { DTIASAPI.ReportToShow(seq, placement, entrance); });
        buttons1[1].onClick.AddListener(delegate { DTIASAPI.ReportShowSuccess(seq, placement, entrance); });
        buttons1[2].onClick.AddListener(delegate
        {
            DTIASAPI.ReportShowFail(seq, placement, errorCode, errorMsg, entrance);
        });
        buttons1[3].onClick.AddListener(delegate
        {
            DTIASAPI.ReportSubscribe(seq, placement, sku, orderId, price, currency, entrance);
            //用法相同
        });
        buttons1[4].onClick.AddListener(delegate
        {
            DTIASAPI.ReportSusbscribeSuccess(seq, placement, sku, orderId, originalOrderId, price, currency,
                entrance);
        });
        buttons1[5].onClick.AddListener(delegate
        {
            DTIASAPI.ReportSubscribeFail(seq, placement, sku, orderId, originalOrderId, price, currency,
                errorCode, entrance, errorMsg);
        });


        buttons1[6].onClick.AddListener(delegate { SceneManager.LoadSceneAsync("Sample"); });
    }

    private void OnConfigFethedCallback(bool isSuccess, string errorMessage)
    {
        if (isSuccess)
            print("onfigFetched OnSuccess!!!!!");
        else
            print("onfigFetched OnError:" + errorMessage);
    }
}