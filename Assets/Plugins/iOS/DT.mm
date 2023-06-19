//
//  DT.m
//  UnityFramework
//
//  Created by Lilin on 2023/6/19.
//

#import <Foundation/Foundation.h>

extern "C" {
    void initSDK(const char *appId, bool isDebug, int logLevel, const char *properties) {
        NSLog(@"invoke initSDK");
    }
}
