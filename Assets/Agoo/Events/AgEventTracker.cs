using System;
using System.Collections.Generic;

namespace Agoo.Events
{
    public class AgEventTracker
    {
        private readonly List<Action> _removeListenerCallBacks = new();

        public void Track(Action removeCall)
        {
            _removeListenerCallBacks.Add(removeCall);
        }

        public void RemoveAllListeners()
        {
            foreach (var call in _removeListenerCallBacks) {
                call?.SafeInvoke();
            }

            _removeListenerCallBacks.Clear();
        }
    }
}
