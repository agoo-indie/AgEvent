using System;
using System.Collections.Generic;

namespace Agoo.Events
{
    /// <summary>
    /// 无参数事件字典
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public class AgEventDictionary<TKey> : AgEventDictionaryBase<TKey>
    {
        public void Invoke(TKey key)
        {
            InvokeImpl(key);
        }
    }

    /// <summary>
    /// 事件字典
    /// </summary>
    public class AgEventDictionary<TKey, T1> : AgEventDictionaryBase<TKey>
    {
        private readonly Dictionary<TKey, AgEvent<T1>> _keysT = new();

        private AgEvent<T1> GetEventTByKey(TKey key, bool createWhenNotExist = true)
        {
            if (!_keysT.TryGetValue(key, out var keyEvent)) {
                if (createWhenNotExist) {
                    keyEvent = new();
                    _keysT.Add(key, keyEvent);
                }
            }

            return keyEvent;
        }

        public void AddListener(TKey key, Action<T1> call, AgEventTracker tracker = null)
        {
            GetEventTByKey(key)?.AddListener(call, tracker);
        }

        public void AddListenerOnce(TKey key, Action<T1> call, AgEventTracker tracker = null)
        {
            GetEventTByKey(key)?.AddListenerOnce(call, tracker);
        }

        public void RemoveListener(TKey key, Action<T1> call)
        {
            GetEventTByKey(key, false)?.RemoveListener(call);
        }

        public override void RemoveAllListeners()
        {
            base.RemoveAllListeners();

            foreach (var k in _keysT) {
                k.Value?.RemoveAllListeners();
            }

            _keysT.Clear();
        }

        public void Invoke(TKey key, T1 arg1)
        {
            InvokeImpl(key);

            if (_keysT.TryGetValue(key, out var keyEvent)) {
                keyEvent.Invoke(arg1);
            }
        }
    }

    /// <summary>
    /// 事件字典
    /// </summary>
    public class AgEventDictionary<TKey, T1, T2> : AgEventDictionaryBase<TKey>
    {
        private readonly Dictionary<TKey, AgEvent<T1, T2>> _keysT = new();

        private AgEvent<T1, T2> GetEventTByKey(TKey key, bool createWhenNotExist = true)
        {
            if (!_keysT.TryGetValue(key, out var keyEvent)) {
                if (createWhenNotExist) {
                    keyEvent = new();
                    _keysT.Add(key, keyEvent);
                }
            }

            return keyEvent;
        }

        public void AddListener(TKey key, Action<T1, T2> call, AgEventTracker tracker = null)
        {
            GetEventTByKey(key)?.AddListener(call, tracker);
        }

        public void AddListenerOnce(TKey key, Action<T1, T2> call, AgEventTracker tracker = null)
        {
            GetEventTByKey(key)?.AddListenerOnce(call, tracker);
        }

        public void RemoveListener(TKey key, Action<T1, T2> call)
        {
            GetEventTByKey(key, false)?.RemoveListener(call);
        }

        public override void RemoveAllListeners()
        {
            base.RemoveAllListeners();

            foreach (var k in _keysT) {
                k.Value?.RemoveAllListeners();
            }

            _keysT.Clear();
        }

        public void Invoke(TKey key, T1 arg1, T2 arg2)
        {
            InvokeImpl(key);

            if (_keysT.TryGetValue(key, out var keyEvent)) {
                keyEvent.Invoke(arg1, arg2);
            }
        }
    }

    /// <summary>
    /// 事件字典
    /// </summary>
    public class AgEventDictionary<TKey, T1, T2, T3> : AgEventDictionaryBase<TKey>
    {
        private readonly Dictionary<TKey, AgEvent<T1, T2, T3>> _keysT = new();

        private AgEvent<T1, T2, T3> GetEventTByKey(TKey key, bool createWhenNotExist = true)
        {
            if (!_keysT.TryGetValue(key, out var keyEvent)) {
                if (createWhenNotExist) {
                    keyEvent = new();
                    _keysT.Add(key, keyEvent);
                }
            }

            return keyEvent;
        }

        public void AddListener(TKey key, Action<T1, T2, T3> call, AgEventTracker tracker = null)
        {
            GetEventTByKey(key)?.AddListener(call, tracker);
        }

        public void AddListenerOnce(TKey key, Action<T1, T2, T3> call, AgEventTracker tracker = null)
        {
            GetEventTByKey(key)?.AddListenerOnce(call, tracker);
        }

        public void RemoveListener(TKey key, Action<T1, T2, T3> call)
        {
            GetEventTByKey(key, false)?.RemoveListener(call);
        }

        public override void RemoveAllListeners()
        {
            base.RemoveAllListeners();

            foreach (var k in _keysT) {
                k.Value?.RemoveAllListeners();
            }

            _keysT.Clear();
        }

        public void Invoke(TKey key, T1 arg1, T2 arg2, T3 arg3)
        {
            InvokeImpl(key);

            if (_keysT.TryGetValue(key, out var keyEvent)) {
                keyEvent.Invoke(arg1, arg2, arg3);
            }
        }
    }
}
