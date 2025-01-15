using System;
using UnityEngine;
using System.Collections.Generic;

namespace Bidapp
{
   public interface IBidappInterstitialDelegate
    {
        void OnInterstitialDidLoadAd(string identifier, string networkId);
        void OnInterstitialDidFailToLoadAd(string identifier, string networkId, string errorDescription);
        void OnInterstitialDidDisplayAd(string identifier, string networkId);
        void OnInterstitialDidClickAd(string identifier, string networkId);
        void OnInterstitialDidHideAd(string identifier, string networkId);
        void OnInterstitialDidFailToDisplayAd(string identifier, string networkId, string errorDescription);
        void OnInterstitialAllNetworksFailedToDisplayAd(string identifier); 
    }

   public interface IBidappRewardedDelegate
    {
        void OnRewardedDidLoadAd(string identifier, string networkId);
        void OnRewardedDidFailToLoadAd(string identifier, string networkId, string errorDescription);
        void OnRewardedDidDisplayAd(string identifier, string networkId);
        void OnRewardedDidClickAd(string identifier, string networkId);
        void OnRewardedDidHideAd(string identifier, string networkId);
        void OnRewardedDidFailToDisplayAd(string identifier, string networkId, string errorDescription);
        void OnRewardedAllNetworksFailedToDisplayAd(string identifier);
        void OnUserDidReceiveReward(string identifier);
    }
    
   public interface IBidappBannerDelegate
    {
        void OnBannerDidDisplayAd(string identifier, string networkId);
        void OnBannerFailedToDisplayAd(string identifier, string networkId, string errorDescription);
        void OnBannerClicked(string identifier, string networkId);
        void OnBannerAllNetworksFailedToDisplayAd(string identifier);
    }

    public class BidappSDKDelegate : MonoBehaviour
    {
        private Dictionary<string, IBidappInterstitialDelegate> interstitialDelegates = new Dictionary<string, IBidappInterstitialDelegate>();
        private Dictionary<string, IBidappRewardedDelegate> rewardedDelegates = new Dictionary<string, IBidappRewardedDelegate>();
        private Dictionary<string, IBidappBannerDelegate> bannerDelegates = new Dictionary<string, IBidappBannerDelegate>();

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
            IBidappInterstitialDelegate interstitialDelegate = null;
            if (interstitialDelegates.TryGetValue(identifier, out interstitialDelegate))
            {
                interstitialDelegate.OnInterstitialDidLoadAd(identifier, networkId);
            }
        }

        protected void event_OnInterstitialDidFailToLoadAd(string identifier, string networkId, string errorDescription)
        {
            IBidappInterstitialDelegate interstitialDelegate = null;
            if (interstitialDelegates.TryGetValue(identifier, out interstitialDelegate))
            {
                interstitialDelegate.OnInterstitialDidFailToLoadAd(identifier, networkId, errorDescription);
            }
        }

        protected void event_OnInterstitialDidDisplayAd(string identifier, string networkId)
        {
            IBidappInterstitialDelegate interstitialDelegate = null;
            if (interstitialDelegates.TryGetValue(identifier, out interstitialDelegate))
            {
                interstitialDelegate.OnInterstitialDidDisplayAd(identifier, networkId);
            }

            BidappBinding.Instance.Pause(true);
        }

        protected void event_OnInterstitialDidClickAd(string identifier, string networkId)
        {
            IBidappInterstitialDelegate interstitialDelegate = null;
            if (interstitialDelegates.TryGetValue(identifier, out interstitialDelegate))
            {
                interstitialDelegate.OnInterstitialDidClickAd(identifier, networkId);
            }
        }

        protected void event_OnInterstitialDidHideAd(string identifier, string networkId)
        {
            IBidappInterstitialDelegate interstitialDelegate = null;
            if (interstitialDelegates.TryGetValue(identifier, out interstitialDelegate))
            {
                interstitialDelegate.OnInterstitialDidHideAd(identifier, networkId);
            }
        }

        protected void event_OnInterstitialDidFailToDisplayAd(string identifier, string networkId, string errorDescription)
        {
            IBidappInterstitialDelegate interstitialDelegate = null;
            if (interstitialDelegates.TryGetValue(identifier, out interstitialDelegate))
            {
                interstitialDelegate.OnInterstitialDidFailToDisplayAd(identifier, networkId, errorDescription);
            }
        }

        protected void event_OnInterstitialAllNetworksFailedToDisplayAd(string identifier)
        {
            IBidappInterstitialDelegate interstitialDelegate = null;
            if (interstitialDelegates.TryGetValue(identifier, out interstitialDelegate))
            {
                interstitialDelegate.OnInterstitialAllNetworksFailedToDisplayAd(identifier);
            }
        }

        protected void event_OnRewardedDidLoadAd(string identifier, string networkId)
        {
            IBidappRewardedDelegate rewardedDelegate = null;
            if (rewardedDelegates.TryGetValue(identifier, out rewardedDelegate))
            {
                rewardedDelegate.OnRewardedDidLoadAd(identifier, networkId);
            }
        }

