//
//  DTAD.m
//  UnityFramework
//
//  Created by Lilin on 2023/6/27.
//

#import <Foundation/Foundation.h>
#import <datatower_ai_core/DTIASReport.h>

extern "C" {

void reportIasToShow(const char * iasSeq, const char * iasEntrance, const char * iasPlacement) {
    
    [DTIASReport reportToShow:[NSString stringWithUTF8String:iasSeq] entrance:[NSString stringWithUTF8String:iasEntrance] placement:[NSString stringWithUTF8String:iasPlacement] properties:@{}];
}

void reportShowSuccess(const char * iasSeq, const char * iasEntrance, const char * iasPlacement) {
    [DTIASReport reportShowSuccess:[NSString stringWithUTF8String:iasSeq] entrance:[NSString stringWithUTF8String:iasEntrance] placement:[NSString stringWithUTF8String:iasPlacement] properties:@{}];
}

void reportShowFail(const char * iasSeq, const char * iasEntrance, const char * iasPlacement, const char * iasCode, const char * iasMsg) {
    [DTIASReport reportShowFail:[NSString stringWithUTF8String:iasSeq] entrance:[NSString stringWithUTF8String:iasEntrance] placement:[NSString stringWithUTF8String:iasPlacement] errorCode:[NSString stringWithUTF8String:iasCode] errorMsg:[NSString stringWithUTF8String:iasMsg] properties:@{}];
}

void reportSubscribe(const char * iasSeq, const char * iasEntrance, const char * iasPlacement, const char * iasSku, const char * iasOrderId,
                     const char * iasPrice,
                     const char * iasCurrency) {
    [DTIASReport reportSubscribe:[NSString stringWithUTF8String:iasSeq]  entrance:[NSString stringWithUTF8String:iasEntrance] placement:[NSString stringWithUTF8String:iasPlacement] sku:[NSString stringWithUTF8String:iasSku] orderId:[NSString stringWithUTF8String:iasOrderId] price:[NSString stringWithUTF8String:iasPrice] currency:[NSString stringWithUTF8String:iasCurrency] properties:@{}];
}

void reportSubscribeSuccess(
                            const char * iasSeq, const char * iasEntrance, const char * iasPlacement, const char * iasSku, const char * iasOrderId, const char * iasOriginalOrderId, const char * iasPrice,
                            const char * iasCurrency) {
    [DTIASReport reportSubscribeSuccess:[NSString stringWithUTF8String:iasSeq]  entrance:[NSString stringWithUTF8String:iasEntrance] placement:[NSString stringWithUTF8String:iasPlacement] sku:[NSString stringWithUTF8String:iasSku] orderId:[NSString stringWithUTF8String:iasOrderId] originalOrderId:[NSString stringWithUTF8String:iasOriginalOrderId] price:[NSString stringWithUTF8String:iasPrice] currency:[NSString stringWithUTF8String:iasCurrency] properties:@{}];
}

void reportSubscribeFail(const char * iasSeq,const char * iasEntrance,const char * iasPlacement,const char * iasSku,const char * iasOrderId,
                         const char * iasOriginalOrderId,const char * iasPrice,const char * iasCurrency,const char * iasCode,const char * iasMsg) {

    [DTIASReport reportSubscribeFail:[NSString stringWithUTF8String:iasSeq] entrance:[NSString stringWithUTF8String:iasEntrance] placement:[NSString stringWithUTF8String:iasPlacement] sku:[NSString stringWithUTF8String:iasSku] orderId:[NSString stringWithUTF8String:iasOrderId] originalOrderId:[NSString stringWithUTF8String:iasOriginalOrderId] price:[NSString stringWithUTF8String:iasPrice] currency:[NSString stringWithUTF8String:iasCurrency] errorCode:[NSString stringWithUTF8String:iasCode] errorMsg:[NSString stringWithUTF8String:iasMsg] properties:@{}];
}

}
