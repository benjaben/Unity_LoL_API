using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

namespace LoLAPI
{
    public class LoLAPI_Demo : MonoBehaviour
    {
        private Button FetchInfoButton;
        private TMP_InputField SummonerNameInputField;
        private TextMeshProUGUI SummonerNameText;
        private LoLAPI_WebRequest m_APIRequester;

        private void Awake()
        {
            m_APIRequester = new LoLAPI_WebRequest();
            FetchInfoButton = GetChildComponent<Button>("Button_FetchInfo");
            SummonerNameInputField = GetChildComponent<TMP_InputField>("InputField_SummonerName");
            SummonerNameText = GetChildComponent<TextMeshProUGUI>("Text_SummonerName");
        }

        private void Start()
        {
            FetchInfoButton.onClick.AddListener(Button_FetchInfo);
        }

        private void Button_FetchInfo()
        {
            m_APIRequester.GetSummonerDTO(SummonerNameInputField.text, (data) => 
            {
                SummonerNameText.text = data.name;
            });
        }

        private T GetChildComponent<T>(string name) where T : Component
        {
            return new List<T>(GetComponentsInChildren<T>()).Find(x => x.name == name);
        }
    }
}