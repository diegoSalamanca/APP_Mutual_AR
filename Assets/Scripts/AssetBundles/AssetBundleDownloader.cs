using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using UnityEngine.UI;

public class AssetBundleDownloader : MonoBehaviour
{

    public string urlServer;

    public string bundleName;
    
    public Slider slider;

    public GameObject StartButton, retry_Exit_Buttons, downloadButtons;

    public TMPro.TextMeshProUGUI textoEstado;

    uint version = 0;

    string hash;

    private void Start()
    {        
        ValidateVersion();
    }


    public void StartDownload()
    {
        Caching.ClearCache(); //delete cache

        slider.gameObject.SetActive(false);
        StartCoroutine(DownloadBundle());        
        StartButton.SetActive(false);
        retry_Exit_Buttons.SetActive(false);
        downloadButtons.SetActive(false);        
    }

    public void ValidateVersion()
    {
        slider.gameObject.SetActive(false);
        StartCoroutine(GetVersion());
        StartButton.SetActive(false);
        retry_Exit_Buttons.SetActive(false);
        
    }

    IEnumerator GetVersion()
    {
        slider.gameObject.SetActive(false);
        var versionurl = urlServer + "version.json";
        var request = UnityWebRequest.Get(versionurl);
        yield return request.SendWebRequest();

        while (!request.isDone)
        {            
            textoEstado.text = "validando la verison de los datos";
            yield return null;
        }

        if (request.error != null)
        {
            textoEstado.text = "Error " + request.error;
            retry_Exit_Buttons.SetActive(true);
            yield break;
        }

        if (request.isNetworkError || request.isHttpError)
        {
            textoEstado.text = "Error de red" + request.error;
            yield break;
        }

        var hashtocompare = new Hash128();

        //hash.Append(version);
      

        

        //var versionObject = new VersionObject();

        string stringResult = System.Text.Encoding.UTF8.GetString(request.downloadHandler.data);

        var versionObject = JsonUtility.FromJson<VersionObject>(stringResult);

        var versionResult = versionObject.version;

        hash = versionObject.hash;

        version = versionResult;

        var intversion = (int)version;
        print("intversion "+intversion);

        print(hash);

        //hashtocompare = hash;
        //hashtocompare.Append(hash);

        if (Caching.IsVersionCached(urlServer + bundleName, intversion))
        {
            print("ya en memoria ");            
            StartCoroutine(LoadCacheBundle());
            yield break;

        }

        print("hash = "+ Hash128.Parse(hash));
        
        textoEstado.text = "Versión "+ version + "\n Se necesita descargar datos adicionales se recomienda realizar la descarga mediante WI-FI";

        downloadButtons.SetActive(true);
    }




    IEnumerator DownloadBundle()
    {       

        textoEstado.text = "validanto datos";

        string url = urlServer + bundleName;
        var request = UnityWebRequestAssetBundle.GetAssetBundle(url, version, 0);

        var operacion = request.SendWebRequest();

        string size = request.GetResponseHeader("Content-Length");


        if (request.error != null)
        {
            textoEstado.text = "Error " + request.error;
            retry_Exit_Buttons.SetActive(true);            
            yield break;
        }

        slider.gameObject.SetActive(true);


        while (!operacion.isDone)
        {
            //slider.gameObject.SetActive(true);
            //print("% = " + request.downloadProgress);
            slider.value = request.downloadProgress;
            textoEstado.text = "Descargando datos adicionales "+ (request.downloadProgress * 100).ToString("f0")+ "%" ;
            yield return null;
        }

            slider.gameObject.SetActive(false);
            textoEstado.text = "Descarga completada, ¡Gracias!";
            slider.value = 1;
            StartButton.SetActive(true);

            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);

            BundlesData.mainAssetBundle = bundle;

            var manifesthash = bundle.GetHashCode();

            print("hash descargado "+ Hash128.Parse( manifesthash.ToString()));

            print("resultado = " + bundle.name);        

    }

    IEnumerator LoadCacheBundle()
    {
        slider.gameObject.SetActive(false);

        textoEstado.text = "validanto datos";

        string url = urlServer + bundleName;
        var request = UnityWebRequestAssetBundle.GetAssetBundle(url, version, 0);

        var operacion = request.SendWebRequest();

        string size = request.GetResponseHeader("Content-Length");


        if (request.error != null)
        {
            textoEstado.text = "Error " + request.error;
            retry_Exit_Buttons.SetActive(true);
            yield break;
        }      


        while (!operacion.isDone)
        {
            
            slider.value = request.downloadProgress;
            textoEstado.text = "Descargando datos adicionales " + (request.downloadProgress * 100).ToString("f0") + "%";
            yield return null;
        }

        AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);

        BundlesData.mainAssetBundle = bundle;

        textoEstado.text = "No se necesitan datos adicionales";
        StartButton.SetActive(true);

    }

}


[System.Serializable]
public class VersionObject
{
    public uint version;
    public string hash;
}