        protected void event_OnRewardedDidFailToLoadAd(string identifier, string networkId, string errorDescription)
        {
            IBidappRewardedDelegate rewardedDelegate = null;
            if (rewardedDelegates.TryGetValue(identifier, out rewardedDelegate)) {
                rewardedDelegate.OnRewardedDidFailToLoadAd(identifier, networkId, errorDescription);
            }
        }

        protected void event_OnRewardedDidDisplayAd(string identifier, string networkId)
        {
            IBidappRewardedDelegate rewardedDelegate = null;
            if (rewardedDelegates.TryGetValue(identifier, out rewardedDelegate)) {
                rewardedDelegate.OnRewardedDidDisplayAd(identifier, networkId);
            }

            BidappBinding.Instance.Pause(true);
        }

        protected void event_OnRewardedDidClickAd(string identifier, string networkId)
        {
            IBidappRewardedDelegate rewardedDelegate = null;
            if (rewardedDelegates.TryGetValue(identifier, out rewardedDelegate))
            {
                rewardedDelegate.OnRewardedDidClickAd(identifier, networkId);
            }
        }

        protected void event_OnRewardedDidHideAd(string identifier, string networkId)
        {
            IBidappRewardedDelegate rewardedDelegate = null;
            if (rewardedDelegates.TryGetValue(identifier, out rewardedDelegate))
            {
                rewardedDelegate.OnRewardedDidHideAd(identifier, networkId);
            }
        }

        protected void event_OnRewardedDidFailToDisplayAd(string identifier, string networkId, string errorDescription)
        {
            IBidappRewardedDelegate rewardedDelegate = null;
            if (rewardedDelegates.TryGetValue(identifier, out rewardedDelegate))
            {
                rewardedDelegate.OnRewardedDidFailToDisplayAd(identifier, networkId, errorDescription);
            }
        }

        protected void event_OnRewardedAllNetworksFailedToDisplayAd(string identifier)
        {
            IBidappRewardedDelegate rewardedDelegate = null;
            if (rewardedDelegates.TryGetValue(identifier, out rewardedDelegate))
            {
                rewardedDelegate.OnRewardedAllNetworksFailedToDisplayAd(identifier);
            }
        }

        protected void event_OnUserDidReceiveReward(string identifier)
        {
            IBidappRewardedDelegate rewardedDelegate = null;
            if (rewardedDelegates.TryGetValue(identifier, out rewardedDelegate))
            {
                rewardedDelegate.OnUserDidReceiveReward(identifier);
            }
        }

        protected void event_OnBannerDidDisplayAd(string identifier, string networkId)
        {
            IBidappBannerDelegate bannerDelegate = null;
            if (bannerDelegates.TryGetValue(identifier, out bannerDelegate))
            {
                bannerDelegate.OnBannerDidDisplayAd(identifier,networkId);
            }
        }

        protected void event_OnBannerFailedToDisplayAd(string identifier, string networkId, string errorDescription)
        {
            IBidappBannerDelegate bannerDelegate = null;
            if (bannerDelegates.TryGetValue(identifier, out bannerDelegate))
            {
                bannerDelegate.OnBannerFailedToDisplayAd(identifier, networkId, errorDescription);
            }
        }

        protected void event_OnBannerClicked(string identifier, string networkId)
        {
            IBidappBannerDelegate bannerDelegate = null;
            if (bannerDelegates.TryGetValue(identifier, out bannerDelegate))
            {
                bannerDelegate.OnBannerClicked(identifier,networkId);
            }
        }

        protected void event_OnBannerAllNetworksFailedToDisplayAd(string identifier)
        {
            IBidappBannerDelegate bannerDelegate = null;
            if (bannerDelegates.TryGetValue(identifier, out bannerDelegate))
            {
                bannerDelegate.OnBannerAllNetworksFailedToDisplayAd(identifier);
            }
        }
          

        protected void event_OnEvent(string[] arguments)
        {
            //Unknown event
        }

        public void SetInterstitialDelegate(IBidappInterstitialDelegate interstitialDelegate, string identifier)
        {
            if (string.IsNullOrEmpty(identifier))
            {
                // Обработка случая, когда идентификатор равен null или пустой строке
                return;
            }

            if (interstitialDelegate != null)
            {
                interstitialDelegates[identifier] = interstitialDelegate;  // добавление или обновление
            }
            else
            {
                interstitialDelegates.Remove(identifier);  // удаление
            }
        }

        public void SetRewardedDelegate(IBidappRewardedDelegate rewardedDelegate, string identifier)
        {
            if (string.IsNullOrEmpty(identifier))
            {
                // Обработка случая, когда идентификатор равен null или пустой строке
                return;
            }

            if (rewardedDelegate != null)
            {
                rewardedDelegates[identifier] = rewardedDelegate;  // добавление или обновление
            }
            else
            {
                rewardedDelegates.Remove(identifier);  // удаление
            }
        }

        public void SetBannerDelegate(IBidappBannerDelegate bannerDelegate, string identifier)
        {
            if (string.IsNullOrEmpty(identifier))
            {
                // Обработка случая, когда идентификатор равен null или пустой строке
                return;
            }

            if (bannerDelegate != null)
            {
                bannerDelegates[identifier] = bannerDelegate;  // добавление или обновление
            }
            else
            {
                bannerDelegates.Remove(identifier);  // удаление
            }
        }

    }
}
