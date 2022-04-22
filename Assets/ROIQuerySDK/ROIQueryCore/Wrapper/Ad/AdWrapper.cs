﻿using System;
using System.Collections.Generic;

namespace ROIQuery
{
    public partial class ROIQueryAdReportWrapper
    {
        private ROIQueryAdReportWrapper()
        {
            _init();
        }

        public static ROIQueryAdReportWrapper Instance
        {
            get { return Nested.instance; }
        }

        private class Nested
        {
            //Explicit static constructor to tell C# compiler
            //not to mark type as beforefieldinit
            static Nested()
            {
            }

            internal static readonly ROIQueryAdReportWrapper instance = new ROIQueryAdReportWrapper();
        }


        public void ReportEntrance(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "", Dictionary<string, object> properties = null)
        {
            _reportEntrance(id, type, platform, location, seq, entrance, properties);
        }

        public void ReportToShow(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",
            Dictionary<string, object> properties = null)
        {
            _reportToShow(id, type, platform, location, seq, entrance, properties);
        }

        public void ReportImpression(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",
            Dictionary<string, object> properties = null)
        {
            _reportImpression(id, type, platform, location, seq, entrance, properties);
        }


        public void ReportShow(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",
            Dictionary<string, object> properties = null)
        {
            _reportShow(id, type, platform, location, seq, entrance, properties);
        }

        public void ReportClose(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",
            Dictionary<string, object> properties = null)
        {
            _reportClose(id, type, platform, location, seq, entrance, properties);
        }

        public void ReportClick(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",
            Dictionary<string, object> properties = null)
        {
            _reportClick(id, type, platform, location, seq, entrance, properties);
        }

        public void ReportRewarded(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",
            Dictionary<string, object> properties = null)
        {
            _reportRewarded(id, type, platform, location, seq, entrance, properties);
        }

        public void ReportLeftApp(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",
            Dictionary<string, object> properties = null)
        {
            _reportLeftApp(id, type, platform, location, seq, entrance, properties);
        }

        public void ReportConversionByClick(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",
            Dictionary<string, object> properties = null)
        {
            _reportConversionByClick(id, type, platform, location, seq, entrance, properties);
        }

        public void ReportConversionByLeftApp(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",
            Dictionary<string, object> properties = null)
        {
            _reportConversionByLeftApp(id, type, platform, location, seq, entrance, properties);
        }

        public void ReportConversionByImpression(string id, AdType type, AdPlatform platform, string location,
            string seq, string entrance = "",
            Dictionary<string, object> properties = null)
        {
            _reportConversionByImpression(id, type, platform, location, seq, entrance, properties);
        }

        public void ReportConversionByRewarded(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "",
            Dictionary<string, object> properties = null)
        {
            _reportConversionByRewarded(id, type, platform, location, seq, entrance, properties);
        }

        public void ReportPaid(string id, AdType type, AdPlatform platform, string location, string seq, string value,
            string currency, string precision, string entrance = "",
            Dictionary<string, object> properties = null)
        {
            _reportPaid(id, type, platform, location, seq, value, currency, precision, entrance, properties);
        }

        public void ReportPaid(string id, AdType type, string platform, string adgroupName,string adgroupType, string location, string seq,
            AdMediation mediation, string mediationId, string value, string currency, string precision, string country,
            string entrance = "",
            Dictionary<string, object> properties = null)
        {
            _reportPaid(id, type, platform, adgroupName,adgroupType, location, seq, mediation, mediationId, value, currency,
                precision, country, entrance, properties);
        }
        
        public void ReportPaid(string id, AdType type, AdPlatform platform, string location, string seq,AdMediation mediation, string mediationId,  string value,
            string precision, string country, Dictionary<string, object> properties = null)
        {
            _reportPaid(id, type, platform, location, seq, mediation, mediationId, value, precision, country, properties);
                
        }

        public string GenerateUUID()
        {
            return _generateUUID();
        }

        public AdPlatform GetPlatform(AdMediation mediation, string networkName,string adgroupName,  string networkPlacementId,
            string adgroupType)
        {
            return _getPlatform(mediation, networkName, networkPlacementId,adgroupName, adgroupType);
        }
    }
}