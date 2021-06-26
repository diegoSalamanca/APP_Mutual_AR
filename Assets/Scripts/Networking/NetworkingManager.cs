using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class NetworkingManager : MonoBehaviour
{
    string url = "http://eabc-vm-node-mutual.eastus.cloudapp.azure.com:3003/api";

    string logindataJsonString = "{  \"userId\": \"9.442.895-5\" }";

    private void Start()
    {
        SendData();
    }

    public void SendData()
    {
        StartCoroutine(GetAPI(url));
    }

    IEnumerator GetAPI(string url)
    {

        byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes( logindataJsonString );


        using (UnityWebRequest peticion = UnityWebRequest.Post(url, "") )
        {
            peticion.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);

            peticion.SetRequestHeader("Content-Type", "application/json");

            peticion.SetRequestHeader("X-API-Key", "LXFKz7N7741HHxU30PBo");            

            yield return peticion.SendWebRequest();

            if (peticion.isNetworkError )
            {
                print("error de red");

            }

            else if ( peticion.isHttpError)
            {
                print("error de http");
                print(peticion.error);
                print(peticion.responseCode);
            }

            else
            {
                if (peticion.isDone)
                {
                    print("ok");
                    //print(peticion.downloadHandler.data);

                    string stringResult = System.Text.Encoding.UTF8.GetString(peticion.downloadHandler.data);

                    print(stringResult);

                    /*var jsonResult = JsonUtility.FromJson<PokemonList>(stringResult);

                    foreach (var item in jsonResult.results)
                    {
                        print(item.name);
                    }*/

                }
            }

        }
    }
}
