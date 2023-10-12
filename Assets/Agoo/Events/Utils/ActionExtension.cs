using System;
using UnityEngine;

namespace Agoo.Events
{
    public static class ActionExtension
    {
        public static void SafeInvoke(this Action action)
        {
            try {
                action?.Invoke();
            }
            catch (Exception ex) {
                Debug.LogException(ex);
            }
        }

        public static void SafeInvoke<T1>(this Action<T1> action, T1 arg1)
        {
            try {
                action?.Invoke(arg1);
            }
            catch (Exception ex) {
                Debug.LogException(ex);
            }
        }

        public static void SafeInvoke<T1, T2>(this Action<T1, T2> action, T1 arg1, T2 arg2)
        {
            try {
                action?.Invoke(arg1, arg2);
            }
            catch (Exception ex) {
                Debug.LogException(ex);
            }
        }

        public static void SafeInvoke<T1, T2, T3>(this Action<T1, T2, T3> action, T1 arg1, T2 arg2, T3 arg3)
        {
            try {
                action?.Invoke(arg1, arg2, arg3);
            }
            catch (Exception ex) {
                Debug.LogException(ex);
            }
        }

        public static void SafeInvoke<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            try {
                action?.Invoke(arg1, arg2, arg3, arg4);
            }
            catch (Exception ex) {
                Debug.LogException(ex);
            }
        }

        public static TResult SafeInvoke<TResult>(this Func<TResult> func)
        {
            try {
                if (func != null) {
                    return func.Invoke();
                }

                return default;
            }
            catch (Exception ex) {
                Debug.LogException(ex);
                return default;
            }
        }

        public static TResult SafeInvoke<T1, TResult>(this Func<T1, TResult> func, T1 arg1)
        {
            try {
                if (func != null) {
                    return func.Invoke(arg1);
                }

                return default;
            }
            catch (Exception ex) {
                Debug.LogException(ex);
                return default;
            }
        }

        public static TResult SafeInvoke<T1, T2, TResult>(this Func<T1, T2, TResult> func, T1 arg1, T2 arg2)
        {
            try {
                if (func != null) {
                    return func.Invoke(arg1, arg2);
                }

                return default;
            }
            catch (Exception ex) {
                Debug.LogException(ex);
                return default;
            }
        }

        public static TResult SafeInvoke<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> func, T1 arg1, T2 arg2, T3 arg3)
        {
            try {
                if (func != null) {
                    return func.Invoke(arg1, arg2, arg3);
                }

                return default;
            }
            catch (Exception ex) {
                Debug.LogException(ex);
                return default;
            }
        }

        public static TResult SafeInvoke<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            try {
                if (func != null) {
                    return func.Invoke(arg1, arg2, arg3, arg4);
                }

                return default;
            }
            catch (Exception ex) {
                Debug.LogException(ex);
                return default;
            }
        }
    }
}
