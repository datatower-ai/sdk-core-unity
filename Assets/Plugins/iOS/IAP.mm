//
//  DTAD.m
//  UnityFramework
//
//  Created by Lilin on 2023/6/27.
//

#import <Foundation/Foundation.h>
#import <DataTowerAICore/DTIAPReport.h>

extern "C" {

void reportIapEntrance(const char * order, const char * sku, double price, const char * currency, const char * seq,
                       const char * entrance) {
    [DTIAPReport reportEntrance:[NSString stringWithUTF8String:order] sku:[NSString stringWithUTF8String:sku] price:@(price) currency:[NSString stringWithUTF8String:currency] seq:[NSString stringWithUTF8String:seq] placement:[NSString stringWithUTF8String:entrance]];
}

void reportToPurchase(const char * order, const char * sku, double price, const char * currency, const char * seq,
                      const char * entrance) {
    [DTIAPReport reportToPurchase:[NSString stringWithUTF8String:order] sku:[NSString stringWithUTF8String:sku] price:@(price) currency:[NSString stringWithUTF8String:currency] seq:[NSString stringWithUTF8String:seq] placement:[NSString stringWithUTF8String:entrance]];
}

void reportPurchased(const char * order, const char * sku, double price, const char * currency, const char * seq,
                     const char * entrance) {
    [DTIAPReport reportPurchased:[NSString stringWithUTF8String:order] sku:[NSString stringWithUTF8String:sku] price:@(price) currency:[NSString stringWithUTF8String:currency] seq:[NSString stringWithUTF8String:seq] placement:[NSString stringWithUTF8String:entrance]];
}

void reportNotToPurchased(const char * order, const char * sku, double price, const char * currency,
                          const char * seq, const char * code, const char * entrance, const char * msg) {
    [DTIAPReport reportNotToPurchased:[NSString stringWithUTF8String:order] sku:[NSString stringWithUTF8String:seq] price:@(price) currency:[NSString stringWithUTF8String:currency] seq:[NSString stringWithUTF8String:seq] code:[NSString stringWithUTF8String:code] msg:[NSString stringWithUTF8String:msg] placement:[NSString stringWithUTF8String:entrance]];
}
}
