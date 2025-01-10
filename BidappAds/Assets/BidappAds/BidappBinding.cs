using UnityEngine;

namespace Bidapp
{
    public class BidappBinding
    {
        private static BidappBinding IosInstance;
        private static BidappBinding AndroidInstance;
        private static BidappBinding OtherInstance;

        public static BidappBinding Instance
        {
            get
            {
                #if UNITY_IOS || UNITY_IPHONE

                if (IosInstance == null)
                {
                    IosInstance = new BidappBindingIOS();
                }
                return IosInstance;

                #elif UNITY_ANDROID

                if (AndroidInstance == null)
                {
                    AndroidInstance = new BidappBindingAndroid();
                }
                return AndroidInstance;

                #else

                if (OtherInstance == null)
                {
                    OtherInstance = new BidappBinding();
                }
                return OtherInstance;

                #endif
            }
        }

        public virtual void Start(string appId, string formats)
        {
        }

        public virtual void SetLogging(bool logging)
        {
        }

        public virtual string CreateInterstitial()
        {
            return "";
        }

        public virtual void DestroyInterstitial(string identifier)
        {
        }

        public virtual void ShowInterstitial(string identifier)
        {
        }

        public virtual bool IsInterstitialAdReady(string identifier)
        {
            return false;
        }

        public virtual string CreateRewarded()
        {
            return "";
        }

        public virtual void DestroyRewarded(string identifier)
        {
        }

        public virtual void ShowRewarded(string identifier)
        {
        }

         public virtual bool IsRewardedAdReady(string identifier)
         {
            return false;
         }

        public virtual string ShowBanner(string bannerSize = BidappBannerSize.Size_320x50, float x = 0.0f, float y = 0.0f, float width = 320.0f, float height = 50.0f)
        {
            return "";
        }

        public virtual string ShowBannerAtPosition(string position, string bannerSize, float marginTop = 0, float marginLeft = 0, float marginBottom = 0, float marginRight = 0)
        {
            return "";
        }

        public virtual void StopBannerAutorefresh(string identifier)
        {
        }

        public virtual void SetBannerRefreshInterval(string identifier, double refreshInterval)
        {
        }

        public virtual void RefreshBanner(string identifier)
        {
        }

        public virtual void RemoveBanner(string identifier)
        {
        }

        public virtual void SetTestMode(bool isEnabled) { }

        public virtual void SetCallbacks(BidappSDKDelegate sdkDelegate) { }

        public virtual void OnPause(bool pauseStatus) { }
        public virtual void Pause(bool pauseStatus) { }
        public virtual void SetGDPRConsent(bool consent) { }
        public virtual void SetCCPAConsent(bool consent) { }
        public virtual void SetSubjectToCOPPA(bool consent) { }

        public virtual void RequestTrackingAuthorization() { }

        public virtual void SetParameterValue(string parameterName, string parameterValue, string instanceIdentifier="") { }
        public virtual string GetParameterValue(string parameterName, string instanceIdentifier = "")
        {
            return "";
        }
    }
}
