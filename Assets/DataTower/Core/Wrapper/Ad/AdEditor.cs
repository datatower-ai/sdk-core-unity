﻿using System.Collections.Generic;

namespace DataTower.Core.Wrapper
{
    public partial class DTAdReportWrapper
    {
#if UNITY_STANDALONE || UNITY_EDITOR
        private void _init()
        {
            R_Log.Debug("Editor Log: calling init.");
        }

        private void _reportLoadBegin(string id, AdType type, AdPlatform platform, string seq,
            Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            R_Log.Debug("Editor Log: calling report load begin.");
            R_Utils.ValidateJsonDictionary(properties);
        }

        private void _reportLoadEnd(string id, AdType type, AdPlatform platform, long duration, bool result, string seq,
            int errorCode, string errorMessage, Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            R_Log.Debug("Editor Log: calling report load end.");
            R_Utils.ValidateJsonDictionary(properties);
        }

        private void _reportToShow(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "", Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            R_Log.Debug("Editor Log: calling reportToShow.");
            R_Utils.ValidateJsonDictionary(properties);
        }


        private void _reportShow(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "", Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            R_Log.Debug("Editor Log: calling reportShow.");
            R_Utils.ValidateJsonDictionary(properties);
        }

        private void _reportClose(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "", Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            R_Log.Debug("Editor Log: calling reportClose.");
            R_Utils.ValidateJsonDictionary(properties);
        }

        private void _reportClick(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "", Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            R_Log.Debug("Editor Log: calling reportClick.");
            R_Utils.ValidateJsonDictionary(properties);
        }

        private void _reportRewarded(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "", Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            R_Log.Debug("Editor Log: calling reportRewarded.");
            R_Utils.ValidateJsonDictionary(properties);
        }

        private void _reportLeftApp(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "", Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            R_Log.Debug("Editor Log: calling reportLeftApp.");
            R_Utils.ValidateJsonDictionary(properties);
        }

        private void _reportConversionByClick(string id, AdType type, AdPlatform platform, string location, string seq,
            string entrance = "", Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            R_Log.Debug("Editor Log: calling reportConversionByClick.");
            R_Utils.ValidateJsonDictionary(properties);
        }

        private void _reportConversionByLeftApp(string id, AdType type, AdPlatform platform, string location,
            string seq, string entrance = "", Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            R_Log.Debug("Editor Log: calling reportConversionByLeftApp.");
            R_Utils.ValidateJsonDictionary(properties);
        }


        private void _reportConversionByRewarded(string id, AdType type, AdPlatform platform, string location,
            string seq, string entrance = "", Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            R_Log.Debug("Editor Log: calling reportConversionByRewarded.");
            R_Utils.ValidateJsonDictionary(properties);
        }

        private void _reportPaid(string id, AdType type, AdPlatform platform, string location, string seq, double value,
            string currency, string precision, string entrance = "", Dictionary<string, object> properties = null, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            R_Log.Debug("Editor Log: calling reportPaid.");
            R_Utils.ValidateJsonDictionary(properties);
        }


        private void _reportPaid(string id, AdType type, string platform, string adgroupName, string adgroupType,
            string location, string seq,
            AdMediation mediation, string mediationId, double value, string currency, string precision, string country,
            string entrance = "", Dictionary<string, object> properties = null)
        {
            R_Log.Debug("Editor Log: calling reportPaid.");
            R_Utils.ValidateJsonDictionary(properties);
        }

        private void _reportPaid(string id, AdType type, AdPlatform platform, string location, string seq,
            AdMediation mediation, string mediationId, double value,
            string precision, string country, Dictionary<string, object> properties = null)
        {
            R_Log.Debug("Editor Log: calling reportPaid.");
            R_Utils.ValidateJsonDictionary(properties);
        }

        private string _generateUUID()
        {
            R_Log.Debug("Editor Log: calling onAppBackgrounded.");
            return "";
        }

        private AdPlatform _getPlatform(AdMediation mediation, string networkName, string networkPlacementId,
            string adgroupName, string adgroupType)
        {
            return AdPlatform.IDLE;
        }

        private void _reportShowFailed(string id, AdType type, AdPlatform platform, string location, string seq,
            int errorCode, string errorMessage, string entrance, Dictionary<string, object> properties, 
            AdMediation mediation = AdMediation.IDLE, 
            string mediationId = "")
        {
            R_Log.Debug("Editor Log: calling reportShowFailed.");
            R_Utils.ValidateJsonDictionary(properties);
        }

        private void _reportReturnApp()
        {
            R_Log.Debug("Editor Log: calling reportReturnApp.");
        }
#endif
    }
}