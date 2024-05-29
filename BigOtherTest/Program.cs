using BigOther.Basic;
using System.Numerics;

namespace Test
{
    public class Player : Item
    {
        public string Name="123";
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
       
        static void fun(int o, int n)
        {
            if(o>n)
            {
                Console.WriteLine($"玩家受到了{o-n}点伤害");
            }
            else
            {
                Console.WriteLine($"玩家回复了{n - o}点体力");
            }
            

        }
        public static void Main(string[] args)
        {
            Player player = new Player(10, 100);
            player.HP.RenderEffect += fun;
            
            Console.WriteLine(player["HP"]);
            player["HP"] = 5;
            Console.WriteLine(player["HP"]);
            Console.WriteLine(player.ToString());
        }

       
    }
}

