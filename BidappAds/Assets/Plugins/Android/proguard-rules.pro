# Add project specific ProGuard rules here.
# By default, the flags in this file are appended to flags specified
# in /Users/paveliohin/Library/Android/sdk/tools/proguard/proguard-android.txt
# You can edit the include path and order by changing the proguardFiles
# directive in build.gradle.
#
# For more details, see
#   http://developer.android.com/guide/developing/tools/proguard.html

# Add any project specific keep options here:

# If your project uses WebView with JS, uncomment the following
# and specify the fully qualified class name to the JavaScript interface
# class:
#-keepclassmembers class fqcn.of.javascript.interface.for.webview {
#   public *;
#}

-keepattributes Exceptions, InnerClasses, Signature, Deprecated, SourceFile, LineNumberTable, *Annotation*, EnclosingMethod
-dontwarn android.webkit.**
#adcel
-keep class co.adcel.** {*;}
-dontwarn co.adcel.**
#adcolony
-keepclassmembers class * {
    @android.webkit.JavascriptInterface <methods>;
}
-keep class com.immersion.** {*;}
-dontwarn com.immersion.**
-dontnote com.immersion.**
-keep class com.jirbo.** {*;}
-dontwarn com.jirbo.**
-dontnote com.jirbo.**
-keep class com.adcolony.** {*;}
-dontwarn com.adcolony.**
#applovin
-keep class com.applovin.** {*;}
-dontwarn com.applovin.**
#startapp
-keep class com.startapp.** {*;}
-dontwarn com.startapp.**
#inmobi
-keepattributes SourceFile,LineNumberTable
-keep class com.inmobi.** { *; }
-dontwarn com.inmobi.**
-keep public class com.google.android.gms.**
-dontwarn com.google.android.gms.**
-dontwarn com.squareup.picasso.**
-keep class com.google.android.gms.ads.identifier.AdvertisingIdClient{
     public *;
}
-keep class com.google.android.gms.ads.identifier.AdvertisingIdClient$Info{
     public *;
}
# skip the Picasso library classes
-keep class com.squareup.picasso.** {*;}
-dontwarn com.squareup.picasso.**
-dontwarn com.squareup.okhttp.**
# skip Moat classes
-keep class com.moat.** {*;}
-dontwarn com.moat.**
# skip AVID classes
-keep class com.integralads.avid.library.* {*;}
#mytarget
-keep class com.my.target.** {*;}
-dontwarn com.my.target.**
#mopub
-keep class com.mopub.** {*;}
-dontwarn com.mopub.**
#smaato
-keep class com.smaato.soma.** {*;}
-dontwarn com.smaato.soma.**
-dontwarn org.fmod.**
-keep class org.fmod.** { *; }
-keepclassmembers  class com.tms.rarus.videoserver.* { *; }
-keepclassmembers  class com.unity3d.player.** { *; }
-keepclassmembers  class org.fmod.** { *; }
#chartboost
-keep class com.chartboost.** {*;}
-dontwarn com.chartboost.**
#unity3d
-keep class com.applifier.** {*;}
-keep class com.unity3d.** {*;}
-dontwarn com.unity3d.**
#personagraph
-keep public class com.personagraph.api.PGAgent {
    public *;
}
-keep public interface com.personagraph.api.PGAgent$PGUserProfileCallback {
    public *;
}
-keep public interface com.personagraph.api.PGAgent$PGEventsCallbackListener {
    public *;
}
-keep public class com.personagraph.api.PGSettings {
    public *;
}
-keep public class com.personagraph.api.PGSensorState {
    public *;
}
-keep public class com.personagraph.api.PGException {
    public *;
}
-keep public class com.personagraph.api.PGSourceType{
    public *;
}
-keep class com.personagraph.sensor.app.InstalledAppSensor {*;}
-keep class com.personagraph.sensor.app.RunningAppSensor {*;}
-keep class com.personagraph.sensor.location.LocationSensor{*;}
-keep class com.personagraph.sensor.location.LocationTracker {*;}
-keep class com.personagraph.sensor.fb.FBSensor {*;}
-keep class com.personagraph.sensor.service.SensorService {*;}
-keep class com.personagraph.sensor.service.ConnectivityChangeReceiver {*;}
#yandex
-keep class com.yandex.metrica.** { *; }
-dontwarn com.yandex.metrica.**
-keep class com.yandex.mobile.ads.** { *; }
-dontwarn com.yandex.mobile.ads.**
#tapsense
-dontwarn **CompatHoneycomb
-dontwarn com.tapsense.android.publisher.**
-keep class android.support.v4.**
-keep class com.tapsense.android.publisher.TS**
-keep class com.tapsense.mobileads.**
#amazon
-dontwarn com.amazon.**
-keep class com.amazon.** {*;}
#vungle
-keep class com.vungle.** { public *; }
-dontwarn com.vungle.**
-keep class javax.inject.*
-keepattributes *Annotation*
-keepattributes Signature
-keep class dagger.*
#avocarrot
-dontwarn com.avocarrot.**
-keep class com.avocarrot.** {*;}
#supersonic
-keepclassmembers class com.ironsource.sdk.controller.IronSourceWebView$JSInterface {
    public *;
}
-keepclassmembers class * implements android.os.Parcelable {
    public static final android.os.Parcelable$Creator *;
}
-keep public class com.google.android.gms.ads.** {
   public *;
}
-keep class com.ironsource.adapters.** { *;
}
#woobi
-keep class com.woobi.** { *; }
#nativex
-keep public class com.google.gson
-keep class Gson**
-keepclassmembers class Gson** {
    *;
}
-keepattributes Signature, *Annotation*
-keep class com.nativex.** {
    *;
}
#tapjoy
-keep class com.tapjoy.** { *; }
-keepattributes JavascriptInterface
-keep class * extends java.util.ListResourceBundle {
protected Object[][] getContents();
}
-keep public class com.google.android.gms.common.internal.safeparcel.SafeParcelable {
public static final *** NULL;
}
-keepnames @com.google.android.gms.common.annotation.KeepName class *
-keepclassmembernames class * {
@com.google.android.gms.common.annotation.KeepName *;
}
-keepnames class * implements android.os.Parcelable {
public static final ** CREATOR;
}
-keep class com.google.android.gms.ads.identifier.** { *; }
-dontwarn com.tapjoy.internal.**
#/tapjoy

#flurry
-keep class com.flurry.** { *; }
-dontwarn com.flurry.**

# Required if you are using the Millennial SDK:
-keep class com.millennialmedia.** { *; }
-dontwarn com.millennialmedia.**

#leadbolt
-dontwarn android.support.v4.**
-keep public class com.google.android.gms.* { public *; }
-dontwarn com.google.android.gms.**

-keep class com.apptracker.** { *; }
-dontwarn com.apptracker.**
-keepclassmembers class **.R$* {
	public static <fields>;
}
-keep class **.R$*

-dontwarn org.apache.**
-dontwarn com.google.**
-dontwarn android.**