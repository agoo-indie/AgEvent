using Agoo.Events;
using UnityEngine;

namespace Agoo.Samples.Events
{
    public class TestAgEventTracker : MonoBehaviour
    {
        public readonly AgEvent<string> onString = new();
        public readonly AgEvent<int> onInt = new();
        public readonly AgEvent onVoid = new();

        private readonly AgEventTracker _eventTracker = new();

        public void Start()
        {
            onString.AddListener(CallbackVoid, _eventTracker);
            onString.AddListenerOnce(CallbackString, _eventTracker);

            onInt.AddListener(CallbackInt, _eventTracker);
            onInt.AddListenerOnce(CallbackVoid, _eventTracker);

            onVoid.AddListener(CallbackVoid, _eventTracker);
        }

        public void Destroy()
        {
            // 通过ClearAllSubscriptions可以安全地进行反注册
            _eventTracker.RemoveAllListeners();
        }

        private void CallbackVoid()
        {
            Debug.Log("CallbackVoid");
        }

        private void CallbackInt(int i)
        {
            Debug.Log($"CallbackInt({i})");
        }

        private void CallbackString(string s)
        {
            Debug.Log($"CallbackString({s})");
        }
    }
}