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

    public GameObject StartButton, retry_Exit_Buttons;

    public TMPro.TextMeshProUGUI textoEstado;

    private void Start()
    {
        StartDownload();
    }


    public void StartDownload()
    {
        //print("se limpio el cache "+ Caching.CleanCache());
        StartCoroutine(DownloadBundle());
        StartButton.SetActive(false);
        retry_Exit_Buttons.SetActive(false);
    }

    


    IEnumerator DownloadBundle()
    {
        textoEstado.text = "validanto datos";

        string url = urlServer + bundleName;
        var request = UnityWebRequestAssetBundle.GetAssetBundle(url, 1, 0);

        var operacion = request.SendWebRequest();
      

        if (request.error != null)
        {
            textoEstado.text = "Error " + request.error;
            retry_Exit_Buttons.SetActive(true);
            yield break;
        }




        while (!operacion.isDone)
        {
            print("% = " + request.downloadProgress);
            slider.value = request.downloadProgress;
            textoEstado.text = "Descargando datos adicionales "+ (request.downloadProgress * 100).ToString("f0")+ "%" ;
            yield return null;
        }

       
            textoEstado.text = "Descarga completada, ¡Gracias!";
            slider.value = 1;
            StartButton.SetActive(true);

            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);

            BundlesData.mainAssetBundle = bundle;
            //print("resultado = " + bundle.name);
        

    }

    public void SaveData(string stringResult)
    {
        //string stringResult = System.Text.Encoding.UTF8.GetString(peticion.downloadHandler.data);

        string localDireccion = Path.Combine(Application.persistentDataPath, bundleName);

        print(localDireccion);


        FileStream fileStream = new FileStream(localDireccion, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(stringResult);
        }
    }

    public void SaveAssetBundle(AssetBundle bundle)
    {
        //string stringResult = System.Text.Encoding.UTF8.GetString(peticion.downloadHandler.data);

        string localDireccion = Path.Combine(Application.persistentDataPath, bundleName);

        print(localDireccion);


        FileStream fileStream = new FileStream(localDireccion, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(bundle);
        }
    }

    public void LoadAssetFromFile()
    {
        var direction = Path.Combine(Application.streamingAssetsPath, bundleName);

        if (File.Exists(direction))
            print("El archivo " + direction + " SI existe");
        else
            print("El archivo " + direction + " NO existe");


        //var myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.persistentDataPath, bundleName));
        var myLoadedAssetBundle = AssetBundle.LoadFromFile(direction);
        if (myLoadedAssetBundle == null)
        {
            Debug.Log("Failed to load AssetBundles!");
            return;
        }
        //var prefab = myLoadedAssetBundle.LoadAsset<GameObject>(AssetName);
        //Instantiate(prefab);
    }
}
