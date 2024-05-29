using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace BigOther
{
    namespace Basic
    {
        public class Item
        {
            public object this[string characterName]
            {
                get 
                {
                    var c = (Icharacter)this.GetType().GetField(characterName).GetValue(this);
                    return c.GetUnion(); 
                }
                set
                {
                    var c = (Icharacter)this.GetType().GetField(characterName).GetValue(this);
                    c.SetUnion(value);
                }
            }
            public void SetCharacterVal<T>(string characterName,T value)
            {
                GetCharacterObject<T>(characterName).Set(value);
            }
            public character<T> GetCharacterObject<T>(string characterName)
            {
                return (character<T>)(this.GetType().GetField(characterName).GetValue(this));
            }
            public T GetCharacterVal<T>(string characterName)
            {   
                return GetCharacterObject<T>(characterName).Get();
            }
            public override string ToString()
            {
                string res = "";
                foreach (var info in this.GetType().GetFields())
                {
                    if (!typeof(Icharacter).IsAssignableFrom(info.FieldType))
                    {
                        continue;
                    }
                    res += info.Name+","+ ((Icharacter)info.GetValue(this)).Type+","+ info.GetValue(this) + "\n";
                }
                return res;
            }
        }
    }
    
}
