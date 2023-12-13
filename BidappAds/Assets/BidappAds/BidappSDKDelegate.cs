using System;
using UnityEngine;

namespace Bidapp
{
    public class BidappSDKDelegate : MonoBehaviour
    {
        public event Action<string, string> OnInterstitialDidLoadAd;
        public event Action<string, string, string> OnInterstitialDidFailToLoadAd;
        public event Action<string, string> OnInterstitialDidDisplayAd;
        public event Action<string, string> OnInterstitialDidClickAd;
        public event Action<string, string> OnInterstitialDidHideAd;
        public event Action<string, string, string> OnInterstitialDidFailToDisplayAd;
        public event Action<string> OnInterstitialAllNetworksFailedToDisplayAd;

        public event Action<string, string> OnRewardedDidLoadAd;
        public event Action<string, string, string> OnRewardedDidFailToLoadAd;
        public event Action<string, string> OnRewardedDidDisplayAd;
        public event Action<string, string> OnRewardedDidClickAd;
        public event Action<string, string> OnRewardedDidHideAd;
        public event Action<string, string, string> OnRewardedDidFailToDisplayAd;
        public event Action<string> OnRewardedAllNetworksFailedToDisplayAd;
        public event Action<string> OnUserDidReceiveReward;

        public event Action<string,string> OnBannerDidDisplayAd;
        public event Action<string,string,string> OnBannerFailedToDisplayAd;
        public event Action<string,string> OnBannerClicked;
        public event Action<string> OnBannerAllNetworksFailedToDisplayAd;

        public static BidappSDKDelegate CreateInstance(MonoBehaviour obj)
        {
            BidappSDKDelegate sdkDelegate = null;
            #if UNITY_IOS || UNITY_IPHONE

            sdkDelegate = obj.gameObject.AddComponent<BidappSDKDelegateIOS>();

            #elif UNITY_ANDROID

            sdkDelegate = obj.gameObject.AddComponent<BidappSDKDelegateAndroid>();

            #else

            sdkDelegate = obj.gameObject.AddComponent<BidappSDKDelegate>();

            #endif

            return sdkDelegate;
        }

        protected void event_OnInterstitialDidLoadAd(string identifier, string networkId)
        {
            if (OnInterstitialDidLoadAd != null)
            {
                OnInterstitialDidLoadAd(identifier, networkId);
            }
        }

        protected void event_OnInterstitialDidFailToLoadAd(string identifier, string networkId, string errorDescription)
        {
            if (OnInterstitialDidFailToLoadAd != null)
            {
                OnInterstitialDidFailToLoadAd(identifier, networkId, errorDescription);
            }
        }

        protected void event_OnInterstitialDidDisplayAd(string identifier, string networkId)
        {
            if (OnInterstitialDidDisplayAd != null)
            {
                OnInterstitialDidDisplayAd(identifier, networkId);
            }

            BidappBinding.Instance.Pause(true);
        }

        protected void event_OnInterstitialDidClickAd(string identifier, string networkId)
        {
            if (OnInterstitialDidClickAd != null)
            {
                OnInterstitialDidClickAd(identifier, networkId);
            }
        }

        protected void event_OnInterstitialDidHideAd(string identifier, string networkId)
        {
            if (OnInterstitialDidHideAd != null)
            {
                OnInterstitialDidHideAd(identifier, networkId);
            }
        }

        protected void event_OnInterstitialDidFailToDisplayAd(string identifier, string networkId, string errorDescription)
        {
            if (OnInterstitialDidFailToDisplayAd != null)
            {
                OnInterstitialDidFailToDisplayAd(identifier, networkId, errorDescription);
            }
        }

        protected void event_OnInterstitialAllNetworksFailedToDisplayAd(string identifier)
        {
            if (OnInterstitialAllNetworksFailedToDisplayAd != null)
            {
                OnInterstitialAllNetworksFailedToDisplayAd(identifier);
            }
        }

        protected void event_OnRewardedDidLoadAd(string identifier, string networkId)
        {
            if (OnRewardedDidLoadAd != null)
            {
                OnRewardedDidLoadAd(identifier, networkId);
            }
        }

        protected void event_OnRewardedDidFailToLoadAd(string identifier, string networkId, string errorDescription)
        {
            if (OnRewardedDidFailToLoadAd != null)
            {
                OnRewardedDidFailToLoadAd(identifier, networkId, errorDescription);
            }
        }

        protected void event_OnRewardedDidDisplayAd(string identifier, string networkId)
        {
            if (OnRewardedDidDisplayAd != null)
            {
                OnRewardedDidDisplayAd(identifier, networkId);
            }

            BidappBinding.Instance.Pause(true);
        }

        protected void event_OnRewardedDidClickAd(string identifier, string networkId)
        {
            if (OnRewardedDidClickAd != null)
            {
                OnRewardedDidClickAd(identifier, networkId);
            }
        }

        protected void event_OnRewardedDidHideAd(string identifier, string networkId)
        {
            if (OnRewardedDidHideAd != null)
            {
                OnRewardedDidHideAd(identifier, networkId);
            }
        }

        protected void event_OnRewardedDidFailToDisplayAd(string identifier, string networkId, string errorDescription)
        {
            if (OnRewardedDidFailToDisplayAd != null)
            {
                OnRewardedDidFailToDisplayAd(identifier, networkId, errorDescription);
            }
        }

        protected void event_OnRewardedAllNetworksFailedToDisplayAd(string identifier)
        {
            if (OnRewardedAllNetworksFailedToDisplayAd != null)
            {
                OnRewardedAllNetworksFailedToDisplayAd(identifier);
            }
        }

        protected void event_OnUserDidReceiveReward(string identifier)
        {
            if (OnUserDidReceiveReward != null)
            {
                OnUserDidReceiveReward(identifier);
            }
        }

        protected void event_OnBannerDidDisplayAd(string identifier, string networkId)
        {
            if (OnBannerDidDisplayAd != null)
            {
                OnBannerDidDisplayAd(identifier,networkId);
            }
        }

        protected void event_OnBannerFailedToDisplayAd(string identifier, string networkId, string errorDescription)
        {
            if (OnBannerFailedToDisplayAd != null)
            {
                OnBannerFailedToDisplayAd(identifier, networkId, errorDescription);
            }
        }

        protected void event_OnBannerClicked(string identifier, string networkId)
        {
            if (OnBannerClicked != null)
            {
                OnBannerClicked(identifier,networkId);
            }
        }

        protected void event_OnBannerAllNetworksFailedToDisplayAd(string identifier)
        {
            if (OnBannerAllNetworksFailedToDisplayAd != null)
            {
                OnBannerAllNetworksFailedToDisplayAd(identifier);
            }
        }
    }
}
