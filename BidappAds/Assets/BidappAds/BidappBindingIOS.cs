using UnityEngine;
using System.Runtime.InteropServices;

namespace Bidapp
{
    public class BidappBindingIOS : BidappBinding
    {
        //---
#if UNITY_IOS
[DllImport("__Internal")]
private static extern void Bidapp_start_platform(string pubid, string formats);
#endif

        public override void Start(string pubid, string formats)
        {
#if UNITY_IOS
    if (!string.IsNullOrEmpty(formats) && formats.Contains("-"))
    {
        Debug.Log("!!! WARNING !!! You passed Bidapp pubid value to the formats parameter while calling start() method!");
    }

    Bidapp_start_platform(pubid, formats);
#endif
        }

        //---
#if UNITY_IOS
    [DllImport("__Internal")]
    private static extern void Bidapp_setLogging_platform(bool logging);
#endif

        public override void SetLogging(bool logging)
        {
#if UNITY_IOS
    Bidapp_setLogging_platform(logging);
#elif UNITY_ANDROID
    Debug.Log("SetLogging is not supported on Android.");
#else
            Debug.LogWarning("SetLogging is not supported on this platform.");
#endif
        }

        //---
#if UNITY_IOS
[DllImport("__Internal")]
private static extern void Bidapp_setTestMode_platform(bool testMode);
#endif

        public override void SetTestMode(bool testMode)
        {
#if UNITY_IOS
    Bidapp_setTestMode_platform(testMode);
#else
            Debug.LogWarning("SetTestMode is not supported on this platform.");
#endif
        }

        //---
#if UNITY_IOS
[DllImport("__Internal")]
private static extern string Bidapp_createInterstitial_platform();
#endif

        public override string CreateInterstitial()
        {
#if UNITY_IOS
    return Bidapp_createInterstitial_platform();
#else
            Debug.LogWarning("CreateInterstitial is not supported on this platform.");
            return string.Empty;
#endif
        }

        //---
#if UNITY_IOS
[DllImport("__Internal")]
private static extern void Bidapp_destroyInterstitial_platform(string identifier);
#endif

        public override void DestroyInterstitial(string identifier)
        {
#if UNITY_IOS
    Bidapp_destroyInterstitial_platform(identifier);
#else
            Debug.LogWarning("DestroyInterstitial is not supported on this platform.");
#endif
        }

        //---
#if UNITY_IOS
[DllImport("__Internal")]
private static extern void Bidapp_showInterstitial_platform(string identifier);
#endif

        public override void ShowInterstitial(string identifier)
        {
#if UNITY_IOS
    Bidapp_showInterstitial_platform(identifier);
#else
            Debug.LogWarning("ShowInterstitial is not supported on this platform.");
#endif
        }

        //---
#if UNITY_IOS
[DllImport("__Internal")]
private static extern string Bidapp_createRewarded_platform();
#endif

        public override string CreateRewarded()
        {
#if UNITY_IOS
    return Bidapp_createRewarded_platform();
#else
            Debug.LogWarning("CreateRewarded is not supported on this platform.");
            return string.Empty;
#endif
        }

        //---
#if UNITY_IOS
[DllImport("__Internal")]
private static extern void Bidapp_destroyRewarded_platform(string identifier);
#endif

        public override void DestroyRewarded(string identifier)
        {
#if UNITY_IOS
    Bidapp_destroyRewarded_platform(identifier);
#else
            Debug.LogWarning("DestroyRewarded is not supported on this platform.");
#endif
        }

        //---
#if UNITY_IOS
[DllImport("__Internal")]
private static extern void Bidapp_showRewarded_platform(string identifier);
#endif

        public override void ShowRewarded(string identifier)
        {
#if UNITY_IOS
    Bidapp_showRewarded_platform(identifier);
#else
            Debug.LogWarning("ShowRewarded is not supported on this platform.");
#endif
        }

        //---
#if UNITY_IOS
[DllImport("__Internal")]
private static extern string Bidapp_showBanner_platform(string bannerSize, float x, float y, float width, float height);
#endif

        public override string ShowBanner(string bannerSize, float x, float y, float width, float height)
        {
#if UNITY_IOS
    return Bidapp_showBanner_platform(bannerSize, x, y, width, height);
#else
            Debug.LogWarning("ShowBanner is not supported on this platform.");
            return string.Empty;
#endif
        }

        //---
#if UNITY_IOS
[DllImport("__Internal")]
private static extern string Bidapp_showBannerAtPosition_platform(string position, string bannerSize, float marginTop, float marginLeft, float marginBottom, float marginRight);
#endif

        public override string ShowBannerAtPosition(string position, string bannerSize, float marginTop, float marginLeft, float marginBottom, float marginRight)
        {
#if UNITY_IOS
    return Bidapp_showBannerAtPosition_platform(position, bannerSize, marginTop, marginLeft, marginBottom, marginRight);
#else
            Debug.LogWarning("ShowBannerAtPosition is not supported on this platform.");
            return string.Empty;
#endif
        }

        //---
#if UNITY_IOS
[DllImport("__Internal")]
private static extern void Bidapp_stopBannerAutorefresh_platform(string identifier);
#endif

