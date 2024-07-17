using System;
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
            var dict = new Dictionary<string, object>
            {
                { "test_properties", "property value" }, 
                { "test_int", 123 }, 
                { "test_float", 123.4F }, 
                { "test_double", 123.4D }, 
                { "test_bool", true },
                { "test_list", new List<int>{1, 2, 3} },
                { "test_dict", new Dictionary<string, object> { { "a", "b"}, { "c", 2 } } },
                { "test_long", 1000L },
                { "test_byte", 0x20 },
                { "test_uint", 20U },
                { "test_ulong", 20UL },
                { "test_short", (short) 20 },
                { "test_ushort", (ushort) 20 },
                { "test_sbyte", (sbyte) 5 },
                { "test_char", (char) 'A' },
            };
            if (ConfigMgr.IsReportNullData)
            {
                DTIAPReport.ReportPurchaseSuccess(Order, null, 3.32, "rmb", dict);
                DTIAPReport.ReportPurchaseSuccess(Order, "sdk123", 3.32, null, dict);
                DTIAPReport.ReportPurchaseSuccess(Order, "sdk123", 3.32, "rmb", null);
                DTIAPReport.ReportPurchaseSuccess(Order, null, 3.32, null, null);
            }
            else
            {
                DTIAPReport.ReportPurchaseSuccess(Order, "sdk123", 3.32, "rmb", dict);
            }
        }
        );

        buttons2[1].onClick.AddListener(delegate { SceneManager.LoadSceneAsync("Sample"); });
    }
}