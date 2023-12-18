#import <UIKit/UIKit.h>
#include "BidappSDKPluginDefs.h"
#include "BidappSDKPlugin.h"

#include <bidapp/BidappAds.h>
#include <Bidapp/BIDInterstitial.h>
#include <Bidapp/BIDRewarded.h>
#include <Bidapp/BIDBannerView.h>
#include <Bidapp/BIDConfiguration.h>
#include <Bidapp/BIDConsent.h>
#include <Bidapp/BIDAdFormat.h>
#include <Bidapp/BIDAdInfo.h>

#if __has_include(<AppTrackingTransparency/AppTrackingTransparency.h>)
#import <AppTrackingTransparency/AppTrackingTransparency.h>
#endif

#define BIDAPP_onInterstitialDidLoadAd ("onInterstitialDidLoadAd")
#define BIDAPP_onInterstitialDidFailToLoadAd ("onInterstitialDidFailToLoadAd")

#define BIDAPP_onInterstitialDidDisplayAd ("onInterstitialDidDisplayAd")
#define BIDAPP_onInterstitialDidClickAd ("onInterstitialDidClickAd")
#define BIDAPP_onInterstitialDidHideAd ("onInterstitialDidHideAd")
#define BIDAPP_onInterstitialDidFailToDisplayAd ("onInterstitialDidFailToDisplayAd")
#define BIDAPP_onInterstitialAllNetworksFailedToDisplayAd ("onInterstitialAllNetworksFailedToDisplayAd")

#define BIDAPP_onRewardedDidLoadAd ("onRewardedDidLoadAd")
#define BIDAPP_onRewardedDidFailToLoadAd ("onRewardedDidFailToLoadAd")

#define BIDAPP_onRewardedDidDisplayAd ("onRewardedDidDisplayAd")
#define BIDAPP_onRewardedDidClickAd ("onRewardedDidClickAd")
#define BIDAPP_onRewardedDidHideAd ("onRewardedDidHideAd")
#define BIDAPP_onRewardedDidFailToDisplayAd ("onRewardedDidFailToDisplayAd")
#define BIDAPP_onRewardedAllNetworksFailedToDisplayAd ("onRewardedAllNetworksFailedToDisplayAd")
#define BIDAPP_onUserDidReceiveReward ("onUserDidReceiveReward")

#define BIDAPP_onBannerDidDisplayAd ("onBannerDidDisplayAd")
#define BIDAPP_onBannerFailedToDisplayAd ("onBannerFailedToDisplayAd")
#define BIDAPP_onBannerClicked ("onBannerClicked")
#define BIDAPP_onBannerAllNetworksFailedToDisplayAd ("onBannerAllNetworksFailedToDisplayAd")

void UnityPause(int pause);

static NSString* ToNSString(const char* pStr)
{
	if (pStr)
	{
		return [NSString stringWithUTF8String:pStr];
	}
	return nil;
}

static const char* FromNSString(NSString *nsString)
{
	const char *chString = [nsString UTF8String];
	if (chString == NULL)
		return NULL;
	char *resultString = (char*)malloc(strlen(chString) + 1);
	strcpy(resultString, chString);
	return resultString;
}

@interface BidappSDKPluginName : NSString

+(id)name;

@end

@implementation BidappSDKPluginName

char* unityBidappSDK_targetName = NULL;

+(id)name
{
	return [NSString stringWithFormat:@"&plugin=%@", BIDAPPSDK_PLUGIN_NAME];
}

static NSMutableDictionary<NSString*,BIDBannerView*>* banners = nil;

NSString* identifierForBanner(BIDBannerView *adView)
{
	for (NSString* s in banners)
	{
		if (banners[s] == adView)
		{
			return s;
		}
	}
	
	return @"";
}

+ (void)adView:(BIDBannerView *)adView didDisplayAd:(BIDAdInfo *)adInfo
{
	const char* bannerId = identifierForBanner(adView).UTF8String;
	const char* networkId = @(adInfo.networkId).stringValue.UTF8String;
	
	BIDAPP_PLUGIN_CALLBACK_ARG_ARG(onBannerDidDisplayAd, bannerId, networkId);
}

