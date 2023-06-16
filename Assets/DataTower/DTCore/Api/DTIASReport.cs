using System.Collections.Generic;
using DataTower.Wrapper.IAS;

namespace DataTower
{
    /**
     * 订阅上报
     */
    public class DTIASReport
    {
        /* 对齐 Android SDK 2.0.0
         
        public static void ReportToShow(string iasSeq, string iasPlacement, string iasEntrance = "")
        {
            ROIQueryIASReportWrapper.Instace().ReportShow(iasSeq, iasPlacement, iasEntrance);
        }

        public static void ReportShowSuccess(string iasSeq, string iasPlacement, string iasEntrance = "")
        {
            ROIQueryIASReportWrapper.Instace().ReportShowSuccess(iasSeq, iasPlacement, iasEntrance);
        }

        public static void ReportShowFail(string iasSeq, string iasPlacement, string iasCode, string iasMsg = "",
            string iasEntrance = "")
        {
            ROIQueryIASReportWrapper.Instace().ReportShowFail(iasSeq, iasPlacement, iasCode, iasMsg, iasEntrance);
        }

        public static void ReportSubscribe(string iasSeq, string iasPlacement, string iasSku, string iasOrderId,
            string iasPrice,
            string iasCurrency, string iasEntrance = "")
        {
            ROIQueryIASReportWrapper.Instace().ReportSubscribe(iasSeq, iasPlacement, iasSku, iasOrderId, iasPrice,
                iasCurrency, iasEntrance);
        }

        public static void ReportSusbscribeSuccess(string iasSeq, string iasPlacement, string iasSku, string iasOrderId,
            string iasOriginalOrderId, string iasPrice,
            string iasCurrency, string iasEntrance = "")
        {
            ROIQueryIASReportWrapper.Instace().ReportSusbscribeSuccess(iasSeq, iasPlacement, iasSku, iasOrderId,
                iasOriginalOrderId, iasPrice,
                iasCurrency, iasEntrance);
        }

        public static void ReportSubscribeFail(string iasSeq, string iasPlacement, string iasSku, string iasOrderId,
            string iasOriginalOrderId, string iasPrice,
            string iasCurrency, string iasCode, string iasEntrance = "", string iasMsg = "")
        {
            ROIQueryIASReportWrapper.Instace().ReportSubscribeFail(iasSeq, iasPlacement, iasSku, iasOrderId,
                iasOriginalOrderId, iasPrice,
                iasCurrency, iasCode, iasEntrance, iasMsg);
        }
        */

        /// <summary>
        ///     订阅成功上报
        /// </summary>
        /// <param name="originalOrderId">订单id</param>
        /// <param name="orderId">订单id</param>
        /// <param name="sku">商品id</param>
        /// <param name="price">价格， 如 9.99</param>
        /// <param name="currency">货币，如usd</param>
        /// <param name="properties">自定义属性</param>
        public void ReportSubscribeSuccess(string originalOrderId, string orderId, string sku, double price,
            string currency, Dictionary<string, object> properties)
        {
            ROIQueryIASReportWrapper.Instace()
                .ReportSubscribeSuccess(originalOrderId, orderId, sku, price, currency, properties);
        }
    }
}