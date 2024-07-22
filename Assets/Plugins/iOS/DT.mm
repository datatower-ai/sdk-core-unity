//
//  DT.m
//  UnityFramework
//
//  Created by Lilin on 2023/6/19.
//

#import <Foundation/Foundation.h>
#import <DataTowerAICore/DTAnalytics.h>
#import <DataTowerAICore/DT.h>
#import <DataTowerAICore/DTAnalyticsUtils.h>

NS_ENUM(NSInteger, UnityLogLevel)
{
    DEFAULT = 2,
    VERBOSE = 2,
    DEBUG = 3,
    INFO = 4,
    WARN = 5,
    ERROR = 6,
    ASSERT = 7
};

NSString *SafeStringWithUTF8String(const char *cStr) {
    if(NULL == cStr)
        return @"";
    
    return [NSString stringWithUTF8String:cStr];
}

NSDictionary *jsonStr2Dictionary(const char *jsonStr) {
    if(NULL == jsonStr)
    {
        return [NSDictionary new];
    }
    
    NSString *jsonString = SafeStringWithUTF8String(jsonStr);
    NSData *data = [jsonString dataUsingEncoding:NSUTF8StringEncoding];
    NSDictionary *ret = [NSJSONSerialization JSONObjectWithData:data options:kNilOptions error:nil];
    return ret;
}

DTLoggingLevel convertUnityLogLevel(enum UnityLogLevel level) {
    DTLoggingLevel ret = DTLoggingLevelError;
    if (level <= DEBUG) {
        ret = DTLoggingLevelDebug;
    } else if (level <= INFO) {
        ret = DTLoggingLevelInfo;
    }
    return ret;
}

extern "C" {
void initSDK(const char *appId, const char* serverUrl, bool isDebug, int logLevel, const char *jsonStr, bool enableUpload) {
    
    DTLoggingLevel iOSLogLevel = convertUnityLogLevel((enum UnityLogLevel)logLevel);
    if (jsonStr != NULL) {
        NSDictionary *props = jsonStr2Dictionary(jsonStr);
        [DT initSDK:SafeStringWithUTF8String(appId) serverUrl:SafeStringWithUTF8String(serverUrl) channel:DTChannelAppStore isDebug:isDebug logLevel:iOSLogLevel commonProperties:props enableTrack:enableUpload];
    } else {
        [DT initSDK:SafeStringWithUTF8String(appId) serverUrl:SafeStringWithUTF8String(serverUrl) channel:DTChannelAppStore isDebug:isDebug logLevel:iOSLogLevel enableTrack:enableUpload];
    }
}

void enableUpload(bool enable) {
    [DTAnalytics setEnableTracking:enable];
}

char* getDataTowerId() {
    NSString *result = [DTAnalytics getDataTowerId];
    size_t length = strlen([result UTF8String]);
    char *ret = (char *)malloc(length);
    strcpy(ret, [result UTF8String]);
    
    return ret;
}

void userUniqAppend(const char *jsonStr) {
    if(NULL == jsonStr)
        return;
    
    NSDictionary *dictParam = jsonStr2Dictionary(jsonStr);
    [DTAnalytics userUniqAppend:dictParam];
}

void userSet(const char *jsonStr) {
    
    NSDictionary *dictParam = jsonStr2Dictionary(jsonStr);
    [DTAnalytics userSet:dictParam];
}

void userAdd(const char* jsonStr) {
    
    NSDictionary *dictParam = jsonStr2Dictionary(jsonStr);
    [DTAnalytics userAdd:dictParam];
}

void userSetOnce(const char* jsonStr) {
    
    NSDictionary *dictParam = jsonStr2Dictionary(jsonStr);
    [DTAnalytics userSetOnce:dictParam];
}

void userUnset(const char* jsonStr) {
    
    [DTAnalytics userUnset:SafeStringWithUTF8String(jsonStr)];
}

void userAppend(const char* jsonStr) {
    
    NSDictionary *dictParam = jsonStr2Dictionary(jsonStr);
    [DTAnalytics userAppend:dictParam];
}

void userDelete() {
    [DTAnalytics userDelete];
}

void setAccountId(const char* plainStr) {
    
    NSString *strParam = SafeStringWithUTF8String(plainStr);
    [DTAnalytics setAccountId:strParam];
}

void setFirebaseAppInstanceId(const char* plainStr) {
    
    NSString *strParam = SafeStringWithUTF8String(plainStr);
    [DTAnalytics setFirebaseAppInstanceId:strParam];
}

void setAppsFlyerId(const char* plainStr) {
    
    NSString *strParam = SafeStringWithUTF8String(plainStr);
    [DTAnalytics setAppsFlyerId:strParam];
}

void setKochavaId(const char* plainStr) {
    
    NSString *strParam = SafeStringWithUTF8String(plainStr);
    [DTAnalytics setKochavaId:strParam];
}

void setAdjustId(const char* plainStr) {
    
    NSString *strParam = SafeStringWithUTF8String(plainStr);
    [DTAnalytics setAdjustId:strParam];
}

void trackEvent(const char* eventName, const char* jsonStr) {
    
    NSString *strParam = SafeStringWithUTF8String(eventName);
    if(jsonStr != NULL)
    {
        NSDictionary *dictParam = jsonStr2Dictionary(jsonStr);
        [DTAnalytics trackEventName:strParam properties:dictParam];
    }
    else
    {
        [DTAnalytics trackEventName:strParam];
    }
}

void trackTimerStart(const char* eventName) {
    
    NSString *strParam = SafeStringWithUTF8String(eventName);
    [DTAnalyticsUtils trackTimerStart:strParam];
}

void trackTimerPause(const char* eventName) {
    
    NSString *strParam = SafeStringWithUTF8String(eventName);
    [DTAnalyticsUtils trackTimerPause:strParam];
}

void trackTimerResume(const char* eventName) {
    NSString *strParam = SafeStringWithUTF8String(eventName);
    [DTAnalyticsUtils trackTimerResume:strParam];
}

void trackTimerEnd(const char* eventName, const char* jsonStr) {
    NSString *strParam = SafeStringWithUTF8String(eventName);
    if(jsonStr != NULL)
    {
        NSDictionary *dictParam = jsonStr2Dictionary(jsonStr);
        [DTAnalyticsUtils trackTimerEnd:strParam properties:dictParam];
    }
    else
    {
        [DTAnalyticsUtils trackTimerEnd:strParam];
    }
}

void setSuperProperties(const char* jsonStr) {
    NSDictionary *dictParam = jsonStr2Dictionary(jsonStr);
    [DTAnalytics setSuperProperties:dictParam];
}

}
