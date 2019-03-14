using UnityEngine;
using System.Collections;

namespace LoLAPI
{
    public class LoLAPI_Routines : MonoBehaviour
    {
        public static LoLAPI_Routines Singleton { get; private set; }

        private void Awake()
        {
            Singleton = this;
        }

        public void RunCoroutine(IEnumerator routine)
        {
            StartCoroutine(routine);
        }
    }
}