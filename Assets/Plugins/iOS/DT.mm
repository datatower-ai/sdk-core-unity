//
//  DT.m
//  UnityFramework
//
//  Created by Lilin on 2023/6/19.
//

#import <Foundation/Foundation.h>
#import <datatower_ai_core/DTAnalytics.h>
#import <datatower_ai_core/DT.h>
#import <datatower_ai_core/DTAnalyticsUtils.h>


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

NSDictionary *jsonStr2Dictionary(const char *jsonStr) {
    NSString *jsonString = [NSString stringWithUTF8String:jsonStr];
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
void initSDK(const char *appId, const char* serverUrl, bool isDebug, int logLevel, const char *jsonStr) {
    
    DTLoggingLevel iOSLogLevel = convertUnityLogLevel((enum UnityLogLevel)logLevel);
    if (jsonStr != NULL) {
        NSDictionary *props = jsonStr2Dictionary(jsonStr);
        [DT initSDK:[NSString stringWithUTF8String:appId] serverUrl:[NSString stringWithUTF8String:serverUrl] channel:DTChannelAppStore isDebug:isDebug logLevel:iOSLogLevel commonProperties:props];
    } else {
        [DT initSDK:[NSString stringWithUTF8String:appId] serverUrl:[NSString stringWithUTF8String:serverUrl] channel:DTChannelAppStore isDebug:isDebug logLevel:iOSLogLevel];
    }
}

char* getDataTowerId() {
    NSString *result = [DTAnalytics getDataTowerId];
    size_t length = strlen([result UTF8String]);
    char *ret = (char *)malloc(length);
    strcpy(ret, [result UTF8String]);
    
    return ret;
}

void userUniqAppend(const char *jsonStr) {
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
    [DTAnalytics userUnset:[NSString stringWithUTF8String:jsonStr]];
}

void userAppend(const char* jsonStr) {
    NSDictionary *dictParam = jsonStr2Dictionary(jsonStr);
    [DTAnalytics userAppend:dictParam];
}

void userDelete() {
    [DTAnalytics userDelete];
}

void setAccountId(const char* plainStr) {
    NSString *strParam = [NSString stringWithUTF8String:plainStr];
    [DTAnalytics setAccountId:strParam];
}

void setFirebaseAppInstanceId(const char* plainStr) {
    NSString *strParam = [NSString stringWithUTF8String:plainStr];
    [DTAnalytics setFirebaseAppInstanceId:strParam];
}

void setAppsFlyerId(const char* plainStr) {
    NSString *strParam = [NSString stringWithUTF8String:plainStr];
    [DTAnalytics setAppsFlyerId:strParam];
}

void setKochavaId(const char* plainStr) {
    NSString *strParam = [NSString stringWithUTF8String:plainStr];
    [DTAnalytics setKochavaId:strParam];
}

void setAdjustId(const char* plainStr) {
    NSString *strParam = [NSString stringWithUTF8String:plainStr];
    [DTAnalytics setAdjustId:strParam];
}

void trackEvent(const char* eventName, const char* jsonStr) {
    NSString *strParam = [NSString stringWithUTF8String:eventName];
    NSDictionary *dictParam = jsonStr2Dictionary(jsonStr);
    [DTAnalytics trackEventName:strParam properties:dictParam];
}

void trackTimerStart(const char* eventName) {
    NSString *strParam = [NSString stringWithUTF8String:eventName];
    [DTAnalyticsUtils trackTimerStart:strParam];
}

void trackTimerPause(const char* eventName) {
    NSString *strParam = [NSString stringWithUTF8String:eventName];
    [DTAnalyticsUtils trackTimerPause:strParam];
}

void trackTimerResume(const char* eventName) {
    NSString *strParam = [NSString stringWithUTF8String:eventName];
    [DTAnalyticsUtils trackTimerResume:strParam];
}

void trackTimerEnd(const char* eventName, const char* jsonStr) {
    NSString *strParam = [NSString stringWithUTF8String:eventName];
    NSDictionary *dictParam = jsonStr2Dictionary(jsonStr);
    [DTAnalyticsUtils trackTimerEnd:strParam properties:dictParam];
}

}
