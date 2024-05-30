using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace BigOther
{
    namespace Basic
    {
        /// <summary>
        /// 项目类，包含若干特性
        /// <br/>
        /// 继承该类的子类包含的特性可以被识别
        /// </summary>
        public class Item : IBasic
        {
            private Icharacter GetCharacter(string characterName)
            {
                var res = this.GetType().GetField(characterName);
                if (res!=null&&!typeof(Icharacter).IsAssignableFrom(res.FieldType))
                {
                    throw new Exception("you defined same character's name!");
                }
                if(res==null)
                {
                    if (extraCharacter != null && extraCharacter.ContainsKey(characterName))
                    {
                        return extraCharacter[characterName];
                    }
                    else
                    {
                        return null;
                    }
                }
                var ires = (Icharacter)res.GetValue(this);
                ires.SetFather(this);
                return ires;
            }
            private Dictionary<string, Icharacter> extraCharacter;
            /// <summary>
            /// 添加新特性
            /// </summary>
            /// <param name="characterName"></param>
            /// <param name="character"></param>
            public void AddNewCharacter(string characterName,Icharacter character)
            {
                if(this.extraCharacter==null)
                {
                    this.extraCharacter = new Dictionary<string, Icharacter>();
                }
                character.SetFather(this);
                this.extraCharacter[characterName] = character;

            }
            /// <summary>
            /// 根据特性名获取、修改特性的值(不会判断类型，不太安全)
            /// </summary>
            /// <param name="characterName"></param>
            /// <returns>特性值</returns>
            public object this[string characterName]
            {
                get 
                {
                    if(GetCharacter(characterName) == null) return null;
                    return GetCharacter(characterName).UnionValue; 
                }
                set
                {
                    if (GetCharacter(characterName) == null)
                    {
                        throw new Exception("cant find the character!");                
                    }
                    GetCharacter(characterName).UnionValue = value;
                }
            }
            /// <summary>
            /// 通过特性名修改特性值(需标注类型,安全）
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="characterName"></param>
            /// <param name="value"></param>
            public void SetCharacterVal<T>(string characterName,T value)
            {
                GetCharacterObject<T>(characterName).Set(value);
            }
            /// <summary>
            /// 通过特性名获取特性对象(需标注类型,安全）
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="characterName"></param>
            /// <returns></returns>
            public character<T> GetCharacterObject<T>(string characterName)
            {
                if(GetCharacter(characterName).UnionType != typeof(T))
                {
                    Exception e = new Exception("错误类型！");
                }
                return (character<T>)GetCharacter(characterName);
            }
            /// <summary>
            /// 通过特性名获得特性值(需标注类型,安全）
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="characterName"></param>
            /// <returns></returns>
            public T GetCharacterVal<T>(string characterName)
            {   
                return GetCharacterObject<T>(characterName).Get();
            }
            /// <summary>
            /// 获取所有特性的字典
            /// </summary>
            public Dictionary<string,Icharacter> characters
            {
                get
                {
                    var res =new Dictionary<string,Icharacter>();
                    foreach (var info in this.GetType().GetFields())
                    {
                        if (!typeof(Icharacter).IsAssignableFrom(info.FieldType))
                        {
                            continue;
                        }
                        var ich = (Icharacter)info.GetValue(this);
                        ich.SetFather(this);
                        res.Add(info.Name, ich);
                    }
                    if(extraCharacter!=null)
                    {
                        foreach(var item in extraCharacter)
                        {
                            res.Add(item.Key, item.Value);
                        }
                    }
                    return res;     
                }
            }
            /// <summary>
            /// 获取项目池对象
            /// </summary>
            public IBasic father => null;

            /// <summary>
            /// get：如果所有特性均激活，返回真，否则返回假；
            /// set：设置所有特性
            /// </summary>
            public bool enable
            {
                get
                {
                    foreach(var v in characters.Values)
                    {
                        if (!v.enable)
                        {
                            return false;
                        }
                    }
                    return true;
                }
                set
                {
                    foreach(var v in characters.Values)
                    {
                        v.enable= value;
                    }
                }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <returns>csv格式字符串：特性名,特性类型,特性值</returns>
            public override string ToString()
            {
                string res = "";
                foreach(var item in characters)
                {
                    res += item.Key + "," + item.Value.UnionType + "," + item.Value.UnionValue + "\n";
                }
                return res;
            }
        }
    }
    
}
