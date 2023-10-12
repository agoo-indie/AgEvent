using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Agoo.Events
{
    public static class UnityEventExtension
    {
        #region AddListener

        public static void AddListener(this UnityEvent evt, UnityAction call, AgEventTracker tracker = null)
        {
            evt.AddListener(call);

            tracker?.Track(() => evt.RemoveListener(call));
        }

        public static void AddListener(this Toggle.ToggleEvent evt, UnityAction<bool> call, AgEventTracker tracker = null)
        {
            evt.AddListener(call);

            tracker?.Track(() => evt.RemoveListener(call));
        }

        public static void AddListener(this EventTrigger.TriggerEvent evt, UnityAction<BaseEventData> call, AgEventTracker tracker = null)
        {
            evt.AddListener(call);

            tracker?.Track(() => evt.RemoveListener(call));
        }

        public static void AddListener(this TMP_Dropdown.DropdownEvent evt, UnityAction<int> call, AgEventTracker tracker = null)
        {
            evt.AddListener(call);

            tracker?.Track(() => evt.RemoveListener(call));
        }

        public static void AddListener(this TMP_InputField.OnChangeEvent evt, UnityAction<string> call, AgEventTracker tracker = null)
        {
            evt.AddListener(call);

            tracker?.Track(() => evt.RemoveListener(call));
        }

        public static void AddListener<T>(this UnityEvent<T> evt, UnityAction<T> call, AgEventTracker tracker = null)
        {
            evt.AddListener(call);

            tracker?.Track(() => evt.RemoveListener(call));
        }

        public static void AddListener<T1, T2>(this UnityEvent<T1, T2> evt, UnityAction<T1, T2> call, AgEventTracker tracker = null)
        {
            evt.AddListener(call);

            tracker?.Track(() => evt.RemoveListener(call));
        }

        public static void AddListener<T1, T2, T3>(this UnityEvent<T1, T2, T3> evt, UnityAction<T1, T2, T3> call, AgEventTracker tracker = null)
        {
            evt.AddListener(call);

            tracker?.Track(() => evt.RemoveListener(call));
        }

        public static void AddListener<T1, T2, T3, T4>(this UnityEvent<T1, T2, T3, T4> evt, UnityAction<T1, T2, T3, T4> call, AgEventTracker tracker = null)
        {
            evt.AddListener(call);

            tracker?.Track(() => evt.RemoveListener(call));
        }

        #endregion

        #region As AgEvent

        public static IAgEvent ToAgEvent(this UnityEvent unityEvent)
        {
            return new AgUnityEvent(unityEvent);
        }

        public static IAgEvent ToAgEvent<T1>(this UnityEvent<T1> unityEvent)
        {
            return new AgUnityEvent<T1>(unityEvent);
        }

        #endregion
    }
}