+ (void)adView:(BIDBannerView *)adView didFailToDisplayAd:(BIDAdInfo *)adInfo error:(NSError *)error
{
	const char* bannerId = identifierForBanner(adView).UTF8String;
	const char* networkId = @(adInfo.networkId).stringValue.UTF8String;
	NSString* errorDescription_ = error.localizedDescription;
	const char* errorDescription = errorDescription_.UTF8String;
	
	BIDAPP_PLUGIN_CALLBACK_ERROR_ARG_ARG_ARG(onBannerFailedToDisplayAd, bannerId, networkId, errorDescription);
}

+ (void)adView:(BIDBannerView *)adView didClicked:(BIDAdInfo *)adInfo
{
	const char* bannerId = identifierForBanner(adView).UTF8String;
	const char* networkId = @(adInfo.networkId).stringValue.UTF8String;
	
	BIDAPP_PLUGIN_CALLBACK_ARG_ARG(onBannerClicked, bannerId, networkId);
}

+ (void)allNetworksFailedToDisplayAdInAdView:(BIDBannerView *)adView
{
	const char* bannerId = identifierForBanner(adView).UTF8String;
	
	BIDAPP_PLUGIN_CALLBACK_ARG(onBannerAllNetworksFailedToDisplayAd,bannerId);
}

@end

@interface BIDInterstitialWrapper : NSObject<BIDInterstitialDelegate,BIDFullscreenLoadDelegate>
{
	BIDInterstitial* interstitial;
	NSString* idt;
}

@end

@implementation BIDInterstitialWrapper

-(id)initWithIdentifier:(NSString*)idt_
{
	if (self = [super init])
	{
		idt = idt_;
		interstitial = [BIDInterstitial new];
		interstitial.loadDelegate = self;
	}
	
	return self;
}

- (void)didLoadAd:(BIDAdInfo*)adInfo
{
	const char* idt_ = idt.UTF8String;
	const char* networkId = @(adInfo.networkId).stringValue.UTF8String;
	
	BIDAPP_PLUGIN_CALLBACK_ARG_ARG(onInterstitialDidLoadAd, idt_, networkId);
}

- (void)didFailToLoadAd:(BIDAdInfo*)adInfo error:(NSError *)error
{
	const char* idt_ = idt.UTF8String;
	const char* networkId = @(adInfo.networkId).stringValue.UTF8String;
	NSString* errorDescription_ = error.localizedDescription;
	const char* errorDescription = errorDescription_.UTF8String;
	
	BIDAPP_PLUGIN_CALLBACK_ERROR_ARG_ARG_ARG(onInterstitialDidFailToLoadAd, idt_, networkId, errorDescription);
}

-(void)show
{
	[interstitial showWithDelegate:self];
}

- (nonnull UIViewController*)viewControllerForDisplayAd
{
#ifdef UNITY_IOS
	return UnityGetGLViewController();
#else
	return [[UIViewController alloc]init];//Stub
#endif
}

- (void)didDisplayAd:(BIDAdInfo*)adInfo
{
	const char* idt_ = idt.UTF8String;
	const char* networkId = @(adInfo.networkId).stringValue.UTF8String;
	
	BIDAPP_PLUGIN_CALLBACK_ARG_ARG(onInterstitialDidDisplayAd, idt_, networkId);
}

- (void)didClickAd:(BIDAdInfo*)adInfo
{
	const char* idt_ = idt.UTF8String;
	const char* networkId = @(adInfo.networkId).stringValue.UTF8String;
	
	BIDAPP_PLUGIN_CALLBACK_ARG_ARG(onInterstitialDidClickAd, idt_, networkId);
}

