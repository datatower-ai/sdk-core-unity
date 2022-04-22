﻿﻿using System;
using System.Collections.Generic;


namespace ROIQuery
{
    /// <summary>
    /// 广告类型
    /// </summary>
    public enum AdType : int
    {
        IDLE = -1,
        BANNER = 0,
        INTERSTITIAL = 1,
        NATIVE = 2,
        REWARDED = 3,
        REWARDED_INTERSTITIAL = 4,
        APP_OPEN = 5,
        MREC = 6
    }

    /// <summary>
    /// 广告平台
    /// </summary>
    public enum AdPlatform : int
    {
        IDLE = -1,
        ADMOB = 0,
        MOPUB = 1,
        ADCOLONY = 2,
        APPLOVIN = 3,
        CHARTBOOST = 4,
        FACEBOOK = 5,
        INMOBI = 6,
        IRONSOURCE = 7,
        PANGLE = 8,
        SNAP_AUDIENCE_NETWORK = 9,
        TAPJOY = 10,
        UNITY_ADS = 11,
        VERIZON_MEDIA = 12,
        VUNGLE = 13,
        ADX = 14,
        COMBO = 15,
        BIGO = 16,
        HISAVANA = 17,
        APPLOVIN_EXCHANGE = 18
    }

    /// <summary>
    /// 广告聚合平台
    /// </summary>
    public enum AdMediation : int
    {
        IDLE = -1,
        MOPUB = 0,
        MAX = 1,
        HISAVANA = 2
    }

    public class ROIQueryAdReport
    {
        /// <summary>
        /// 上报 广告入口
        /// </summary>
        /// <param name="id">广告最小单元id</param>
        /// <param name="type">广告类型</param>
        /// <param name="platform">广告平台</param>
        /// <param name="location">广告位</param>
        /// <param name="seq">系列行为标识</param>
        /// <param name="entrance">广告入口</param>
        public static void ReportEntrance(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "", Dictionary<string, object> properties = null)
        {
            ROIQueryAdReportWrapper.Instance.ReportEntrance(id, type, platform, location, seq, entrance, properties);
        }


        /// <summary>
        /// 上报 广告展示请求
        /// </summary>
        /// <param name="id">广告最小单元id</param>
        /// <param name="type">广告类型</param>
        /// <param name="platform">广告平台</param>
        /// <param name="location">广告位</param>
        /// <param name="seq">系列行为标识</param>
        /// <param name="entrance">广告入口</param>
        public static void ReportToShow(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "", Dictionary<string, object> properties = null)
        {
            ROIQueryAdReportWrapper.Instance.ReportToShow(id, type, platform, location, seq, entrance, properties);
        }


        /// <summary>
        /// 上报 广告展示
        /// </summary>
        /// <param name="id">广告最小单元id</param>
        /// <param name="type">广告类型</param>
        /// <param name="platform">广告平台</param>
        /// <param name="location">广告位</param>
        /// <param name="seq">系列行为标识</param>
        /// <param name="entrance">广告入口</param>
        public static void ReportShow(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "", Dictionary<string, object> properties = null)
        {
            ROIQueryAdReportWrapper.Instance.ReportShow(id, type, platform, location, seq, entrance, properties);
        }

        /// <summary>
        /// 上报 广告曝光
        /// </summary>
        /// <param name="id">广告最小单元id</param>
        /// <param name="type">广告类型</param>
        /// <param name="platform">广告平台</param>
        /// <param name="location">广告位</param>
        /// <param name="seq">系列行为标识</param>
        /// <param name="entrance">广告入口</param>
        public static void ReportImpression(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "", Dictionary<string, object> properties = null)
        {
            ROIQueryAdReportWrapper.Instance.ReportImpression(id, type, platform, location, seq, entrance);
        }


        /// <summary>
        /// 上报 广告关闭
        /// </summary>
        /// <param name="id">广告最小单元id</param>
        /// <param name="type">广告类型</param>
        /// <param name="platform">广告平台</param>
        /// <param name="location">广告位</param>
        /// <param name="seq">系列行为标识</param>
        /// <param name="entrance">广告入口</param>
        public static void ReportClose(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "", Dictionary<string, object> properties = null)
        {
            ROIQueryAdReportWrapper.Instance.ReportClose(id, type, platform, location, seq, entrance, properties);
        }


