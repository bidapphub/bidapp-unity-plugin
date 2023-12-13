using UnityEngine;
using System.Diagnostics;
using System;

namespace Bidapp.AndroidWrapper 
{
	public class BidappAndroidWrapper 
	{
		private const string UNITY_ANDROID = "UNITY_ANDROID";


        public static string Version
        {
            get
            {
                return GetResult<string>("getVersion");
            }
        }


        [Conditional(UNITY_ANDROID)]
	    public static void Bidapp_start_platform(string pubid, string adContentType)
	    {
	       CallWrapperMethodWithContext(
                wrapperContext => CallWrapperMethod("start", wrapperContext, pubid));
	    }


		[Conditional(UNITY_ANDROID)]
		public static void Bidapp_setLogging_platform(bool logging)
		{
			CallWrapperMethod ("setLogging", logging);
		}



        [Conditional(UNITY_ANDROID)]
		public static void Bidapp_setTestMode_platform(bool isEnabled)
		{
			CallWrapperMethod ("setTestMode", isEnabled);
		}
        

		public static string Bidapp_createInterstitial_platform(bool enableAutoload)
		{
            var id = "";    
		CallWrapperMethodWithContext(
                wrapperContext => id = GetResult<string>("createInterstitial", wrapperContext, enableAutoload));
            return id;  

		}

        [Conditional(UNITY_ANDROID)]
		public static void Bidapp_loadInterstitial_platform(string identifier)
		{
			
               CallWrapperMethod("loadInterstitial", identifier);
		}


        [Conditional(UNITY_ANDROID)]
		public static void Bidapp_destroyInterstitial_platform(string identifier)
		{			
               CallWrapperMethod("destroyInterstitial", identifier);
		}

        [Conditional(UNITY_ANDROID)]
		public static void Bidapp_showInterstitial_platform(string identifier)
		{
			CallWrapperMethodWithContext(
                wrapperContext => CallWrapperMethod("showInterstitial", wrapperContext, identifier));
		}


        //----------------------------------------------------------------

		public static string Bidapp_createRewarded_platform(bool enableAutoload)
		{
              var id = "";            
				CallWrapperMethodWithContext(
                wrapperContext => id = GetResult<string>("createRewarded", wrapperContext, enableAutoload));
                return id;
		}


		public static void Bidapp_loadRewarded_platform(string identifier)
		{
			
               CallWrapperMethod("loadRewarded", identifier);
		}



		public static void Bidapp_destroyRewarded_platform(string identifier)
		{			
               CallWrapperMethod("destroyRewarded", identifier);
		}


		public static void Bidapp_showRewarded_platform(string identifier)
		{
			CallWrapperMethodWithContext(
                wrapperContext => CallWrapperMethod("showRewarded", wrapperContext, identifier));
		}

        //----------------------------------------------------------------


        public static string Bidapp_showBanner_platform(float x, float y)
        {
             var id = "";            
             CallWrapperMethodWithContext(
                wrapperContext => id = GetResult<string>("showBanner", wrapperContext, x, y));
                 return id;
        }



        public static string Bidapp_showBanner_platform(string bannerSize, float x, float y)
        {
             var id = "";  
            CallWrapperMethodWithContext(
                wrapperContext => id = GetResult<string>("showBanner", wrapperContext, x, y, bannerSize));
                return id;
        }



        public static string Bidapp_showBannerAtPosition_platform(string bannerPositon)
        {
            var id = "";  
            CallWrapperMethodWithContext(
                wrapperContext => id = GetResult<string>("showBannerAtPosition", wrapperContext, bannerPositon));
                return id;
        }



        public static string Bidapp_showBannerAtPosition_platform(string bannerPositon, string bannerSize)
        {
             var id = "";  
            CallWrapperMethodWithContext(
                wrapperContext => id = GetResult<string>("showBannerAtPosition", wrapperContext, bannerPositon, bannerSize));
                return id;                
        }

        [Conditional(UNITY_ANDROID)]
        public static void Bidapp_stopBannerAutorefresh_platform(string identifier)
        {
              CallWrapperMethod("stopBannerAutorefresh", identifier);
        }

        
        [Conditional(UNITY_ANDROID)]
        public static void Bidapp_setBannerRefreshInterval_platform(string identifier, double refreshInterval)
        {
              CallWrapperMethod("setBannerRefreshInterval", identifier, refreshInterval);
        }

