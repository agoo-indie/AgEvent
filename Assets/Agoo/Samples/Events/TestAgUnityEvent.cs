using Agoo.Events;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Agoo.Samples.Events
{
    public class TestAgUnityEvent : MonoBehaviour
    {
        public readonly UnityEvent onUnity = new();
        public readonly Toggle.ToggleEvent onToggleEvent = new();
        public AgEvent onAny { get; private set; }
        public AgEvent onDelay { get; private set; }

        public void Start()
        {
            // var agEvent = onUnity.ToAgEvent();
            // agEvent.AddListener(CallbackAny);
            //
            // onUnity.Invoke();
            //
            // agEvent.RemoveListener(CallbackAny);
            //
            // onUnity.Invoke();
            //
            // return;

            onAny = new AnyInvoke(onUnity.ToAgEvent(), onToggleEvent.ToAgEvent());
            onAny.AddListener(CallbackAny);

            // 下面的调用后，会打印3次CallbackAny
            onUnity.Invoke();
            onToggleEvent.Invoke(true);

            onAny.RemoveAllListeners();

            onUnity.Invoke();
            onToggleEvent.Invoke(true);

            // onDelay = new DelayInvoke(onUnity.ToAgEvent());
            // onDelay.AddListener(CallbackDelay);
            //
            // onUnity.Invoke();
        }

        // 注意CallbackAny不能接收参数
        private void CallbackAny()
        {
            Debug.Log("CallbackAny");
        }

        private void CallbackDelay()
        {
            Debug.Log("CallbackDelay");
        }
    }
}