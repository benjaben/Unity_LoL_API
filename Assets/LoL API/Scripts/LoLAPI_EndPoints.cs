using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System;

namespace LoLAPI
{
    public class LoLAPI_WebRequest
    {
        private IEnumerator GetRequest<T>(string url, Action<T> callback) where T : LoLAPI_JsonObject
        {
            using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
            {
                // Request and wait for the desired page.
                yield return webRequest.SendWebRequest();

                if (webRequest.isNetworkError)
                {
                    Debug.LogError("[LoLAPI] - " + webRequest.error);
                }
                else
                {
                    if(callback != null)
                    {
                        callback.Invoke(LoLAPI_Json.ToObject<T>(webRequest.downloadHandler.text));
                    }
                }
            }
        }
    }
}