        /// <summary>
        /// 上报 广告点击
        /// </summary>
        /// <param name="id">广告最小单元id</param>
        /// <param name="type">广告类型</param>
        /// <param name="platform">广告平台</param>
        /// <param name="location">广告位</param>
        /// <param name="seq">系列行为标识</param>
        /// <param name="entrance">广告入口</param>
        public static void ReportClick(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "", Dictionary<string, object> properties = null)
        {
            ROIQueryAdReportWrapper.Instance.ReportClick(id, type, platform, location, seq, entrance, properties);
        }


        /// <summary>
        /// 上报 激励广告已获得奖励
        /// </summary>
        /// <param name="id">广告最小单元id</param>
        /// <param name="type">广告类型</param>
        /// <param name="platform">广告平台</param>
        /// <param name="location">广告位</param>
        /// <param name="seq">系列行为标识</param>
        /// <param name="entrance">广告入口</param>
        public static void ReportRewarded(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "", Dictionary<string, object> properties = null)
        {
            ROIQueryAdReportWrapper.Instance.ReportRewarded(id, type, platform, location, seq, entrance, properties);
        }


        /// <summary>
        /// 上报 访问广告链接，离开当前app(页面)
        /// </summary>
        /// <param name="id">广告最小单元id</param>
        /// <param name="type">广告类型</param>
        /// <param name="platform">广告平台</param>
        /// <param name="location">广告位</param>
        /// <param name="seq">系列行为标识</param>
        /// <param name="entrance">广告入口</param>
        public static void ReportLeftApp(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "", Dictionary<string, object> properties = null)
        {
            ROIQueryAdReportWrapper.Instance.ReportLeftApp(id, type, platform, location, seq, entrance, properties);
        }


        /// <summary>
        /// 上报 自定义转化，通过点击
        /// </summary>
        /// <param name="id">广告最小单元id</param>
        /// <param name="type">广告类型</param>
        /// <param name="platform">广告平台</param>
        /// <param name="location">广告位</param>
        /// <param name="seq">系列行为标识</param>
        /// <param name="entrance">广告入口</param>
        public static void ReportConversionByClick(string id, AdType type, AdPlatform platform, string location,
            string seq, string entrance = "", Dictionary<string, object> properties = null)
        {
            ROIQueryAdReportWrapper.Instance.ReportConversionByClick(id, type, platform, location, seq, entrance,
                properties);
        }

        /// <summary>
        /// 上报 自定义转化，通过跳出app
        /// </summary>
        /// <param name="id">广告最小单元id</param>
        /// <param name="type">广告类型</param>
        /// <param name="platform">广告平台</param>
        /// <param name="location">广告位</param>
        /// <param name="seq">系列行为标识</param>
        /// <param name="entrance">广告入口</param>
        public static void ReportConversionByLeftApp(string id, AdType type, AdPlatform platform, string location,
            string seq, string entrance = "", Dictionary<string, object> properties = null)
        {
            ROIQueryAdReportWrapper.Instance.ReportConversionByLeftApp(id, type, platform, location, seq, entrance,
                properties);
        }

        /// <summary>
        /// 上报 自定义转化，通过曝光
        /// </summary>
        /// <param name="id">广告最小单元id</param>
        /// <param name="type">广告类型</param>
        /// <param name="platform">广告平台</param>
        /// <param name="location">广告位</param>
        /// <param name="seq">系列行为标识</param>
        /// <param name="entrance">广告入口</param>
        public static void ReportConversionByImpression(string id, AdType type, AdPlatform platform, string location,
            string seq, string entrance = "", Dictionary<string, object> properties = null)
        {
            ROIQueryAdReportWrapper.Instance.ReportConversionByImpression(id, type, platform, location, seq, entrance,
                properties);
        }

