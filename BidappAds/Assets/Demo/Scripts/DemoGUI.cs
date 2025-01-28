using UnityEngine;
using System;
using Bidapp;
using Bidapp.AndroidWrapper;

public class DemoGUI : MonoBehaviour
{
	string interstitialIdentifier1;
    string interstitialIdentifier2;
    string rewardedIdentifier1;
    string rewardedIdentifier2;
    string bannerIdentifier;
 
    // Use this for initialization
    void Start()
    {
#if UNITY_ANDROID
        Debug.Log("BidappAndroidVersion: " + BidappAndroidWrapper.Version);
#endif
         BidappSDKDelegate.CreateInstance(this);
    
         BidappBinding.Instance.SetCallbacks(BidappSDKDelegate.Instance);
        
        BidappBinding.Instance.SetTestMode(true);        
		BidappBinding.Instance.SetLogging(true);

        string adContentType = BidappFormat.Interstitial + BidappFormat.Banner + BidappFormat.Rewarded;

        string pubid = "";

#if UNITY_ANDROID
		pubid = "15ddd248-7acc-46ce-a6fd-e6f6543d22cd";
#endif
#if UNITY_IOS || UNITY_IPHONE
		pubid = "15ddd248-7acc-46ce-a6fd-e6f6543d22cd";
#endif

        BidappBinding.Instance.RequestTrackingAuthorization();
        
        BidappBinding.Instance.Start(pubid, adContentType);

		interstitialIdentifier1 = BidappBinding.Instance.CreateInterstitial();
        BidappSDKDelegate.Instance.SetInterstitialDelegate(new BidappInterstitialDelegate(), interstitialIdentifier1);
        interstitialIdentifier2 = BidappBinding.Instance.CreateInterstitial();
        BidappSDKDelegate.Instance.SetInterstitialDelegate(new BidappInterstitialDelegate2(), interstitialIdentifier2);
        rewardedIdentifier1 = BidappBinding.Instance.CreateRewarded();
        BidappSDKDelegate.Instance.SetRewardedDelegate(new BidappRewardedDelegate(), rewardedIdentifier1);
        rewardedIdentifier2 = BidappBinding.Instance.CreateRewarded();
        BidappSDKDelegate.Instance.SetRewardedDelegate(new BidappRewardedDelegate2(), rewardedIdentifier2);

        Debug.Log("Started with pubid = " + pubid);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnGUI()
    {
        DrawMenu();
    }

    public void DrawMenu()
    {
		GUI.skin.button.fontSize = 30;

		Rect rect = new Rect (Screen.width / 2 - 250, 200, 500, Screen.height - 80);

		GUILayout.BeginArea(rect);

		var buttonHeight = GUILayout.Height(88);

		if (GUILayout.Button("Show Interstitial 1", buttonHeight))
		{
		    if (BidappBinding.Instance.IsInterstitialAdReady(interstitialIdentifier1))
		    {
			    BidappBinding.Instance.ShowInterstitial(interstitialIdentifier1);
			}
			else {
			    Debug.Log("Interstitial 1 with id" + interstitialIdentifier1 + " not ready");
			}
		}

		if (GUILayout.Button("Show Interstitial 2", buttonHeight))
		{
           	if (BidappBinding.Instance.IsInterstitialAdReady(interstitialIdentifier2))
           	{
           	    BidappBinding.Instance.ShowInterstitial(interstitialIdentifier2);
           	}
           	else {
           	    Debug.Log("Interstitial 2 with id" + interstitialIdentifier2 + " not ready");
           	}
        }

		if (GUILayout.Button("Show Rewarded 1", buttonHeight))
		{
           	if (BidappBinding.Instance.IsRewardedAdReady(rewardedIdentifier1))
           	{
                BidappBinding.Instance.ShowRewarded(rewardedIdentifier1);
           	}
            else {
                Debug.Log("Rewarded 1 with id" + rewardedIdentifier1 + " not ready");
            }
        }

		if (GUILayout.Button("Show Rewarded 2", buttonHeight))
		{
           	if (BidappBinding.Instance.IsRewardedAdReady(rewardedIdentifier2))
           	{
               BidappBinding.Instance.ShowRewarded(rewardedIdentifier2);
            }
            else {
               Debug.Log("Rewarded 2 with id" + rewardedIdentifier2 + " not ready");
            }
        }

		if (GUILayout.Button("Show banner", buttonHeight))
		{
            BidappSDKDelegate.Instance.SetBannerDelegate(null, bannerIdentifier);
            BidappBinding.Instance.RemoveBanner(bannerIdentifier);
			bannerIdentifier = BidappBinding.Instance.ShowBanner(BidappBannerSize.Size_320x50, 0f, 100f, 320f, 50f);
            BidappSDKDelegate.Instance.SetBannerDelegate(new BidappBannerDelegate(), bannerIdentifier);
        }

		if (GUILayout.Button("Show Banner At Position", buttonHeight))
		{
            BidappSDKDelegate.Instance.SetBannerDelegate(null, bannerIdentifier);
            BidappBinding.Instance.RemoveBanner(bannerIdentifier);
            bannerIdentifier = BidappBinding.Instance.ShowBannerAtPosition(BidappBannerPosition.BottomCenter, BidappBannerSize.Size_320x50);
            BidappSDKDelegate.Instance.SetBannerDelegate(new BidappBannerDelegate(), bannerIdentifier);
        }

		if (GUILayout.Button("Set banner refresh interval", buttonHeight))
		{
			System.Random random = new System.Random();
			var newRefreshInterval = random.Next(30,60);

			Debug.Log("New Banner RefreshInterval: " + newRefreshInterval);

			BidappBinding.Instance.SetBannerRefreshInterval(bannerIdentifier, newRefreshInterval);
		}

		if (GUILayout.Button("Refresh banner", buttonHeight))
		{
			BidappBinding.Instance.RefreshBanner(bannerIdentifier);
		}

		if (GUILayout.Button("Remove banner", buttonHeight))
		{
            BidappSDKDelegate.Instance.SetBannerDelegate(null, bannerIdentifier);
            BidappBinding.Instance.RemoveBanner(bannerIdentifier);
            bannerIdentifier = "";
        }

		GUILayout.EndArea();
    }

    void OnApplicationPause(bool pauseStatus)
    {
        Debug.Log("OnApplicationPause: " + pauseStatus);
        BidappBinding.Instance.OnPause(pauseStatus);
    }
}

public class BidappInterstitialDelegate : IBidappInterstitialDelegate
{
    public void OnInterstitialDidLoadAd(string identifier, string networkId)
    {
        Debug.Log($"BIDUnity Interstitial1 OnInterstitialDidLoadAd: interstitialId {identifier}, providerId: {networkId}");
    }