- (void)didHideAd:(BIDAdInfo*)adInfo
{
	Bidapp_pause_platform(false);
	
	const char* idt_ = idt.UTF8String;
	const char* networkId = @(adInfo.networkId).stringValue.UTF8String;
	
	BIDAPP_PLUGIN_CALLBACK_ARG_ARG(onInterstitialDidHideAd, idt_, networkId);
}

- (void)didFailToDisplayAd:(BIDAdInfo*)adInfo error:(NSError *)error
{
	const char* idt_ = idt.UTF8String;
	const char* networkId = @(adInfo.networkId).stringValue.UTF8String;
	NSString* errorDescription_ = error.localizedDescription;
	const char* errorDescription = errorDescription_.UTF8String;
	
	BIDAPP_PLUGIN_CALLBACK_ERROR_ARG_ARG_ARG(onRewardedDidFailToDisplayAd, idt_, networkId, errorDescription);
}

-(void)allNetworksDidFailToDisplayAd
{
	const char* idt_ = idt.UTF8String;
	
	BIDAPP_PLUGIN_CALLBACK_ARG(onInterstitialAllNetworksFailedToDisplayAd, idt_);
}

@end

@interface BIDRewardedWrapper : NSObject<BIDRewardedDelegate,BIDFullscreenLoadDelegate>
{
	BIDRewarded* rewarded;
	NSString* idt;
}

@end

@implementation BIDRewardedWrapper

-(id)initWithIdentifier:(NSString*)idt_
{
	if (self = [super init])
	{
		idt = idt_;
		rewarded = [BIDRewarded new];
		rewarded.loadDelegate = self;
	}
	
	return self;
}

- (void)didLoadAd:(BIDAdInfo*)adInfo
{
	const char* idt_ = idt.UTF8String;
	const char* networkId = @(adInfo.networkId).stringValue.UTF8String;
	
	BIDAPP_PLUGIN_CALLBACK_ARG_ARG(onRewardedDidLoadAd, idt_, networkId);
}

- (void)didFailToLoadAd:(BIDAdInfo*)adInfo error:(NSError *)error
{
	const char* idt_ = idt.UTF8String;
	const char* networkId = @(adInfo.networkId).stringValue.UTF8String;
	NSString* errorDescription_ = error.localizedDescription;
	const char* errorDescription = errorDescription_.UTF8String;
	
	BIDAPP_PLUGIN_CALLBACK_ERROR_ARG_ARG_ARG(onRewardedDidFailToLoadAd, idt_, networkId, errorDescription);
}

-(void)show
{
	[rewarded showWithDelegate:self];
}

- (nonnull UIViewController*)viewControllerForDisplayAd
{
#ifdef UNITY_IOS
	return UnityGetGLViewController();
#else
	return [[UIViewController alloc]init];//Stub
#endif
}

- (void)didDisplayAd:(BIDAdInfo*)adInfo
{
	const char* idt_ = idt.UTF8String;
	const char* networkId = @(adInfo.networkId).stringValue.UTF8String;
	
	BIDAPP_PLUGIN_CALLBACK_ARG_ARG(onRewardedDidDisplayAd, idt_, networkId);
}

- (void)didClickAd:(BIDAdInfo*)adInfo
{
	const char* idt_ = idt.UTF8String;
	const char* networkId = @(adInfo.networkId).stringValue.UTF8String;
	
	BIDAPP_PLUGIN_CALLBACK_ARG_ARG(onRewardedDidClickAd, idt_, networkId);
}

- (void)didHideAd:(BIDAdInfo*)adInfo
{
	Bidapp_pause_platform(false);
	
	const char* idt_ = idt.UTF8String;
	const char* networkId = @(adInfo.networkId).stringValue.UTF8String;
	
	BIDAPP_PLUGIN_CALLBACK_ARG_ARG(onRewardedDidHideAd, idt_, networkId);
}

