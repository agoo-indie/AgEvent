using System.Collections.Generic;
using UnityEngine;

namespace Agoo.Events
{
    /// <summary>
    /// 延迟触发事件
    /// 接收一个Event，把Event的触发时机延迟到下一帧
    /// </summary>
    public class DelayInvoke : AgEvent
    {
        #region Updater

        private class Updater : MonoBehaviour
        {
            private readonly HashSet<DelayInvoke> _delayInvokeList = new();

            public void Add(DelayInvoke delayInvoke)
            {
                _delayInvokeList.Add(delayInvoke);
            }

            private void LateUpdate()
            {
                foreach (var delayInvoke in _delayInvokeList) {
                    delayInvoke.Invoke();
                }

                _delayInvokeList.Clear();
            }
        }

        private static Updater s_updater;

        private static Updater GetUpdater()
        {
            if (s_updater == null) {
                var go = new GameObject("DelayInvoke Updater");
                Object.DontDestroyOnLoad(go);

                s_updater = go.AddComponent<Updater>();
            }

            return s_updater;
        }

        #endregion

        private readonly AgEventTracker _eventTracker = new();

        public DelayInvoke(IAgEvent evt)
        {
            evt.AddListener(MarkDirty, _eventTracker);
        }

        ~DelayInvoke()
        {
            _eventTracker.RemoveAllListeners();
            Debug.Log("~AnyInvoke");
        }

        private void MarkDirty()
        {
            GetUpdater().Add(this);
        }
    }
}
