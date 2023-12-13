namespace Bidapp
{
	public static class BidappLinkedSources
	{
		public static string[] frameworks()
		{
			return new string[] { "AVFoundation.framework","Accelerate.framework","AdSupport.framework","AudioToolbox.framework","CFNetwork.framework","CoreFoundation.framework","CoreGraphics.framework","CoreImage.framework","CoreLocation.framework","CoreMedia.framework","CoreMotion.framework","CoreTelephony.framework","CoreText.framework","CoreVideo.framework","ImageIO.framework","JavaScriptCore.framework","LocalAuthentication.framework","MediaPlayer.framework","MessageUI.framework","Metal.framework","MetalKit.framework","OpenGLES.framework","QuartzCore.framework","SafariServices.framework","Security.framework","Social.framework","StoreKit.framework","SystemConfiguration.framework","WatchConnectivity.framework","WebKit.framework","AppTrackingTransparency.framework","CoreServices.framework","NetworkExtension.framework"};
		}

		public static string[] libraries()
		{
			return new string[] { "libbz2.dylib","libc++abi.dylib","libc++.dylib","libiconv.dylib","libresolv.dylib","libsqlite3.dylib","libxml2.dylib","libz.dylib" };
		}
	}
}