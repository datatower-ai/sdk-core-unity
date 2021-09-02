
using ROIQuery.Utils;
using ROIQuery.AdReport;
using ROIQuery.Analytics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ad_Sample : MonoBehaviour
{
    private string seq = "123434534";

    public Button[] buttons1;
   
   

    // Start is called before the first frame update
    void Awake()
    {
        print("sample awake====");

        buttons1[0].onClick.AddListener(delegate {
            R_Log.Debug("report entrance----");
            ROIQueryAdReport.ReportEntrance("0130", AdType.INTERSTITIAL, AdPlatform.ADMOB, "home", seq, "center");

        });
        buttons1[1].onClick.AddListener(delegate {
            R_Log.Debug("report toShow");
            ROIQueryAdReport.ReportToShow("0130", AdType.NATIVE, AdPlatform.ADMOB, "home7", seq, "center");

        });

        buttons1[9].onClick.AddListener(delegate {
            R_Log.Debug("report show");
            ROIQueryAdReport.ReportShow("0130", AdType.REWARDED, AdPlatform.ADMOB, "user", seq, "center2");

        });

        buttons1[2].onClick.AddListener(delegate {
            R_Log.Debug("report impression");
            ROIQueryAdReport.ReportImpression("0130", AdType.REWARDED, AdPlatform.ADMOB, "home4", seq, "center");
            ROIQueryAdReport.ReportConversionByImpression("0130", AdType.REWARDED, AdPlatform.ADMOB, "home4", seq, "center");

        });
        buttons1[3].onClick.AddListener(delegate {
            R_Log.Debug("report close");
            ROIQueryAdReport.ReportClose("0130", AdType.BANNER, AdPlatform.ADMOB, "home", seq, "center5");

        });
        buttons1[4].onClick.AddListener(delegate {
            R_Log.Debug("report click");
            ROIQueryAdReport.ReportClick("0130", AdType.BANNER, AdPlatform.ADMOB, "cart", seq, "center4");
            ROIQueryAdReport.ReportConversionByClick("0130", AdType.BANNER, AdPlatform.ADMOB, "cart", seq, "center4");


        });
        buttons1[5].onClick.AddListener(delegate {
            ROIQueryAnalytics.SetFirebaseAppInstanceId("sdfsjdiofjaoisjdi");
            R_Log.Debug("report Paid");
            //ROIQueryAdReport.ReportLeftApp("0130", AdType.BANNER, AdPlatform.ADMOB, "home2", seq, "center3");
            //ROIQueryAdReport.ReportPaid("0130", AdType.BANNER, AdPlatform.MOPUB, "home2", "2000", "01", "1", seq, "center3");
            ROIQueryAdReport.ReportPaid("ad_id_0130", AdType.REWARDED, "unity", "home2", seq, AdMediation.MOPUB, "mediatione_id_212324", "5000", "usd", "1", "US","center4");

        });
        buttons1[6].onClick.AddListener(delegate {
            R_Log.Debug("report rewarded");
            ROIQueryAdReport.ReportRewarded("0130", AdType.REWARDED, AdPlatform.ADMOB, "user", seq, "center2");
            ROIQueryAdReport.ReportConversionByRewarded("0130", AdType.REWARDED, AdPlatform.ADMOB, "user", seq, "center2");
        });

        buttons1[8].onClick.AddListener(delegate {
            R_Log.Debug("report left app");
            ROIQueryAdReport.ReportLeftApp("0130", AdType.REWARDED, AdPlatform.ADMOB, "user", seq, "center2");
            ROIQueryAdReport.ReportConversionByLeftApp("0130", AdType.REWARDED, AdPlatform.ADMOB, "user", seq, "center2");

        });
        
        buttons1[7].onClick.AddListener(delegate {
            SceneManager.LoadSceneAsync("Sample");
        });

       

    }





}
