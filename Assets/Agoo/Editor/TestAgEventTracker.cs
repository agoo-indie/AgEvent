using Agoo.Events;
using NUnit.Framework;

namespace Agoo
{
    public class TestAgEventTracker
    {
        private readonly AgEvent<string> _stringEvent = new();
        private readonly AgEvent<int> _intEvent = new();
        private readonly AgEvent _voidEvent = new();
        private readonly AgEventTracker _eventTracker = new();

        private int _callbackVoidNum;
        private int _callbackIntNum;
        private int _callbackStringNum;

        [Test]
        public void Entry()
        {
            _stringEvent.AddListener(CallbackVoid, _eventTracker);
            _stringEvent.AddListenerOnce(CallbackString, _eventTracker);

            _intEvent.AddListener(CallbackInt, _eventTracker);
            _intEvent.AddListenerOnce(CallbackVoid, _eventTracker);

            _voidEvent.AddListener(CallbackVoid, _eventTracker);

            _stringEvent.Invoke("Test");
            _intEvent.Invoke(0);
            _voidEvent.Invoke();

            Assert.IsTrue(_callbackStringNum == 1);
            Assert.IsTrue(_callbackIntNum == 1);
            Assert.IsTrue(_callbackVoidNum == 3);

            _eventTracker.RemoveAllListeners();

            _stringEvent.Invoke("Test");
            _intEvent.Invoke(0);
            _voidEvent.Invoke();

            Assert.IsTrue(_callbackStringNum == 1);
            Assert.IsTrue(_callbackIntNum == 1);
            Assert.IsTrue(_callbackVoidNum == 3);
        }

        private void CallbackVoid()
        {
            ++_callbackVoidNum;
        }

        private void CallbackInt(int i)
        {
            ++_callbackIntNum;
        }

        private void CallbackString(string s)
        {
            ++_callbackStringNum;
        }
    }
}