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
    [ROIQuery initSDKWithAppid:app_id_string channel:ROIQueryChannelAPPSTORE isDebug:isDebug logLevel:logLevel commonProperties:properties_dict];
}

void roiTrack(const char *event_name, const char *properties){
    NSString *event_name_string = event_name != NULL ? [NSString stringWithUTF8String:event_name] : nil;
    NSDictionary *properties_dict = nil;
    changeToDictionary(properties, &properties_dict);
    [ROIQueryAnalytics trackWithEventName:event_name_string properties:properties_dict];
}

void roiFlush(){
    [ROIQueryAnalytics flush];
}

void trackPageOpen(const char *properties){
    NSDictionary *properties_dict = nil;
    changeToDictionary(properties, &properties_dict);
    [ROIQueryAnalytics trackPageOpenWithProperties:properties_dict];
}


void trackPageClose(const char *properties){
    NSDictionary *properties_dict = nil;
    changeToDictionary(properties, &properties_dict);
    [ROIQueryAnalytics trackPageCloseWithProperties:properties_dict];
}


void trackAppClose(const char *properties){
    NSDictionary *properties_dict = nil;
    changeToDictionary(properties, &properties_dict);
    [ROIQueryAnalytics trackAppCloseWithProperties:properties_dict];
}


void setAccountId(const char *accountId){
    NSString *accountId_string = accountId != NULL ? [NSString stringWithUTF8String:accountId] : nil;
    [ROIQueryAnalytics setAccountIdWithAccountId:accountId_string];
}

void setFirebaseAppInstanceId(const char *fid){
    NSString *fid_string = fid != NULL ? [NSString stringWithUTF8String:fid] : nil;
    [ROIQueryAnalytics setAccountIdWithAccountId:fid_string];
}

void setKochavaId(const char *koid){
    NSString *id_string = koid != NULL ? [NSString stringWithUTF8String:koid] : nil;
    [ROIQueryAnalytics setKochavaIDWithKoid:id_string];
}

void setAppsFlyerId(const char *afid){
    NSString *id_string = afid != NULL ? [NSString stringWithUTF8String:afid] : nil;
    [ROIQueryAnalytics setAppsFlyerIDWithAfuid:id_string];
}

void setUserProperties(const char *properties){
    NSDictionary *properties_dict = nil;
    changeToDictionary(properties, &properties_dict);
    [ROIQueryAnalytics setUserPropertiesWithProperties:properties_dict];
}

void onAppForeground(){
    [ROIQueryAnalytics onAppForeground];
}

void onAppBackground(){
    [ROIQueryAnalytics onAppBackground];
}

// cloud config


void fetchWithCallback(ConfigCallback callback){
    [ROIQueryCloudConfig
     fetchWithSuccess:^(void){
        NSLog(@"Success");
        callback(true,"");
    }
     error:^(NSString * _Nullable msg){
        NSLog(@"Error");
        callback(false,roiStrdup([msg UTF8String]));
    }];
}

int getInt(const char *key, int default_value){
    NSString *key_string = key != NULL ? [NSString stringWithUTF8String:key] : nil;
    NSNumber *number = [NSNumber numberWithInt:default_value];
    return [[ROIQueryCloudConfig getNumberWithKey:key_string fallback:number] intValue];
}

double getDouble(const char *key, double default_value){
    NSString *key_string = key != NULL ? [NSString stringWithUTF8String:key] : nil;
    NSNumber *number = [NSNumber numberWithDouble:default_value];
    return [[ROIQueryCloudConfig getNumberWithKey:key_string fallback:number] doubleValue];
}

long getLong(const char *key, long default_value){
    NSString *key_string = key != NULL ? [NSString stringWithUTF8String:key] : nil;
    NSNumber *number = [NSNumber numberWithLong:default_value];
    return [[ROIQueryCloudConfig getNumberWithKey:key_string fallback:number] longValue];
}

const char* getString(const char *key, const char *default_value){
    NSString *key_string = key != NULL ? [NSString stringWithUTF8String:key] : nil;
    NSString *key_value = default_value != NULL ? [NSString stringWithUTF8String:default_value] : nil;
    NSString *result =  [ROIQueryCloudConfig getStringWithKey:key_string fallback:key_value];
    return roiStrdup([result UTF8String]);
}

BOOL getBoolean(const char *key, BOOL default_value){
    NSString *key_string = key != NULL ? [NSString stringWithUTF8String:key] : nil;
    return [ROIQueryCloudConfig getBooleanWithKey:key_string fallback:default_value];
}

