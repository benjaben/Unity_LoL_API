using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using System;

namespace LoLAPI
{
    public class LoLAPI_WebRequest
    {
        public void GetSummonerDTO(string summonerName, Action<LoLAPI_JsonSummonerDTO> callback)
        {
            LoLAPI_Routines.Singleton.RunCoroutine(GetRequest<LoLAPI_JsonSummonerDTO>("/lol/summoner/v4/summoners/by-name/" + summonerName, callback));
        }

        public void GetChampionMasteries(string summonerId, Action<List<LoLAPI_JsonChampionMasteryDTOCollection>> callback)
        {
            LoLAPI_Routines.Singleton.RunCoroutine(GetRequest<LoLAPI_JsonChampionMasteryDTOCollection>("/lol/champion-mastery/v4/champion-masteries/by-summoner/" + summonerId, callback));
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

        private IEnumerator GetRequest<T>(string endpoint, Action<List<T>> callback) where T : LoLAPI_JsonObject
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
                    if (callback != null)
                    {
                        callback.Invoke(LoLAPI_Json.ToObjects<T>(webRequest.downloadHandler.text));
                    }
                }
            }
        }
    }
}