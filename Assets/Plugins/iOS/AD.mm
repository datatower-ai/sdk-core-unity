//
//  DTAD.m
//  UnityFramework
//
//  Created by Lilin on 2023/6/27.
//

#import <Foundation/Foundation.h>
#import <DataTowerAICore/DTAdReport.h>

extern NSDictionary *jsonStr2Dictionary(const char *jsonStr);

extern NSString *SafeStringWithUTF8String(const char*);

extern "C" {
void reportLoadBegin(const char *adid, int type, int platform, const char * seq, int mediation, const char * mediationId, const char * properties) {
    
    NSDictionary *dict = nil;
    if (properties) {
        dict = jsonStr2Dictionary(properties);
    }
    
    [DTAdReport reportLoadBegin:SafeStringWithUTF8String(adid) type:(DTAdType)type platform:(DTAdPlatform)platform seq:SafeStringWithUTF8String(seq) mediation:(DTAdMediation)mediation mediationId:SafeStringWithUTF8String(mediationId)  properties:dict];
}

void reportLoadEnd(const char * adId, int type, int platform, long duration, bool result, const char * seq, int mediation, const char * mediationId, int errorCode, const char * errorMessage, const char * properties) {
    
    NSDictionary *dict = nil;
    if (properties) {
        dict = jsonStr2Dictionary(properties);
    }
    
    [DTAdReport reportLoadEnd:SafeStringWithUTF8String(adId) type:(DTAdType)type platform:(DTAdPlatform)platform duration:@(duration) result:result seq:SafeStringWithUTF8String(seq) mediation:(DTAdMediation)mediation mediationId:SafeStringWithUTF8String(mediationId)  errorCode:errorCode errorMessage:SafeStringWithUTF8String(errorMessage) properties:dict];
}


void reportShowFailed(const char * adId, int type, int platform, const char * location, const char * seq, int mediation, const char * mediationId, int errorCode, const char * errorMessage, const char * entrance, const char * properties) {
    NSDictionary *dict = nil;
    if (properties) {
        dict = jsonStr2Dictionary(properties);
    }
    
    [DTAdReport reportAdShowFail:SafeStringWithUTF8String(adId) type:(DTAdType)type platform:(DTAdPlatform)platform location:SafeStringWithUTF8String(location) seq:SafeStringWithUTF8String(seq) mediation:(DTAdMediation)mediation mediationId:SafeStringWithUTF8String(mediationId) errorCode: errorCode errorMessage:SafeStringWithUTF8String(errorMessage) properties:dict entrance:SafeStringWithUTF8String(entrance)];
}

void reportToShow(const char * adId, int type, int platform, const char * location, const char * seq,
                  int mediation, const char * mediationId, const char * properties,const char * entrance) {
    NSDictionary *dict = nil;
    if (properties) {
        dict = jsonStr2Dictionary(properties);
    }
    
    [DTAdReport reportToShow:SafeStringWithUTF8String(adId) type:(DTAdType)type platform:(DTAdPlatform)platform location:SafeStringWithUTF8String(location) seq:SafeStringWithUTF8String(seq) mediation:(DTAdMediation)mediation mediationId:SafeStringWithUTF8String(mediationId) properties:dict entrance:SafeStringWithUTF8String(entrance)];

}

void reportShow(const char * adId, int type, int platform, const char * location, const char * seq,
                int mediation, const char * mediationId, const char * properties,const char * entrance) {
    NSDictionary *dict = nil;
    if (properties) {
        dict = jsonStr2Dictionary(properties);
    }
    
    [DTAdReport reportShow:SafeStringWithUTF8String(adId) type:(DTAdType)type platform:(DTAdPlatform)platform location:SafeStringWithUTF8String(location) seq:SafeStringWithUTF8String(seq) mediation:(DTAdMediation)mediation mediationId:SafeStringWithUTF8String(mediationId) properties:dict entrance:SafeStringWithUTF8String(entrance)];
}

void reportAdShowFail(const char * adId, int type, int platform, const char * location, const char * seq,
                      int mediation, const char * mediationId, int errorCode, const char * errorMessage,const char * properties,const char * entrance) {
    NSDictionary *dict = nil;
    if (properties) {
        dict = jsonStr2Dictionary(properties);
    }
    
    [DTAdReport reportAdShowFail:SafeStringWithUTF8String(adId) type:(DTAdType)type platform:(DTAdPlatform)platform location:SafeStringWithUTF8String(location) seq:SafeStringWithUTF8String(seq) mediation:(DTAdMediation)mediation mediationId:SafeStringWithUTF8String(mediationId) errorCode:errorCode errorMessage:SafeStringWithUTF8String(errorMessage) properties:dict entrance:SafeStringWithUTF8String(entrance)];
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
    
    [DTAdReport reportClose:SafeStringWithUTF8String(adId) type:(DTAdType)type platform:(DTAdPlatform)platform location:SafeStringWithUTF8String(location) seq:SafeStringWithUTF8String(seq) mediation:(DTAdMediation)mediation mediationId:SafeStringWithUTF8String(mediationId) properties:dict entrance:SafeStringWithUTF8String(entrance)];
    
}

void reportClick(const char * adId, int type, int platform, const char * location, const char * seq,
                 int mediation, const char * mediationId, const char * properties,const char * entrance) {
    
    NSDictionary *dict = nil;
    if (properties) {
        dict = jsonStr2Dictionary(properties);
    }
    
    [DTAdReport reportClick:SafeStringWithUTF8String(adId) type:(DTAdType)type platform:(DTAdPlatform)platform location:SafeStringWithUTF8String(location) seq:SafeStringWithUTF8String(seq) mediation:(DTAdMediation)mediation mediationId:SafeStringWithUTF8String(mediationId) properties:dict entrance:SafeStringWithUTF8String(entrance)];
}

void reportRewarded(const char * adId, int type, int platform, const char * location, const char * seq,
                    int mediation, const char * mediationId, const char * properties,const char * entrance) {
    NSDictionary *dict = nil;
    if (properties) {
        dict = jsonStr2Dictionary(properties);
    }
    
    [DTAdReport reportRewarded:SafeStringWithUTF8String(adId) type:(DTAdType)type platform:(DTAdPlatform)platform location:SafeStringWithUTF8String(location) seq:SafeStringWithUTF8String(seq) mediation:(DTAdMediation)mediation mediationId:SafeStringWithUTF8String(mediationId) properties:dict entrance:SafeStringWithUTF8String(entrance)];
}

void reportLeftApp(const char * adId, int type, int platform, const char * location, const char * seq,
                   int mediation, const char * mediationId, const char * properties,const char * entrance) {
    NSDictionary *dict = nil;
    if (properties) {
        dict = jsonStr2Dictionary(properties);
    }
    
    [DTAdReport reportLeftApp:SafeStringWithUTF8String(adId) type:(DTAdType)type platform:(DTAdPlatform)platform location:SafeStringWithUTF8String(location) seq:SafeStringWithUTF8String(seq) mediation:(DTAdMediation)mediation mediationId:SafeStringWithUTF8String(mediationId) properties:dict entrance:SafeStringWithUTF8String(entrance)];
}

void reportConversionByClick(const char * adId, int type, int platform, const char * location,
                             const char * seq,int mediation, const char * mediationId, const char * properties,const char * entrance) {
    NSDictionary *dict = nil;
    if (properties) {
        dict = jsonStr2Dictionary(properties);
    }
    
    [DTAdReport reportConversionByClick:SafeStringWithUTF8String(adId) type:(DTAdType)type platform:(DTAdPlatform)platform location:SafeStringWithUTF8String(location) seq:SafeStringWithUTF8String(seq) mediation:(DTAdMediation)mediation mediationId:SafeStringWithUTF8String(mediationId) properties:dict entrance:SafeStringWithUTF8String(entrance)];
}

void reportConversionByLeftApp(const char * adId, int type, int platform, const char * location,
                               const char * seq, int mediation, const char * mediationId, const char * properties,const char * entrance) {
    NSDictionary *dict = nil;
    if (properties) {
        dict = jsonStr2Dictionary(properties);
    }
    
    [DTAdReport reportConversionByLeftApp:SafeStringWithUTF8String(adId) type:(DTAdType)type platform:(DTAdPlatform)platform location:SafeStringWithUTF8String(location) seq:SafeStringWithUTF8String(seq) mediation:(DTAdMediation)mediation mediationId:SafeStringWithUTF8String(mediationId) properties:dict entrance:SafeStringWithUTF8String(entrance)];
}

void reportConversionByRewarded(const char * adId, int type, int platform, const char * location,
                                const char * seq, int mediation, const char * mediationId, const char * properties, const char * entrance) {
    NSDictionary *dict = nil;
    if (properties) {
        dict = jsonStr2Dictionary(properties);
    }
    
    [DTAdReport reportConversionByRewarded:SafeStringWithUTF8String(adId) type:(DTAdType)type platform:(DTAdPlatform)platform location:SafeStringWithUTF8String(location) seq:SafeStringWithUTF8String(seq) mediation:(DTAdMediation)mediation mediationId:SafeStringWithUTF8String(mediationId) properties:dict entrance:SafeStringWithUTF8String(entrance)];
}

void reportPaid(const char * adId, int type, int platform, const char * location, const char * seq,
                int mediation, const char * mediationId, double value, const char * currency, const char * precision, const char * properties, const char * entrance) {
    NSDictionary *dict = nil;
    if (properties) {
        dict = jsonStr2Dictionary(properties);
    }
    
    [DTAdReport reportPaid:SafeStringWithUTF8String(adId) type:(DTAdType)type platform:(DTAdPlatform)platform location:SafeStringWithUTF8String(location) seq:SafeStringWithUTF8String(seq) mediation:(DTAdMediation)mediation mediationId:SafeStringWithUTF8String(mediationId) value:value currency:SafeStringWithUTF8String(currency) precision:SafeStringWithUTF8String(precision) properties:dict entrance:SafeStringWithUTF8String(entrance)];
}

void reportPaidWithMediation(const char * adId, int type, int platform, const char * adgroupType, const char * location,
                             const char * seq,
                             int mediation, const char * mediationId, double value, const char * currency, const char * precision, const char * country,
                             const char * properties, const char * entrance) {
    NSDictionary *dict = nil;
    if (properties) {
        dict = jsonStr2Dictionary(properties);
    }
    
    [DTAdReport reportPaid:SafeStringWithUTF8String(adId) type:(DTAdType)type platform:(DTAdPlatform)platform location:SafeStringWithUTF8String(location) seq:SafeStringWithUTF8String(seq) mediation:(DTAdMediation)mediation mediationId:SafeStringWithUTF8String(mediationId) value:value  precision:SafeStringWithUTF8String(precision) country:SafeStringWithUTF8String(country) properties:dict entrance:SafeStringWithUTF8String(entrance)];
}

void reportPaidWithCountry(const char *adId, int type, int platform, const char *location, const char *seq,
            int mediation, const char *mediationId, double value, const char *precision, const char *country, const char *properties, const char *entrance) {
    NSDictionary *dict = nil;
    if (properties) {
        dict = jsonStr2Dictionary(properties);
    }
    
    [DTAdReport reportPaid:SafeStringWithUTF8String(adId) type:(DTAdType)type platform:(DTAdPlatform)platform location:SafeStringWithUTF8String(location) seq:SafeStringWithUTF8String(seq) mediation:(DTAdMediation)mediation mediationId:SafeStringWithUTF8String(mediationId)  value:value precision:SafeStringWithUTF8String(precision) country:SafeStringWithUTF8String(country) properties:dict entrance:SafeStringWithUTF8String(entrance)];
}

}
