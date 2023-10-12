using Agoo.Events;
using UnityEngine;

namespace Agoo.Samples.Events
{
    public class TestAgEvent : MonoBehaviour
    {
        public readonly AgEvent<string> onStringEvent = new();

        private void Start()
        {
            onStringEvent.AddListener(CallbackVoid);
            onStringEvent.AddListener(CallbackString);

            // 下面的调用会打印
            // CallbackVoid
            // CallbackString(Hello World!)
            onStringEvent.Invoke("Hello World!");

            onStringEvent.RemoveListener(CallbackVoid);
            onStringEvent.RemoveListener(CallbackString);
        }

        private void CallbackVoid()
        {
            Debug.Log("CallbackVoid");
        }

        private void CallbackString(string s)
        {
            Debug.Log($"CallbackString({s})");
        }
    }
}