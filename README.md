<div align="center">
       <img alt="Logo" src="https://github.com/bidapphub/bidapp-ads-android/assets/148830475/b1a7003c-fe70-40ed-9db8-1cbee73ba200" width="120"/>
</div>
 <br/><br/>
<div align="center">
    <p>
        <img src="https://img.shields.io/badge/Bidapp-_Unity plugin-blue"/>
        <img src="https://img.shields.io/badge/Android-green"/>
        <img src="https://img.shields.io/badge/IOS-red"/>
    </p>
</div>

# Bidapp ads Unity plugin
Current repository сontains Bidapp demo app with plugin for Unity

# Documentation
Complete integration instructions and usage guide for the Bidapp Ads SDK can be found [here](https://docs.bidapp.io).

# Overview
Bidapp monetization plugin for Unity
Bidapp helps you generate more ad revenue and gives you all tools necessary to work with ad networks. Our framework is a waterfall system that prioritizes
between ad networks, taking into account user geography and ad rate for your inventory


# Quick guide for demo app
1. To select ad networks to use with the Bidapp mediation you should edit the ./BidappAds/Assets/BidappAds/Editor/Dependencies.xml file in your project. Comment out all of the unwanted ad networks section and save the file:

- Example for Android 

```xml    
    <androidPackage spec="io.bidapp:bidappUnity:1.1.0" />
    <androidPackage spec="io.bidapp.networks:admob:1.1.0" />
    <!--androidPackage spec="io.bidapp.networks:digitalturbine:1.1.0" /-->
    <!--androidPackage spec="io.bidapp.networks:facebook:1.1.0" /-->      
```
Launch forse resolve in Unity project (Assets -> External Dependency Manager -> Android Resolver -> Force Resolve)

- Example for IOS

```xml
		<iosPod name="bidapp" addToAllTargets="false" />
		<!--iosPod name="bidapp/Applovin" addToAllTargets="false" /-->
		<iosPod name="bidapp/ApplovinMax" addToAllTargets="false" />
		<!--iosPod name="bidapp/Unity" addToAllTargets="false" /-->
```

2. Go to the [Bidapp dashboard](https://dashboard-564.pages.dev), add a new application, and connect advertising networks. (The name of your package in Unity must match the one you created in the BidApp dashboard.)
3. Edit Start() method and set your PubId in DemoGUI.cs script (BidappAds\Assets\Scripts)
   
   For detailed information, follow the link provided in the documentation.

![reward_unity](https://github.com/bidapphub/bidapp-unity-plugin/assets/148830475/db3b8783-2920-456a-bdeb-bcb042c813a9)
![banner_unity](https://github.com/bidapphub/bidapp-unity-plugin/assets/148830475/ebe1ac2d-6819-4fc9-b103-9a19f090828b)
![interstitial_unity](https://github.com/bidapphub/bidapp-unity-plugin/assets/148830475/314b24cb-add6-412b-9abd-94e59cb4ce2b)


# Contact Us
Email: [support@bidapp.io](support@bidapp.io)
