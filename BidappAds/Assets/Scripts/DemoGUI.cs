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
        var sdkDelegate = BidappSDKDelegate.CreateInstance(this);

        sdkDelegate.OnInterstitialDidLoadAd += (interstitialIdentifier, providerId) => Debug.Log(String.Format("BIDUnity OnInterstitialDidLoadAd: interstitialId {0}, providerId: {1}", interstitialIdentifier, providerId));
        sdkDelegate.OnInterstitialDidFailToLoadAd += (interstitialIdentifier, providerId, errorDescription) => Debug.Log(String.Format("BIDUnity OnInterstitialDidFailToLoadAd: interstitialId {0}, providerId: {1}, errorDescription: {2}", interstitialIdentifier, providerId, errorDescription));
        sdkDelegate.OnInterstitialDidDisplayAd += (interstitialIdentifier, providerId) => Debug.Log(String.Format("BIDUnity OnInterstitialDidDisplayAd: interstitialId {0}, providerId: {1}", interstitialIdentifier, providerId));
        sdkDelegate.OnInterstitialDidClickAd += (interstitialIdentifier, providerId) => Debug.Log(String.Format("BIDUnity OnInterstitialDidClickAd: interstitialId {0}, providerId: {1}", interstitialIdentifier, providerId));
        sdkDelegate.OnInterstitialDidHideAd += (interstitialIdentifier, providerId) => Debug.Log(String.Format("BIDUnity OnInterstitialDidHideAd: interstitialId {0}, providerId: {1}", interstitialIdentifier, providerId));
        sdkDelegate.OnInterstitialDidFailToDisplayAd += (interstitialIdentifier, providerId, errorDescription) => Debug.Log(String.Format("BIDUnity OnInterstitialDidFailToDisplayAd: interstitialId {0}, providerId: {1}, errorDescription: {2}", interstitialIdentifier, providerId, errorDescription));
        sdkDelegate.OnInterstitialAllNetworksFailedToDisplayAd += (interstitialIdentifier) => Debug.Log(String.Format("BIDUnity OnInterstitialAllNetworksFailedToDisplayAd: interstitialId {0}, providerId: {1}", interstitialIdentifier));

        sdkDelegate.OnRewardedDidLoadAd += (rewardedIdentifier, providerId) => Debug.Log(String.Format("BIDUnity OnRewardedDidLoadAd: rewardedId {0}, providerId: {1}", rewardedIdentifier, providerId));
        sdkDelegate.OnRewardedDidFailToLoadAd += (rewardedIdentifier, providerId, errorDescription) => Debug.Log(String.Format("BIDUnity OnRewardedDidFailToLoadAd: interstitialId {0}, providerId: {1}, errorDescription: {2}", rewardedIdentifier, providerId, errorDescription));
        sdkDelegate.OnRewardedDidDisplayAd += (rewardedIdentifier, providerId) => Debug.Log(String.Format("BIDUnity OnRewardedDidDisplayAd: rewardedId {0}, providerId: {1}", rewardedIdentifier, providerId));
        sdkDelegate.OnRewardedDidClickAd += (rewardedIdentifier, providerId) => Debug.Log(String.Format("BIDUnity OnRewardedDidClickAd: rewardedId {0}, providerId: {1}", rewardedIdentifier, providerId));
        sdkDelegate.OnRewardedDidHideAd += (rewardedIdentifier, providerId) => Debug.Log(String.Format("BIDUnity OnRewardedDidHideAd: rewardedId {0}, providerId: {1}", rewardedIdentifier, providerId));
        sdkDelegate.OnRewardedDidFailToDisplayAd += (rewardedIdentifier, providerId, errorDescription) => Debug.Log(String.Format("BIDUnity OnRewardedDidDisplayAd: interstitialId {0}, providerId: {1}, errorDescription: {2}", rewardedIdentifier, providerId, errorDescription));
        sdkDelegate.OnRewardedAllNetworksFailedToDisplayAd += (rewardedIdentifier) => Debug.Log(String.Format("BIDUnity OnRewardedAllNetworksFailedToDisplayAd: rewardedId {0}", rewardedIdentifier));
        sdkDelegate.OnUserDidReceiveReward += (rewardedIdentifier) => Debug.Log(String.Format("BIDUnity OnUserDidReceiveReward: rewardedId {0}", rewardedIdentifier));

        sdkDelegate.OnBannerDidDisplayAd += (bannerIdentifier, providerId) => Debug.Log(String.Format("BIDUnity OnBannerDidDisplayAd: bannerId {0}, providerId: {1}", bannerIdentifier, providerId));
        sdkDelegate.OnBannerFailedToDisplayAd += (bannerIdentifier, providerId, errorDescription) => Debug.Log(String.Format("BIDUnity OnBannerDidDisplayAd: bannerId {0}, providerId: {1}, errorDescription: {2}", bannerIdentifier, providerId, errorDescription));
        sdkDelegate.OnBannerClicked += (bannerIdentifier, providerId) => Debug.Log(String.Format("BIDUnity OnBannerClicked: bannerId {0}, providerId: {1}", bannerIdentifier, providerId));
        sdkDelegate.OnBannerAllNetworksFailedToDisplayAd += (bannerIdentifier) => Debug.Log(String.Format("BIDUnity OnBannerAllNetworksFailedToDisplayAd: bannerId {0}", bannerIdentifier));

        BidappBinding.Instance.SetCallbacks(sdkDelegate);
        
        BidappBinding.Instance.SetTestMode(true);        
		BidappBinding.Instance.SetLogging(true);

        string adContentType = BidappContentType.Interstitial + BidappContentType.Banner + BidappContentType.Rewarded;

        string pubid = "";

