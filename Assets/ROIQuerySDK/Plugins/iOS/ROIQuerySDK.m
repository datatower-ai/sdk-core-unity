#if __has_include(<ROIQueryCore/ROIQueryCore-Swift.h>)
#import <ROIQueryCore/ROIQueryCore-Swift.h>
#else
#import <ROIQueryCore/ROIQueryCore-Swift.h>

#endif
#import <Foundation/Foundation.h>


typedef void (*ConfigCallback)(BOOL isSuccess, const char *errorMessage);


// tools
void changeToDictionary(const char *json, NSDictionary **properties_dict) {
    NSString *json_string = json != NULL ? [NSString stringWithUTF8String:json] : nil;
    if (json_string) {
        *properties_dict = [NSJSONSerialization JSONObjectWithData:[json_string dataUsingEncoding:NSUTF8StringEncoding] options:kNilOptions error:nil];
    }
}

char* roiStrdup(const char* string) {
    if (string == NULL)
        return NULL;
    char* res = (char*)malloc(strlen(string) + 1);
    strcpy(res, string);
    return res;
}

// ROIQueryAnalytics
void initSDK(const char *appId ,BOOL isDebug, int logLevel, const char *properties){
    NSString *app_id_string = appId != NULL ? [NSString stringWithUTF8String:appId] : nil;
    NSDictionary *properties_dict = nil;
    changeToDictionary(properties, &properties_dict);
    [DT initSDKWithAppid:app_id_string channel:DTChannelAPPSTORE isDebug:isDebug logLevel:logLevel commonProperties:properties_dict];
}

void roiTrack(const char *event_name, const char *properties){
    NSString *event_name_string = event_name != NULL ? [NSString stringWithUTF8String:event_name] : nil;
    NSDictionary *properties_dict = nil;
    changeToDictionary(properties, &properties_dict);
    [DTAnalytics trackWithEventName:event_name_string properties:properties_dict];
}

void setAccountId(const char *accountId){
    NSString *accountId_string = accountId != NULL ? [NSString stringWithUTF8String:accountId] : nil;
    [DTAnalytics setAccountIdWithAccountId:accountId_string];
}

void setFirebaseAppInstanceId(const char *fid){
    NSString *fid_string = fid != NULL ? [NSString stringWithUTF8String:fid] : nil;
    [DTAnalytics setAccountIdWithAccountId:fid_string];
}

void setKochavaId(const char *koid){
    NSString *id_string = koid != NULL ? [NSString stringWithUTF8String:koid] : nil;
    [DTAnalytics setKochavaIDWithKoid:id_string];
}

void setAppsFlyerId(const char *afid){
    NSString *id_string = afid != NULL ? [NSString stringWithUTF8String:afid] : nil;
    [DTAnalytics setAppsFlyerIDWithAfuid:id_string];
}

void setAdjust(const char *afid){
    NSString *id_string = afid != NULL ? [NSString stringWithUTF8String:afid] : nil;
    [DTAnalytics setAdjustIdWithAdjustId:id_string];
}

void userSet(const char *properties){
    NSDictionary *properties_dict = nil;
    changeToDictionary(properties, &properties_dict);
    [DTAnalytics userSetWithProperties:properties_dict];
}

void userSetOnce(const char *properties){
    NSDictionary *properties_dict = nil;
    changeToDictionary(properties, &properties_dict);
    [DTAnalytics userSetOnceWithProperties:properties_dict];
}

void userAppend(const char *properties){
    NSDictionary *properties_dict = nil;
    changeToDictionary(properties, &properties_dict);
    [DTAnalytics userAppendWithProperties:properties_dict];
}

void userAdd(const char *properties){
    NSDictionary *properties_dict = nil;
    changeToDictionary(properties, &properties_dict);
    [DTAnalytics userAddWithProperties:properties_dict];
}

////todo 待更新
//void userUnset(const char[] properties){
//
//}

