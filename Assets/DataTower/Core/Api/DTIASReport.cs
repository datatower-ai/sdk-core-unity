using System.Collections.Generic;
using DataTower.Core.Wrapper;

namespace DataTower.Core
{
    /**
     * 订阅上报
     */
    public class DTIASReport
    {
        /// <summary>
        ///     订阅成功上报
        /// </summary>
        /// <param name="originalOrderId">订单id</param>
        /// <param name="orderId">订单id</param>
        /// <param name="sku">商品id</param>
        /// <param name="price">价格， 如 9.99</param>
        /// <param name="currency">货币，如usd</param>
        /// <param name="properties">自定义属性</param>
        public static void ReportSubscribeSuccessAndroid(string originalOrderId, string orderId, string sku, double price,
            string currency, Dictionary<string, object> properties)
        {
            DTIASReportWrapper.Instace()
                .ReportSubscribeSuccess(originalOrderId, orderId, sku, price, currency, properties);
        }

        public static void ReportSubscribeSuccessIos(string seq, string placement, string sku, string orderId,
            string originalOrderId, string price, string currency, string entrance)
        {
            DTIASReportWrapper.Instace()
                .ReportSusbscribeSuccess(seq, placement, sku, orderId, originalOrderId, price, currency, entrance);
        }
    }
}