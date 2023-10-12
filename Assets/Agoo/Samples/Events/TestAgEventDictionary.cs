using Agoo.Events;
using UnityEngine;

namespace Agoo.Samples.Events
{
    public class TestAgEventDictionary : MonoBehaviour
    {
        public readonly AgEventDictionary<int> onDict = new();

        public void Start()
        {
            onDict.AddListener(100, CallbackDict100);
            onDict.AddListener(200, CallbackDict);
            onDict.AddListener(300, CallbackDict);
            onDict.onKeyChanged.AddListener(CallbackDictKeyChanged);

            // 下面的调用打印CallbackDict100和CallbackDictKeyChanged:100
            onDict.Invoke(100);

            // 下面的调用打印CallbackDictKeyChanged:150
            onDict.Invoke(150);

            // 下面的调用打印CallbackDict和CallbackDictKeyChanged:300
            onDict.Invoke(300);
        }

        private void CallbackDict100()
        {
            Debug.Log("CallbackDict100");
        }

        private void CallbackDict()
        {
            Debug.Log("CallbackDict");
        }

        private void CallbackDictKeyChanged(int key)
        {
            Debug.Log($"CallbackDictKeyChanged:{key}");
        }
    }
}