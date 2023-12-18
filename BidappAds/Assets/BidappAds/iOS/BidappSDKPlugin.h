#ifndef BidappSDKPlugin_h
#define BidappSDKPlugin_h

#ifndef BIDAPP_PLUGIN_VIEW_SOURCE
#define BIDAPP_PLUGIN_VIEW_SOURCE ([[[[UIApplication sharedApplication] keyWindow]rootViewController] view])
#endif

#define BIDAPP_INTERSTITIAL @"Interstitial"
#define BIDAPP_REWARDED @"Rewarded"
#define BIDAPP_BANNER @"Banner"

#ifdef __cplusplus
#ifdef BIDAPP_USE_C_EXTERN
extern "C"
{
#endif
#endif
    
    void Bidapp_start_platform(const char* pubid, const char* formats);
    void Bidapp_setLogging_platform(bool logging);
    void Bidapp_setTestMode_platform(bool testMode);

    const char* Bidapp_createInterstitial_platform(void);
    const char* Bidapp_createRewarded_platform(void);
    void Bidapp_destroyInterstitial_platform(const char* idt);
    void Bidapp_destroyRewarded_platform(const char* idt);
    void Bidapp_showInterstitial_platform(const char* idt);
    void Bidapp_showRewarded_platform(const char* idt);

    const char* Bidapp_showBanner_platform(const char* bannerSize, float x, float y, float width, float height);
    const char* Bidapp_showBannerAtPosition_platform(const char* position, const char* bannerSize, float marginTop, float marginLeft, float marginBottom, float marginRight);
    void Bidapp_stopBannerAutorefresh_platform(const char* bannerId);
    void Bidapp_setBannerRefreshInterval_platform(const char* bannerId, double refreshInterval);
    void Bidapp_refreshBanner_platform(const char* bannerId);
    void Bidapp_removeBanner_platform(const char* bannerId);

    void Bidapp_setGDPRConsent_platform(bool consent);
    void Bidapp_setCCPAConsent_platform(bool consent);
    void Bidapp_setSubjectToCOPPA_platform(bool subjectToCOPPA);

    void Bidapp_pause_platform(bool pauseStatus);

    void Bidapp_requestTrackingAuthorization_platform();
    
    //Used in Unity platform only
    void Bidapp_setUnityCallbackTargetName_platform(const char* targetName);

    void Bidapp_setParameterValue_platform(const char* parameterName, const char* parameterValue, const char* instanceIdentifier);
    const char* Bidapp_getParameterValue_platform(const char* parameterName, const char* instanceIdentifier);
    
#ifdef __cplusplus
#ifdef BIDAPP_USE_C_EXTERN
}
#endif
#endif

#endif
