using System.Collections.Generic;
using ROIQuery;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ad_Sample : MonoBehaviour
{
    public Button[] buttons1;
    private readonly string seq = "123434534";

    // Start is called before the first frame update
    private void Awake()
    {
        // ROIQueryRewarded.OnAdIsEnableEvent += OnAdIsEnable;

        ROIQueryAdReport.ReportLoadBegin("0130", AdType.INTERSTITIAL, AdPlatform.ADMOB, seq);

        ROIQueryAdReport.ReportLoadEnd("0130", AdType.INTERSTITIAL, AdPlatform.ADMOB, 2000, false, seq, -1, "no ads");


        var dictionary = new Dictionary<string, object>();

        dictionary.Add("test_ad_properties", "adProperties");

        buttons1[0].onClick.AddListener(delegate { R_Log.Debug("report entrance----"); });
        buttons1[1].onClick.AddListener(delegate
        {
            R_Log.Debug("report toShow");
            ROIQueryAdReport.ReportToShow("0130", AdType.NATIVE, AdPlatform.ADMOB, "home7", seq, "center", dictionary);
            ROIQueryAdReport.ReportShowFailed("0130", AdType.NATIVE, AdPlatform.ADMOB, "home7", seq, -2, "no ads");
        });
        buttons1[9].onClick.AddListener(delegate
        {
            // R_Log.Debug("report show");
            ROIQueryAdReport.ReportShow("0130", AdType.REWARDED, AdPlatform.ADMOB, "user", seq, "center2", dictionary);
        });

        buttons1[2].onClick.AddListener(delegate { R_Log.Debug("report impression"); });
        buttons1[3].onClick.AddListener(delegate
        {
            R_Log.Debug("report close");
            ROIQueryAdReport.ReportClose("0130", AdType.BANNER, AdPlatform.ADMOB, "home", seq, "center5");
        });
        buttons1[4].onClick.AddListener(delegate
        {
            R_Log.Debug("report click");
            ROIQueryAdReport.ReportClick("0130", AdType.BANNER, AdPlatform.ADMOB, "cart", seq, "center4");
            ROIQueryAdReport.ReportConversionByClick("0130", AdType.BANNER, AdPlatform.ADMOB, "cart", seq, "center4");
        });
        buttons1[5].onClick.AddListener(delegate
        {
            ROIQueryAnalytics.SetFirebaseAppInstanceId("sdfsjdiofjaoisjdi");
            R_Log.Debug("report Paid");
            //ROIQueryAdReport.ReportLeftApp("0130", AdType.BANNER, AdPlatform.ADMOB, "home2", seq, "center3");
            //ROIQueryAdReport.ReportPaid("0130", AdType.BANNER, AdPlatform.MOPUB, "home2", "2000", "01", "1", seq, "center3");
            ROIQueryAdReport.ReportPaid("ad_id_0130", AdType.REWARDED, "unity", "marketplace", "home2", "", seq,
                AdMediation.MOPUB, "mediatione_id_212324", "5000", "usd", "1", "US", "center4");
        });
        buttons1[6].onClick.AddListener(delegate
        {
            R_Log.Debug("report rewarded");
            ROIQueryAdReport.ReportRewarded("0130", AdType.REWARDED, AdPlatform.ADMOB, "user", seq, "center2");
            ROIQueryAdReport.ReportConversionByRewarded("0130", AdType.REWARDED, AdPlatform.ADMOB, "user", seq,
                "center2");
        });

        buttons1[8].onClick.AddListener(delegate
        {
            R_Log.Debug("report left app");
            ROIQueryAdReport.ReportLeftApp("0130", AdType.REWARDED, AdPlatform.ADMOB, "user", seq, "center2");
            ROIQueryAdReport.ReportConversionByLeftApp("0130", AdType.REWARDED, AdPlatform.ADMOB, "user", seq,
                "center2");

#if UNITY_ANDROID
            OpenBrowser("https://blog.csdn.net/qq_37310110/article/details/88416465");
#endif
        });

        buttons1[7].onClick.AddListener(delegate { SceneManager.LoadSceneAsync("Sample"); });
        buttons1[10].onClick.AddListener(delegate
        {
            ROIQueryAdReport.ReportShowFailed("0120",AdType.BANNER,AdPlatform.IDLE,"user",seq,-20,
                "test for reportShowFailed error","reportShowFailed entrance");
            
            
        });
        
        buttons1[11].onClick.AddListener(delegate
        {
        });
    }


    private void OnAdIsEnable(bool enable)
    {
        R_Log.Debug("ROIQueryRewarded OnAdIsEnable--Ad_Sample" + enable);
    }

    private void OnAdRewarded(string placement)
    {
        R_Log.Debug("ROIQueryRewarded OnAdRewarded--Ad_Sample, placement" + placement);
    }

    public void OpenBrowser(string url)
    {
        if (Application.platform == RuntimePlatform.Android)
        {
 
            Debug.Log(GetType() + "/OpenBrowserWithNoAAR()/");
 
            AndroidJavaObject uri = new AndroidJavaObject("android.net.Uri").CallStatic<AndroidJavaObject>("parse", url);
            AndroidJavaObject intent = new AndroidJavaObject("android.content.Intent", "android.intent.action.VIEW", uri);
            
            AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
           jo.Call("startActivity", intent);

        }

    }
}