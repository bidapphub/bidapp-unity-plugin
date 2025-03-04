using System;
using UnityEngine;

namespace Bidapp.AndroidWrapper 
{

	public abstract class ATABidappAdListener 
#if UNITY_ANDROID 
        : AndroidJavaProxy
#endif
	{
        protected ATABidappAdListener() 
#if UNITY_ANDROID
            : base("io.bidapp.bidappUnity.BidappAdsListener")
#endif
		{
		}

	
		public virtual void OnInterstitialDidLoadAd(String identifier, String networkId)
		{
        }

		public virtual void OnInterstitialDidFailToLoadAd(String identifier, String networkId, String errorDescription)
		{
		}

		public virtual void OnInterstitialDidDisplayAd(String identifier, String networkId)
		{
        }

		public virtual void OnInterstitialDidClickAd(String identifier, String networkId)
		{
        }

		public virtual void OnInterstitialDidHideAd(String identifier, String networkId)
		{
        }

		public virtual void OnInterstitialDidFailToDisplayAd(String identifier, String networkId, String errorDescription)
		{
        }

        public virtual void OnInterstitialDidReceiveRevenue(String identifier, String networkId, String networkName, double revenue, String precision)
        {
        }

        public virtual void OnInterstitialAllNetworksFailedToDisplayAd(String errorDescription)
		{
        }





		public virtual void OnRewardedDidLoadAd(String identifier, String networkId)
		{
        }

		public virtual void OnRewardedDidFailToLoadAd(String identifier, String networkId, String errorDescription)
		{
        }

		public virtual void OnRewardedDidDisplayAd(String identifier, String networkId)
		{
        }

		public virtual void OnRewardedDidClickAd(String identifier, String networkId)
		{
        }

		public virtual void OnRewardedDidHideAd(String identifier, String networkId)
		{
        }

		public virtual void OnRewardedDidFailToDisplayAd(String identifier, String networkId, String errorDescription)
		{
        }

		public virtual void OnRewardedAllNetworksFailedToDisplayAd(String errorDescription)
		{
        }

        public virtual void OnRewardedDidReceiveRevenue(String identifier, String networkId, String networkName, double revenue, String precision)
        {
        }

        public virtual void OnUserDidReceiveReward(String identifier)
		{
        }



		public virtual void OnBannerDidLoadAd(String identifier, String networkId)
		{
        }

		public virtual void OnBannerDidDisplayAd(String identifier, String networkId)
		{
        }

		public virtual void OnBannerFailedToDisplayAd(String identifier, String networkId, String errorDescription)
		{
        }

		public virtual void OnBannerClicked(String identifier, String networkId)
		{
        }

        public virtual void OnBannerDidReceiveRevenue(String identifier, String networkId, String networkName, double revenue, String precision)
        {
        }

        public virtual void OnBannerAllNetworksFailedToDisplayAd(String identifier)
		{
        }

    }
}