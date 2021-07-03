
using UnityEngine;


public class AddBundleAsChild : MonoBehaviour
{
    bool assetready = false;
    public string assetName;

    AssetBundleDownloader assetBundleDownloader;
    
    void Start()
    {
        assetBundleDownloader = FindObjectOfType<AssetBundleDownloader>();

        if (!assetready)
        {
            assetready = true;
            
        }

        GameObject asset = BundlesData.mainAssetBundle.LoadAsset<GameObject>(assetName);

        Instantiate(asset, transform);

    }

    

}
