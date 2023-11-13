using System.Collections.Generic;
using DataTower;
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
        var dictionary = new Dictionary<string, object>();

        dictionary.Add("test_ad_properties", "adProperties");
        
        buttons1[0].onClick.AddListener(delegate { 
            R_Log.Debug("ReportLoadBegin");
            DTAdReport.ReportLoadBegin("0130", AdType.INTERSTITIAL, AdPlatform.ADMOB, seq, 
                mediation: AdMediation.MAX, mediationId: "mediation_id_max_123");
        });

        buttons1[1].onClick.AddListener(delegate { 
            R_Log.Debug("ReportLoadEnd");
            DTAdReport.ReportLoadEnd("0130", AdType.INTERSTITIAL, AdPlatform.ADMOB, 2000, false, seq, -1, "no ads");
        });
        
        buttons1[2].onClick.AddListener(delegate { 
            R_Log.Debug("ReportClick");
            DTAdReport.ReportClick("0130", AdType.BANNER, AdPlatform.ADMOB, "cart", seq, "center4");
        });
        
        buttons1[3].onClick.AddListener(delegate { 
            R_Log.Debug("ReportClose");
           DTAdReport.ReportClose("0130", AdType.BANNER, AdPlatform.ADMOB, "home", seq, "center5");
        });
        
        buttons1[4].onClick.AddListener(delegate { 
            R_Log.Debug("ReportPaid");
           DTAdReport.ReportPaid("0130", AdType.BANNER, AdPlatform.MOPUB, "home2", "2000", 0.1, "1", seq, "center3");
        });
        
        buttons1[5].onClick.AddListener(delegate { 
            R_Log.Debug("ReportRewarded");
            DTAdReport.ReportRewarded("0130", AdType.REWARDED, AdPlatform.ADMOB, "user", seq, "center2");
        });
        
        buttons1[6].onClick.AddListener(delegate { 
            R_Log.Debug("ReportShow");
            DTAdReport.ReportShow("0130", AdType.REWARDED, AdPlatform.ADMOB, "user", seq, "center2", dictionary);
        });
        
        buttons1[7].onClick.AddListener(delegate { 
            R_Log.Debug("ReportLeftApp");
            DTAdReport.ReportLeftApp("0130", AdType.BANNER, AdPlatform.ADMOB, "home2", seq, "center3");
        });
        
        buttons1[8].onClick.AddListener(delegate { 
            R_Log.Debug("ReportShowFailed");
            DTAdReport.ReportShowFailed("0130", AdType.NATIVE, AdPlatform.ADMOB, "home7", seq, -2, "no ads");
        });
        
        buttons1[9].onClick.AddListener(delegate { 
            R_Log.Debug("ReportToShow");
            DTAdReport.ReportToShow("0130", AdType.NATIVE, AdPlatform.ADMOB, "home7", seq, "center", dictionary);
        });
        
        buttons1[10].onClick.AddListener(delegate { 
            R_Log.Debug("ReportConversionByClick");
            DTAdReport.ReportConversionByClick("0130", AdType.BANNER, AdPlatform.ADMOB, "cart", seq, "center4");
        });
        
        buttons1[11].onClick.AddListener(delegate { 
            R_Log.Debug("ReportConversionByRewarded");
            DTAdReport.ReportConversionByRewarded("0130", AdType.REWARDED, AdPlatform.ADMOB, "user", seq, "center2");
        });
        
        buttons1[12].onClick.AddListener(delegate { 
            R_Log.Debug("ReportConversionByLeftApp");
            DTAdReport.ReportConversionByLeftApp("0130", AdType.REWARDED, AdPlatform.ADMOB, "user", seq, "center2");
        });

        buttons1[13].onClick.AddListener(delegate { SceneManager.LoadSceneAsync("Sample"); });
    }


    private void OnAdIsEnable(bool enable)
    {
        R_Log.Debug("DT Rewarded OnAdIsEnable--Ad_Sample" + enable);
    }

    private void OnAdRewarded(string placement)
    {
        R_Log.Debug("DT Rewarded OnAdRewarded--Ad_Sample, placement" + placement);
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