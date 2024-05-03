using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDungeon
{
    public class Skills
    {








        static public void Namjak(Player player)
        {




            if (true) // 20% + cooltime 적용 
            {
                player.stat.AttackInc -= 5;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\"바론\" 이 플레이어를 응시합니다!");
                Console.WriteLine($"{player.Name} 에게 이번 전투동안 강력한 디버프가 적용됩니다.");
                Console.WriteLine($"{player.Name} 의 공격력 {player.stat.Attack + 5} -> {player.stat.Attack}");
            }
            

        }

    }
}