//
//  DTAD.m
//  UnityFramework
//
//  Created by Lilin on 2023/6/27.
//

#import <Foundation/Foundation.h>
#import <DataTowerAICore/DTIAPReport.h>

extern NSString *SafeStringWithUTF8String(const char*);

extern "C" {

void reportIapEntrance(const char * order, const char * sku, double price, const char * currency, const char * seq,
                       const char * entrance) {
    [DTIAPReport reportEntrance:SafeStringWithUTF8String(order) sku:SafeStringWithUTF8String(sku) price:@(price) currency:SafeStringWithUTF8String(currency) seq:SafeStringWithUTF8String(seq) placement:SafeStringWithUTF8String(entrance)];
    [DTIAPReport reportEntrance:SafeStringWithUTF8String(order) sku:SafeStringWithUTF8String(sku) price:@(price) currency:SafeStringWithUTF8String(currency) seq:SafeStringWithUTF8String(seq) placement:SafeStringWithUTF8String(entrance)];
}

void reportToPurchase(const char * order, const char * sku, double price, const char * currency, const char * seq,
                      const char * entrance) {
    [DTIAPReport reportToPurchase:SafeStringWithUTF8String(order) sku:SafeStringWithUTF8String(sku) price:@(price) currency:SafeStringWithUTF8String(currency) seq:SafeStringWithUTF8String(seq) placement:SafeStringWithUTF8String(entrance)];
}

void reportPurchased(const char * order, const char * sku, double price, const char * currency, const char * seq,
                     const char * entrance) {
    [DTIAPReport reportPurchased:SafeStringWithUTF8String(order) sku:SafeStringWithUTF8String(sku) price:@(price) currency:SafeStringWithUTF8String(currency) seq:SafeStringWithUTF8String(seq) placement:SafeStringWithUTF8String(entrance)];
}

void reportNotToPurchased(const char * order, const char * sku, double price, const char * currency,
                          const char * seq, const char * code, const char * entrance, const char * msg) {
    [DTIAPReport reportNotToPurchased:SafeStringWithUTF8String(order) sku:SafeStringWithUTF8String(seq) price:@(price) currency:SafeStringWithUTF8String(currency) seq:SafeStringWithUTF8String(seq) code:SafeStringWithUTF8String(code) msg:SafeStringWithUTF8String(msg) placement:SafeStringWithUTF8String(entrance)];
}
}
