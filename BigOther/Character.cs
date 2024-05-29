using System;
using System.Runtime.CompilerServices;

namespace BigOther
{
   
    namespace Basic
    {
        /// <summary>
        /// delegate void SetEventHandler(T oldValue, T newValue)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class character<T>
        {
            private T value;
            public delegate void SetEventHandler(T oldValue, T newValue);
            public event SetEventHandler DataEffect;
            public event SetEventHandler RenderEffect;
            public character(T value)
            {
                this.value = value;
            }
            public void Set(T value)
            {
                DataEffect?.Invoke(this.value,value);
                RenderEffect?.Invoke(this.value, value);
                this.value = value;

            }

            //public static implicit operator character<T>(T val)
            //{
            //    var res = new character<T>();
            //    res.Set(val);
            //    return res;
            //}
            public T Get()
            {
                return value;
            }
            public override string ToString()
            {
                return value.ToString();
            }
        }
    }
   
}
