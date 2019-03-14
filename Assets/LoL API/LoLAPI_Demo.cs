using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

namespace LoLAPI
{
    public class LoLAPI_Demo : MonoBehaviour
    {
        private Button m_FetchInfoButton;
        private TMP_InputField m_SummonerNameInputField;
        private TextMeshProUGUI m_SummonerNameText;
        private LoLAPI_WebRequest m_APIRequester;
        private string m_StoredSummonerId;

        private void Awake()
        {
            m_APIRequester = new LoLAPI_WebRequest();
            m_FetchInfoButton = GetChildComponent<Button>("Button_FetchInfo");
            m_SummonerNameInputField = GetChildComponent<TMP_InputField>("InputField_SummonerName");
            m_SummonerNameText = GetChildComponent<TextMeshProUGUI>("Text_SummonerName");
        }

        private void Start()
        {
            m_FetchInfoButton.onClick.AddListener(Button_FetchInfo);
        }

        private void Button_FetchInfo()
        {
            m_APIRequester.GetSummonerDTO(m_SummonerNameInputField.text, (data) => 
            {
                m_SummonerNameText.text = data.name;
                m_StoredSummonerId = data.id;

                m_APIRequester.GetChampionMasteries(m_StoredSummonerId, (championData) => 
                {
                    Debug.Log(championData[0].championId);
                });
            });
        }

        private T GetChildComponent<T>(string name) where T : Component
        {
            return new List<T>(GetComponentsInChildren<T>()).Find(x => x.name == name);
        }
    }
}