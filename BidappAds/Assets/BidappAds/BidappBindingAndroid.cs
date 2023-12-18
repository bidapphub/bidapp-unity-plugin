using UnityEngine;
using Bidapp.AndroidWrapper;

namespace Bidapp
{
    public sealed class BidappBindingAndroid : BidappBinding
    {
        public void Bidapp_start_platform(string appId = "", string format = BidappFormat.Interstitial)
        {
            if (null != format &&
               (format.Contains(":")))
            {
			    Debug.Log("!!! WARNING !!! You passed AdCel appId value to the format parameter while calling start() method!");
			}
            Debug.Log("INITIALIZE");
			BidappAndroidWrapper.Bidapp_start_platform(appId, format);
        }
        public override void Start(string appId = "", string format = BidappFormat.Interstitial)
        {
            Bidapp_start_platform(appId, format);
        }

        //---
        public void Bidapp_setLogging_platform(bool logging)
        {
			BidappAndroidWrapper.Bidapp_setLogging_platform(logging);
        }
        public override void SetLogging(bool logging)
        {
            Bidapp_setLogging_platform(logging);
        }

              //---
		public void Bidapp_setTestMode_platform(bool isEnabled)
		{
			BidappAndroidWrapper.Bidapp_setTestMode_platform(isEnabled);
		}
        public override void SetTestMode(bool isEnabled)
        {
            Bidapp_setTestMode_platform(isEnabled);
        }

              //---
		public string Bidapp_createInterstitial_platform()
		{
			return BidappAndroidWrapper.Bidapp_createInterstitial_platform(true);
		}
        public override string CreateInterstitial()
        {
            return Bidapp_createInterstitial_platform();
        }


        public void Bidapp_destroyInterstitial_platform(string identifier)
		{
			BidappAndroidWrapper.Bidapp_destroyInterstitial_platform(identifier);
		}
        public override void DestroyInterstitial(string identifier)
        {
            Bidapp_destroyInterstitial_platform(identifier);
        }

        //---
         public void Bidapp_showInterstitial_platform(string identifier)
		{
			BidappAndroidWrapper.Bidapp_showInterstitial_platform(identifier);
		}
        public override void ShowInterstitial(string identifier)
        {
            Bidapp_showInterstitial_platform(identifier);
        }


        //---
		public string Bidapp_createRewarded_platform()
		{
			return BidappAndroidWrapper.Bidapp_createRewarded_platform(true);
		}
        public override string CreateRewarded()
        {
            return Bidapp_createRewarded_platform();
        }


        public void Bidapp_destroyRewarded_platform(string identifier)
		{
			BidappAndroidWrapper.Bidapp_destroyRewarded_platform(identifier);
		}
        public override void DestroyRewarded(string identifier)
        {
            Bidapp_destroyRewarded_platform(identifier);
        }

        //---
         public void Bidapp_showRewarded_platform(string identifier)
		{
			BidappAndroidWrapper.Bidapp_showRewarded_platform(identifier);
		}
        public override void ShowRewarded(string identifier)
        {
            Bidapp_showRewarded_platform(identifier);
        }

        //---
        public string Bidapp_showBanner_platform(string bannerSize = BidappBannerSize.Size_320x50, float x = 0.0f, float y = 0.0f, float width = 320.0f, float height = 50.0f)
		{
			return BidappAndroidWrapper.Bidapp_showBanner_platform(bannerSize, x, y);
		}
        public override string ShowBanner(string bannerSize = BidappBannerSize.Size_320x50, float x = 0.0f, float y = 0.0f, float width = 320.0f, float height = 50.0f)
        {
            return Bidapp_showBanner_platform(bannerSize, x, y, width, height);
        }

