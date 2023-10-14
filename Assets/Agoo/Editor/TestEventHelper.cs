namespace Agoo
{
    public class TestEventHelper
    {
        public bool CallbackVoidResult;
        public string CallbackStringResult;

        public void ResetResult()
        {
            CallbackVoidResult = default;
            CallbackStringResult = default;
        }

        public void CallbackVoid()
        {
            CallbackVoidResult = true;
        }

        public void CallbackString(string s)
        {
            CallbackStringResult = s;
        }
    }
}