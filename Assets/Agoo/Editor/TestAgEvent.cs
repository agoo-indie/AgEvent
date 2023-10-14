using Agoo.Events;
using NUnit.Framework;

namespace Agoo
{
    public class TestAgEvent
    {
        private readonly AgEvent<string> _stringEvent = new();
        private bool _callbackVoid;
        private string _callbackString;

        [Test]
        public void Entry()
        {
            _stringEvent.AddListener(CallbackVoid);
            _stringEvent.AddListener(CallbackString);

            _stringEvent.Invoke("Hello World!");

            Assert.IsTrue(_callbackVoid);
            Assert.IsTrue(_callbackString == "Hello World!");

            _stringEvent.RemoveListener(CallbackVoid);
            _stringEvent.RemoveListener(CallbackString);

            _callbackVoid = false;
            _callbackString = null;

            _stringEvent.Invoke("Hello World!");

            Assert.IsFalse(_callbackVoid);
            Assert.IsTrue(_callbackString == null);
        }

        private void CallbackVoid()
        {
            _callbackVoid = true;
        }

        private void CallbackString(string s)
        {
            _callbackString = s;
        }
    }
}
