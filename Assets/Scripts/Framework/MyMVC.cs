using System;
using UnityEngine;

namespace MyMVC
{
    public abstract class MyModel
    {
    
    }
    
    public abstract class MyView : MonoBehaviour        
    {
    
    }
    
    public abstract class MyController : MonoBehaviour      // 要通用的话，可以做一个框架，统一管理所有m v c
    {
    
    }
    
    // 数据驱动实现
    public class BindData<T>
    {
        public BindData(T defaultValue = default)
        {
            mvalue = defaultValue;
        }

        private T mvalue;

        public T Value
        {
            get { return mvalue; }
            set
            {
                if (value == null && mvalue == null) return;
                if (value != null && value.Equals(mvalue)) return;

                SetValue(value);    
                mOnValueChanged?.Invoke(value);     // 当数据变化时调用注册的回调事件
            }
        }

        public void SetValue(T newValue)
        {
            mvalue = newValue;
        }

        private Action<T> mOnValueChanged = (v) => { };

        public void Register(Action<T> onValueChanged)
        {
            mOnValueChanged += onValueChanged;
        }

        public void UnRegister(Action<T> onValueChanged)
        {
            mOnValueChanged -= onValueChanged;
        }
    }
}