using System;
using System.Collections.Generic;
using System.Linq;

namespace Agoo.Events
{
    public class AgEventDictionaryBase<TKey>
    {
        public readonly AgEvent<TKey> onKeyChanged = new();

        private readonly Dictionary<TKey, AgEvent> _keys = new();

        private AgEvent GetEventByKey(TKey key, bool createWhenNotExist = true)
        {
            if (!_keys.TryGetValue(key, out var keyEvent)) {
                if (createWhenNotExist) {
                    keyEvent = new AgEvent();
                    _keys.Add(key, keyEvent);
                }
            }

            return keyEvent;
        }

        public void AddListener(TKey key, Action call, AgEventTracker tracker = null)
        {
            GetEventByKey(key)?.AddListener(call, tracker);
        }

        public void AddListenerOnce(TKey key, Action call, AgEventTracker tracker = null)
        {
            GetEventByKey(key)?.AddListenerOnce(call, tracker);
        }

        public void RemoveListener(TKey key, Action call)
        {
            GetEventByKey(key, false)?.RemoveListener(call);
        }

        public virtual void RemoveAllListeners()
        {
            onKeyChanged.RemoveAllListeners();

            foreach (var k in _keys) {
                k.Value?.RemoveAllListeners();
            }

            _keys.Clear();
        }

        public AgEvent AnyKeyChanged(params TKey[] keys)
        {
            return new AnyInvoke(keys.Select(k => GetEventByKey(k)));
        }

        public AgEvent AnyKeyChanged(IEnumerable<TKey> keys)
        {
            return new AnyInvoke(keys.Select(k => GetEventByKey(k)));
        }

        protected void InvokeImpl(TKey key)
        {
            onKeyChanged?.Invoke(key);

            if (_keys.TryGetValue(key, out var keyEvent)) {
                keyEvent.Invoke();
            }
        }
    }
}