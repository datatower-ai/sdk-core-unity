using System.Collections.Generic;

namespace DataTower.Core.Wrapper
{
    public partial class DTIASReportWrapper
    {
        public static DTIASReportWrapper Instace()
        {
            return Nested.Instance;
        }

        public void ReportShow(string seq, string placement, string entrance)
        {
            _reportToShow(seq, placement, entrance);
        }

        public void ReportShowSuccess(string iasSeq, string iasPlacement, string iasEntrance)
        {
            _reportShowSuccess(iasSeq, iasPlacement, iasEntrance);
        }

        public void ReportShowFail(string iasSeq, string iasPlacement, string iasCode, string iasMsg,
            string iasEntrance)
        {
            _reportShowFail(iasSeq, iasPlacement, iasCode, iasMsg, iasEntrance);
        }

        public void ReportSubscribe(string iasSeq, string iasPlacement, string iasSku, string iasOrderId,
            string iasPrice,
            string iasCurrency, string iasEntrance)
        {
            _reportSubscribe(iasSeq, iasPlacement, iasSku, iasOrderId, iasPrice, iasCurrency, iasEntrance);
        }

        public void ReportSusbscribeSuccess(string iasSeq, string iasPlacement, string iasSku, string iasOrderId,
            string iasOriginalOrderId, string iasPrice,
            string iasCurrency, string iasEntrance)
        {
            _reportSusbscribeSuccess(iasSeq, iasPlacement, iasSku, iasOrderId, iasOriginalOrderId, iasPrice,
                iasCurrency, iasEntrance);
        }

        public void ReportSubscribeFail(string iasSeq, string iasPlacement, string iasSku, string iasOrderId,
            string iasOriginalOrderId, string iasPrice,
            string iasCurrency, string iasCode, string iasEntrance, string iasMsg)
        {
            _reportSubscribeFail(iasSeq, iasPlacement, iasSku, iasOrderId, iasOriginalOrderId, iasPrice, iasCurrency,
                iasCode, iasEntrance, iasMsg);
        }

        public void ReportSubscribeSuccess(string originalOrderId, string orderId, string sku, double price,
            string currency, Dictionary<string, object> properties)
        {
            _reportSubscribeSuccess(originalOrderId, orderId, sku, price, currency, properties);
        }

        private class Nested
        {
            internal static readonly DTIASReportWrapper Instance = new DTIASReportWrapper();

            static Nested()
            {
            }
        }
    }
}