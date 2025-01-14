using UnityEngine;
using System;

namespace Bidapp.AndroidWrapper
{
    public class BidappAndroidWrapper
    {
        private static readonly string BidappSDK = "io.bidapp.bidappUnity.BidappUnity";
        private static AndroidJavaClass _BidappSDK;

        private static AndroidJavaClass GetBridge()
        {
            if (_BidappSDK == null)
            {
                try
                {
                    _BidappSDK = new AndroidJavaClass(BidappSDK);
                }
                catch (Exception e)
                {
                    Debug.LogError($"Failed to initialize BidappSDK: {e.Message}");
                }
            }
            return _BidappSDK;
        }

        public static void Bidapp_start_platform(string pubid, string format)
        {
            try
            {
                GetBridge()?.CallStatic("start", pubid, format);
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to call start method on BidappSDK: {e.Message}");
            }
        }


        public static string Version
        {
            get
            {
                try
                {
                    return GetBridge()?.CallStatic<string>("getVersion");
                }
                catch (Exception e)
                {
                    Debug.LogError($"Failed to call getVersion method on BidappSDK: {e.Message}");
                }
                return "Unknown";
            }
        }


        public static void Bidapp_setLogging_platform(bool logging)
        {
            try
            {
                GetBridge()?.CallStatic("setLogging", logging);
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to call setLogging method on BidappSDK: {e.Message}");
            }
        }


        public static void Bidapp_setTestMode_platform(bool isEnabled)
        {
            try
            {
                GetBridge()?.CallStatic("setTestMode", isEnabled);
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to call setTestMode method on BidappSDK: {e.Message}");
            }
        }



        //----------------------------------------------------------------

        public static string Bidapp_createInterstitial_platform(bool enableAutoload)
        {
            try
            {
                var id = GetBridge()?.CallStatic<string>("createInterstitial", enableAutoload);
                return id;
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to create interstitial: {e.Message}");
                return "0";
            }
        }

        public static void Bidapp_loadInterstitial_platform(string identifier)
        {
            try
            {
                GetBridge()?.CallStatic("loadInterstitial", identifier);
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to load interstitial with identifier: {identifier}. Error: {e.Message}");
            }
        }

        public static void Bidapp_destroyInterstitial_platform(string identifier)
        {
            try
            {
                GetBridge()?.CallStatic("destroyInterstitial", identifier);
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to destroy interstitial with identifier: {identifier}. Error: {e.Message}");
            }
        }

        public static void Bidapp_showInterstitial_platform(string identifier)
        {
            try
            {
                GetBridge()?.CallStatic("showInterstitial", identifier);
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to show interstitial with identifier: {identifier}. Error: {e.Message}");
            }
        }

        public static bool Bidapp_isInterstitialAdReady_platform(string identifier)
            {
            try
            {
                var isAdReady = GetBridge().CallStatic<bool>("isInterstitialAdReady", identifier);
                return isAdReady;
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to run interstitial is ad ready method with identifier: {identifier}. Error: {e.Message}");
                return false;
            }
        }



        //----------------------------------------------------------------

        public static string Bidapp_createRewarded_platform(bool enableAutoload)
        {
            try
            {
                var id = GetBridge().CallStatic<string>("createRewarded", enableAutoload);
                return id;
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to create rewarded ad: {e.Message}");
                return "0";
            }
        }

        public static void Bidapp_loadRewarded_platform(string identifier)
        {
            try
            {
                GetBridge().CallStatic("loadRewarded", identifier);
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to load rewarded ad with identifier: {identifier}. Error: {e.Message}");
            }
        }

        public static void Bidapp_destroyRewarded_platform(string identifier)
        {
            try
            {
                GetBridge().CallStatic("destroyRewarded", identifier);
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to destroy rewarded ad with identifier: {identifier}. Error: {e.Message}");
            }
        }

        public static void Bidapp_showRewarded_platform(string identifier)
        {
            try
            {
                GetBridge().CallStatic("showRewarded", identifier);
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to show rewarded ad with identifier: {identifier}. Error: {e.Message}");
            }
        }



