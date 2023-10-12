using System;
using Agoo.Events;
using UnityEngine;

namespace Agoo.Samples.Events
{
    public class TestAgEventOneShot : MonoBehaviour
    {
        public readonly AgEvent<string> onStringEvent = new();

        public void Start()
        {
            onStringEvent.AddListenerOnce(CallbackString);

            // 下面的调用会打印
            // CallbackString(Hello World!)
            onStringEvent.Invoke("Hello World!");

            // 下面的调用不会打印任何东西
            onStringEvent.Invoke("Hello World 2!");

            // 注意就算onString内部已经反注册了这个监听，但你重复反注册是不会报错的，可以放心调用
            onStringEvent.RemoveListener(CallbackString);
        }

        private void CallbackString(string s)
        {
            Debug.Log($"CallbackString({s})");
        }
    }
}