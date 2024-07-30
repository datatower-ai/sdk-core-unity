using System.Collections.Generic;
using DataTower.Core.Wrapper;

namespace DataTower.Core
{
    public class DTIAPReport
    {
        /// <summary>
        ///     购买成功上报 (Android)
        /// </summary>
        /// <param name="order">订单id</param>
        /// <param name="sku">商品id</param>
        /// <param name="price">价格， 如 9.99</param>
        /// <param name="currency">货币，如usd</param>
        /// <param name="properties">自定义属性</param>
        public static void ReportPurchaseSuccessAndroid(string order, string sku, double price, string currency, 
            Dictionary<string, object> properties = null)
        {
            DTIAPReportWrapper.Instance.ReportPurchaseSuccess(order, sku, price, currency, properties);
        }
        
        
        /// <summary>
        ///     购买成功上报 (iOS)
        /// </summary>
        /// <param name="order">订单id</param>
        /// <param name="sku">商品id</param>
        /// <param name="price">价格， 如 9.99</param>
        /// <param name="currency">货币，如usd</param>
        /// <param name="seq">标识</param>
        /// <param name="entrance">入口</param>
        public static void ReportPurchaseSuccessIos(string order, string sku, double price, string currency, 
            string seq, string entrance = "")
        {
            DTIAPReportWrapper.Instance.ReportPurchased(order, sku, price, currency, seq, entrance);
        }
    }
}