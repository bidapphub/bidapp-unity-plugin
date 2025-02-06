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
       private static readonly object _lock = new object();

        private static BidappSDKDelegate _sdkDelegate = null;
        public static BidappSDKDelegate Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_sdkDelegate == null)
                    {
                        CreateInstance();
                    }
                }
                return _sdkDelegate;
            }
        }

        private static void CreateInstance()
        {
            string objectName = "BidappSDKDelegate";

        #if UNITY_IOS || UNITY_IPHONE
            objectName = "BidappSDKDelegateIOS";
        #elif UNITY_ANDROID
            objectName = "BidappSDKDelegateAndroid";
        #endif

            var existingObject = GameObject.Find(objectName);
            if (existingObject != null)
            {
                _sdkDelegate = existingObject.GetComponent<BidappSDKDelegate>();
                return;
            }


        #if UNITY_IOS || UNITY_IPHONE
            var theType = typeof(BidappSDKDelegateIOS); 
            _sdkDelegate = new GameObject(objectName, theType).GetComponent<BidappSDKDelegateIOS>();
        #elif UNITY_ANDROID
            var theType = typeof(BidappSDKDelegateAndroid); 
            _sdkDelegate = new GameObject(objectName, theType).GetComponent<BidappSDKDelegateAndroid>();
        #else
            var theType = typeof(BidappSDKDelegate);
            _sdkDelegate = new GameObject(objectName, theType).GetComponent<BidappSDKDelegate>();
        #endif

        }

        void Awake()
        {
            DontDestroyOnLoad(gameObject); 
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
                return;
            }

            if (interstitialDelegate != null)
            {
                interstitialDelegates[identifier] = interstitialDelegate;  
            }
            else
            {
                interstitialDelegates.Remove(identifier);  
            }
        }

        public void SetRewardedDelegate(IBidappRewardedDelegate rewardedDelegate, string identifier)
        {
            if (string.IsNullOrEmpty(identifier))
            {
                 return;
            }

            if (rewardedDelegate != null)
            {
                rewardedDelegates[identifier] = rewardedDelegate;  
            }
            else
            {
                rewardedDelegates.Remove(identifier);  
            }
        }

        public void SetBannerDelegate(IBidappBannerDelegate bannerDelegate, string identifier)
        {
            if (string.IsNullOrEmpty(identifier))
            {
                return;
            }

            if (bannerDelegate != null)
            {
                bannerDelegates[identifier] = bannerDelegate; 
            }
            else
            {
                bannerDelegates.Remove(identifier);  
            }
        }

        internal void RemoveInterstitialDelegate(string identifier)
        {
            if (identifier == null)
            {
                Debug.LogWarning("Remove interstitial delegate: identifier is null");
                return;
            }
            interstitialDelegates.Remove(identifier);
        }

        internal void RemoveRewardedDelegate(string identifier)
        {
            if (identifier == null)
            {
                Debug.LogWarning("Remove rewarded delegate: identifier is null");
                return;
            }
            rewardedDelegates.Remove(identifier);
        }

        internal void RemoveBannerDelegate(string identifier)
        {
            if (identifier == null)
            {
                Debug.LogWarning("Remove banner delegate: identifier is null");
                return;
            }
            bannerDelegates.Remove(identifier);
        }


    }
}
