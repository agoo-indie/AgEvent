using System.Collections.Generic;

namespace Agoo.Events
{
    /// <summary>
    /// 任意触发
    /// 接收多个AgEvent，当其中任意一个事件被触发时，触发自己
    /// </summary>
    public class AnyInvoke : AgEvent
    {
        private IEnumerable<IAgEvent> _events;

        public AnyInvoke(params IAgEvent[] events)
        {
            SetSubEvents(events);
        }

        public AnyInvoke(IEnumerable<IAgEvent> events)
        {
            SetSubEvents(events);
        }

        private void SetSubEvents(IEnumerable<IAgEvent> events)
        {
            _events = events;

            if (_events != null) {
                foreach (var evt in _events) {
                    evt?.AddListener(Invoke);
                }
            }
        }

        public override void RemoveAllListeners()
        {
            if (_events != null) {
                foreach (var evt in _events) {
                    evt?.RemoveListener(Invoke);
                }

                _events = null;
            }

            base.RemoveAllListeners();
        }
    }
}