        /// <summary>
        /// 上报 自定义转化，通过获得激励
        /// </summary>
        /// <param name="id">广告最小单元id</param>
        /// <param name="type">广告类型</param>
        /// <param name="platform">广告平台</param>
        /// <param name="location">广告位</param>
        /// <param name="seq">系列行为标识</param>
        /// <param name="entrance">广告入口</param>
        public static void ReportConversionByRewarded(string id, AdType type, AdPlatform platform, string location,
            string seq, string entrance = "", Dictionary<string, object> properties = null)
        {
            ROIQueryAdReportWrapper.Instance.ReportConversionByRewarded(id, type, platform, location, seq, entrance,
                properties);
        }


        /// <summary>
        /// 上报 广告展示价值,适用于单独的广告平台
        /// </summary>
        /// <param name="id">广告最小单元id</param>
        /// <param name="type">广告类型</param>
        /// <param name="platform">广告平台</param>
        /// <param name="location">广告位</param>
        /// <param name="seq">系列行为标识</param>
        /// <param name="value">价值</param>
        /// <param name="currency">货币</param>
        /// <param name="precision">精确度</param>
        /// <param name="entrance">广告入口</param>
        public static void ReportPaid(string id, AdType type, AdPlatform platform, string location, string seq,
            string value, string currency, string precision, string entrance = "",
            Dictionary<string, object> properties = null)
        {
            ROIQueryAdReportWrapper.Instance.ReportPaid(id, type, platform, location, seq, value, currency, precision,
                entrance, properties);
        }


        /// <summary>
        /// 上报 广告展示价值，适用于聚合广告平台
        /// </summary>
        /// <param name="id">广告最小单元id</param>
        /// <param name="type">广告类型</param>
        /// <param name="platform">广告平台</param>
        /// <param name="adgroupName">广告组名称</param>
        /// <param name="adgroupType">广告组类别</param>
        /// <param name="location">广告位</param>
        /// <param name="seq">系列行为标识</param>
        /// <param name="mediation">聚合平台</param>
        /// <param name="mediationId">聚合平台广告id</param>
        /// <param name="value">价值</param>
        /// <param name="currency">货币</param>
        /// <param name="precision">精确度</param>
        /// <param name="country">国家</param>
        /// <param name="entrance">广告入口</param>
        public static void ReportPaid(string id, AdType type, string platform, string adgroupName, string adgroupType,
            string location, string seq,
            AdMediation mediation, string mediationId, string value, string currency, string precision, string country,
            string entrance = "", Dictionary<string, object> properties = null)
        {
            ROIQueryAdReportWrapper.Instance.ReportPaid(id, type, platform, adgroupName, adgroupType, location, seq,
                mediation, mediationId,
                value, currency, precision, country, entrance, properties);
        }

        /// <summary>
        /// 上报 广告展示价值，适用于聚合广告平台 max
        /// </summary>
        /// <param name="id">广告最小单元id</param>
        /// <param name="type">广告类型</param>
        /// <param name="platform">广告平台</param>
        /// <param name="location">广告位</param>
        /// <param name="seq">系列行为标识</param>
        /// <param name="mediation">聚合平台</param>
        /// <param name="mediationId">聚合平台广告id</param>
        /// <param name="value">价值</param>
        /// <param name="precision">精确度</param>
        /// <param name="country">国家</param>
        public static void ReportPaid(string id, AdType type, AdPlatform platform,
            string location, string seq,
            AdMediation mediation, string mediationId, string value, string precision, string country,
             Dictionary<string, object> properties = null)
        {
            ROIQueryAdReportWrapper.Instance.ReportPaid(id, type, platform, location, seq,
                mediation, mediationId, value,  precision, country, properties);
                
        }



        /// <summary>
        /// 生成uuid，用于生成 seq
        /// </summary>
        public static string GenerateUUID()
        {
            return ROIQueryAdReportWrapper.Instance.GenerateUUID();
        }


        /// <summary>
        /// 获取聚合平台具体广告网络
        /// </summary>
        public static AdPlatform GetPlatform(AdMediation mediation, string networkName, string networkPlacementId,
            string adgroupName, string adgroupType)
        {
            return ROIQueryAdReportWrapper.Instance.GetPlatform(mediation, networkName, networkPlacementId, adgroupName,
                adgroupType);
        }
    }
}