    public void OnInterstitialDidFailToLoadAd(string identifier, string networkId, string errorDescription)
    {
        Debug.Log($"BIDUnity Interstitial1 OnInterstitialDidFailToLoadAd: interstitialId {identifier}, providerId: {networkId}, errorDescription: {errorDescription}");
    }

    public void OnInterstitialDidDisplayAd(string identifier, string networkId)
    {
        Debug.Log($"BIDUnity Interstitial1 OnInterstitialDidDisplayAd: interstitialId {identifier}, providerId: {networkId}");
    }

    public void OnInterstitialDidClickAd(string identifier, string networkId)
    {
        Debug.Log($"BIDUnity Interstitial1 OnInterstitialDidClickAd: interstitialId {identifier}, providerId: {networkId}");
    }

    public void OnInterstitialDidHideAd(string identifier, string networkId)
    {
        Debug.Log($"BIDUnity Interstitial1 OnInterstitialDidHideAd: interstitialId {identifier}, providerId: {networkId}");
    }

    public void OnInterstitialDidFailToDisplayAd(string identifier, string networkId, string errorDescription)
    {
        Debug.Log($"BIDUnity Interstitial1 OnInterstitialDidFailToDisplayAd: interstitialId {identifier}, providerId: {networkId}, errorDescription: {errorDescription}");
    }

    public void OnInterstitialAllNetworksFailedToDisplayAd(string identifier)
    {
        Debug.Log($"BIDUnity Interstitial1 OnInterstitialAllNetworksFailedToDisplayAd: interstitialId {identifier}");
    }
}

public class BidappRewardedDelegate : IBidappRewardedDelegate
{
    public void OnRewardedDidLoadAd(string identifier, string networkId)
    {
        Debug.Log($"BIDUnity Rewarded1 OnRewardedDidLoadAd: rewardedId {identifier}, providerId: {networkId}");
    }

    public void OnRewardedDidFailToLoadAd(string identifier, string networkId, string errorDescription)
    {
        Debug.Log($"BIDUnity Rewarded1 OnRewardedDidFailToLoadAd: rewardedId {identifier}, providerId: {networkId}, errorDescription: {errorDescription}");
    }

    public void OnRewardedDidDisplayAd(string identifier, string networkId)
    {
        Debug.Log($"BIDUnity Rewarded1 OnRewardedDidDisplayAd: rewardedId {identifier}, providerId: {networkId}");
    }

    public void OnRewardedDidClickAd(string identifier, string networkId)
    {
        Debug.Log($"BIDUnity Rewarded1 OnRewardedDidClickAd: rewardedId {identifier}, providerId: {networkId}");
    }

    public void OnRewardedDidHideAd(string identifier, string networkId)
    {
        Debug.Log($"BIDUnity Rewarded1 OnRewardedDidHideAd: rewardedId {identifier}, providerId: {networkId}");
    }

    public void OnRewardedDidFailToDisplayAd(string identifier, string networkId, string errorDescription)
    {
        Debug.Log($"BIDUnity Rewarded1 OnRewardedDidFailToDisplayAd: rewardedId {identifier}, providerId: {networkId}, errorDescription: {errorDescription}");
    }

    public void OnRewardedAllNetworksFailedToDisplayAd(string identifier)
    {
        Debug.Log($"BIDUnity Rewarded1 OnRewardedAllNetworksFailedToDisplayAd: rewardedId {identifier}");
    }