- (void)didFailToDisplayAd:(BIDAdInfo*)adInfo error:(NSError *)error
{
	const char* idt_ = idt.UTF8String;
	const char* networkId = @(adInfo.networkId).stringValue.UTF8String;
	NSString* errorDescription_ = error.localizedDescription;
	const char* errorDescription = errorDescription_.UTF8String;
	
	BIDAPP_PLUGIN_CALLBACK_ERROR_ARG_ARG_ARG(onRewardedDidFailToDisplayAd, idt_, networkId, errorDescription);
}

-(void)allNetworksDidFailToDisplayAd
{
	const char* idt_ = idt.UTF8String;
	
	BIDAPP_PLUGIN_CALLBACK_ARG(onRewardedAllNetworksFailedToDisplayAd, idt_);
}

#pragma mark - BIDRewardedDelegate

- (void)didRewardUser
{
	const char* idt_ = idt.UTF8String;

	BIDAPP_PLUGIN_CALLBACK_ARG(onUserDidReceiveReward,idt_);
}

@end

void Bidapp_setUnityCallbackTargetName_platform(const char* targetName);

void Bidapp_setUnityCallbackTargetName_platform(const char* targetName)
{
	if (NULL != targetName)
	{
		char* _old = unityBidappSDK_targetName;
		
		char* _unityBidappSDK_targetName = (char*)malloc(strlen(targetName) + 1);
		
		strcpy(_unityBidappSDK_targetName, targetName);
		
		unityBidappSDK_targetName = _unityBidappSDK_targetName;
		
		if (NULL != _old)
		{
			free(_old);
		}
	}
	
	NSLog(@"Setting unity callback for object with name: %s", unityBidappSDK_targetName);
}

static BIDConfiguration* config()
{
	static BIDConfiguration* config = nil;
	if (!config)
	{
		config = [BIDConfiguration new];
	}
		
	return config;
}

void Bidapp_start_platform_(NSString* pubid, NSString* formats)
{
	if ([formats rangeOfString:BIDAPP_INTERSTITIAL].location != NSNotFound)
	{
		[config() enableInterstitialAds];
	}
	
	if ([formats rangeOfString:BIDAPP_REWARDED].location != NSNotFound)
	{
		[config() enableRewardedAds];
	}
	
	if ([formats rangeOfString:BIDAPP_BANNER].location != NSNotFound)
	{
		[config() enableBannerAds];
	}

	Bidapp_requestTrackingAuthorization_platform();
	
	//if (@available(iOS 14, *)) {
	//    dispatch_after(dispatch_time(DISPATCH_TIME_NOW, 1 * NSEC_PER_SEC), dispatch_get_main_queue(), ^{
	//        [ATTrackingManager requestTrackingAuthorizationWithCompletionHandler:^(ATTrackingManagerAuthorizationStatus s){}];
			
	//        [BidappAds startWithPubid:ToNSString(pubid) config:config()];
	//    });
	//}
	//else {
		[BidappAds startWithPubid:pubid config:config()];
	//}
}


void Bidapp_start_platform(const char* pubid, const char* formats)
{
	NSString* pubid_ = ToNSString(pubid);
	NSString* formats_ = ToNSString(formats);
	
	if (![NSThread isMainThread])
	{
		dispatch_async(dispatch_get_main_queue(), ^{
			
			Bidapp_start_platform_(pubid_,formats_);
		});
		
		return;
	}
	
	Bidapp_start_platform_(pubid_,formats_);
}

void Bidapp_setLogging_platform(bool logging)
{
	if (![NSThread isMainThread])
	{
		dispatch_async(dispatch_get_main_queue(), ^{
			
			Bidapp_setLogging_platform(logging);
		});
		
		return;
	}
	
	if (logging)
	{
		[config() enableLogging];
	}
}

void Bidapp_setTestMode_platform(bool testMode)
{
	if (![NSThread isMainThread])
	{
		dispatch_async(dispatch_get_main_queue(), ^{
			
			Bidapp_setTestMode_platform(testMode);
		});
		
		return;
	}
	
	if (testMode)
	{
		[config() enableTestMode];
	}
}

static int idt = 1;
static int createIdentifier(void)
{
	@synchronized ([BidappSDKPluginName class])
	{
		return ++idt;
	}
}

