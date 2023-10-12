using System;

namespace Agoo.Events
{
    public class AgEventBase : IAgEvent
    {
        private event Action onAction;

        ~AgEventBase()
        {
            RemoveAllListeners();
        }

        public void AddListener(Action call, AgEventTracker tracker = null)
        {
            onAction += call;

            tracker?.Track(() => onAction -= call);
        }

        public void AddListenerOnce(Action call, AgEventTracker tracker = null)
        {
            void oneShotCallBack()
            {
                onAction -= oneShotCallBack;
                call?.SafeInvoke();
            }

            onAction += oneShotCallBack;

            tracker?.Track(() => onAction -= oneShotCallBack);
        }

        public void RemoveListener(Action call)
        {
            onAction -= call;
        }

        public virtual void RemoveAllListeners()
        {
            onAction = null;
        }

        protected void InvokeImpl()
        {
            onAction?.SafeInvoke();
        }
    }
}