#if UNITY_ANDROID
		pubid = "15ddd248-7acc-46ce-a6fd-e6f6543d22cd";
#endif
#if UNITY_IOS || UNITY_IPHONE
		pubid = "15ddd248-7acc-46ce-a6fd-e6f6543d22cd";
#endif
       // BidappBinding.Instance.SetTestMode(true);

        BidappBinding.Instance.RequestTrackingAuthorization();
        
        BidappBinding.Instance.Start(pubid, adContentType);

		interstitialIdentifier1 = BidappBinding.Instance.CreateInterstitial();
        interstitialIdentifier2 = BidappBinding.Instance.CreateInterstitial();
        rewardedIdentifier1 = BidappBinding.Instance.CreateRewarded();
        rewardedIdentifier2 = BidappBinding.Instance.CreateRewarded();

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
			BidappBinding.Instance.ShowInterstitial(interstitialIdentifier1);
		}

		if (GUILayout.Button("Show Interstitial 2", buttonHeight))
		{
            BidappBinding.Instance.ShowInterstitial(interstitialIdentifier2);
        }

		if (GUILayout.Button("Show Rewarded 1", buttonHeight))
		{
            BidappBinding.Instance.ShowRewarded(rewardedIdentifier1);
        }

		if (GUILayout.Button("Show Rewarded 2", buttonHeight))
		{
            BidappBinding.Instance.ShowRewarded(rewardedIdentifier2);
        }

		if (GUILayout.Button("Show banner", buttonHeight))
		{
			BidappBinding.Instance.RemoveBanner(bannerIdentifier);
			bannerIdentifier = BidappBinding.Instance.ShowBanner(BidappBannerSize.Size_320x50, 0f, 100f, 320f, 50f);
		}

		if (GUILayout.Button("Show Banner At Position", buttonHeight))
		{
            BidappBinding.Instance.RemoveBanner(bannerIdentifier);
            bannerIdentifier = BidappBinding.Instance.ShowBannerAtPosition(BidappBannerPosition.BottomCenter, BidappBannerSize.Size_320x50);
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
