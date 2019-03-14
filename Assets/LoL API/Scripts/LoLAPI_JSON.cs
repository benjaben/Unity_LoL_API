using UnityEngine;

namespace LoLAPI
{
    public static class LoLAPI_Json
    {
        public static T ToObject<T>(string json) where T : LoLAPI_JsonObject
        {
            return UnityEngine.JsonUtility.FromJson<T>(json);
        }
    }

    public abstract class LoLAPI_JsonObject
    {
        
    }

    public class LolAPI_JSONSummonerDTO : LoLAPI_JsonObject
    {
        public int profileIconId;
        public string name;
        public string puuid;
        public long summonerLevel;
        public long revisionDate;
        public string id;
        public string accountId;
    }
}