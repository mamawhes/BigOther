using System;
using System.Runtime.CompilerServices;

namespace BigOther
{
   
    namespace Basic
    {
        /// <summary>
        /// 特性的接口，统一泛型对象
        /// </summary>
        public interface Icharacter
        {
            /// <summary>
            /// 特性值属性
            /// </summary>
            object UnionValue { get; set; }
            /// <summary>
            /// 特性值类型
            /// </summary>
            Type UnionType { get; }
            /// <summary>
            /// 设置所属项目
            /// </summary>
            /// <param name="father"></param>
            void SetFather(IBasic father);
            /// <summary>
            /// 使能
            /// </summary>
            bool enable { get; set; }
        }
        /// <summary>
        /// 特性泛型类
        /// <br/>
        /// 可以为修改值绑定事件
        /// </summary>
        /// <typeparam name="T">指定的任意数据类型</typeparam>
        public class character<T>:Icharacter, IBasic
        {
            private T value;
            internal IBasic _father=null;
            /// <summary>
            /// 修改值事件的委托
            /// </summary>
            /// <param name="father">获取此特性的项目对象</param>
            /// <param name="oldValue">修改之前的值</param>
            /// <param name="newValue">修改之后的值</param>
            public delegate void SetEventHandler(IBasic father, T oldValue, T newValue);
            /// <summary>
            /// 先执行的事件，影响数据的绑定这个
            /// </summary>
            public event SetEventHandler DataEffect;
            /// <summary>
            /// 后执行的事件，渲染绑定这个
            /// </summary>
            public event SetEventHandler RenderEffect;

            private bool _enable=true;
            /// <summary>
            /// 使能开关，关闭后修改值无效
            /// </summary>
            public bool enable { get => _enable; set => _enable = value; }
            /// <summary>
            /// 构造函数
            /// </summary>
            /// <param name="value"></param>
            public character(T value=default)
            {   
                this.value = value;
            }
            /// <summary>
            /// 修改值
            /// </summary>
            /// <param name="value"></param>
            public void Set(T value)
            {
                if(_enable)
                {
                    DataEffect?.Invoke(father, this.value, value);
                    RenderEffect?.Invoke(father, this.value, value);
                    this.value = value;
                }
            }

            //public static implicit operator character<T>(T val)
            //{
            //    var res = new character<T>();
            //    res.Set(val);
            //    return res;
            //}
            /// <summary>
            /// 获取值
            /// </summary>
            /// <returns></returns>
            public T Get()
            {
                return value;
            }
            /// <summary>
            /// 
            /// </summary>
            /// <returns>值的内容</returns>
            public override string ToString()
            {
                return value.ToString();
            }
            /// <inheritdoc/>
            public void SetFather(IBasic father)
            {
                _father = father;
            }
            /// <inheritdoc/>
            public Type UnionType { get { return typeof(T); } }
            /// <inheritdoc/>
            public object UnionValue
            {
                get
                {
                    return (object)this.Get();
                }
                set
                {
                    this.Set((T)value);
                }
            }
            /// <inheritdoc/>
            public IBasic father => _father;

            
        }
    }
   
}
