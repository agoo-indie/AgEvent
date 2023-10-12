using Agoo.Events;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Agoo.Samples.Events
{
    public class TestAnyInvoke : MonoBehaviour
    {
        public readonly AgEvent<string> onString = new();
        public readonly AgEvent<int> onInt = new();
        public readonly AgEvent onVoid = new();
        public readonly UnityEvent onUnity = new();
        public readonly Toggle.ToggleEvent onToggleEvent = new();
        public AgEvent onAny { get; private set; }

        public void Start()
        {
            onAny = new AnyInvoke(onString, onInt, onVoid, onUnity.ToAgEvent(), onToggleEvent.ToAgEvent());
            onAny.AddListener(CallbackAny);

            // 下面的调用后，会打印3次CallbackAny
            onString.Invoke("Hello World!");
            onInt.Invoke(99);
            onVoid.Invoke();
            onUnity.Invoke();
            onToggleEvent.Invoke(true);
        }

        // 注意CallbackAny不能接收参数
        private void CallbackAny()
        {
            Debug.Log("CallbackAny");
        }
    }
}