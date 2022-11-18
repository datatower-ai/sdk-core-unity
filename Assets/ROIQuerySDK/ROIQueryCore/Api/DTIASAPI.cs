using ROIQuery.Wrapper.IAS;

namespace ROIQuery
{
    /**
     * 订阅上报
     */
    public class ROIQueryIASAPI
    {
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
    }
}