void userDelete(){
    [DTAnalytics userDelete];
}

NSString* getDataTowerId(){
    return [DTAnalytics getDataTowerId];
}

// ad
void reportLoadBegin(const char *adId, int type, int platform, const char *seq, const char  *properties){
    NSString *ad_id_string = adId != NULL ? [NSString stringWithUTF8String:adId] : nil;
    NSString *ad_seq_string = seq != NULL ? [NSString stringWithUTF8String:seq] : nil;
    NSDictionary *properties_dict = nil;
    changeToDictionary(properties, &properties_dict);
    [DTAdReport reportLoadBeginWithId:ad_id_string type:type platform:platform seq:ad_seq_string properties:properties_dict];
}

void reportLoadEnd(const char * adId, int type, int platform, long duration, bool result, const char * seq, int errorCode, const char * errorMessage, const char * properties){
    NSString *ad_id_string = adId != NULL ? [NSString stringWithUTF8String:adId] : nil;
    NSString *ad_seq_string = seq != NULL ? [NSString stringWithUTF8String:seq] : nil;
    NSString *ad_error_message_string = errorMessage != NULL ? [NSString stringWithUTF8String:errorMessage] : nil;
    
    NSDictionary *properties_dict = nil;
    changeToDictionary(properties, &properties_dict);
    
    [DTAdReport reportLoadEndWithId:ad_id_string type:type platform:platform duration:duration result:result seq:ad_seq_string errorCode:errorCode errorMessage:ad_error_message_string properties:properties_dict];
}

void reportToShow(const char *ad_id, int type, int platform, const char *location, const char *seq,const char *properties, const char *entrance){
    NSString *ad_id_string = ad_id != NULL ? [NSString stringWithUTF8String:ad_id] : nil;
    NSString *ad_location_string = location != NULL ? [NSString stringWithUTF8String:location] : nil;
    NSString *ad_seq_string = seq != NULL ? [NSString stringWithUTF8String:seq] : nil;
    NSString *ad_entrance_string = entrance != NULL ? [NSString stringWithUTF8String:entrance] : nil;
    NSDictionary *properties_dict = nil;
    changeToDictionary(properties, &properties_dict);
    [DTAdReport
     reportToShowWithId:ad_id_string
     type:type
     platform:platform
     location:ad_location_string
     seq:ad_seq_string
     properties:properties_dict
     entrance:ad_entrance_string];
}

void reportShow(const char *ad_id, int type, int platform, const char *location, const char *seq,const char *properties, const char *entrance){
    NSString *ad_id_string = ad_id != NULL ? [NSString stringWithUTF8String:ad_id] : nil;
    NSString *ad_location_string = location != NULL ? [NSString stringWithUTF8String:location] : nil;
    NSString *ad_seq_string = seq != NULL ? [NSString stringWithUTF8String:seq] : nil;
    NSString *ad_entrance_string = entrance != NULL ? [NSString stringWithUTF8String:entrance] : nil;
    NSDictionary *properties_dict = nil;
    changeToDictionary(properties, &properties_dict);
    [DTAdReport
     reportShowWithId:ad_id_string
     type:type
     platform:platform
     location:ad_location_string
     seq:ad_seq_string
     properties:properties_dict
     entrance:ad_entrance_string];
}


void reportClose(const char *ad_id, int type, int platform, const char *location, const char *seq,const char *properties, const char *entrance){
    NSString *ad_id_string = ad_id != NULL ? [NSString stringWithUTF8String:ad_id] : nil;
    NSString *ad_location_string = location != NULL ? [NSString stringWithUTF8String:location] : nil;
    NSString *ad_seq_string = seq != NULL ? [NSString stringWithUTF8String:seq] : nil;
    NSString *ad_entrance_string = entrance != NULL ? [NSString stringWithUTF8String:entrance] : nil;
    NSDictionary *properties_dict = nil;
    changeToDictionary(properties, &properties_dict);
    [DTAdReport
     reportCloseWithId:ad_id_string
     type:type
     platform:platform
     location:ad_location_string
     seq:ad_seq_string
     properties:properties_dict
     entrance:ad_entrance_string];
}


