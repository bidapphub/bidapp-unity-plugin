#import <UIKit/UIKit.h>

extern char* unityBidappSDK_targetName;
#define BIDAPP_PLUGIN_CALLBACK(method) if (NULL != unityBidappSDK_targetName) UnitySendMessage(unityBidappSDK_targetName, BIDAPP_##method, "")
#define BIDAPP_PLUGIN_CALLBACK_ARG(method, arg) if (NULL != unityBidappSDK_targetName) UnitySendMessage(unityBidappSDK_targetName, BIDAPP_##method, arg)
#define BIDAPP_PLUGIN_CALLBACK_ERROR_ARG_ARG_ARG(method, arg1, arg2, arg3) BIDAPP_PLUGIN_CALLBACK_ARG_ARG_ARG(method, arg1, arg2, arg3)
#define BIDAPP_PLUGIN_CALLBACK_ARG_ARG(method, arg1, arg2) if (NULL != unityBidappSDK_targetName) UnitySendMessage(unityBidappSDK_targetName, BIDAPP_##method, [NSString stringWithFormat:@"%d#%s#%d#%s", arg1 ? (int)strlen(arg1) : 0, arg1 ? arg1 : "", arg2 ? (int)strlen(arg2) : 0, arg2 ? arg2 : ""].UTF8String)
#define BIDAPP_PLUGIN_CALLBACK_ARG_ARG_ARG(method, arg1, arg2, arg3) if (NULL != unityBidappSDK_targetName) UnitySendMessage(unityBidappSDK_targetName, BIDAPP_##method, [NSString stringWithFormat:@"%d#%s#%d#%s#%d#%s", arg1 ? (int)strlen(arg1) : 0, arg1 ? arg1 : "", arg2 ? (int)strlen(arg2) : 0, arg2 ? arg2 : "", (int)strlen(arg3), arg3 ? arg3 : ""].UTF8String)

#define BIDAPPSDK_PLUGIN_NAME (@"unity")

extern "C"
{
    extern void UnitySendMessage(const char *, const char *, const char *);
    extern UIViewController *UnityGetGLViewController();
}

#define BIDAPP_PLUGIN_VIEW_SOURCE UnityGetGLViewController().view

#ifndef UNITY_IOS
#define UNITY_IOS 1
#endif
#define BIDAPP_USE_C_EXTERN