        //---
		public string Bidapp_showBannerAtPosition_platform(string position, string bannerSize, float marginTop = 0, float marginLeft = 0, float marginBottom = 0, float marginRight = 0)
		{
			return BidappAndroidWrapper.Bidapp_showBannerAtPosition_platform(position, bannerSize);
		}
        public override string ShowBannerAtPosition(string position, string bannerSize, float marginTop = 0, float marginLeft = 0, float marginBottom = 0, float marginRight = 0)
        {
            return Bidapp_showBannerAtPosition_platform(position, bannerSize, marginTop, marginLeft, marginBottom, marginRight);
        }

            //---
         public void Bidapp_stopBannerAutorefresh_platform(string identifier)
		{
			BidappAndroidWrapper.Bidapp_stopBannerAutorefresh_platform(identifier);
		}
        public override void StopBannerAutorefresh(string identifier)
        {
           Bidapp_stopBannerAutorefresh_platform(identifier);
        }

            //---
         public void Bidapp_setBannerRefreshInterval_platform(string identifier, double refreshInterval)
		{
			BidappAndroidWrapper.Bidapp_setBannerRefreshInterval_platform(identifier, refreshInterval);
		}
        public override void SetBannerRefreshInterval(string identifier, double refreshInterval)
        {
            Bidapp_setBannerRefreshInterval_platform(identifier, refreshInterval);
        }

            //---
         public void Bidapp_refreshBanner_platform(string identifier)
		{
			BidappAndroidWrapper.Bidapp_refreshBanner_platform(identifier);
		}
        public override void RefreshBanner(string identifier)
        {
            Bidapp_refreshBanner_platform(identifier);
        }

            //---
         public void Bidapp_removeBanner_platform(string identifier)
		{
			BidappAndroidWrapper.Bidapp_removeBanner_platform(identifier);
		}
        public override void RemoveBanner(string identifier)
        {
            Bidapp_removeBanner_platform(identifier);
        }

                  //---
         public void Bidapp_setGDPRConsent_platform(bool consent)
		{
			BidappAndroidWrapper.Bidapp_setGDPRConsent_platform(consent);
		}
        public override void SetGDPRConsent(bool consent)
        {
            Bidapp_setGDPRConsent_platform(consent);
        }

                     //---
         public void Bidapp_setCCPAConsent_platform(bool consent)
		{
			BidappAndroidWrapper.Bidapp_setCCPAConsent_platform(consent);
		}
        public override void SetCCPAConsent(bool consent)
        {
            Bidapp_setCCPAConsent_platform(consent);
        }

                     //---
         public void Bidapp_setSubjectToCOPPA_platform(bool consent)
		{
			BidappAndroidWrapper.Bidapp_setSubjectToCOPPA_platform(consent);
		}
        public override void SetSubjectToCOPPA(bool consent)
        {
            Bidapp_setSubjectToCOPPA_platform(consent);
        }

                       //---
         public void Bidapp_requestTrackingAuthorization_platform()
		{
			BidappAndroidWrapper.Bidapp_requestTrackingAuthorization_platform();
		}
        public override void RequestTrackingAuthorization()
        {
            Bidapp_requestTrackingAuthorization_platform();
        }


                          //---
         public void Bidapp_setUnityCallbackTargetName_platform(BidappSDKDelegate sdkDelegate)
		{
            BidappSDKDelegateAndroid sdkDelegateAndroid = (BidappSDKDelegateAndroid)sdkDelegate;
			BidappAndroidWrapper.Bidapp_setUnityCallbackTargetName_platform(sdkDelegateAndroid.GetAndroidAdListener());
		}
        public override void SetCallbacks(BidappSDKDelegate sdkDelegate)
        {
            Bidapp_setUnityCallbackTargetName_platform(sdkDelegate);
        }


        
        //---
        public void Bidapp_pause_platform(bool pauseStatus)
        {
			BidappAndroidWrapper.Bidapp_pause_platform(pauseStatus);
        }
        public override void OnPause(bool pauseStatus)
        {
            Bidapp_pause_platform(pauseStatus);
        }

    }
}


