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
        private bool _isDirty;
        private IAgEvent _target;

        #region Updater

        private class Updater : MonoBehaviour
        {
            private readonly List<DelayInvoke> _delayInvokeList = new();

            public void Add(DelayInvoke delayInvoke)
            {
                _delayInvokeList.Add(delayInvoke);
            }

            public void Remove(DelayInvoke delayInvoke)
            {
                _delayInvokeList.Remove(delayInvoke);
            }

            private void Update()
            {
                foreach (var delayInvoke in _delayInvokeList) {
                    if (delayInvoke._isDirty) {
                        delayInvoke.DoInvoke();
                    }
                }
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

        public DelayInvoke(IAgEvent evt)
        {
            _target = evt;
            _target.AddListener(MarkDirty);

            GetUpdater().Add(this);
        }

        public override void RemoveAllListeners()
        {
            _target.RemoveListener(MarkDirty);
            _target = null;

            GetUpdater().Remove(this);

            base.RemoveAllListeners();
        }

        private void MarkDirty()
        {
            _isDirty = true;
        }

        private void DoInvoke()
        {
            _isDirty = false;

            Invoke();
        }
    }
}
