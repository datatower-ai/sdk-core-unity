//
//  DTAD.m
//  UnityFramework
//
//  Created by Lilin on 2023/6/27.
//

#import <Foundation/Foundation.h>
#import <DataTowerAICore/DTAdReport.h>

extern NSDictionary *jsonStr2Dictionary(const char *jsonStr);

extern "C" {
void reportLoadBegin(const char *adid, int type, int platform, const char * seq, int mediation, const char * mediationId, const char * properties) {
    
    NSDictionary *dict = nil;
    if (properties) {
        dict = jsonStr2Dictionary(properties);
    }
    
    [DTAdReport reportLoadBegin:[NSString stringWithUTF8String:adid] type:(DTAdType)type platform:(DTAdPlatform)platform seq:[NSString stringWithUTF8String:seq] mediation:(DTAdMediation)mediation mediationId:[NSString stringWithUTF8String:mediationId]  properties:dict];
}

void reportLoadEnd(const char * adId, int type, int platform, long duration, bool result, const char * seq, int mediation, const char * mediationId, int errorCode, const char * errorMessage, const char * properties) {
    
    NSDictionary *dict = nil;
    if (properties) {
        dict = jsonStr2Dictionary(properties);
    }
    
    [DTAdReport reportLoadEnd:[NSString stringWithUTF8String:adId] type:(DTAdType)type platform:(DTAdPlatform)platform duration:@(duration) result:result seq:[NSString stringWithUTF8String:seq] mediation:(DTAdMediation)mediation mediationId:[NSString stringWithUTF8String:mediationId]  errorCode:errorCode errorMessage:[NSString stringWithUTF8String:errorMessage] properties:dict];
}


void reportShowFailed(const char * adId, int type, int platform, const char * location, const char * seq, int mediation, const char * mediationId, int errorCode, const char * errorMessage, const char * entrance, const char * properties) {
    NSDictionary *dict = nil;
    if (properties) {
        dict = jsonStr2Dictionary(properties);
    }
    
    [DTAdReport reportAdShowFail:[NSString stringWithUTF8String:adId] type:(DTAdType)type platform:(DTAdPlatform)platform location:[NSString stringWithUTF8String:location] seq:[NSString stringWithUTF8String:seq] mediation:(DTAdMediation)mediation mediationId:[NSString stringWithUTF8String:mediationId] errorCode: errorCode errorMessage:[NSString stringWithUTF8String:errorMessage] properties:dict entrance:[NSString stringWithUTF8String:entrance]];
}

void reportToShow(const char * adId, int type, int platform, const char * location, const char * seq,
                  int mediation, const char * mediationId, const char * properties,const char * entrance) {
    NSDictionary *dict = nil;
    if (properties) {
        dict = jsonStr2Dictionary(properties);
    }
    
    [DTAdReport reportToShow:[NSString stringWithUTF8String:adId] type:(DTAdType)type platform:(DTAdPlatform)platform location:[NSString stringWithUTF8String:location] seq:[NSString stringWithUTF8String:seq] mediation:(DTAdMediation)mediation mediationId:[NSString stringWithUTF8String:mediationId] properties:dict entrance:[NSString stringWithUTF8String:entrance]];

}

void reportShow(const char * adId, int type, int platform, const char * location, const char * seq,
                int mediation, const char * mediationId, const char * properties,const char * entrance) {
    NSDictionary *dict = nil;
    if (properties) {
        dict = jsonStr2Dictionary(properties);
    }
    
    [DTAdReport reportShow:[NSString stringWithUTF8String:adId] type:(DTAdType)type platform:(DTAdPlatform)platform location:[NSString stringWithUTF8String:location] seq:[NSString stringWithUTF8String:seq] mediation:(DTAdMediation)mediation mediationId:[NSString stringWithUTF8String:mediationId] properties:dict entrance:[NSString stringWithUTF8String:entrance]];
}

void reportAdShowFail(const char * adId, int type, int platform, const char * location, const char * seq,
                      int mediation, const char * mediationId, int errorCode, const char * errorMessage,const char * properties,const char * entrance) {
    NSDictionary *dict = nil;
    if (properties) {
        dict = jsonStr2Dictionary(properties);
    }
    
    [DTAdReport reportAdShowFail:[NSString stringWithUTF8String:adId] type:(DTAdType)type platform:(DTAdPlatform)platform location:[NSString stringWithUTF8String:location] seq:[NSString stringWithUTF8String:seq] mediation:(DTAdMediation)mediation mediationId:[NSString stringWithUTF8String:mediationId] errorCode:errorCode errorMessage:[NSString stringWithUTF8String:errorMessage] properties:dict entrance:[NSString stringWithUTF8String:entrance]];
}

void reportImpression(const char * id, int type, int platform, const char * location, const char * seq,
                      const char * properties,const char * entrance) {
    
}

void reportClose(const char * adId, int type, int platform, const char * location, const char * seq,
                 int mediation, const char * mediationId, const char * properties,const char * entrance) {
    NSDictionary *dict = nil;
    if (properties) {
        dict = jsonStr2Dictionary(properties);
    }
    
    [DTAdReport reportClose:[NSString stringWithUTF8String:adId] type:(DTAdType)type platform:(DTAdPlatform)platform location:[NSString stringWithUTF8String:location] seq:[NSString stringWithUTF8String:seq] mediation:(DTAdMediation)mediation mediationId:[NSString stringWithUTF8String:mediationId] properties:dict entrance:[NSString stringWithUTF8String:entrance]];
    
}

void reportClick(const char * adId, int type, int platform, const char * location, const char * seq,
                 int mediation, const char * mediationId, const char * properties,const char * entrance) {
    
    NSDictionary *dict = nil;
    if (properties) {
        dict = jsonStr2Dictionary(properties);
    }
    
    [DTAdReport reportClick:[NSString stringWithUTF8String:adId] type:(DTAdType)type platform:(DTAdPlatform)platform location:[NSString stringWithUTF8String:location] seq:[NSString stringWithUTF8String:seq] mediation:(DTAdMediation)mediation mediationId:[NSString stringWithUTF8String:mediationId] properties:dict entrance:[NSString stringWithUTF8String:entrance]];
}

void reportRewarded(const char * adId, int type, int platform, const char * location, const char * seq,
                    int mediation, const char * mediationId, const char * properties,const char * entrance) {
    NSDictionary *dict = nil;
    if (properties) {
        dict = jsonStr2Dictionary(properties);
    }
    
    [DTAdReport reportRewarded:[NSString stringWithUTF8String:adId] type:(DTAdType)type platform:(DTAdPlatform)platform location:[NSString stringWithUTF8String:location] seq:[NSString stringWithUTF8String:seq] mediation:(DTAdMediation)mediation mediationId:[NSString stringWithUTF8String:mediationId] properties:dict entrance:[NSString stringWithUTF8String:entrance]];
}

void reportLeftApp(const char * adId, int type, int platform, const char * location, const char * seq,
                   int mediation, const char * mediationId, const char * properties,const char * entrance) {
    NSDictionary *dict = nil;
    if (properties) {
        dict = jsonStr2Dictionary(properties);
    }
    
    [DTAdReport reportLeftApp:[NSString stringWithUTF8String:adId] type:(DTAdType)type platform:(DTAdPlatform)platform location:[NSString stringWithUTF8String:location] seq:[NSString stringWithUTF8String:seq] mediation:(DTAdMediation)mediation mediationId:[NSString stringWithUTF8String:mediationId] properties:dict entrance:[NSString stringWithUTF8String:entrance]];
}

void reportConversionByClick(const char * adId, int type, int platform, const char * location,
                             const char * seq,int mediation, const char * mediationId, const char * properties,const char * entrance) {
    NSDictionary *dict = nil;
    if (properties) {
        dict = jsonStr2Dictionary(properties);
    }
    
    [DTAdReport reportConversionByClick:[NSString stringWithUTF8String:adId] type:(DTAdType)type platform:(DTAdPlatform)platform location:[NSString stringWithUTF8String:location] seq:[NSString stringWithUTF8String:seq] mediation:(DTAdMediation)mediation mediationId:[NSString stringWithUTF8String:mediationId] properties:dict entrance:[NSString stringWithUTF8String:entrance]];
}

void reportConversionByLeftApp(const char * adId, int type, int platform, const char * location,
                               const char * seq, int mediation, const char * mediationId, const char * properties,const char * entrance) {
    NSDictionary *dict = nil;
    if (properties) {
        dict = jsonStr2Dictionary(properties);
    }
    
    [DTAdReport reportConversionByLeftApp:[NSString stringWithUTF8String:adId] type:(DTAdType)type platform:(DTAdPlatform)platform location:[NSString stringWithUTF8String:location] seq:[NSString stringWithUTF8String:seq] mediation:(DTAdMediation)mediation mediationId:[NSString stringWithUTF8String:mediationId] properties:dict entrance:[NSString stringWithUTF8String:entrance]];
}

void reportConversionByRewarded(const char * adId, int type, int platform, const char * location,
                                const char * seq, int mediation, const char * mediationId, const char * properties, const char * entrance) {
    NSDictionary *dict = nil;
    if (properties) {
        dict = jsonStr2Dictionary(properties);
    }
    
    [DTAdReport reportConversionByRewarded:[NSString stringWithUTF8String:adId] type:(DTAdType)type platform:(DTAdPlatform)platform location:[NSString stringWithUTF8String:location] seq:[NSString stringWithUTF8String:seq] mediation:(DTAdMediation)mediation mediationId:[NSString stringWithUTF8String:mediationId] properties:dict entrance:[NSString stringWithUTF8String:entrance]];
}

void reportPaid(const char * adId, int type, int platform, const char * location, const char * seq,
                int mediation, const char * mediationId, const char * value, const char * currency, const char * precision, const char * properties, const char * entrance) {
    NSDictionary *dict = nil;
    if (properties) {
        dict = jsonStr2Dictionary(properties);
    }
    
    [DTAdReport reportPaid:[NSString stringWithUTF8String:adId] type:(DTAdType)type platform:(DTAdPlatform)platform location:[NSString stringWithUTF8String:location] seq:[NSString stringWithUTF8String:seq] mediation:(DTAdMediation)mediation mediationId:[NSString stringWithUTF8String:mediationId] value:[NSString stringWithUTF8String:value] currency:[NSString stringWithUTF8String:currency] precision:[NSString stringWithUTF8String:precision] properties:dict entrance:[NSString stringWithUTF8String:entrance]];
}

void reportPaidWithMediation(const char * adId, int type, int platform, const char * adgroupType, const char * location,
                             const char * seq,
                             int mediation, const char * mediationId, const char * value, const char * currency, const char * precision, const char * country,
                             const char * properties, const char * entrance) {
    NSDictionary *dict = nil;
    if (properties) {
        dict = jsonStr2Dictionary(properties);
    }
    
    [DTAdReport reportPaid:[NSString stringWithUTF8String:adId] type:(DTAdType)type platform:(DTAdPlatform)platform location:[NSString stringWithUTF8String:location] seq:[NSString stringWithUTF8String:seq] mediation:(DTAdMediation)mediation mediationId:[NSString stringWithUTF8String:mediationId] value:[NSString stringWithUTF8String:value]  precision:[NSString stringWithUTF8String:precision] country:[NSString stringWithUTF8String:country] properties:dict entrance:[NSString stringWithUTF8String:entrance]];
}
}
