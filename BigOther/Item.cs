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
                    res += info.Name+","+info.GetValue(this)+"\n";
                }
                return res;
            }
        }
    }
    
}
