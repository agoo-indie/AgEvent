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
            _unityEvent?.AddListener(call.Invoke, tracker);
        }

        public void RemoveListener(Action call)
        {
            throw new NotImplementedException("Not support! Use AgEventTracker instead.");
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
            _unityEvent?.AddListener(_ => call.Invoke(), tracker);
        }

        public void RemoveListener(Action call)
        {
            throw new NotImplementedException("Not support! Use AgEventTracker instead.");
        }

        public void RemoveAllListeners()
        {
            _unityEvent?.RemoveAllListeners();
        }
    }
}