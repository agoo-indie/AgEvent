using System;

namespace Agoo.Events
{
    /// <summary>
    /// 无参数事件
    /// </summary>
    public class AgEvent : AgEventBase
    {
        public void Invoke()
        {
            InvokeImpl();
        }
    }

    public class AgEvent<T1> : AgEventBase
    {
        private event Action<T1> onActionT;

        public void AddListener(Action<T1> call, AgEventTracker tracker = null)
        {
            onActionT += call;

            tracker?.Track(() => onActionT -= call);
        }

        public void AddListenerOnce(Action<T1> call, AgEventTracker tracker = null)
        {
            void oneShotCallBack(T1 arg1)
            {
                onActionT -= oneShotCallBack;
                call?.SafeInvoke(arg1);
            }

            onActionT += oneShotCallBack;

            tracker?.Track(() => onActionT -= oneShotCallBack);
        }

        public void RemoveListener(Action<T1> call)
        {
            onActionT -= call;
        }

        public override void RemoveAllListeners()
        {
            base.RemoveAllListeners();

            onActionT = null;
        }

        public void Invoke(T1 arg)
        {
            onActionT?.SafeInvoke(arg);

            InvokeImpl();
        }
    }

    public class AgEvent<T1, T2> : AgEventBase
    {
        private event Action<T1, T2> onActionT;

        public void AddListener(Action<T1, T2> call, AgEventTracker tracker = null)
        {
            onActionT += call;

            tracker?.Track(() => onActionT -= call);
        }

        public void AddListenerOnce(Action<T1, T2> call, AgEventTracker tracker = null)
        {
            void oneShotCallBack(T1 arg1, T2 arg2)
            {
                onActionT -= oneShotCallBack;
                call?.SafeInvoke(arg1, arg2);
            }

            onActionT += oneShotCallBack;

            tracker?.Track(() => onActionT -= oneShotCallBack);
        }

        public void RemoveListener(Action<T1, T2> call)
        {
            onActionT -= call;
        }

        public override void RemoveAllListeners()
        {
            base.RemoveAllListeners();

            onActionT = null;
        }

        public void Invoke(T1 arg1, T2 arg2)
        {
            onActionT?.SafeInvoke(arg1, arg2);

            InvokeImpl();
        }
    }

    public class AgEvent<T1, T2, T3> : AgEventBase
    {
        private event Action<T1, T2, T3> onActionT;

        public void AddListener(Action<T1, T2, T3> call, AgEventTracker tracker = null)
        {
            onActionT += call;

            tracker?.Track(() => onActionT -= call);
        }

        public void AddListenerOnce(Action<T1, T2, T3> call, AgEventTracker tracker = null)
        {
            void oneShotCallBack(T1 arg1, T2 arg2, T3 arg3)
            {
                onActionT -= oneShotCallBack;
                call?.SafeInvoke(arg1, arg2, arg3);
            }

            onActionT += oneShotCallBack;

            tracker?.Track(() => onActionT -= oneShotCallBack);
        }

        public void RemoveListener(Action<T1, T2, T3> call)
        {
            onActionT -= call;
        }

        public override void RemoveAllListeners()
        {
            base.RemoveAllListeners();

            onActionT = null;
        }

        public void Invoke(T1 arg1, T2 arg2, T3 arg3)
        {
            onActionT?.SafeInvoke(arg1, arg2, arg3);

            InvokeImpl();
        }
    }

    public class AgEvent<T1, T2, T3, T4> : AgEventBase
    {
        private event Action<T1, T2, T3, T4> onActionT;

        public void AddListener(Action<T1, T2, T3, T4> call, AgEventTracker tracker = null)
        {
            onActionT += call;

            tracker?.Track(() => onActionT -= call);
        }

        public void AddListenerOnce(Action<T1, T2, T3, T4> call, AgEventTracker tracker = null)
        {
            void oneShotCallBack(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
            {
                onActionT -= oneShotCallBack;
                call?.SafeInvoke(arg1, arg2, arg3, arg4);
            }

            onActionT += oneShotCallBack;

            tracker?.Track(() => onActionT -= oneShotCallBack);
        }

        public void RemoveListener(Action<T1, T2, T3, T4> call)
        {
            onActionT -= call;
        }

        public override void RemoveAllListeners()
        {
            base.RemoveAllListeners();

            onActionT = null;
        }

        public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            onActionT?.SafeInvoke(arg1, arg2, arg3, arg4);

            InvokeImpl();
        }
    }
}