        public override void StopBannerAutorefresh(string identifier)
        {
#if UNITY_IOS
    Bidapp_stopBannerAutorefresh_platform(identifier);
#else
            Debug.LogWarning("StopBannerAutorefresh is not supported on this platform.");
#endif
        }

        //---
#if UNITY_IOS
[DllImport("__Internal")]
private static extern void Bidapp_setBannerRefreshInterval_platform(string identifier, double refreshInterval);
#endif

        public override void SetBannerRefreshInterval(string identifier, double refreshInterval)
        {
#if UNITY_IOS
    Bidapp_setBannerRefreshInterval_platform(identifier, refreshInterval);
#else
            Debug.LogWarning("SetBannerRefreshInterval is not supported on this platform.");
#endif
        }

        //---
#if UNITY_IOS
[DllImport("__Internal")]
private static extern void Bidapp_refreshBanner_platform(string identifier);
#endif

        public override void RefreshBanner(string identifier)
        {
#if UNITY_IOS
    Bidapp_refreshBanner_platform(identifier);
#else
            Debug.LogWarning("RefreshBanner is not supported on this platform.");
#endif
        }

        //---
#if UNITY_IOS
[DllImport("__Internal")]
private static extern void Bidapp_removeBanner_platform(string identifier);
#endif

        public override void RemoveBanner(string identifier)
        {
#if UNITY_IOS
    Bidapp_removeBanner_platform(identifier);
#else
            Debug.LogWarning("RemoveBanner is not supported on this platform.");
#endif
        }

        //---
#if UNITY_IOS
[DllImport("__Internal")]
private static extern void Bidapp_setGDPRConsent_platform(bool consent);
#endif

        public override void SetGDPRConsent(bool consent)
        {
#if UNITY_IOS
    Bidapp_setGDPRConsent_platform(consent);
#else
            Debug.LogWarning("SetGDPRConsent is not supported on this platform.");
#endif
        }

        //---
#if UNITY_IOS
[DllImport("__Internal")]
private static extern void Bidapp_setCCPAConsent_platform(bool consent);
#endif

        public override void SetCCPAConsent(bool consent)
        {
#if UNITY_IOS
    Bidapp_setCCPAConsent_platform(consent);
#else
            Debug.LogWarning("SetCCPAConsent is not supported on this platform.");
#endif
        }

        //---
#if UNITY_IOS
[DllImport("__Internal")]
private static extern void Bidapp_setSubjectToCOPPA_platform(bool consent);
#endif

        public override void SetSubjectToCOPPA(bool consent)
        {
#if UNITY_IOS
    Bidapp_setSubjectToCOPPA_platform(consent);
#else
            Debug.LogWarning("SetSubjectToCOPPA is not supported on this platform.");
#endif
        }

        //---
#if UNITY_IOS
[DllImport("__Internal")]
private static extern void Bidapp_requestTrackingAuthorization_platform();
#endif

        public override void RequestTrackingAuthorization()
        {
#if UNITY_IOS
    Bidapp_requestTrackingAuthorization_platform();
#else
            Debug.LogWarning("RequestTrackingAuthorization is not supported on this platform.");
#endif
        }

        //---
#if UNITY_IOS
[DllImport("__Internal")]
private static extern void Bidapp_setUnityCallbackTargetName_platform(string targetName);
#endif

        public void SetUnityCallbackTargetName(string targetName)
        {
#if UNITY_IOS
    Bidapp_setUnityCallbackTargetName_platform(targetName);
#else
            Debug.LogWarning("SetUnityCallbackTargetName is not supported on this platform.");
#endif
        }

        //---
        public override void SetCallbacks(BidappSDKDelegate sdkDelegate)
        {
            SetUnityCallbackTargetName(sdkDelegate.name);
        }

        //---
#if UNITY_IOS
[DllImport("__Internal")]
private static extern void Bidapp_pause_platform(bool pauseStatus);
#endif

        public override void Pause(bool pauseStatus)
        {
#if UNITY_IOS
    Bidapp_pause_platform(pauseStatus);
#else
            Debug.LogWarning("Pause is not supported on this platform.");
#endif
        }

        //---
#if UNITY_IOS
[DllImport("__Internal")]
private static extern void Bidapp_setParameterValue_platform(string parameterName, string parameterValue, string instanceIdentifier);
#endif

        public override void SetParameterValue(string parameterName, string parameterValue, string instanceIdentifier)
        {
#if UNITY_IOS
    Bidapp_setParameterValue_platform(parameterName, parameterValue, instanceIdentifier);
#else
            Debug.LogWarning("SetParameterValue is not supported on this platform.");
#endif
        }

        //---
#if UNITY_IOS
[DllImport("__Internal")]
private static extern string Bidapp_getParameterValue_platform(string parameterName, string instanceIdentifier);
#endif

        public override string GetParameterValue(string parameterName, string instanceIdentifier)
        {
#if UNITY_IOS
    return Bidapp_getParameterValue_platform(parameterName, instanceIdentifier);
#else
            Debug.LogWarning("GetParameterValue is not supported on this platform.");
            return string.Empty;
#endif
        }

    }
}
