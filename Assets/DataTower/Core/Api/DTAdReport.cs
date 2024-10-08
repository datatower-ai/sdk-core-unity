﻿using System.Collections.Generic;
using DataTower.Core.Wrapper;

namespace DataTower.Core
{
    /// <summary>
    ///     广告类型
    /// </summary>
    public enum AdType
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
    ///     广告平台
    /// </summary>
    public enum AdPlatform
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
        APPLOVIN_EXCHANGE = 18,
        MINTEGRAL = 19,
        LIFTOFF = 20,
        A4G = 21,
        GOOGLE_AD_MANAGER = 22,
        FYBER = 23,
        MAIO = 24,
        CRITEO = 25,
        MYTARGET = 26,
        OGURY = 27,
        APPNEXT = 28,
        KIDOZ = 29,
        SMAATO = 30,
        START_IO = 31,
        VERVE = 32,
        LOVINJOYADS = 33,
        YANDEX = 34,
        REKLAMUP = 35,
    }

    /// <summary>
    ///     广告聚合平台
    /// </summary>
    public enum AdMediation
    {
        IDLE = -1,
        MOPUB = 0,
        MAX = 1,
        HISAVANA = 2,
        COMBO = 3,
        TOPON = 4,
        TRADPLUS = 5,
        TOBID = 6,
        ADMOB = 7,
    }

    public class DTAdReport
    {
        /// <summary>
        ///     上报 广告开始加载
        /// </summary>
        /// <param name="id">广告最小单元id</param>
        /// <param name="type">广告类型</param>
        /// <param name="platform">广告平台</param>
        /// <param name="seq">系列行为标识</param>
        /// <param name="properties">自定义属性</param>
        /// <param name="mediation">聚合平台</param>
        /// <param name="mediationId">聚合平台广告id</param>
        public static void ReportLoadBegin(string id, AdType type, AdPlatform platform, string seq,
            Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            DTAdReportWrapper.Instance.ReportLoadBegin(id, type, platform, seq, properties, mediation, mediationId);
        }


        /// <summary>
        ///     上报 广告结束加载
        /// </summary>
        /// <param name="id">广告最小单元id</param>
        /// <param name="type">广告类型</param>
        /// <param name="platform">广告平台</param>
        /// <param name="duration">加载时长</param>
        /// <param name="result">加载结果</param>
        /// <param name="seq">系列行为标识</param>
        /// <param name="errorCode">加载失败错误码</param>
        /// <param name="errorMessage">加载失败错误信息</param>
        /// <param name="properties">自定义属性</param>
        /// <param name="mediation">聚合平台</param>
        /// <param name="mediationId">聚合平台广告id</param>
        public static void ReportLoadEnd(string id, AdType type, AdPlatform platform, long duration, bool result,
            string seq, int errorCode = 0, string errorMessage = "", Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            DTAdReportWrapper.Instance.ReportLoadEnd(id, type, platform, duration, result, seq, errorCode, errorMessage,
                properties, mediation, mediationId);
        }


        /// <summary>
        ///     上报 广告展示请求
        /// </summary>
        /// <param name="id">广告最小单元id</param>
        /// <param name="type">广告类型</param>
        /// <param name="platform">广告平台</param>
        /// <param name="location">广告位</param>
        /// <param name="seq">系列行为标识</param>
        /// <param name="entrance">广告入口</param>
        /// <param name="properties">自定义属性</param>
        /// <param name="mediation">聚合平台</param>
        /// <param name="mediationId">聚合平台广告id</param>
        public static void ReportToShow(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "", Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            DTAdReportWrapper.Instance.ReportToShow(id, type, platform, location, seq, entrance, properties, mediation, mediationId);
        }


        /// <summary>
        ///     上报 广告展示成功
        /// </summary>
        /// <param name="id">广告最小单元id</param>
        /// <param name="type">广告类型</param>
        /// <param name="platform">广告平台</param>
        /// <param name="location">广告位</param>
        /// <param name="seq">系列行为标识</param>
        /// <param name="entrance">广告入口</param>
        /// <param name="properties">自定义属性</param>
        /// <param name="mediation">聚合平台</param>
        /// <param name="mediationId">聚合平台广告id</param>
        public static void ReportShow(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "", Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            DTAdReportWrapper.Instance.ReportShow(id, type, platform, location, seq, entrance, properties, mediation, mediationId);
        }


        /// <summary>
        ///     上报 广告展示失败
        /// </summary>
        /// <param name="id">广告最小单元id</param>
        /// <param name="type">广告类型</param>
        /// <param name="platform">广告平台</param>
        /// <param name="location">广告位</param>
        /// <param name="seq">系列行为标识</param>
        /// <param name="errorCode">加载失败错误码</param>
        /// <param name="errorMessage">加载失败错误信息</param>
        /// <param name="entrance">广告入口</param>
        /// <param name="properties">自定义属性</param>
        /// <param name="mediation">聚合平台</param>
        /// <param name="mediationId">聚合平台广告id</param>
        public static void ReportShowFailed(string id, AdType type, AdPlatform platform, string location, string seq,
            int errorCode = 0, string errorMessage = "", string entrance = "",
            Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            DTAdReportWrapper.Instance.ReportShowFailed(id, type, platform, location, seq, errorCode, errorMessage,
                entrance, properties, mediation, mediationId);
        }


        /// <summary>
        ///     上报 广告关闭
        /// </summary>
        /// <param name="id">广告最小单元id</param>
        /// <param name="type">广告类型</param>
        /// <param name="platform">广告平台</param>
        /// <param name="location">广告位</param>
        /// <param name="seq">系列行为标识</param>
        /// <param name="entrance">广告入口</param>
        /// <param name="properties">自定义属性</param>
        /// <param name="mediation">聚合平台</param>
        /// <param name="mediationId">聚合平台广告id</param>
        public static void ReportClose(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "", Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            DTAdReportWrapper.Instance.ReportClose(id, type, platform, location, seq, entrance, properties, mediation, mediationId);
        }


        /// <summary>
        ///     上报 广告点击
        /// </summary>
        /// <param name="id">广告最小单元id</param>
        /// <param name="type">广告类型</param>
        /// <param name="platform">广告平台</param>
        /// <param name="location">广告位</param>
        /// <param name="seq">系列行为标识</param>
        /// <param name="entrance">广告入口</param>
        /// <param name="properties">自定义属性</param>
        /// <param name="mediation">聚合平台</param>
        /// <param name="mediationId">聚合平台广告id</param>
        public static void ReportClick(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "", Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            DTAdReportWrapper.Instance.ReportClick(id, type, platform, location, seq, entrance, properties, mediation, mediationId);
        }


        /// <summary>
        ///     上报 激励广告已获得奖励
        /// </summary>
        /// <param name="id">广告最小单元id</param>
        /// <param name="type">广告类型</param>
        /// <param name="platform">广告平台</param>
        /// <param name="location">广告位</param>
        /// <param name="seq">系列行为标识</param>
        /// <param name="entrance">广告入口</param>
        /// <param name="properties">自定义属性</param>
        /// <param name="mediation">聚合平台</param>
        /// <param name="mediationId">聚合平台广告id</param>
        public static void ReportRewarded(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "", Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            DTAdReportWrapper.Instance.ReportRewarded(id, type, platform, location, seq, entrance, properties, mediation, mediationId);
        }


        /// <summary>
        ///     上报 访问广告链接，离开当前app(页面)
        /// </summary>
        /// <param name="id">广告最小单元id</param>
        /// <param name="type">广告类型</param>
        /// <param name="platform">广告平台</param>
        /// <param name="location">广告位</param>
        /// <param name="seq">系列行为标识</param>
        /// <param name="entrance">广告入口</param>
        /// <param name="properties">自定义属性</param>
        /// <param name="mediation">聚合平台</param>
        /// <param name="mediationId">聚合平台广告id</param>
        public static void ReportLeftApp(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "", Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            DTAdReportWrapper.Instance.ReportLeftApp(id, type, platform, location, seq, entrance, properties, mediation, mediationId);
        }


        /// <summary>
        ///     上报 自定义转化，通过点击
        /// </summary>
        /// <param name="id">广告最小单元id</param>
        /// <param name="type">广告类型</param>
        /// <param name="platform">广告平台</param>
        /// <param name="location">广告位</param>
        /// <param name="seq">系列行为标识</param>
        /// <param name="entrance">广告入口</param>
        /// <param name="properties">自定义属性</param>
        /// <param name="mediation">聚合平台</param>
        /// <param name="mediationId">聚合平台广告id</param>
        public static void ReportConversionByClick(string id, AdType type, AdPlatform platform, string location,
            string seq, string entrance = "", Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            DTAdReportWrapper.Instance.ReportConversionByClick(id, type, platform, location, seq, entrance,
                properties, mediation, mediationId);
        }

        /// <summary>
        ///     上报 自定义转化，通过跳出app
        /// </summary>
        /// <param name="id">广告最小单元id</param>
        /// <param name="type">广告类型</param>
        /// <param name="platform">广告平台</param>
        /// <param name="location">广告位</param>
        /// <param name="seq">系列行为标识</param>
        /// <param name="entrance">广告入口</param>
        /// <param name="properties">自定义属性</param>
        /// <param name="mediation">聚合平台</param>
        /// <param name="mediationId">聚合平台广告id</param>
        public static void ReportConversionByLeftApp(string id, AdType type, AdPlatform platform, string location,
            string seq, string entrance = "", Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            DTAdReportWrapper.Instance.ReportConversionByLeftApp(id, type, platform, location, seq, entrance,
                properties, mediation, mediationId);
        }

        /// <summary>
        ///     上报 自定义转化，通过获得激励
        /// </summary>
        /// <param name="id">广告最小单元id</param>
        /// <param name="type">广告类型</param>
        /// <param name="platform">广告平台</param>
        /// <param name="location">广告位</param>
        /// <param name="seq">系列行为标识</param>
        /// <param name="entrance">广告入口</param>
        /// <param name="properties">自定义属性</param>
        /// <param name="mediation">聚合平台</param>
        /// <param name="mediationId">聚合平台广告id</param>
        public static void ReportConversionByRewarded(string id, AdType type, AdPlatform platform, string location,
            string seq, string entrance = "", Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            DTAdReportWrapper.Instance.ReportConversionByRewarded(id, type, platform, location, seq, entrance,
                properties, mediation, mediationId);
        }


        /// <summary>
        ///     上报 广告展示价值,适用于单独的广告平台
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
        /// <param name="properties">自定义属性</param>
        /// <param name="mediation">聚合平台</param>
        /// <param name="mediationId">聚合平台广告id</param>
        public static void ReportPaid(string id, AdType type, AdPlatform platform, string location, string seq,
            double value, string currency, string precision, string entrance = "",
            Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            DTAdReportWrapper.Instance.ReportPaid(id, type, platform, location, seq, value, currency, precision,
                entrance, properties, mediation, mediationId);
        }

        /// <summary>
        ///     上报 广告展示价值，适用于聚合广告平台 max
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
        /// <param name="properties">自定义属性</param>
        public static void ReportPaid(string id, AdType type, AdPlatform platform, string location, string seq,
            AdMediation mediation, string mediationId, double value, string precision, string country,
            Dictionary<string, object> properties = null)
        {
            DTAdReportWrapper.Instance.ReportPaid(id, type, platform, location, seq, mediation, mediationId, value,
                precision, country, properties);
        }
    }
}