    public void OnUserDidReceiveReward(string identifier)
    {
        Debug.Log($"BIDUnity Rewarded1 OnUserDidReceiveReward: rewardedId {identifier}");
    }
}


public class BidappInterstitialDelegate2 : IBidappInterstitialDelegate
{
    public void OnInterstitialDidLoadAd(string identifier, string networkId)
    {
        Debug.Log($"BIDUnity Interstitial2 OnInterstitialDidLoadAd: interstitialId {identifier}, providerId: {networkId}");
    }

    public void OnInterstitialDidFailToLoadAd(string identifier, string networkId, string errorDescription)
    {
        Debug.Log($"BIDUnity Interstitial2 OnInterstitialDidFailToLoadAd: interstitialId {identifier}, providerId: {networkId}, errorDescription: {errorDescription}");
    }

    public void OnInterstitialDidDisplayAd(string identifier, string networkId)
    {
        Debug.Log($"BIDUnity Interstitial2 OnInterstitialDidDisplayAd: interstitialId {identifier}, providerId: {networkId}");
    }

    public void OnInterstitialDidClickAd(string identifier, string networkId)
    {
        Debug.Log($"BIDUnity Interstitial2 OnInterstitialDidClickAd: interstitialId {identifier}, providerId: {networkId}");
    }

    public void OnInterstitialDidHideAd(string identifier, string networkId)
    {
        Debug.Log($"BIDUnity Interstitial2 OnInterstitialDidHideAd: interstitialId {identifier}, providerId: {networkId}");
    }

    public void OnInterstitialDidFailToDisplayAd(string identifier, string networkId, string errorDescription)
    {
        Debug.Log($"BIDUnity Interstitial2 OnInterstitialDidFailToDisplayAd: interstitialId {identifier}, providerId: {networkId}, errorDescription: {errorDescription}");
    }

    public void OnInterstitialAllNetworksFailedToDisplayAd(string identifier)
    {
        Debug.Log($"BIDUnity Interstitial2 OnInterstitialAllNetworksFailedToDisplayAd: interstitialId {identifier}");
    }
}

public class BidappRewardedDelegate2 : IBidappRewardedDelegate
{
    public void OnRewardedDidLoadAd(string identifier, string networkId)
    {
        Debug.Log($"BIDUnity Rewarded2 OnRewardedDidLoadAd: rewardedId {identifier}, providerId: {networkId}");
    }

    public void OnRewardedDidFailToLoadAd(string identifier, string networkId, string errorDescription)
    {
        Debug.Log($"BIDUnity Rewarded2 OnRewardedDidFailToLoadAd: rewardedId {identifier}, providerId: {networkId}, errorDescription: {errorDescription}");
    }

    public void OnRewardedDidDisplayAd(string identifier, string networkId)
    {
        Debug.Log($"BIDUnity Rewarded2 OnRewardedDidDisplayAd: rewardedId {identifier}, providerId: {networkId}");
    }

    public void OnRewardedDidClickAd(string identifier, string networkId)
    {
        Debug.Log($"BIDUnity Rewarded2 OnRewardedDidClickAd: rewardedId {identifier}, providerId: {networkId}");
    }

    public void OnRewardedDidHideAd(string identifier, string networkId)
    {
        Debug.Log($"BIDUnity Rewarded2 OnRewardedDidHideAd: rewardedId {identifier}, providerId: {networkId}");
    }

    public void OnRewardedDidFailToDisplayAd(string identifier, string networkId, string errorDescription)
    {
        Debug.Log($"BIDUnity Rewarded2 OnRewardedDidFailToDisplayAd: rewardedId {identifier}, providerId: {networkId}, errorDescription: {errorDescription}");
    }

    public void OnRewardedAllNetworksFailedToDisplayAd(string identifier)
    {
        Debug.Log($"BIDUnity Rewarded2 OnRewardedAllNetworksFailedToDisplayAd: rewardedId {identifier}");
    }

    public void OnUserDidReceiveReward(string identifier)
    {
        Debug.Log($"BIDUnity Rewarded2 OnUserDidReceiveReward: rewardedId {identifier}");
    }
}

public class BidappBannerDelegate : IBidappBannerDelegate
{
    public void OnBannerDidDisplayAd(string identifier, string networkId)
    {
        Debug.Log($"BIDUnity OnBannerDidDisplayAd: bannerId {identifier}, providerId: {networkId}");
    }

    public void OnBannerFailedToDisplayAd(string identifier, string networkId, string errorDescription)
    {
        Debug.Log($"BIDUnity OnBannerFailedToDisplayAd: bannerId {identifier}, providerId: {networkId}, errorDescription: {errorDescription}");
    }

    public void OnBannerClicked(string identifier, string networkId)
    {
        Debug.Log($"BIDUnity OnBannerClicked: bannerId {identifier}, providerId: {networkId}");
    }

    public void OnBannerAllNetworksFailedToDisplayAd(string identifier)
    {
        Debug.Log($"BIDUnity OnBannerAllNetworksFailedToDisplayAd: bannerId {identifier}");
    }
}