static NSMutableDictionary* interstitials = nil;
void Bidapp_createInterstitial_platform(NSString* identifier)
{
	if (!interstitials)
	{
		interstitials = [NSMutableDictionary new];
	}
	
	[interstitials setObject:[[BIDInterstitialWrapper alloc]initWithIdentifier:identifier] forKey:identifier];
}

const char* Bidapp_createInterstitial_platform(void)
{
	int idt = createIdentifier();
	NSString* identifier = @(idt).stringValue;
	
	dispatch_async(dispatch_get_main_queue(), ^{
		
		Bidapp_createInterstitial_platform(identifier);
	});
	
	return FromNSString(identifier);
}

void Bidapp_destroyInterstitial_platform(const char* idt)
{
	NSString* identifier = ToNSString(idt);
	if (!identifier)
	{
		return;
	}
	
	dispatch_async(dispatch_get_main_queue(), ^{
		
		[interstitials removeObjectForKey:identifier];
	});
}

void Bidapp_showInterstitial_platform(const char* idt)
{
	NSString* identifier = ToNSString(idt);
	if (!identifier)
	{
		return;
	}
	
	dispatch_async(dispatch_get_main_queue(), ^{

		BIDInterstitialWrapper* i = interstitials[identifier];
		[i show];
	});
}

static NSMutableDictionary* rewardeds = nil;
void Bidapp_createRewarded_platform(NSString* identifier)
{
	if (!rewardeds)
	{
		rewardeds = [NSMutableDictionary new];
	}
	
	[rewardeds setObject:[[BIDRewardedWrapper alloc]initWithIdentifier:identifier] forKey:identifier];
}

const char* Bidapp_createRewarded_platform(void)
{
	int idt = createIdentifier();
	NSString* identifier = @(idt).stringValue;
	
	dispatch_async(dispatch_get_main_queue(), ^{
		
		Bidapp_createRewarded_platform(identifier);
	});
	
	return FromNSString(identifier);
}

void Bidapp_destroyRewarded_platform(const char* idt)
{
	NSString* identifier = ToNSString(idt);
	if (!identifier)
	{
		return;
	}
	
	dispatch_async(dispatch_get_main_queue(), ^{
		
		[rewardeds removeObjectForKey:identifier];
	});
}

void Bidapp_showRewarded_platform(const char* idt)
{
	NSString* identifier = ToNSString(idt);
	if (!identifier)
	{
		return;
	}
	
	dispatch_async(dispatch_get_main_queue(), ^{

		BIDRewardedWrapper* i = rewardeds[identifier];
		[i show];
	});
}

void Bidapp_showBanner_platform_(NSString* idt, NSString* bannerSize, float x, float y, float width, float height)
{
	BIDBannerView *banner_view = nil;
	if ([bannerSize isEqualToString:@"300x250"]) {
		banner_view = [BIDBannerView bannerWithFormat:[BIDAdFormat banner_300x250] delegate:(id)[BidappSDKPluginName class]];
	}
	else if ([bannerSize isEqualToString:@"320x50"]){
		banner_view = [BIDBannerView bannerWithFormat:[BIDAdFormat banner_320x50] delegate:(id)[BidappSDKPluginName class]];
	}
	else
	{
		return;
	}
	
	[banner_view stopAutorefresh];
	
	banner_view.frame = CGRectMake(x, y, width, height);
	
	if (!banners)
	{
		banners = [NSMutableDictionary new];
	}

	banners[idt] = banner_view;
	
	[BIDAPP_PLUGIN_VIEW_SOURCE addSubview:banner_view];
}

const char* Bidapp_showBanner_platform(const char* bannerSize, float x, float y, float width, float height)
{
	NSString* bannerSize_ = ToNSString(bannerSize);
	
	int idt = createIdentifier();
	NSString* identifier = @(idt).stringValue;

	dispatch_async(dispatch_get_main_queue(), ^{
		
		Bidapp_showBanner_platform_(identifier,bannerSize_,x,y,width,height);
	});
	
	return FromNSString(identifier);
}

