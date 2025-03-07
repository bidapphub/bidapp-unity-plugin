using UnityEngine;
using System.Runtime.InteropServices;

namespace Bidapp
{
        public class BidappBindingIOS : BidappBinding
        {
#if UNITY_IOS
                //---

                [DllImport("__Internal")]
                private static extern void Bidapp_start_platform(string pubid, string formats);

                public override void Start(string pubid, string formats)
                {
                        if (!string.IsNullOrEmpty(formats) && formats.Contains("-"))
                        {
                                Debug.Log("!!! WARNING !!! You passed Bidapp pubid value to the formats parameter while calling start() method!");
                        }

                        Bidapp_start_platform(pubid, formats);
                        SetCallbacks(BidappSDKDelegate.Instance);
                }

                //---
                [DllImport("__Internal")]
                private static extern void Bidapp_setLogging_platform(bool logging);

                public override void SetLogging(bool logging)
                {
                        Bidapp_setLogging_platform(logging);
                }

                //---
                [DllImport("__Internal")]
                private static extern void Bidapp_setTestMode_platform(bool testMode);

                public override void SetTestMode(bool testMode)
                {
                        Bidapp_setTestMode_platform(testMode);
                }

                //---
                [DllImport("__Internal")]
                private static extern string Bidapp_createInterstitial_platform();

                public override string CreateInterstitial()
                {
                        return Bidapp_createInterstitial_platform();
                }

                //---
                [DllImport("__Internal")]
                private static extern void Bidapp_destroyInterstitial_platform(string identifier);

                public override void DestroyInterstitial(string identifier)
                {
                        BidappSDKDelegate.Instance.RemoveInterstitialDelegate(identifier);
                        Bidapp_destroyInterstitial_platform(identifier);
                }

                //---
                [DllImport("__Internal")]
                private static extern void Bidapp_showInterstitial_platform(string identifier);

                public override void ShowInterstitial(string identifier)
                {
                        Bidapp_showInterstitial_platform(identifier);
                }

                //---
                [DllImport("__Internal")]
                private static extern bool Bidapp_isAdReady_platform(string identifier);

                public override bool IsInterstitialAdReady(string identifier)
                {
                        return Bidapp_isAdReady_platform(identifier);
                }

                //---
                [DllImport("__Internal")]
                private static extern string Bidapp_createRewarded_platform();

                public override string CreateRewarded()
                {
                        return Bidapp_createRewarded_platform();
                }

                //---
                [DllImport("__Internal")]
                private static extern void Bidapp_destroyRewarded_platform(string identifier);

                public override void DestroyRewarded(string identifier)
                {
                        BidappSDKDelegate.Instance.RemoveRewardedDelegate(identifier);
                        Bidapp_destroyRewarded_platform(identifier);
                }

                //---
                [DllImport("__Internal")]
                private static extern void Bidapp_showRewarded_platform(string identifier);

                public override void ShowRewarded(string identifier)
                {
                        Bidapp_showRewarded_platform(identifier);
                }

                public override bool IsRewardedAdReady(string identifier)
                {
                        return Bidapp_isAdReady_platform(identifier);
                }

                //---
                [DllImport("__Internal")]
                private static extern string Bidapp_showBanner_platform(string bannerSize, float x, float y, float width, float height);

                public override string ShowBanner(string bannerSize, float x, float y, float width, float height)
                {
                        return Bidapp_showBanner_platform(bannerSize, x, y, width, height);
                }

                //---
                [DllImport("__Internal")]
                private static extern string Bidapp_showBannerAtPosition_platform(string position, string bannerSize, float marginTop, float marginLeft, float marginBottom, float marginRight);

                public override string ShowBannerAtPosition(string position, string bannerSize, float marginTop, float marginLeft, float marginBottom, float marginRight)
                {
                        return Bidapp_showBannerAtPosition_platform(position, bannerSize, marginTop, marginLeft, marginBottom, marginRight);
                }

                //---
                [DllImport("__Internal")]
                private static extern void Bidapp_stopBannerAutorefresh_platform(string identifier);

                public override void StopBannerAutorefresh(string identifier)
                {
                        Bidapp_stopBannerAutorefresh_platform(identifier);
                }

                //---
                [DllImport("__Internal")]
                private static extern void Bidapp_setBannerRefreshInterval_platform(string identifier, double refreshInterval);

                public override void SetBannerRefreshInterval(string identifier, double refreshInterval)
                {
                        Bidapp_setBannerRefreshInterval_platform(identifier, refreshInterval);
                }

                //---
                [DllImport("__Internal")]
                private static extern void Bidapp_refreshBanner_platform(string identifier);

                public override void RefreshBanner(string identifier)
                {
                        Bidapp_refreshBanner_platform(identifier);
                }

                //---
                [DllImport("__Internal")]
                private static extern void Bidapp_removeBanner_platform(string identifier);

                public override void RemoveBanner(string identifier)
                {
                        BidappSDKDelegate.Instance.RemoveBannerDelegate(identifier);
                        Bidapp_removeBanner_platform(identifier);
                }

                //---
                [DllImport("__Internal")]
                private static extern void Bidapp_setGDPRConsent_platform(bool consent);

                public override void SetGDPRConsent(bool consent)
                {
                        Bidapp_setGDPRConsent_platform(consent);
                }

                //---
                [DllImport("__Internal")]
                private static extern void Bidapp_setCCPAConsent_platform(bool consent);

                public override void SetCCPAConsent(bool consent)
                {
                        Bidapp_setCCPAConsent_platform(consent);
                }

                //---
                [DllImport("__Internal")]
                private static extern void Bidapp_setSubjectToCOPPA_platform(bool consent);

                public override void SetSubjectToCOPPA(bool consent)
                {
                        Bidapp_setSubjectToCOPPA_platform(consent);
                }

                //---
                [DllImport("__Internal")]
                private static extern void Bidapp_requestTrackingAuthorization_platform();

                public override void RequestTrackingAuthorization()
                {
                        Bidapp_requestTrackingAuthorization_platform();
                }

                //---
                [DllImport("__Internal")]
                private static extern void Bidapp_setUnityCallbackTargetName_platform(string targetName);

                public void SetUnityCallbackTargetName(string targetName)
                {
                        Bidapp_setUnityCallbackTargetName_platform(targetName);
                }

                //---
                public override void SetCallbacks(BidappSDKDelegate sdkDelegate)
                {
                        SetUnityCallbackTargetName(sdkDelegate.name);
                }

                //---
                [DllImport("__Internal")]
                private static extern void Bidapp_pause_platform(bool pauseStatus);

                public override void Pause(bool pauseStatus)
                {
                        Bidapp_pause_platform(pauseStatus);
                }

                //---
                [DllImport("__Internal")]
                private static extern void Bidapp_setParameterValue_platform(string parameterName, string parameterValue, string instanceIdentifier);

                public override void SetParameterValue(string parameterName, string parameterValue, string instanceIdentifier)
                {
                        Bidapp_setParameterValue_platform(parameterName, parameterValue, instanceIdentifier);
                }

                //---
                [DllImport("__Internal")]
                private static extern string Bidapp_getParameterValue_platform(string parameterName, string instanceIdentifier);

                public override string GetParameterValue(string parameterName, string instanceIdentifier)
                {
                        return Bidapp_getParameterValue_platform(parameterName, instanceIdentifier);
                }

#endif
    }
}