// ad
void reportEntrance(const char *ad_id, int type, int platform, const char *location, const char *seq, const char *properties, const char *entrance){
    NSString *ad_id_string = ad_id != NULL ? [NSString stringWithUTF8String:ad_id] : nil;
    NSString *ad_location_string = location != NULL ? [NSString stringWithUTF8String:location] : nil;
    NSString *ad_seq_string = seq != NULL ? [NSString stringWithUTF8String:seq] : nil;
    NSString *ad_entrance_string = entrance != NULL ? [NSString stringWithUTF8String:entrance] : nil;
    NSDictionary *properties_dict = nil;
    changeToDictionary(properties, &properties_dict);
    [ROIQueryAdReport
     reportEntranceWithId:ad_id_string
     type:type
     platform:platform
     location:ad_location_string
     seq:ad_seq_string
     properties:properties_dict
     entrance:ad_entrance_string];
}
void reportToShow(const char *ad_id, int type, int platform, const char *location, const char *seq,const char *properties, const char *entrance){
    NSString *ad_id_string = ad_id != NULL ? [NSString stringWithUTF8String:ad_id] : nil;
    NSString *ad_location_string = location != NULL ? [NSString stringWithUTF8String:location] : nil;
    NSString *ad_seq_string = seq != NULL ? [NSString stringWithUTF8String:seq] : nil;
    NSString *ad_entrance_string = entrance != NULL ? [NSString stringWithUTF8String:entrance] : nil;
    NSDictionary *properties_dict = nil;
    changeToDictionary(properties, &properties_dict);
    [ROIQueryAdReport
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
    [ROIQueryAdReport
     reportShowWithId:ad_id_string
     type:type
     platform:platform
     location:ad_location_string
     seq:ad_seq_string
     properties:properties_dict
     entrance:ad_entrance_string];
}

void reportImpression(const char *ad_id, int type, int platform, const char *location, const char *seq,const char *properties, const char *entrance){
    NSString *ad_id_string = ad_id != NULL ? [NSString stringWithUTF8String:ad_id] : nil;
    NSString *ad_location_string = location != NULL ? [NSString stringWithUTF8String:location] : nil;
    NSString *ad_seq_string = seq != NULL ? [NSString stringWithUTF8String:seq] : nil;
    NSString *ad_entrance_string = entrance != NULL ? [NSString stringWithUTF8String:entrance] : nil;
    NSDictionary *properties_dict = nil;
    changeToDictionary(properties, &properties_dict);
    [ROIQueryAdReport
     reportImpressionWithId:ad_id_string
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
    [ROIQueryAdReport
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
    [ROIQueryAdReport
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
    [ROIQueryAdReport
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
    [ROIQueryAdReport
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
    [ROIQueryAdReport
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
    [ROIQueryAdReport
     reportConversionByLeftAppWithId:ad_id_string
     type:type
     platform:platform
     location:ad_location_string
     seq:ad_seq_string
     properties:properties_dict
     entrance:ad_entrance_string];
}



void reportConversionByImpression(const char *ad_id, int type, int platform, const char *location, const char *seq,const char *properties, const char *entrance){
    NSString *ad_id_string = ad_id != NULL ? [NSString stringWithUTF8String:ad_id] : nil;
    NSString *ad_location_string = location != NULL ? [NSString stringWithUTF8String:location] : nil;
    NSString *ad_seq_string = seq != NULL ? [NSString stringWithUTF8String:seq] : nil;
    NSString *ad_entrance_string = entrance != NULL ? [NSString stringWithUTF8String:entrance] : nil;
    NSDictionary *properties_dict = nil;
    changeToDictionary(properties, &properties_dict);
    [ROIQueryAdReport
     reportConversionByImpressionWithId:ad_id_string
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
    [ROIQueryAdReport
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
    [ROIQueryAdReport
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
    
    [ROIQueryAdReport
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

const char* generateUUID(){
    return [ROIQueryAdReport generateUUID];
}

int getPlatform(int mediation,const char *networkName,const char *networkPlacementId,const char *adgroupType){
    NSString *networkName_string = ad_id != NULL ? [NSString stringWithUTF8String:networkName] : nil;
    NSString *networkPlacementId_string = ad_id != NULL ? [NSString stringWithUTF8String:networkPlacementId] : nil;
    NSString *adgroupType_string = ad_id != NULL ? [NSString stringWithUTF8String:adgroupType] : nil;
    
    return [ROIQueryAdReport 
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
    [ROIQueryIAPReport reportEntranceWithOrder:order_string sku:sku_string price:price currency:currency_string seq:seq_string entrance:entrance_string];
}

void reportToPurchase(const char *order, const char *sku, double price, const char *currency, const char *seq, const char *entrance){
    NSString *order_string = order != NULL ? [NSString stringWithUTF8String:order] : nil;
    NSString *sku_string = sku != NULL ? [NSString stringWithUTF8String:sku] : nil;
    NSString *currency_string = currency != NULL ? [NSString stringWithUTF8String:currency] : nil;
    NSString *seq_string = seq != NULL ? [NSString stringWithUTF8String:seq] : nil;
    NSString *entrance_string = entrance != NULL ? [NSString stringWithUTF8String:entrance] : nil;
    [ROIQueryIAPReport reportToPurchaseWithOrder:order_string sku:sku_string price:price currency:currency_string seq:seq_string entrance:entrance_string];
}

void reportPurchased(const char *order, const char *sku, double price, const char *currency,  const char *seq,const char *entrance){
    NSString *order_string = order != NULL ? [NSString stringWithUTF8String:order] : nil;
    NSString *sku_string = sku != NULL ? [NSString stringWithUTF8String:sku] : nil;
    NSString *currency_string = currency != NULL ? [NSString stringWithUTF8String:currency] : nil;
    NSString *seq_string = seq != NULL ? [NSString stringWithUTF8String:seq] : nil;
    NSString *entrance_string = entrance != NULL ? [NSString stringWithUTF8String:entrance] : nil;
    [ROIQueryIAPReport reportPurchasedWithOrder:order_string sku:sku_string price:price currency:currency_string seq:seq_string entrance:entrance_string];
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
    [ROIQueryIAPReport reportNotToPurchasedWithOrder:order_string sku:sku_string price:price currency:currency_string seq:seq_string code:code_string msg:msg_string entrance:entrance_string];
    
}
// ias
