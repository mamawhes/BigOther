using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace BigOther
{
    namespace Basic_R
    {
        public interface ICharacter
        {
            string name { get; }
            object value {  get; set; }
            Pool father { get; }
            Type type { get; }

        
        }
        public class Character<T> : ICharacter
        {
            //[private]
            private string _name;
            private T _value;
            private Pool _father;


            public string name { get { return _name; } }
            public object value { get { return Get(); } set { Set((T)value); } }
            public Pool father {get { return _father; } }
            public Type type { get { return typeof(T); } }
            public delegate void EventHandler(Pool father,T oldValue,T newValue);
            public event EventHandler ValueSeted;
            public Character(T value=default,string name="default",Pool father = null)
            {
                this._father = father;
                this._name = name;
                this._value = value;
            }
            public void Set(T value)
            {
                ValueSeted.Invoke(_father,this._value,value);
                this._value=value;
            }
            public T Get()
            {
                return _value;
            }
        }
        public class Pool
        {

        }
    }
}
