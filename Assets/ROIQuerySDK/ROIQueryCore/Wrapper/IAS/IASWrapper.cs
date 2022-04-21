using System;

namespace ROIQuery.Wrapper.IAS
{
    public partial class ROIQueryIASReportWrapper
    {
        public static ROIQueryIASReportWrapper Instace()
        {
            return Nested.instance;
        }

        private class Nested
        {
            static Nested()
            {
            }

            internal static readonly ROIQueryIASReportWrapper instance = new ROIQueryIASReportWrapper();
        }

        public void ReportShow(string seq, string placement, string entrance)
        {
            _reportToShow(seq,placement,entrance);
        }

        public  void ReportShowSuccess(string iasSeq, string iasPlacement, string iasEntrance)
        {
            _reportShowSuccess(iasSeq,iasPlacement,iasEntrance);
        }

        public  void ReportShowFail(string iasSeq, string iasPlacement, string iasCode, string iasMsg, string iasEntrance)
        {
            _reportShowFail(iasSeq,iasPlacement,iasCode,iasMsg,iasEntrance);
        }

        public  void ReportSubscribe(string iasSeq, string iasPlacement, string iasSku, string iasOrderId, string iasPrice,
        string iasCurrency, string iasEntrance)
        {
            _reportSubscribe(iasSeq,iasPlacement,iasSku,iasOrderId,iasPrice,iasCurrency,iasEntrance);
        }

        public  void ReportSusbscribeSuccess(string iasSeq, string iasPlacement, string iasSku, string iasOrderId,
        string iasOriginalOrderId, string iasPrice,
        string iasCurrency, string iasEntrance)
        {
            _reportSusbscribeSuccess(iasSeq,iasPlacement,iasSku,iasOrderId,iasOriginalOrderId,iasPrice,iasCurrency,iasEntrance);
        }

        public  void ReportSubscribeFail(string iasSeq, string iasPlacement, string iasSku, string iasOrderId,
        string iasOriginalOrderId, string iasPrice,
        string iasCurrency, string iasCode, string iasEntrance, string iasMsg)
        {
            _reportSubscribeFail(iasSeq,iasPlacement,iasSku,iasOrderId,iasOriginalOrderId,iasPrice,iasCurrency,iasCode,iasEntrance,iasMsg);
        }
    }
}