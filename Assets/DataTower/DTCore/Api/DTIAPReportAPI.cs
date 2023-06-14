using System.Collections.Generic;

namespace DataTower
{
    public class DTIAPReport
    {
        /* 对齐 Android SDK 2.0.0
         
        /// <summary>
        ///     展示购买入口的时候上报
        /// </summary>
        /// <param name="order">订单id</param>
        /// <param name="sku">商品id</param>
        /// <param name="price">价格， 如 9.99</param>
        /// <param name="currency">货币，如usd</param>
        /// <param name="seq">系列行为标识d</param>
        /// <param name="entrance">入口，可为空</param>
        public static void ReportEntrance(string order, string sku, double price, string currency, string seq,
            string entrance = "")
        {
            ROIQueryIAPReportWrapper.Instance.ReportEntrance(order, sku, price, currency, seq, entrance);
        }

        /// <summary>
        ///     点击购买的时候上报
        /// </summary>
        /// <param name="order">订单id</param>
        /// <param name="sku">商品id</param>
        /// <param name="price">价格， 如 9.99</param>
        /// <param name="currency">货币，如usd</param>
        /// <param name="seq">系列行为标识d</param>
        /// <param name="entrance">入口，可为空</param>
        public static void ReportToPurchase(string order, string sku, double price, string currency, string seq,
            string entrance = "")
        {
            ROIQueryIAPReportWrapper.Instance.ReportToPurchase(order, sku, price, currency, seq, entrance);
        }

        /// <summary>
        ///     购买成功的时候上报，无论是否消耗
        /// </summary>
        /// <param name="order">订单id</param>
        /// <param name="sku">商品id</param>
        /// <param name="price">价格， 如 9.99</param>
        /// <param name="currency">货币，如usd</param>
        /// <param name="seq">系列行为标识d</param>
        /// <param name="entrance">入口，可为空</param>
        public static void ReportPurchased(string order, string sku, double price, string currency, string seq,
            string entrance = "")
        {
            ROIQueryIAPReportWrapper.Instance.ReportPurchased(order, sku, price, currency, seq, entrance);
        }

        /// <summary>
        ///     购买失败的时候上报
        /// </summary>
        /// <param name="order">订单id</param>
        /// <param name="sku">商品id</param>
        /// <param name="price">价格， 如 9.99</param>
        /// <param name="currency">货币，如usd</param>
        /// <param name="seq">系列行为标识d</param>
        /// <param name="code">错误码</param>
        /// <param name="entrance">入口，可为空</param>
        /// <param name="msg">额外信息，可为空</param>
        public static void ReportNotToPurchased(string order, string sku, double price, string currency, string seq,
            string code, string entrance = "", string msg = "")
        {
            ROIQueryIAPReportWrapper.Instance.ReportNotToPurchased(order, sku, price, currency, seq, code, entrance,
                msg);
        }
        */
        
        /// <summary>
        ///     购买成功上报
        /// </summary>
        /// <param name="order">订单id</param>
        /// <param name="sku">商品id</param>
        /// <param name="price">价格， 如 9.99</param>
        /// <param name="currency">货币，如usd</param>
        /// <param name="properties">自定义属性</param>
        public static void ReportPurchaseSuccess(string order, string sku, double price, string currency, 
            Dictionary<string, object> properties = null)
        {
            ROIQueryIAPReportWrapper.Instance.ReportPurchaseSuccess(order, sku, price, currency, properties);
        }

        //todo 下个版本再带上此功能
        /*public static string generateUUID()
        {
            return ROIQueryIAPReportWrapper.Instance.GenerateUUID();
        } */
    }
}