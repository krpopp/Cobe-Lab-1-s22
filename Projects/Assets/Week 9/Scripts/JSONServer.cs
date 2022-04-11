using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;

public class JSONServer : MonoBehaviour
{


    // public static IEnumerator PostScore(string url, string bodyJsonString){
    //     var request = new UnityWebRequest(url, "POST");
    //     byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(bodyJsonString);
    //     request.uploadHandler = new UploadHandlerRaw(jsonToSend);
    //     request.downloadHandler = new DownloadHandlerBuffer();
    //     request.SetRequestHeader("Content-Type", "application/json");
    //     request.SendWebRequest();
    //     while(!request.isDone){
    //         Debug.Log("waiting");
    //         yield return null;
    //     }
    //     //yield return request.SendWebRequest();
    //     Debug.Log("Status Code: " + request.responseCode);
    //     Debug.Log("done!");
    // }

}
