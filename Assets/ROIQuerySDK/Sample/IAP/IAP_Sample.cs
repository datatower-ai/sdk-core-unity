using ROIQuery;
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
            print("Track ReportEntrance.");
            ROIQueryIAPReport.ReportEntrance(order, "sku123", 3.32, "usd", seq, "home");
        });
        buttons2[1].onClick.AddListener(delegate
        {
            print("Track ReportToPurchase.");
            ROIQueryIAPReport.ReportToPurchase(order, "sku123", 3.32, "rmb", seq, "user");
        });
        buttons2[2].onClick.AddListener(delegate
        {
            print("Track ReportPurchased.");
            ROIQueryIAPReport.ReportPurchased(order, "sku123", 3.32, "rmb", seq, "user");
        });
        buttons2[3].onClick.AddListener(delegate
        {
            print("Track ReportNotToPurchased.");
            ROIQueryIAPReport.ReportNotToPurchased(order, "sku123", 3.32, "eup", seq, "200", "home", "not ok");
        });

        buttons2[4].onClick.AddListener(delegate { SceneManager.LoadSceneAsync("Sample"); });
    }


    private void Start()
    {
    }
}