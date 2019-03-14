using UnityEngine;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace LoLAPI
{
    public static class LoLAPI_Json
    {
        public static T ToObject<T>(string json) where T : LoLAPI_JsonObject
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static List<T> ToObjects<T>(string json) where T : LoLAPI_JsonObject
        {
            return JsonConvert.DeserializeObject<List<T>>(json);
        }
    }

    [Serializable]
    public abstract class LoLAPI_JsonObject
    {
        
    }

    [Serializable]
    public class LoLAPI_JsonSummonerDTO : LoLAPI_JsonObject
    {
        public int profileIconId;
        public string name;
        public string puuid;
        public long summonerLevel;
        public long revisionDate;
        public string id;
        public string accountId;
    }

    [Serializable]
    public class LoLAPI_JsonChampionMasteryDTOCollection : LoLAPI_JsonObject
    {
        public bool chestGranted;
        public int championLevel;
        public int championPoints;
        public long championId;
        public long championPointsUntilNextLevel;
        public long lastPlayTime;
        public int tokensEarned;
        public long championPointsSinceLastLevel;
        public string summonerId;
    }
}