        [Conditional(UNITY_ANDROID)]
        public static void Bidapp_refreshBanner_platform(string identifier)
        {
              CallWrapperMethod("refreshBanner", identifier);
        }


        [Conditional(UNITY_ANDROID)]
        public static void Bidapp_removeBanner_platform(string identifier)
        {
             CallWrapperMethodWithContext(
             wrapperContext => CallWrapperMethod("removeBanner",wrapperContext, identifier));
        }

        //----------------------------------------------------------------

           [Conditional(UNITY_ANDROID)]
        public static void Bidapp_setGDPRConsent_platform(bool consent)
        {
              CallWrapperMethod("setGDPRConsent", consent);
        }


           [Conditional(UNITY_ANDROID)]
        public static void Bidapp_setCCPAConsent_platform(bool consent)
        {
              CallWrapperMethod("setCCPAConsent", consent);
        }


           [Conditional(UNITY_ANDROID)]
        public static void Bidapp_setSubjectToCOPPA_platform(bool consent)
        {
              CallWrapperMethod("setSubjectToCOPPA", consent);
        }


        //------------------------------------------------------------------

        
        [Conditional(UNITY_ANDROID)]
        public static void Bidapp_requestTrackingAuthorization_platform()
        {
              CallWrapperMethod("requestTrackingAuthorization");
        }


         [Conditional(UNITY_ANDROID)]
        public static void Bidapp_setUnityCallbackTargetName_platform(ATABidappAdListener sdkDelegate)
        {
              CallWrapperMethod("setCallback", sdkDelegate);
        }


        public static void Bidapp_pause_platform(bool pauseStatus)
        {
            if (pauseStatus)
            {
                CallWrapperMethodWithContext(
                wrapperContext => CallWrapperMethod("onPause", wrapperContext));
            }
            else
            {
                CallWrapperMethodWithContext(
                wrapperContext => CallWrapperMethod("onResume", wrapperContext));
            }
        }


    //------------------------------------------------------------------------------------ 




	    private static T GetResult<T>(string methodName, params object[] args)
	    {
#if UNITY_ANDROID && !UNITY_EDITOR
            return CallWrapperMethod<T>(methodName, args);
#else
	        return default(T);
#endif
	    }
		
		private static void CallWrapperMethod(string methodName, params object[] args)
		{
#if UNITY_ANDROID && !UNITY_EDITOR
			AndroidJNI.AttachCurrentThread();
			using (AndroidJavaClass BidappWrapper = GetWrapperClass()) 
			{
                BidappWrapper.CallStatic(methodName, args);
			}
#endif
		}

        private static T CallWrapperMethod<T>(string methodName, params object[] args)
        {
#if UNITY_ANDROID && !UNITY_EDITOR 
            AndroidJNI.AttachCurrentThread();
            using (AndroidJavaClass BidappWrapper = GetWrapperClass())
            {
                return BidappWrapper.CallStatic<T>(methodName, args);
            }
#else
            return default(T);
#endif
        }

        private static void CallWrapperMethodWithContext(Action<object> action)
        {
#if UNITY_ANDROID && !UNITY_EDITOR 
            AndroidJNI.AttachCurrentThread();
            
            using (var wrapperContext = GetAndroidContext())
            {
                action(wrapperContext);
            }
#endif
}


        



        

#if UNITY_ANDROID && !UNITY_EDITOR 


		private static AndroidJavaClass GetWrapperClass()
		{
			AndroidJNI.AttachCurrentThread();
            return new AndroidJavaClass("io.bidapp.bidappunitywrapper.BidappUnity");
		}
#endif

	private static IDisposable GetAndroidContext()
		{
#if UNITY_ANDROID && !UNITY_EDITOR 
			AndroidJNI.AttachCurrentThread();
			return new AndroidJavaClass ("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject> ("currentActivity");
#else
            return null;
#endif
		}

	    private static string NormalizeAdContentType(string adContentType)
	    {
	        if (adContentType == null)
	        {
                throw new ArgumentNullException("adContentType");
	        }

	        return adContentType.ToLowerInvariant();
	    }

	}
}
