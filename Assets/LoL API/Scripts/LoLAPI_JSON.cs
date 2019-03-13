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
}