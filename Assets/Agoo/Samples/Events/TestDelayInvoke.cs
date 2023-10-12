using Agoo.Events;
using UnityEngine;

namespace Agoo.Samples.Events
{
    public class TestDelayInvoke : MonoBehaviour
    {
        public readonly AgEvent<string> onString = new();
        public readonly AgEvent<int> onInt = new();
        public readonly AgEvent onVoid = new();
        public AgEvent onDelay { get; private set; }

        public void Start()
        {
            onDelay = new DelayInvoke(new AnyInvoke(onString, onInt, onVoid));
            onDelay.AddListener(CallbackDelay);

            Debug.Log($"Begin Delay Invoke At {Time.frameCount}");

            // 下面的调用后，会在下一帧打印1次CallbackDelay
            onString.Invoke("Hello World!");
            onInt.Invoke(99);
            onVoid.Invoke();
        }

        // 注意CallbackDelay不能接收参数
        private void CallbackDelay()
        {
            Debug.Log($"CallbackDelay At {Time.frameCount}");
        }
    }
}