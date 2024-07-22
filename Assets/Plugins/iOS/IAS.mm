//
//  DTAD.m
//  UnityFramework
//
//  Created by Lilin on 2023/6/27.
//

#import <Foundation/Foundation.h>
#import <DataTowerAICore/DTIASReport.h>

extern NSString *SafeStringWithUTF8String(const char*);

extern "C" {

void reportIasToShow(const char * iasSeq, const char * iasEntrance, const char * iasPlacement) {
    
    [DTIASReport reportToShow:SafeStringWithUTF8String(iasSeq) entrance:SafeStringWithUTF8String(iasEntrance) placement:SafeStringWithUTF8String(iasPlacement) properties:@{}];
}

void reportShowSuccess(const char * iasSeq, const char * iasEntrance, const char * iasPlacement) {
    [DTIASReport reportShowSuccess:SafeStringWithUTF8String(iasSeq) entrance:SafeStringWithUTF8String(iasEntrance) placement:SafeStringWithUTF8String(iasPlacement) properties:@{}];
}

void reportShowFail(const char * iasSeq, const char * iasEntrance, const char * iasPlacement, const char * iasCode, const char * iasMsg) {
    [DTIASReport reportShowFail:SafeStringWithUTF8String(iasSeq) entrance:SafeStringWithUTF8String(iasEntrance) placement:SafeStringWithUTF8String(iasPlacement) errorCode:SafeStringWithUTF8String(iasCode) errorMsg:SafeStringWithUTF8String(iasMsg) properties:@{}];
}

void reportSubscribe(const char * iasSeq, const char * iasEntrance, const char * iasPlacement, const char * iasSku, const char * iasOrderId,
                     const char * iasPrice,
                     const char * iasCurrency) {
    [DTIASReport reportSubscribe:SafeStringWithUTF8String(iasSeq)  entrance:SafeStringWithUTF8String(iasEntrance) placement:SafeStringWithUTF8String(iasPlacement) sku:SafeStringWithUTF8String(iasSku) orderId:SafeStringWithUTF8String(iasOrderId) price:SafeStringWithUTF8String(iasPrice) currency:SafeStringWithUTF8String(iasCurrency) properties:@{}];
}

void reportSubscribeSuccess(
                            const char * iasSeq, const char * iasEntrance, const char * iasPlacement, const char * iasSku, const char * iasOrderId, const char * iasOriginalOrderId, const char * iasPrice,
                            const char * iasCurrency) {
    [DTIASReport reportSubscribeSuccess:SafeStringWithUTF8String(iasSeq)  entrance:SafeStringWithUTF8String(iasEntrance) placement:SafeStringWithUTF8String(iasPlacement) sku:SafeStringWithUTF8String(iasSku) orderId:SafeStringWithUTF8String(iasOrderId) originalOrderId:SafeStringWithUTF8String(iasOriginalOrderId) price:SafeStringWithUTF8String(iasPrice) currency:SafeStringWithUTF8String(iasCurrency) properties:@{}];
}

void reportSubscribeFail(const char * iasSeq,const char * iasEntrance,const char * iasPlacement,const char * iasSku,const char * iasOrderId,
                         const char * iasOriginalOrderId,const char * iasPrice,const char * iasCurrency,const char * iasCode,const char * iasMsg) {

    [DTIASReport reportSubscribeFail:SafeStringWithUTF8String(iasSeq) entrance:SafeStringWithUTF8String(iasEntrance) placement:SafeStringWithUTF8String(iasPlacement) sku:SafeStringWithUTF8String(iasSku) orderId:SafeStringWithUTF8String(iasOrderId) originalOrderId:SafeStringWithUTF8String(iasOriginalOrderId) price:SafeStringWithUTF8String(iasPrice) currency:SafeStringWithUTF8String(iasCurrency) errorCode:SafeStringWithUTF8String(iasCode) errorMsg:SafeStringWithUTF8String(iasMsg) properties:@{}];
}

}
