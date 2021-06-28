using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class NetworkingManager : MonoBehaviour
{
    public string ApiUrl;

    public string UserId;

    string logindataJsonString = "{  \"userId\": \"9.442.895-5\" }";

    ApiMutualObject apiMutualObject = new ApiMutualObject();

    private void Start()
    {
        //apiMutualObject.userId = "user testing";
        
    }

    public void SetNetData(string user)
    {
        apiMutualObject.userId = user;
        apiMutualObject.appId = Application.productName;
        apiMutualObject.time = DateTime.Now.ToString();
        apiMutualObject.actionParameter = "location-disabled";
        apiMutualObject.actionValue = Application.platform.ToString();
    }


    public void SetNetDataButton(string CapsuleName, string MicrocapsuleName)
    {
        apiMutualObject.actionTime = DateTime.Now.ToString();
        apiMutualObject.actionGroup = CapsuleName;
        apiMutualObject.actionId = MicrocapsuleName;
        SendData();

    }

    public void SendData()
    {

        var jsonObject = JsonUtility.ToJson(apiMutualObject);

        

        StartCoroutine(GetAPI(ApiUrl, jsonObject));
    }

    IEnumerator GetAPI(string url, string jsonObject)
    {

        byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(jsonObject);


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
