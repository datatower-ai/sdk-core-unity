//
//  DT.m
//  UnityFramework
//
//  Created by Lilin on 2023/6/19.
//

#import <Foundation/Foundation.h>
#import <DataTowerAICore/DTAnalytics.h>
#import <DataTowerAICore/DT.h>


NSDictionary *jsonStr2Dictionary(const char *jsonStr) {
    NSString *jsonString = [NSString stringWithUTF8String:jsonStr];
    NSData *data = [jsonString dataUsingEncoding:NSUTF8StringEncoding];
    NSDictionary *ret = [NSJSONSerialization JSONObjectWithData:data options:kNilOptions error:nil];
    return ret;
}

NSInvocation *makeInvokation(const char *clsName, const char *method) {
    Class cls = NSClassFromString([NSString stringWithUTF8String:clsName]);
    SEL selector = NSSelectorFromString([NSString stringWithUTF8String:method]);
    NSInvocation *invocation = [NSInvocation invocationWithMethodSignature:
                                [cls methodSignatureForSelector:selector]];
    
    [invocation setTarget:cls];
    [invocation setSelector:selector];
    return invocation;
}

extern "C" {
void initSDK(const char *appId, const char* serverUrl, bool isDebug, int logLevel, const char *jsonStr) {
    if (jsonStr != NULL) {
        NSDictionary *props = jsonStr2Dictionary(jsonStr);
        [DT initSDK:[NSString stringWithUTF8String:appId] serverUrl:[NSString stringWithUTF8String:serverUrl] channel:DTChannelAppStore isDebug:isDebug logLevel:(DTLoggingLevel)logLevel commonProperties:props];
    } else {
        [DT initSDK:[NSString stringWithUTF8String:appId] serverUrl:[NSString stringWithUTF8String:serverUrl] channel:DTChannelAppStore isDebug:isDebug logLevel:(DTLoggingLevel)logLevel];
    }
}

char* reflectionInvokeWithReturn(const char *clsName, const char *method) {
    
    void *tempResult = nil;
    NSInvocation *invocation = makeInvokation(clsName, method);
    [invocation invoke];
    [invocation getReturnValue:&tempResult];
    
    NSString *result = (__bridge NSString *)tempResult;;
    
    size_t length = strlen([result UTF8String]);
    char *ret = (char *)malloc(length);
    strcpy(ret, [result UTF8String]);
    
    return ret;
    
}

void reflectionInvoke(const char *clsName, const char *method) {
    NSInvocation *invocation = makeInvokation(clsName, method);
    [invocation invoke];
}

void reflectionInvokeWithJsonStr(const char *clsName, const char *method, const char *jsonStr) {
    NSInvocation *invocation = makeInvokation(clsName, method);
    NSDictionary *dictParam = jsonStr2Dictionary(jsonStr);
    [invocation setArgument:&dictParam atIndex:2];
    [invocation invoke];
}

void reflectionInvokeWithPlainStr(const char *clsName, const char *method, const char *plainStr) {
    NSInvocation *invocation = makeInvokation(clsName, method);
    
    NSString *strParam = [NSString stringWithUTF8String:plainStr];
    [invocation setArgument:&strParam atIndex:2];
    [invocation invoke];
}

void reflectionInvokeWith2Param(const char *clsName, const char *method, const char *plainStr, const char *jsonStr) {
    
    NSInvocation *invocation = makeInvokation(clsName, method);
    
    NSString *strParam = [NSString stringWithUTF8String:plainStr];
    [invocation setArgument:&strParam atIndex:2];
    
    NSDictionary *dictParam = jsonStr2Dictionary(jsonStr);
    [invocation setArgument:&dictParam atIndex:3];
    [invocation invoke];
}
}

