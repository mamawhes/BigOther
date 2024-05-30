using BigOther.Basic;
using System.Numerics;

namespace Test
{
    public class Player : Item
    {
        public character<int> HP;
        public character<int> HPMax;
        public Player(int hp,int hpMax)
        {
            HP=new(hp);
            HPMax=new(hpMax);
        }
    }
    public class Test
    {
       
        static void fun(IBasic father, int o, int n)
        {
            Player player = (Player)father;
            if (o>n)
            {
                Console.WriteLine($"玩家{player["Name"]}受到了{o-n}点伤害");
            }
            else
            {
                Console.WriteLine($"玩家{player["Name"]}回复了{n - o}点体力");
            }
            

        }
        public static void Main(string[] args)
        {
            Player player = new Player(10, 100);
            player.HP.RenderEffect += fun;
            player.AddNewCharacter("Name", new character<string>("mamawhes"));
            Console.WriteLine(player["HP"]);
            player["HP"] = 5;
            
            Console.WriteLine(player["HP"]);
            foreach(var c in player.characters.Values)
            {
                Console.WriteLine(((IBasic)c).father.GetType());
            }
            Console.WriteLine(player);
            
        }

       
    }
}