NSArray<NSLayoutConstraint *>* constraintsForBanner(UIView* banner, UIView* superView, UIEdgeInsets _insets, NSString* _position, CGSize _size)
{
	NSMutableArray *constraints = [NSMutableArray new];
	NSArray* c = [_position componentsSeparatedByString:@";"];
	int xPosition = [c.firstObject intValue];
	int yPosition = [c.lastObject intValue];
	
	[constraints addObject:[NSLayoutConstraint constraintWithItem:banner attribute:NSLayoutAttributeWidth relatedBy:NSLayoutRelationEqual toItem:nil attribute:NSLayoutAttributeNotAnAttribute multiplier:1.0 constant:_size.width]];
	[constraints addObject:[NSLayoutConstraint constraintWithItem:banner attribute:NSLayoutAttributeHeight relatedBy:NSLayoutRelationEqual toItem:nil attribute:NSLayoutAttributeNotAnAttribute multiplier:1.0 constant:_size.height]];
	
	// position horizontally
	switch (xPosition)
	{
		case 1://Center
			[constraints addObject:[NSLayoutConstraint constraintWithItem:banner attribute:NSLayoutAttributeCenterX relatedBy:NSLayoutRelationEqual toItem:superView attribute:NSLayoutAttributeCenterX multiplier:1.0 constant:0]];
			break;
		case 0://Left
			[constraints addObject:[NSLayoutConstraint constraintWithItem:banner attribute:NSLayoutAttributeLeft relatedBy:NSLayoutRelationEqual toItem:superView attribute:NSLayoutAttributeLeft multiplier:1.0 constant:_insets.left]];
			break;
		case 2://Right
			[constraints addObject:[NSLayoutConstraint constraintWithItem:banner attribute:NSLayoutAttributeRight relatedBy:NSLayoutRelationEqual toItem:superView attribute:NSLayoutAttributeRight multiplier:1.0 constant:-_insets.right]];
			break;
			
		default:
			break;
	}
	
	// position vertically
	switch (yPosition)
	{
		case 1://Center
			[constraints addObject:[NSLayoutConstraint constraintWithItem:banner attribute:NSLayoutAttributeCenterY relatedBy:NSLayoutRelationEqual toItem:superView attribute:NSLayoutAttributeCenterY multiplier:1.0 constant:0]];
			break;
		case 2://Bottom
			[constraints addObject:[banner.bottomAnchor constraintEqualToAnchor:superView.safeAreaLayoutGuide.bottomAnchor constant:-_insets.bottom]];
			break;
		case 0://Top
			[constraints addObject:[banner.topAnchor constraintEqualToAnchor:superView.safeAreaLayoutGuide.topAnchor  constant:_insets.top]];
			break;
			
		default:
			break;
	}
	
	return constraints;
}

void Bidapp_showBannerAtPosition_platform_(NSString* idt, NSString* position, NSString* bannerSize, float marginTop, float marginLeft, float marginBottom, float marginRight)
{
	BIDBannerView *banner_view = nil;
	if ([bannerSize isEqualToString:@"300x250"]) {
		banner_view = [BIDBannerView bannerWithFormat:[BIDAdFormat banner_300x250] delegate:(id)[BidappSDKPluginName class]];
	}
	else if ([bannerSize isEqualToString:@"320x50"]){
		banner_view = [BIDBannerView bannerWithFormat:[BIDAdFormat banner_320x50] delegate:(id)[BidappSDKPluginName class]];
	}
	else
	{
		return;
	}
	
	[banner_view stopAutorefresh];
	
	if (!banners)
	{
		banners = [NSMutableDictionary new];
	}

	banners[idt] = banner_view;
	
	[BIDAPP_PLUGIN_VIEW_SOURCE addSubview:banner_view];
	
	banner_view.translatesAutoresizingMaskIntoConstraints = NO;
	NSArray* constraints = constraintsForBanner(banner_view, BIDAPP_PLUGIN_VIEW_SOURCE, UIEdgeInsetsMake(marginTop, marginLeft, marginBottom, marginRight), position, banner_view.bounds.size);
	
	[banner_view.superview addConstraints:constraints];

	for (id item in constraints) {
		NSLayoutConstraint *constraint = (NSLayoutConstraint *)item;
		[constraint setActive:YES];
	}
}

