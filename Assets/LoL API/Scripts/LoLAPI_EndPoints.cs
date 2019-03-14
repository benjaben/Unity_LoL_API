using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System;

namespace LoLAPI
{
    public class LoLAPI_WebRequest
    {
        public void GetSummonerDTO(string summonerName, Action<LolAPI_JSONSummonerDTO> callback)
        {
            LoLAPI_Routines.Singleton.RunCoroutine(GetRequest<LolAPI_JSONSummonerDTO>("/lol/summoner/v4/summoners/by-name/" + summonerName, callback));
        }

        private IEnumerator GetRequest<T>(string endpoint, Action<T> callback) where T : LoLAPI_JsonObject
        {
            string url = "https://na1.api.riotgames.com" + endpoint + "?api_key=" + LoLAPI_Settings.API_KEY;

            using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
            {
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