using System;
using UnityEngine.Events;

namespace Agoo.Events
{
    public class AgUnityEvent : IAgEvent
    {
        private readonly UnityEvent _unityEvent;

        public AgUnityEvent(UnityEvent unityEvent)
        {
            _unityEvent = unityEvent;
        }

        public void AddListener(Action call, AgEventTracker tracker = null)
        {
            var unityAction = (UnityAction)Delegate.CreateDelegate(typeof(UnityAction), call.Target, call.Method);
            _unityEvent?.AddListener(unityAction, tracker);
        }

        public void RemoveListener(Action call)
        {
            var unityAction = (UnityAction)Delegate.CreateDelegate(typeof(UnityAction), call.Target, call.Method);
            _unityEvent?.RemoveListener(unityAction);
        }

        public void RemoveAllListeners()
        {
            _unityEvent?.RemoveAllListeners();
        }
    }

    public class AgUnityEvent<T1> : IAgEvent
    {
        private readonly UnityEvent<T1> _unityEvent;

        public AgUnityEvent(UnityEvent<T1> unityEvent)
        {
            _unityEvent = unityEvent;
        }

        public void AddListener(Action call, AgEventTracker tracker = null)
        {
            var unityAction = (UnityAction<T1>)Delegate.CreateDelegate(typeof(UnityAction<T1>), call.Target, call.Method);
            _unityEvent?.AddListener(unityAction, tracker);
        }

        public void RemoveListener(Action call)
        {
            var unityAction = (UnityAction<T1>)Delegate.CreateDelegate(typeof(UnityAction<T1>), call.Target, call.Method);
            _unityEvent?.RemoveListener(unityAction);
        }

        public void RemoveAllListeners()
        {
            _unityEvent?.RemoveAllListeners();
        }
    }
}