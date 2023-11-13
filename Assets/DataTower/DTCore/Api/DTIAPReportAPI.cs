using System.Collections.Generic;

namespace DataTower
{
    public class DTIAPReport
    {
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
            DTIAPReportWrapper.Instance.ReportPurchaseSuccess(order, sku, price, currency, properties);
        }
    }
}