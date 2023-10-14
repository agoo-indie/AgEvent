using System;
using System.Collections.Generic;
using UnityEngine;

namespace Agoo.Events
{
    /// <summary>
    /// 任意触发
    /// 接收多个AgEvent，当其中任意一个事件被触发时，触发自己
    /// </summary>
    public class AnyInvoke : AgEvent, IDisposable
    {
        private IEnumerable<IAgEvent> _events;
        private readonly AgEventTracker _eventTracker = new();

        public AnyInvoke(params IAgEvent[] events)
        {
            AddListeners(events);
        }

        public AnyInvoke(IEnumerable<IAgEvent> events)
        {
            AddListeners(events);
        }

        private void AddListeners(IEnumerable<IAgEvent> events)
        {
            _events = events;

            if (_events != null) {
                foreach (var evt in _events) {
                    evt?.AddListener(Invoke, _eventTracker);
                }
            }
        }

        public void Dispose()
        {
            _eventTracker.RemoveAllListeners();
            GC.SuppressFinalize(this);
        }
    }
}
