#if (UNITY_IOS) || (UINITY_IPHONE) || (UNITY_ANDROID)
using System;
using System.Text;
using System.IO;
using System.Xml;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEditor;
using UnityEditor.Android;
using UnityEditor.Callbacks;

using Bidapp;

namespace UnityEngine.Advertisements
{
  public class BidappAndroidPostprocessor : IPostGenerateGradleAndroidProject
  {
    public int callbackOrder { get { return 1; } }
    public void OnPostGenerateGradleAndroidProject(string basePath)
    {
        var androidManifest = new BidappAndroidManifest(GetManifestPath(basePath));
		var changed = androidManifest.SetHardwareAccelerated(true);
		if (changed)
		{
			androidManifest.Save();
			UnityEngine.Debug.Log("Successfully updated the hardwareAccelerated to true.");
		}
		else
		{
			UnityEngine.Debug.LogWarning("Failed to update the hardwareAccelerated to true.");
		}
        EnableJetifierIfRequired(basePath);
        PatchBuildGradle(basePath);
	}



	private string GetManifestPath(string basePath)
	{
		var pathBuilder = new StringBuilder(basePath);
		pathBuilder.Append(Path.DirectorySeparatorChar).Append("src");
		pathBuilder.Append(Path.DirectorySeparatorChar).Append("main");
		pathBuilder.Append(Path.DirectorySeparatorChar).Append("AndroidManifest.xml");
		return pathBuilder.ToString();
	}
        
    
    private void EnableJetifierIfRequired(string path)
    {
        //string[] files = Directory.GetFiles(Application.dataPath + "/Plugins/Android" , "androidx.*.aar");
 
        //if(files.Length > 0)
        //{
            string gradlePropertiesPath = path + "/../gradle.properties";
            if (!File.Exists(gradlePropertiesPath))
            {
                gradlePropertiesPath = path + "/../gradleOut/gradle.properties";
            }
 
            string[] lines = File.ReadAllLines(gradlePropertiesPath);
 
            // Need jetifier patch process
            bool hasAndroidXProperty = lines.Any(text => text.Contains("android.useAndroidX"));
            bool hasJetifierProperty = lines.Any(text => text.Contains("android.enableJetifier"));
 
            StringBuilder builder = new StringBuilder();
 
            foreach(string each in lines)
            {
                builder.AppendLine(each);
            }
 
            if (!hasAndroidXProperty)
            {
                builder.AppendLine("android.useAndroidX=true");
            }
 
            if (!hasJetifierProperty)
            {
                builder.AppendLine("android.enableJetifier=true");
            }
 
            File.WriteAllText(gradlePropertiesPath, builder.ToString());
        //}
    }
    private void PatchBuildGradle(string path)
    {
        //string[] files = Directory.GetFiles(Application.dataPath + "/Plugins/Android" , "androidx.*.aar");
 
        //if(files.Length > 0)
        //{
            string buildGradlePath = path + "/../launcher/build.gradle";
            if (!File.Exists(buildGradlePath))
            {
                buildGradlePath = path + "/../build.gradle";
            }

            string[] lines = File.ReadAllLines(buildGradlePath);
 
            bool hasMultiDexEnabledProperty = lines.Any(text => text.Contains("multiDexEnabled true"));
            bool applicationStarted = false;
            StringBuilder builder = new StringBuilder();
            foreach(string each in lines)
            {
                if (each.Contains("apply plugin: 'com.android.application'"))
                {
                    applicationStarted = true;
                }
                if (each.Contains("dependencies") && applicationStarted)
                {
           builder.AppendLine("repositories {");
            builder.AppendLine("    mavenCentral()");
            builder.AppendLine("    maven { url 'https://cboost.jfrog.io/artifactory/chartboost-ads/' }");
            builder.AppendLine("}");
                }
                builder.AppendLine(each);
                if (!hasMultiDexEnabledProperty && each.Contains("defaultConfig")) {
                    builder.AppendLine("multiDexEnabled true");
                }
                if (each.Contains("dependencies") && applicationStarted)
                {
                    builder.AppendLine("    implementation 'androidx.multidex:multidex:2.0.1'");

                }
            }
 
            File.WriteAllText(buildGradlePath, builder.ToString());
        //}
    }
}


internal class BidappAndroidXmlDocument : XmlDocument
{
	private string m_Path;
	protected XmlNamespaceManager nsMgr;
	public readonly string AndroidXmlNamespace = "http://schemas.android.com/apk/res/android";

	public BidappAndroidXmlDocument(string path)
	{
		m_Path = path;
		using (var reader = new XmlTextReader(m_Path))
		{
			reader.Read();
			Load(reader);
		}
		nsMgr = new XmlNamespaceManager(NameTable);
		nsMgr.AddNamespace("android", AndroidXmlNamespace);
	}

	public string Save()
	{
		return SaveAs(m_Path);
	}

	public string SaveAs(string path)
	{
		using (var writer = new XmlTextWriter(path, new UTF8Encoding(false)))
		{
			writer.Formatting = Formatting.Indented;
			Save(writer);
		}
		return path;
	}
}


internal class BidappAndroidManifest : BidappAndroidXmlDocument
{
	public BidappAndroidManifest(string path) : base(path)
	{
	}

	internal XmlNode GetActivityWithLaunchIntent()
	{
		return
			SelectSingleNode(
				"/manifest/application/activity[intent-filter/action/@android:name='android.intent.action.MAIN' and "
				+ "intent-filter/category/@android:name='android.intent.category.LAUNCHER']",
				nsMgr);
	}

	internal bool SetHardwareAccelerated(bool enabled)
	{
		bool changed = false;
		var activity = GetActivityWithLaunchIntent() as XmlElement;
		if (activity.GetAttribute("hardwareAccelerated", AndroidXmlNamespace) != ((enabled) ? "true" : "false"))
		{
			activity.SetAttribute("hardwareAccelerated", AndroidXmlNamespace, (enabled) ? "true" : "false");
			changed = true;
		}
		return changed;
	}
}
}
#endif