        public static bool Bidapp_isRewardedAdReady_platform(string identifier)
        {
            try
            {
                var isAdReady = GetBridge().CallStatic<bool>("isRewardedAdReady", identifier);
                return isAdReady;
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to run rewarded is ad ready method with identifier: {identifier}. Error: {e.Message}");
                return false;
            }
        }

        //----------------------------------------------------------------


        public static string Bidapp_showBanner_platform(float x, float y)
        {
            try
            {
                var id = GetBridge().CallStatic<string>("showBanner", x, y);
                return id;
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to show banner: {e.Message}");
                return "0";
            }
        }

        public static string Bidapp_showBanner_platform(string bannerSize, float x, float y)
        {
            try
            {
                var id = GetBridge().CallStatic<string>("showBanner", x, y, bannerSize);
                return id;
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to show banner with size {bannerSize}: {e.Message}");
                return "0";
            }
        }

        public static string Bidapp_showBannerAtPosition_platform(string bannerPosition)
        {
            try
            {
                var id = GetBridge().CallStatic<string>("showBannerAtPosition", bannerPosition);
                return id;
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to show banner at position {bannerPosition}: {e.Message}");
                return "0";
            }
        }

        public static string Bidapp_showBannerAtPosition_platform(string bannerPosition, string bannerSize)
        {
            try
            {
                var id = GetBridge().CallStatic<string>("showBannerAtPosition", bannerPosition, bannerSize);
                return id;
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to show banner at position {bannerPosition} with size {bannerSize}: {e.Message}");
                return "0";
            }
        }

        public static void Bidapp_stopBannerAutorefresh_platform(string identifier)
        {
            try
            {
                GetBridge().CallStatic("stopBannerAutorefresh", identifier);
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to stop banner autorefresh for identifier {identifier}: {e.Message}");
            }
        }

        public static void Bidapp_setBannerRefreshInterval_platform(string identifier, double refreshInterval)
        {
            try
            {
                GetBridge().CallStatic("setBannerRefreshInterval", identifier, refreshInterval);
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to set banner refresh interval for identifier {identifier}: {e.Message}");
            }
        }

        public static void Bidapp_refreshBanner_platform(string identifier)
        {
            try
            {
                GetBridge().CallStatic("refreshBanner", identifier);
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to refresh banner for identifier {identifier}: {e.Message}");
            }
        }

        public static void Bidapp_removeBanner_platform(string identifier)
        {
            try
            {
                GetBridge().CallStatic("removeBanner", identifier);
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to remove banner for identifier {identifier}: {e.Message}");
            }
        }

        //----------------------------------------------------------------

        public static void Bidapp_setGDPRConsent_platform(bool consent)
        {
            try
            {
                GetBridge().CallStatic("setGDPRConsent", consent);
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to set GDPR consent: {e.Message}");
            }
        }

        public static void Bidapp_setCCPAConsent_platform(bool consent)
        {
            try
            {
                GetBridge().CallStatic("setCCPAConsent", consent);
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to set CCPA consent: {e.Message}");
            }
        }

        public static void Bidapp_setSubjectToCOPPA_platform(bool consent)
        {
            try
            {
                GetBridge().CallStatic("setSubjectToCOPPA", consent);
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to set COPPA consent: {e.Message}");
            }
        }


        //----------------------------------------------------------------


        public static void Bidapp_requestTrackingAuthorization_platform()
        {
            try
            {
                GetBridge().CallStatic("requestTrackingAuthorization");
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to request tracking authorization: {e.Message}");
            }
        }

        public static void Bidapp_setUnityCallbackTargetName_platform(ATABidappAdListener sdkDelegate)
        {
            try
            {
                GetBridge().CallStatic("setCallback", sdkDelegate);
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to set Unity callback target: {e.Message}");
            }
        }

        public static void Bidapp_pause_platform(bool pauseStatus)
        {
            try
            {
                string method = pauseStatus ? "onPause" : "onResume";
                GetBridge().CallStatic(method);
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to pause/resume: {e.Message}");
            }
        }

    }


}