void reportClick(const char *ad_id, int type, int platform, const char *location, const char *seq,const char *properties, const char *entrance){
    NSString *ad_id_string = ad_id != NULL ? [NSString stringWithUTF8String:ad_id] : nil;
    NSString *ad_location_string = location != NULL ? [NSString stringWithUTF8String:location] : nil;
    NSString *ad_seq_string = seq != NULL ? [NSString stringWithUTF8String:seq] : nil;
    NSString *ad_entrance_string = entrance != NULL ? [NSString stringWithUTF8String:entrance] : nil;
    NSDictionary *properties_dict = nil;
    changeToDictionary(properties, &properties_dict);
    [DTAdReport
     reportClickWithId:ad_id_string
     type:type
     platform:platform
     location:ad_location_string
     seq:ad_seq_string
     properties:properties_dict
     entrance:ad_entrance_string];
}



void reportRewarded(const char *ad_id, int type, int platform, const char *location, const char *seq,const char *properties, const char *entrance){
    NSString *ad_id_string = ad_id != NULL ? [NSString stringWithUTF8String:ad_id] : nil;
    NSString *ad_location_string = location != NULL ? [NSString stringWithUTF8String:location] : nil;
    NSString *ad_seq_string = seq != NULL ? [NSString stringWithUTF8String:seq] : nil;
    NSString *ad_entrance_string = entrance != NULL ? [NSString stringWithUTF8String:entrance] : nil;
    NSDictionary *properties_dict = nil;
    changeToDictionary(properties, &properties_dict);
    [DTAdReport
     reportRewardedWithId:ad_id_string
     type:type
     platform:platform
     location:ad_location_string
     seq:ad_seq_string
     properties:properties_dict
     entrance:ad_entrance_string];
}


void reportLeftApp(const char *ad_id, int type, int platform, const char *location, const char *seq,const char *properties, const char *entrance){
    NSString *ad_id_string = ad_id != NULL ? [NSString stringWithUTF8String:ad_id] : nil;
    NSString *ad_location_string = location != NULL ? [NSString stringWithUTF8String:location] : nil;
    NSString *ad_seq_string = seq != NULL ? [NSString stringWithUTF8String:seq] : nil;
    NSString *ad_entrance_string = entrance != NULL ? [NSString stringWithUTF8String:entrance] : nil;
    NSDictionary *properties_dict = nil;
    changeToDictionary(properties, &properties_dict);
    [DTAdReport
     reportLeftAppWithId:ad_id_string
     type:type
     platform:platform
     location:ad_location_string
     seq:ad_seq_string
     properties:properties_dict
     entrance:ad_entrance_string];
}


void reportConversionByClick(const char *ad_id, int type, int platform, const char *location, const char *seq,const char *properties, const char *entrance){
    NSString *ad_id_string = ad_id != NULL ? [NSString stringWithUTF8String:ad_id] : nil;
    NSString *ad_location_string = location != NULL ? [NSString stringWithUTF8String:location] : nil;
    NSString *ad_seq_string = seq != NULL ? [NSString stringWithUTF8String:seq] : nil;
    NSString *ad_entrance_string = entrance != NULL ? [NSString stringWithUTF8String:entrance] : nil;
    NSDictionary *properties_dict = nil;
    changeToDictionary(properties, &properties_dict);
    [DTAdReport
     reportConversionByClickWithId:ad_id_string
     type:type
     platform:platform
     location:ad_location_string
     seq:ad_seq_string
     properties:properties_dict
     entrance:ad_entrance_string];
}



