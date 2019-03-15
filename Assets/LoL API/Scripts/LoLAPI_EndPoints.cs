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
            LoLAPI_Routines.Singleton.RunCoroutine(GetRequestCR<LoLAPI_JsonSummonerDTO>("/lol/summoner/v4/summoners/by-name/" + summonerName, callback));
        }

        public void GetChampionMasteries(string summonerId, Action<List<LoLAPI_JsonChampionMasteryDTO>> callback)
        {
            LoLAPI_Routines.Singleton.RunCoroutine(GetRequestCR<LoLAPI_JsonChampionMasteryDTO>("/lol/champion-mastery/v4/champion-masteries/by-summoner/" + summonerId, callback));
        }

        public void GetChampionData(Action<LoLAPI_JsonChampionDataCollection> callback)
        {
            LoLAPI_Routines.Singleton.RunCoroutine(GetDataCR<LoLAPI_JsonChampionDataCollection>("champion.json", callback));
        }

        private IEnumerator GetRequestCR<T>(string endpoint, Action<T> callback) where T : LoLAPI_JsonObject
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

        private IEnumerator GetRequestCR<T>(string endpoint, Action<List<T>> callback) where T : LoLAPI_JsonObject
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

        private IEnumerator GetDataCR<T>(string endpoint, Action<T> callback) where T : LoLAPI_JsonObject
        {
            string url = "http://ddragon.leagueoflegends.com/cdn/6.24.1/data/en_US/" + endpoint;

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
                        callback.Invoke(LoLAPI_Json.ToObject<T>(webRequest.downloadHandler.text));
                    }
                }
            }
        }
    }
}