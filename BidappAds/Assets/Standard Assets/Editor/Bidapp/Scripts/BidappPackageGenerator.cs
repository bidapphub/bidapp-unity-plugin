using UnityEngine;
using UnityEditor;
using System.Collections;

public class BidappPackageGenerator : MonoBehaviour {

	private static string[] assetPathNames = {
		"Assets/Plugins",
		"Assets/Standard Assets",
		"Assets/WebPlayerTemplates"
	};

	private static string defaultFileName = "BidappAds";
	private static string defaultFileExtension = "unitypackage";

	public static void CreatePackage() {
		string fileNameWithPath = defaultFileName + "." + defaultFileExtension;

		AssetDatabase.ExportPackage(assetPathNames, fileNameWithPath, ExportPackageOptions.Recurse);

		Debug.Log("BidappAds package created");
	}
}