void reportConversionByLeftApp(const char *ad_id, int type, int platform, const char *location, const char *seq,const char *properties, const char *entrance){
    NSString *ad_id_string = ad_id != NULL ? [NSString stringWithUTF8String:ad_id] : nil;
    NSString *ad_location_string = location != NULL ? [NSString stringWithUTF8String:location] : nil;
    NSString *ad_seq_string = seq != NULL ? [NSString stringWithUTF8String:seq] : nil;
    NSString *ad_entrance_string = entrance != NULL ? [NSString stringWithUTF8String:entrance] : nil;
    NSDictionary *properties_dict = nil;
    changeToDictionary(properties, &properties_dict);
    [DTAdReport
     reportConversionByLeftAppWithId:ad_id_string
     type:type
     platform:platform
     location:ad_location_string
     seq:ad_seq_string
     properties:properties_dict
     entrance:ad_entrance_string];
}


void reportConversionByRewarded(const char *ad_id, int type, int platform, const char *location, const char *seq,const char *properties, const char *entrance){
    NSString *ad_id_string = ad_id != NULL ? [NSString stringWithUTF8String:ad_id] : nil;
    NSString *ad_location_string = location != NULL ? [NSString stringWithUTF8String:location] : nil;
    NSString *ad_seq_string = seq != NULL ? [NSString stringWithUTF8String:seq] : nil;
    NSString *ad_entrance_string = entrance != NULL ? [NSString stringWithUTF8String:entrance] : nil;
    NSDictionary *properties_dict = nil;
    changeToDictionary(properties, &properties_dict);
    [DTAdReport
     reportConversionByRewardedWithId:ad_id_string
     type:type
     platform:platform
     location:ad_location_string
     seq:ad_seq_string
     properties:properties_dict
     entrance:ad_entrance_string];
}


void reportPaid(const char *ad_id, int type, int platform, const char *location, const char *seq,const char *value,const char *currency,const char *precision,
                const char *properties,const char *entrance){
    NSString *ad_id_string = ad_id != NULL ? [NSString stringWithUTF8String:ad_id] : nil;
    NSString *ad_location_string = location != NULL ? [NSString stringWithUTF8String:location] : nil;
    NSString *ad_seq_string = seq != NULL ? [NSString stringWithUTF8String:seq] : nil;
    NSString *ad_value_string = value != NULL ? [NSString stringWithUTF8String:value] : nil;
    NSString *ad_currency_string = currency != NULL ? [NSString stringWithUTF8String:currency] : nil;
    NSString *ad_precision_string = precision != NULL ? [NSString stringWithUTF8String:precision] : nil;
    NSString *ad_entrance_string = entrance != NULL ? [NSString stringWithUTF8String:entrance] : nil;
    NSDictionary *properties_dict = nil;
    changeToDictionary(properties, &properties_dict);
    [DTAdReport
     reportPaidWithId:ad_id_string
     type:type
     platform:platform
     location:ad_location_string
     seq:ad_seq_string
     value:ad_value_string
     currency:ad_currency_string
     precision:ad_precision_string
     properties:properties_dict
     entrance:ad_entrance_string];
}


