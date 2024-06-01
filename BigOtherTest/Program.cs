//using BigOther.Basic;
using System.Numerics;
using BigOther.Basic_R;
namespace Test
{
    //public class Player : Item
    //{
    //    public Character<int> HP;
    //    public Character<int> HPMax;
    //    public Player(int hp,int hpMax)
    //    {
    //        HP=new(hp);
    //        HPMax=new(hpMax);
    //    }
    //}
    public class Test
    {

        static void fun(Pool father, int o, int n)
        {
        
            if (o > n)
            {
                Console.WriteLine($"玩家受到了{o - n}点伤害");
            }
            else
            {
                Console.WriteLine($"玩家回复了{n - o}点体力");
            }


        }
        public static void Main(string[] args)
        {
            Character<int> hp = new Character<int>(100);
            hp.ValueSeted += fun;
            hp.Set(10);
            //Item item = new();//新建项目
            //item["name"] = "mamawhes";//项目新增name特性，赋值为"mamawhes"
            //item["hp"] = 100;//项目新增hp特性，赋值为"100"
            //item["hp_max"] = 100;//项目新增hp_max特性，赋值为"100"
            //item.GetCharacterObject<int>("hp").DataEffect += fun;//为hp绑定事件
            //item["hp"] = 50;//设置hp的值为50
            //Console.WriteLine(item);//打印项目









           // Player player = new Player(10, 100);
           // player.HP.RenderEffect += fun;
           ////player.AddNewCharacter("Name", new character<string>("mamawhes"));
           // player["Name"] = "mamawhes";
           // Console.WriteLine(player["HP"]);
           // player["HP"] = 5;
            
           // Console.WriteLine(player["HP"]);
           // foreach(var c in player.characters.Values)
           // {
           //     Console.WriteLine(((IBasic)c).father.GetType());
           // }
           // Console.WriteLine(player);
            
        }

        private static void Hp_ValueSeted(Pool father, int oldValue, int newValue)
        {
            throw new NotImplementedException();
        }
    }
}

