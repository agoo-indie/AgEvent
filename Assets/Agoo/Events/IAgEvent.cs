using System;
using UnityEngine.Events;

namespace Agoo.Events
{
    public interface IAgEvent
    {
        void AddListener(Action call, AgEventTracker tracker = null);
        void RemoveListener(Action call);
        void RemoveAllListeners();
    }
}