void reportPaidWithMediation(const char *ad_id, int type, const char *platform,const char *adgroupType, const char *location, const char *seq, int mediation, const char *mediationId,
                const char *value,const char *currency,const char *precision,const char *country,const char *properties, const char *entrance){
    NSString *ad_id_string = ad_id != NULL ? [NSString stringWithUTF8String:ad_id] : nil;
    NSString *ad_platform_string = platform != NULL ? [NSString stringWithUTF8String:platform] : nil;
    NSString *ad_adgroupType_string = platform != NULL ? [NSString stringWithUTF8String:adgroupType] : nil;
    NSString *ad_location_string = location != NULL ? [NSString stringWithUTF8String:location] : nil;
    NSString *ad_seq_string = seq != NULL ? [NSString stringWithUTF8String:seq] : nil;
    NSString *ad_mediationId_string = mediationId != NULL ? [NSString stringWithUTF8String:mediationId] : nil;
    NSString *ad_value_string = value != NULL ? [NSString stringWithUTF8String:value] : nil;
    NSString *ad_currency_string = currency != NULL ? [NSString stringWithUTF8String:currency] : nil;
    NSString *ad_precision_string = precision != NULL ? [NSString stringWithUTF8String:precision] : nil;
    NSString *ad_country_string = country != NULL ? [NSString stringWithUTF8String:country] : nil;
    NSString *ad_entrance_string = entrance != NULL ? [NSString stringWithUTF8String:entrance] : nil;
    
    NSDictionary *properties_dict = nil;
    changeToDictionary(properties, &properties_dict);
    
    [DTAdReport
     reportPaidWithId:ad_id_string
     type:type
     platform:ad_platform_string
     adgroupType:ad_adgroupType_string
     location:ad_location_string
     seq:ad_seq_string
     mediation:mediation
     mediationId:ad_mediationId_string
     value:ad_value_string
     currency:ad_currency_string
     precision:ad_precision_string
     country:ad_country_string
     properties:properties_dict
     entrance:ad_entrance_string];
}

int getPlatform(int mediation,const char *networkName,const char *networkPlacementId,const char *adgroupType){
    NSString *networkName_string = networkName != NULL ? [NSString stringWithUTF8String:networkName] : nil;
    NSString *networkPlacementId_string = networkPlacementId != NULL ? [NSString stringWithUTF8String:networkPlacementId] : nil;
    NSString *adgroupType_string = adgroupType != NULL ? [NSString stringWithUTF8String:adgroupType] : nil;
    
    return [DTAdReport
    getPlatformWithMediation:mediation
    networkName:networkName_string
    networkPlacementId:networkPlacementId_string
    adgroupType:adgroupType_string];
}

// iap
void reportIapEntrance(const char *order, const char *sku, double price, const char *currency, const char *seq,const char *entrance){
    NSString *order_string = order != NULL ? [NSString stringWithUTF8String:order] : nil;
    NSString *sku_string = sku != NULL ? [NSString stringWithUTF8String:sku] : nil;
    NSString *currency_string = currency != NULL ? [NSString stringWithUTF8String:currency] : nil;
    NSString *seq_string = seq != NULL ? [NSString stringWithUTF8String:seq] : nil;
    NSString *entrance_string = entrance != NULL ? [NSString stringWithUTF8String:entrance] : nil;
    [DTIAPReport reportEntranceWithOrder:order_string sku:sku_string price:price currency:currency_string seq:seq_string placement:entrance_string];
}

void reportToPurchase(const char *order, const char *sku, double price, const char *currency, const char *seq, const char *entrance){
    NSString *order_string = order != NULL ? [NSString stringWithUTF8String:order] : nil;
    NSString *sku_string = sku != NULL ? [NSString stringWithUTF8String:sku] : nil;
    NSString *currency_string = currency != NULL ? [NSString stringWithUTF8String:currency] : nil;
    NSString *seq_string = seq != NULL ? [NSString stringWithUTF8String:seq] : nil;
    NSString *entrance_string = entrance != NULL ? [NSString stringWithUTF8String:entrance] : nil;
    [DTIAPReport reportToPurchaseWithOrder:order_string sku:sku_string price:price currency:currency_string seq:seq_string placement:entrance_string];
}

void reportPurchased(const char *order, const char *sku, double price, const char *currency,  const char *seq,const char *entrance){
    NSString *order_string = order != NULL ? [NSString stringWithUTF8String:order] : nil;
    NSString *sku_string = sku != NULL ? [NSString stringWithUTF8String:sku] : nil;
    NSString *currency_string = currency != NULL ? [NSString stringWithUTF8String:currency] : nil;
    NSString *seq_string = seq != NULL ? [NSString stringWithUTF8String:seq] : nil;
    NSString *entrance_string = entrance != NULL ? [NSString stringWithUTF8String:entrance] : nil;
    [DTIAPReport reportPurchasedWithOrder:order_string sku:sku_string price:price currency:currency_string seq:seq_string placement:entrance_string];
}

