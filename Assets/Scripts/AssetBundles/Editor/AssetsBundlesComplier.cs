using UnityEngine;
using UnityEditor;
using System.IO;

public class AssetsBundlesComplier 
{
    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {
        string assetBundleDirectory = "Assets/StreamingAssets";

        if (!Directory.Exists(Application.streamingAssetsPath))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }

        AssetBundleManifest assetMf = BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);


        //save hash

        
      

        /*Hash128 hash128 = assetMf.GetAssetBundleHash("AssetBundles");

        string data = hash128.ToString();
        string path = "Assets/Resources/AssetInfo/AssetBundleInfo.txt";

        //Save the Hash128 to the Resources folder
        using (FileStream fileStream = new FileStream(path, FileMode.Create))
        {
            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                writer.Write(data);
            }
        }
        UnityEditor.AssetDatabase.Refresh();*/
    }

}

