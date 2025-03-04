using System;
using Bidapp.AndroidWrapper;
using UnityEngine;

namespace Bidapp
{
    public sealed class BidappSDKDelegateAndroid : BidappSDKDelegate
    {
        public ATABidappAdListener GetAndroidAdListener()
        {
            return new AndroidAdListener(this);
        }


        private class AndroidAdListener : ATABidappAdListener
        {
            private readonly BidappSDKDelegateAndroid _sdkDelegate;

            public AndroidAdListener(BidappSDKDelegateAndroid sdkDelegate)
            {
                _sdkDelegate = sdkDelegate;
            }
            public override void OnInterstitialDidLoadAd(String identifier, String networkId)
            {
                BidappThreadUtil.Post(state => _sdkDelegate.event_OnInterstitialDidLoadAd(identifier, networkId));                
            }
            public override void OnInterstitialDidFailToLoadAd(String identifier, String networkId, String errorDescription)
            {
                BidappThreadUtil.Post(state => _sdkDelegate.event_OnInterstitialDidFailToLoadAd(identifier, networkId, errorDescription));
            }           
            public override void OnInterstitialDidDisplayAd(String identifier, String networkId)
            {
                BidappThreadUtil.Post(state => _sdkDelegate.event_OnInterstitialDidDisplayAd(identifier, networkId));                
            }
            public override void OnInterstitialDidClickAd(String identifier, String networkId)
            {
                BidappThreadUtil.Post(state => _sdkDelegate.event_OnInterstitialDidClickAd(identifier, networkId));              
            }
            public override void OnInterstitialDidHideAd(String identifier, String networkId)
            {
                BidappThreadUtil.Post(state => _sdkDelegate.event_OnInterstitialDidHideAd(identifier, networkId));                
            }
            public override void OnInterstitialDidFailToDisplayAd(String identifier, String networkId, String errorDescription)
            {
                BidappThreadUtil.Post(state => _sdkDelegate.event_OnInterstitialDidFailToDisplayAd(identifier, networkId, errorDescription));
            }

            public override void OnInterstitialDidReceiveRevenue(string identifier, string networkId, string networkName, double revenue, string precision)
            {
                BidappThreadUtil.Post(state => _sdkDelegate.event_OnInterstitialDidReceiveRevenue(identifier, networkId, networkName, revenue, precision));
            }

            public override void OnInterstitialAllNetworksFailedToDisplayAd(String errorDescription)
            {
                BidappThreadUtil.Post(state => _sdkDelegate.event_OnInterstitialAllNetworksFailedToDisplayAd(errorDescription));
            }



            public override void OnRewardedDidLoadAd(String identifier, String networkId)
            {
                BidappThreadUtil.Post(state => _sdkDelegate.event_OnRewardedDidLoadAd(identifier, networkId));
            }
            public override void OnRewardedDidFailToLoadAd(String identifier, String networkId, String errorDescription)
            {
                BidappThreadUtil.Post(state => _sdkDelegate.event_OnRewardedDidFailToLoadAd(identifier, networkId, errorDescription));
            }
            public override void OnRewardedDidDisplayAd(String identifier, String networkId)
            {
                BidappThreadUtil.Post(state => _sdkDelegate.event_OnRewardedDidDisplayAd(identifier, networkId));
            }
            public override void OnRewardedDidClickAd(String identifier, String networkId)
            {
                BidappThreadUtil.Post(state => _sdkDelegate.event_OnRewardedDidClickAd(identifier, networkId));
            }
            public override void OnRewardedDidHideAd(String identifier, String networkId)
            {
                BidappThreadUtil.Post(state => _sdkDelegate.event_OnRewardedDidHideAd(identifier, networkId));
            }
            public override void OnRewardedDidFailToDisplayAd(String identifier, String networkId, String errorDescription)
            {
                BidappThreadUtil.Post(state => _sdkDelegate.event_OnRewardedDidFailToDisplayAd(identifier, networkId, errorDescription));
            }
            public override void OnRewardedDidReceiveRevenue(string identifier, string networkId, string networkName, double revenue, string precision)
            {
                BidappThreadUtil.Post(state => _sdkDelegate.event_OnRewardedDidReceiveRevenue(identifier, networkId, networkName, revenue, precision));
            }
            public override void OnRewardedAllNetworksFailedToDisplayAd(String errorDescription)
            {
                BidappThreadUtil.Post(state => _sdkDelegate.event_OnRewardedAllNetworksFailedToDisplayAd(errorDescription));
            }
            public override void OnUserDidReceiveReward(String identifier)
            {
                BidappThreadUtil.Post(state => _sdkDelegate.event_OnUserDidReceiveReward(identifier));
            }

            

            public override void OnBannerDidDisplayAd(String identifier, String networkId)
            {
                BidappThreadUtil.Post(state => _sdkDelegate.event_OnBannerDidDisplayAd(identifier, networkId));
            }
              public override void OnBannerFailedToDisplayAd(String identifier, String networkId, String errorDescription)
            {
                BidappThreadUtil.Post(state => _sdkDelegate.event_OnBannerFailedToDisplayAd(identifier, networkId, errorDescription));
            }            
            public override void OnBannerClicked(String identifier, String networkId)
            {
                BidappThreadUtil.Post(state => _sdkDelegate.event_OnBannerClicked(identifier, networkId));        
            }
            public override void OnBannerDidReceiveRevenue(string identifier, string networkId, string networkName, double revenue, string precision)
            {
                BidappThreadUtil.Post(state => _sdkDelegate.event_OnBannerDidReceiveRevenue(identifier, networkId, networkName, revenue, precision));
            }
            public override void OnBannerAllNetworksFailedToDisplayAd(String identifier)
            {
                BidappThreadUtil.Post(state => _sdkDelegate.event_OnBannerAllNetworksFailedToDisplayAd(identifier));      
            }

        }

   };
}