void reportNotToPurchased(const char *order, const char *sku, double price, const char *currency,
                          const char *seq, const char *code, const char *entrance, const char *msg ){
    NSString *order_string = order != NULL ? [NSString stringWithUTF8String:order] : nil;
    NSString *sku_string = sku != NULL ? [NSString stringWithUTF8String:sku] : nil;
    NSString *currency_string = currency != NULL ? [NSString stringWithUTF8String:currency] : nil;
    NSString *seq_string = seq != NULL ? [NSString stringWithUTF8String:seq] : nil;
    NSString *code_string = code != NULL ? [NSString stringWithUTF8String:code] : nil;
    NSString *entrance_string = entrance != NULL ? [NSString stringWithUTF8String:entrance] : nil;
    NSString *msg_string = msg != NULL ? [NSString stringWithUTF8String:msg] : nil;
    [DTIAPReport reportNotToPurchasedWithOrder:order_string sku:sku_string price:price currency:currency_string seq:seq_string code:code_string msg:msg_string placement:entrance_string];
    
}
// ias

void reportIasToShow(const char * iasSeq, const char * iasEntrance, const char * iasPlacement){
    NSString *seq_string = iasSeq != NULL ? [NSString stringWithUTF8String:iasSeq] : nil;
    NSString *entrance_string = iasEntrance != NULL ? [NSString stringWithUTF8String:iasEntrance] : nil;
    NSString *placement_string = iasPlacement != NULL ? [NSString stringWithUTF8String:iasPlacement] : nil;
    
    [DTIASReport reportToShowWithIasSeq:seq_string iasEntrance:entrance_string iasPlacement:placement_string];
    
}

void reportShowSuccess(const char * iasSeq, const char * iasEntrance, const char * iasPlacement){
    NSString *seq_string = iasSeq != NULL ? [NSString stringWithUTF8String:iasSeq] : nil;
    NSString *entrance_string = iasEntrance != NULL ? [NSString stringWithUTF8String:iasEntrance] : nil;
    NSString *placement_string = iasPlacement != NULL ? [NSString stringWithUTF8String:iasPlacement] : nil;
    
    [DTIASReport reportShowSuccessWithIasSeq:seq_string iasEntrance:entrance_string iasPlacement:placement_string];
}

void reportShowFail(const char * iasSeq, const char * iasEntrance, const char * iasPlacement, const char * iasCode, const char * iasMsg){
    NSString *seq_string = iasSeq != NULL ? [NSString stringWithUTF8String:iasSeq] : nil;
    NSString *entrance_string = iasEntrance != NULL ? [NSString stringWithUTF8String:iasEntrance] : nil;
    NSString *placement_string = iasPlacement != NULL ? [NSString stringWithUTF8String:iasPlacement] : nil;
    NSString *code_string = iasCode != NULL ? [NSString stringWithUTF8String:iasCode] : nil;
    NSString *msg_string = iasMsg != NULL ? [NSString stringWithUTF8String:iasMsg] : nil;
    [DTIASReport reportShowFailWithIasSeq:seq_string  iasEntrance:entrance_string iasPlacement:placement_string
                                  iasCode:code_string iasMsg:msg_string
     ];
}