const char* Bidapp_showBannerAtPosition_platform(const char* position, const char* bannerSize, float marginTop, float marginLeft, float marginBottom, float marginRight)
{
	NSString* position_ = ToNSString(position);
	NSString* bannerSize_ = ToNSString(bannerSize);
	
	int idt = createIdentifier();
	NSString* identifier = @(idt).stringValue;
	
	dispatch_async(dispatch_get_main_queue(), ^{
		
		Bidapp_showBannerAtPosition_platform_(identifier,position_,bannerSize_,marginTop,marginLeft,marginBottom,marginRight);
	});
	
	return FromNSString(identifier);
}

void Bidapp_stopBannerAutorefresh_platform(const char* bannerId)
{
	NSString* identifier = ToNSString(bannerId);
	if (!identifier)
	{
		return;
	}
	
	dispatch_async(dispatch_get_main_queue(), ^{
		[banners[identifier] stopAutorefresh];
	});
}

void Bidapp_setBannerRefreshInterval_platform(const char* bannerId, double refreshInterval)
{
	NSString* identifier = ToNSString(bannerId);
	if (!identifier)
	{
		return;
	}
	
	dispatch_async(dispatch_get_main_queue(), ^{
		[banners[identifier] startAutorefresh:refreshInterval];
	});
}

void Bidapp_refreshBanner_platform(const char* bannerId)
{
	NSString* identifier = ToNSString(bannerId);
	if (!identifier)
	{
		return;
	}
	
	dispatch_async(dispatch_get_main_queue(), ^{
		[banners[identifier] refreshAd];
	});
}

void Bidapp_removeBanner_platform(const char* bannerId)
{
	NSString* identifier = ToNSString(bannerId);
	if (!identifier)
	{
		return;
	}
	
	dispatch_async(dispatch_get_main_queue(), ^{
		[banners[identifier] stopAutorefresh];
		[banners[identifier] removeFromSuperview];
		[banners removeObjectForKey:identifier];
	});
}

void Bidapp_setGDPRConsent_platform(bool consent)
{
	dispatch_async(dispatch_get_main_queue(), ^{
		
		BIDConsent.GDPR = @(consent);
	});
}

void Bidapp_setCCPAConsent_platform(bool consent)
{
	dispatch_async(dispatch_get_main_queue(), ^{
		
		BIDConsent.CCPA = @(consent);
	});
}

void Bidapp_setSubjectToCOPPA_platform(bool subjectToCOPPA)
{
	dispatch_async(dispatch_get_main_queue(), ^{
		
		BIDConsent.COPPA = @(!subjectToCOPPA);
	});
}

void Bidapp_requestTrackingAuthorization_platform()
{
	if (@available(iOS 14, *)) {
		Class attClass = NSClassFromString(@"ATTrackingManager");
		SEL requestATTSEL = NSSelectorFromString(@"requestTrackingAuthorizationWithCompletionHandler:");
		if ([attClass respondsToSelector:requestATTSEL]) {
			  void (^statusBlock)(int) = ^(int status) {};
			  [attClass performSelector:requestATTSEL withObject:statusBlock];
		}
	}
}

void Bidapp_pause_platform(bool pauseStatus)
{
#ifdef UNITY_IOS
	UnityPause(pauseStatus ? 1 : 0);
#endif
}

void Bidapp_setParameterValue_platform(const char* parameterName, const char* parameterValue, const char* instanceIdentifier)
{
}

const char* Bidapp_getParameterValue_platform(const char* parameterName, const char* instanceIdentifier)
{
    return FromNSString(@"");
}
