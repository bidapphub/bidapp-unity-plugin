#if (UNITY_IOS) || (UINITY_IPHONE) || (UNITY_ANDROID)
using System;
using System.IO;
using System.Xml;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;

using Bidapp;

namespace UnityEngine.Advertisements
{
  public static class BidappPostprocessor
  {
    [PostProcessBuild(2160)]
    public static void OnPostProcessBuild (BuildTarget target, string path)
    {
#if (UNITY_IOS) || (UINITY_IPHONE)
#if (UNITY_IOS)
      if (target == BuildTarget.iOS) {
#else
      if (target == BuildTarget.iPhone) {
#endif
        PostProcessBuild_iOS (path);
      }
#endif
    }

    [PostProcessBuild(-9)]
    public static void OnPostProcessBuildEarly (BuildTarget target, string path)
    {
#if (UNITY_IOS) || (UINITY_IPHONE)
#if (UNITY_IOS)
      if (target == BuildTarget.iOS) {
#else
      if (target == BuildTarget.iPhone) {
#endif
        FixUnityPlistAppendBug (path);
      }
#endif
    }

    private static void PostProcessBuild_iOS (string path)
    {
      ProcessInfoPlist (path);

      //string pathToPbxproj = path + "/Unity-iPhone.xcodeproj/project.pbxproj";
      //string fileContent = File.ReadAllText(pathToPbxproj);
      //bool isSimulator = fileContent.Replace(" ","").Contains("SUPPORTED_PLATFORMS=iphonesimulator");
      //string replacedContent = isSimulator ? fileContent.Replace("ios-arm64/","ios-arm64_x86_64-simulator/").Replace("ios-arm64\"","ios-arm64_x86_64-simulator\"").Replace("ios-arm64 ","ios-arm64_x86_64-simulator ").Replace("ios-arm64;","ios-arm64_x86_64-simulator;") : fileContent.Replace("ios-arm64_x86_64-simulator","ios-arm64");
      
      //File.WriteAllText(pathToPbxproj, replacedContent);
    }

	private static void ProcessInfoPlist (string path)
	{
		// Get plist
		string plistPath = path + "/Info.plist";
		PlistDocument plist = new PlistDocument();
		plist.ReadFromString(File.ReadAllText(plistPath));
		
		// Get root
		PlistElementDict rootDict = plist.root;

		// Set ATS
		PlistElementDict ats = (PlistElementDict)rootDict["NSAppTransportSecurity"];
		if (ats == null) {
			ats = rootDict.CreateDict("NSAppTransportSecurity");
		}
		ats.SetBoolean("NSAllowsArbitraryLoads", true);
		ats.SetBoolean("NSAllowsArbitraryLoadsForMedia", true);
		ats.SetBoolean("NSAllowsArbitraryLoadsInWebContent", true);

		PlistElementArray gadId = (PlistElementArray)rootDict["GADApplicationIdentifier"];
		if (gadId == null)
		{
                        rootDict.SetString("GADApplicationIdentifier", "ca-app-pub-4562214607373293~2049470164");
		}

		// Set Calendars Usage Description
		rootDict.SetString("NSCalendarsUsageDescription", "Adding events");
		
		// Set Schemes
		PlistElementArray aqs = (PlistElementArray)rootDict["LSApplicationQueriesSchemes"];
		if (aqs == null)
		{
			aqs = rootDict.CreateArray("LSApplicationQueriesSchemes");
		}
        
        // Set Apple Tracking Transparency
        rootDict.SetString("NSUserTrackingUsageDescription", "Your data will be used to deliver personalized ads to you.");

		var fb = "fb";
		var instagram = "instagram";
		var tumblr = "tumblr";
		var twitter = "twitter";
		foreach (var v in aqs.values)
    {
			if (!(v is PlistElementString)) continue;
			
			PlistElementString rlElm = v as PlistElementString;
			if (String.Equals(rlElm.value,fb)) fb = null;
			if (String.Equals(rlElm.value,instagram)) instagram = null;
			if (String.Equals(rlElm.value,tumblr)) tumblr = null;
			if (String.Equals(rlElm.value,twitter)) twitter = null;
    }

		if (fb != null) aqs.AddString(fb);
		if (instagram != null) aqs.AddString(instagram);
		if (tumblr != null) aqs.AddString(tumblr);
		if (twitter != null) aqs.AddString(twitter);

        // iOS 14
		PlistElementArray ska = (PlistElementArray)rootDict["SKAdNetworkItems"];
		if (ska == null)
		{
			ska = rootDict.CreateArray("SKAdNetworkItems");
		}

        HashSet<string> allIdts = new HashSet<string>(BidappSKAdNetwork.items());

    foreach (var v in ska.values)
    {
			if (!(v is PlistElementDict)) continue;
			
			PlistElementDict rlElmDict = v as PlistElementDict;
      PlistElementString rlElm = (PlistElementString)rlElmDict["SKAdNetworkIdentifier"];
      string idt = rlElm.value;

      allIdts.Remove(idt);
    }

    foreach (var v in allIdts)
    {
			PlistElementDict d = ska.AddDict();
      d.SetString("SKAdNetworkIdentifier", v);
		}

		// Write to file
		File.WriteAllText(plistPath, plist.WriteToString());
	}

	// This fixes an Info.plist append bug near UIInterfaceOrientation on some Unity versions (atleast on Unity 4.2.2)
	private static void FixUnityPlistAppendBug (string path)
	{
		try {
			string file = System.IO.Path.Combine (path, "Info.plist");
			
			if (!File.Exists (file)) {
				return;
			}
			
			string processedContents = "";
			bool bugFound = false;
			
			using (StreamReader sr = new StreamReader(file)) {
				bool previousWasEndString = false;
				while (sr.Peek() >= 0) {
					string line = sr.ReadLine ();
					
					if (previousWasEndString && line.Trim ().StartsWith ("</string>")) {
						bugFound = true;
					} else {
						processedContents += line + "\n";
					}
					
					previousWasEndString = line.Trim ().EndsWith ("</string>");
				}
			}
			
			if (bugFound) {
				File.Delete (file);
				
				using (StreamWriter streamWriter = File.CreateText(file)) {
					streamWriter.Write (processedContents);
				}
				
				Debug.Log ("UnityAdsPostprocessor found and fixed a known Unity plist append bug in the Info.plist.");
			}
		} catch (Exception e) {
			Debug.Log ("Unable to process plist file: " + e);
		}
	}
}
}
#endif