void reportSubscribe(const char * iasSeq, const char * iasEntrance, const char * iasPlacement, const char * iasSku, const char * iasOrderId,
                     const char * iasPrice,const char * iasCurrency){
    NSString *seq_string = iasSeq != NULL ? [NSString stringWithUTF8String:iasSeq] : nil;
    NSString *entrance_string = iasEntrance != NULL ? [NSString stringWithUTF8String:iasEntrance] : nil;
    NSString *placement_string = iasPlacement != NULL ? [NSString stringWithUTF8String:iasPlacement] : nil;
    NSString *sku_string = iasSku != NULL ? [NSString stringWithUTF8String:iasSku] : nil;
    NSString *orderId_string = iasOrderId != NULL ? [NSString stringWithUTF8String:iasOrderId] : nil;
    NSString *price_string = iasPrice != NULL ? [NSString stringWithUTF8String:iasPrice] : nil;
    NSString *currency_string = iasCurrency != NULL ? [NSString stringWithUTF8String:iasCurrency] : nil;
    [DTIASReport reportSubscribeWithIasSeq:seq_string iasEntrance:entrance_string iasPlacement:placement_string iasSku:sku_string iasOrderId:orderId_string iasPrice:price_string iasCurrency:currency_string
     ];
}

void reportSubscribeFail(const char *  iasSeq,const char *  iasEntrance,const char *  iasPlacement,const char *  iasSku,const char *  iasOrderId,
                         const char *  iasOriginalOrderId,const char *  iasPrice,const char *  iasCurrency,const char *  iasCode,const char *  iasMsg){
    NSString *seq_string = iasSeq != NULL ? [NSString stringWithUTF8String:iasSeq] : nil;
    NSString *entrance_string = iasEntrance != NULL ? [NSString stringWithUTF8String:iasEntrance] : nil;
    NSString *placement_string = iasPlacement != NULL ? [NSString stringWithUTF8String:iasPlacement] : nil;
    NSString *sku_string = iasSku != NULL ? [NSString stringWithUTF8String:iasSku] : nil;
    NSString *orderId_string = iasOrderId != NULL ? [NSString stringWithUTF8String:iasOrderId] : nil;
    NSString *orignalOrderId_string = iasOriginalOrderId != NULL ? [NSString stringWithUTF8String:iasOriginalOrderId] : nil;
    NSString *price_string = iasPrice != NULL ? [NSString stringWithUTF8String:iasPrice] : nil;
    NSString *currency_string = iasCurrency != NULL ? [NSString stringWithUTF8String:iasCurrency] : nil;
    NSString *code_string = iasCode != NULL ? [NSString stringWithUTF8String:iasCode] : nil;
    NSString *msg_string = iasMsg != NULL ? [NSString stringWithUTF8String:iasMsg] : nil;
    
    [DTIASReport reportSubscribeFailWithIasSeq:seq_string  iasEntrance:entrance_string iasPlacement:placement_string
                                    iasSku:sku_string iasOrderId:orderId_string iasOriginalOrderId:orignalOrderId_string
                                      iasPrice:price_string iasCurrency:currency_string
                                       iasCode:code_string iasMsg:msg_string
     ];
}


//DTAnalyticsUtils
void trackTimerStart(const char * eventName){
    NSString *eventName_string = eventName != NULL ? [NSString stringWithUTF8String:eventName] : nil;
    [DTAnalyticsUtils trackTimerStartWithEventName:eventName_string];
}

void trackTimerPause(const char * eventName){
    NSString *eventName_string = eventName != NULL ? [NSString stringWithUTF8String:eventName] : nil;
    [DTAnalyticsUtils trackTimerPauseWithEventName:eventName_string];
}

void trackTimerResume(const char * eventName){
    NSString *eventName_string = eventName != NULL ? [NSString stringWithUTF8String:eventName] : nil;
    [DTAnalyticsUtils trackTimerResumeWithEventName:eventName_string];
}

void trackTimerEnd(const char * eventName,const char *properties){
    NSString *eventName_string = eventName != NULL ? [NSString stringWithUTF8String:eventName] : nil;
    NSDictionary *properties_dict = nil;
    changeToDictionary(properties, &properties_dict);
    
    //todo 待更新
//    [DTAnalyticsUtils trackTimerEndWithEventName:eventName_string properties:properties_dict]
}
