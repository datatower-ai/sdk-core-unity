using System.Collections.Generic;
using DataTower.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ad_Sample : MonoBehaviour
{
    public Button[] buttons1;
    private const string Seq = "123434534";

    // Start is called before the first frame update
    private void Awake()
    {
        var dictionary = new Dictionary<string, object> { { "test_ad_properties", "adProperties" } };

        buttons1[0].onClick.AddListener(delegate
        {
            R_Log.Debug("ReportLoadBegin");

            if (ConfigMgr.IsReportNullData)
            {
                DTAdReport.ReportLoadBegin("0130", AdType.INTERSTITIAL, AdPlatform.ADMOB, null,
        mediation: AdMediation.MAX, mediationId: null, properties: null);
            }
            else
            {
                DTAdReport.ReportLoadBegin("0130", AdType.INTERSTITIAL, AdPlatform.ADMOB, Seq,
                    mediation: AdMediation.MAX, mediationId: "mediation_id_max_123");
            }
        });

        buttons1[1].onClick.AddListener(delegate
        {
            R_Log.Debug("ReportLoadEnd");

            if (ConfigMgr.IsReportNullData)
            {
                DTAdReport.ReportLoadEnd("0130", AdType.INTERSTITIAL, AdPlatform.ADMOB, 2000, false, null, -1, "no ads");
            }
            else
            {
                DTAdReport.ReportLoadEnd("0130", AdType.INTERSTITIAL, AdPlatform.ADMOB, 2000, false, Seq, -1, "no ads");
            }
        });

        buttons1[2].onClick.AddListener(delegate
        {
            R_Log.Debug("ReportClick");
            if (ConfigMgr.IsReportNullData)
            {
                DTAdReport.ReportClick("0130", AdType.BANNER, AdPlatform.ADMOB, null, null, null, null, mediationId: null);
            }
            else
            {
                DTAdReport.ReportClick("0130", AdType.BANNER, AdPlatform.ADMOB, "cart", Seq, "center4");
            }
        });

        buttons1[3].onClick.AddListener(delegate
        {
            R_Log.Debug("ReportClose");
            if (ConfigMgr.IsReportNullData)
            {
                DTAdReport.ReportClose("0130", AdType.BANNER, AdPlatform.ADMOB, null, null, null, null, mediationId: null);
            }
            else
            {
                DTAdReport.ReportClose("0130", AdType.BANNER, AdPlatform.ADMOB, "home", Seq, "center5");
            }
        });

        buttons1[4].onClick.AddListener(delegate
        {
            R_Log.Debug("ReportPaid");
            if (ConfigMgr.IsReportNullData)
            {
                DTAdReport.ReportPaid("0130", AdType.BANNER, AdPlatform.MOPUB, null, null, 0.1, null, null, null, mediationId: null);
            }
            else
            {
                DTAdReport.ReportPaid("0130", AdType.BANNER, AdPlatform.MOPUB, "home2", "2000", 0.1, "1", Seq, "center3");
            }
        });

        buttons1[5].onClick.AddListener(delegate
        {
            R_Log.Debug("ReportRewarded");
            if (ConfigMgr.IsReportNullData)
            {
                DTAdReport.ReportRewarded("0130", AdType.REWARDED, AdPlatform.ADMOB, null, null, null, mediationId: null);
            }
            else
            {
                DTAdReport.ReportRewarded("0130", AdType.REWARDED, AdPlatform.ADMOB, "user", Seq, "center2");
            }
        });

        buttons1[6].onClick.AddListener(delegate
        {
            R_Log.Debug("ReportShow");
            if (ConfigMgr.IsReportNullData)
            {
                DTAdReport.ReportShow("0130", AdType.REWARDED, AdPlatform.ADMOB, null, null, null, null, mediationId: null);
            }
            else
            {
                DTAdReport.ReportShow("0130", AdType.REWARDED, AdPlatform.ADMOB, "user", Seq, "center2", dictionary);
            }
        });

        buttons1[7].onClick.AddListener(delegate
        {
            R_Log.Debug("ReportLeftApp");
            if (ConfigMgr.IsReportNullData)
            {
                DTAdReport.ReportLeftApp("0130", AdType.BANNER, AdPlatform.ADMOB, null, null, null, null, mediationId: null);
            }
            else
            {
                DTAdReport.ReportLeftApp("0130", AdType.BANNER, AdPlatform.ADMOB, "home2", Seq, "center3");
            }
        });

        buttons1[8].onClick.AddListener(delegate
        {
            R_Log.Debug("ReportShowFailed");

            if (ConfigMgr.IsReportNullData)
            {
                DTAdReport.ReportShowFailed("0130", AdType.NATIVE, AdPlatform.ADMOB, null, null, 0, null, mediationId: null);
            }
            else
            {
                DTAdReport.ReportShowFailed("0130", AdType.NATIVE, AdPlatform.ADMOB, "home7", Seq, -2, "no ads");
            }
        });

        buttons1[9].onClick.AddListener(delegate
        {
            R_Log.Debug("ReportToShow");
            if (ConfigMgr.IsReportNullData)
            {
                DTAdReport.ReportToShow("0130", AdType.NATIVE, AdPlatform.ADMOB, null, null, null, null, mediationId: null);
            }
            else
            {
                DTAdReport.ReportToShow("0130", AdType.NATIVE, AdPlatform.ADMOB, "home7", Seq, "center", dictionary);
            }
        });

        buttons1[10].onClick.AddListener(delegate
        {
            R_Log.Debug("ReportConversionByClick");
            if (ConfigMgr.IsReportNullData)
            {
                DTAdReport.ReportConversionByClick("0130", AdType.BANNER, AdPlatform.ADMOB, null, null, null, null, mediationId: null);
            }
            else
            {
                DTAdReport.ReportConversionByClick("0130", AdType.BANNER, AdPlatform.ADMOB, "cart", Seq, "center4");
            }
        });

        buttons1[11].onClick.AddListener(delegate
        {
            R_Log.Debug("ReportConversionByRewarded");
            if (ConfigMgr.IsReportNullData)
            {
                DTAdReport.ReportConversionByRewarded("0130", AdType.REWARDED, AdPlatform.ADMOB, null, null, null, null, mediationId: null);
            }
            else
            {
                DTAdReport.ReportConversionByRewarded("0130", AdType.REWARDED, AdPlatform.ADMOB, "user", Seq, "center2");
            }
        });

        buttons1[12].onClick.AddListener(delegate
        {
            R_Log.Debug("ReportConversionByLeftApp");
            if (ConfigMgr.IsReportNullData)
            {
                DTAdReport.ReportConversionByLeftApp("0130", AdType.REWARDED, AdPlatform.ADMOB, null, null, null, null, mediationId: null);
            }
            else
            {
                DTAdReport.ReportConversionByLeftApp("0130", AdType.REWARDED, AdPlatform.ADMOB, "user", Seq, "center2");
            }
        });

        buttons1[13].onClick.AddListener(delegate { SceneManager.LoadSceneAsync("Sample"); });
    }
}