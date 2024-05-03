using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDungeon
{
    public class Skills
    {
        static public void WormPattern(Player player, Monster monster)
        {
            int monsterAct = 0;

            monsterAct = monster.turn % 5;

            switch (monsterAct)
            {
                case 0: // 1턴 디버프 적용
                    player.stat.AttackInc -= 1;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine();
                    Console.WriteLine($"\"바론\" 이 플레이어를 응시합니다!");
                    Console.WriteLine($"{player.Name} 에게 이번 전투동안 강력한 디버프가 적용됩니다.");
                    Console.WriteLine($"{player.Name} 의 공격력 {player.stat.Attack + 1} -> {player.stat.Attack}");
                    break;
                case 1:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\"바론\" 의 2연타 공격!!");
                    monster.HitDamage(player, monster);
                    monster.HitDamage(player, monster);
                    break;
                case 2:
                    Console.WriteLine("\"바론\" 의 2연타 공격!!");
                    monster.HitDamage(player, monster);
                    monster.HitDamage(player, monster);
                    break;
                case 3:
                    player.stat.AttackInc -= 1;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine();
                    Console.WriteLine($"\"바론\" 이 플레이어를 응시합니다!");
                    Console.WriteLine($"{player.Name} 에게 이번 전투동안 강력한 디버프가 적용됩니다.");
                    Console.WriteLine($"{player.Name} 의 공격력 {player.stat.Attack + 1} -> {player.stat.Attack}");
                    break;
                default:
                    Console.WriteLine("\"바론\" 의 2연타 공격!!");
                    monster.HitDamage(player, monster);
                    monster.HitDamage(player, monster);
                    break;


            }
            monster.turn++; // 몬스터 다음패턴
        }
        static public void CannonPattern(Player player, Monster monster)
        {
            int monsterAct = 0;

            monsterAct = monster.turn % 5;

            switch (monsterAct)
            {
                case 0: // 1턴 디버프 적용
                    player.stat.AttackInc -= 1;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine();
                    Console.WriteLine($"\"바론\" 이 플레이어를 응시합니다!");
                    Console.WriteLine($"{player.Name} 에게 이번 전투동안 강력한 디버프가 적용됩니다.");
                    Console.WriteLine($"{player.Name} 의 공격력 {player.stat.Attack + 1} -> {player.stat.Attack}");
                    break;
                case 1:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\"바론\" 의 2연타 공격!!");
                    monster.HitDamage(player, monster);
                    monster.HitDamage(player, monster);
                    break;
                case 2:
                    Console.WriteLine("\"바론\" 의 2연타 공격!!");
                    monster.HitDamage(player, monster);
                    monster.HitDamage(player, monster);
                    break;
                case 3:
                    player.stat.AttackInc -= 1;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine();
                    Console.WriteLine($"\"바론\" 이 플레이어를 응시합니다!");
                    Console.WriteLine($"{player.Name} 에게 이번 전투동안 강력한 디버프가 적용됩니다.");
                    Console.WriteLine($"{player.Name} 의 공격력 {player.stat.Attack + 1} -> {player.stat.Attack}");
                    break;
                default:
                    Console.WriteLine("\"바론\" 의 2연타 공격!!");
                    monster.HitDamage(player, monster);
                    monster.HitDamage(player, monster);
                    break;


            }
            monster.turn++; // 몬스터 다음패턴
        }
        static public void MinionPattern(Player player, Monster monster)
        {
            int monsterAct = 0;

            monsterAct = monster.turn % 5;

            switch (monsterAct)
            {
                case 0: // 1턴 디버프 적용
                    player.stat.AttackInc -= 1;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine();
                    Console.WriteLine($"\"바론\" 이 플레이어를 응시합니다!");
                    Console.WriteLine($"{player.Name} 에게 이번 전투동안 강력한 디버프가 적용됩니다.");
                    Console.WriteLine($"{player.Name} 의 공격력 {player.stat.Attack + 1} -> {player.stat.Attack}");
                    break;
                case 1:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\"바론\" 의 2연타 공격!!");
                    monster.HitDamage(player, monster);
                    monster.HitDamage(player, monster);
                    break;
                case 2:
                    Console.WriteLine("\"바론\" 의 2연타 공격!!");
                    monster.HitDamage(player, monster);
                    monster.HitDamage(player, monster);
                    break;
                case 3:
                    player.stat.AttackInc -= 1;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine();
                    Console.WriteLine($"\"바론\" 이 플레이어를 응시합니다!");
                    Console.WriteLine($"{player.Name} 에게 이번 전투동안 강력한 디버프가 적용됩니다.");
                    Console.WriteLine($"{player.Name} 의 공격력 {player.stat.Attack + 1} -> {player.stat.Attack}");
                    break;
                default:
                    Console.WriteLine("\"바론\" 의 2연타 공격!!");
                    monster.HitDamage(player, monster);
                    monster.HitDamage(player, monster);
                    break;


            }
            monster.turn++; // 몬스터 다음패턴
        }





        static public void BaronPattern(Player player, Monster monster)
        {
            int monsterAct = 0;

            monsterAct = monster.turn % 5;

            switch (monsterAct)
            {
                case 0: // 1턴 디버프 적용
                    player.stat.AttackInc -= 1;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine();
                    Console.WriteLine($"\"바론\" 이 플레이어를 응시합니다!");
                    Console.WriteLine($"{player.Name} 에게 이번 전투동안 강력한 디버프가 적용됩니다.");
                    Console.WriteLine($"{player.Name} 의 공격력 {player.stat.Attack + 1} -> {player.stat.Attack}");
                    break;
                case 1:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\"바론\" 의 2연타 공격!!");
                    monster.HitDamage(player, monster);
                    monster.HitDamage(player, monster);
                    break;
                case 2:
                    Console.WriteLine("\"바론\" 의 2연타 공격!!");
                    monster.HitDamage(player, monster);
                    monster.HitDamage(player, monster);
                    break;
                case 3:
                    player.stat.AttackInc -= 1;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine();
                    Console.WriteLine($"\"바론\" 이 플레이어를 응시합니다!");
                    Console.WriteLine($"{player.Name} 에게 이번 전투동안 강력한 디버프가 적용됩니다.");
                    Console.WriteLine($"{player.Name} 의 공격력 {player.stat.Attack + 1} -> {player.stat.Attack}");
                    break;
                default:
                    Console.WriteLine("\"바론\" 의 2연타 공격!!");
                    monster.HitDamage(player, monster);
                    monster.HitDamage(player, monster);
                    break;
                
            
            }
            monster.turn++; // 몬스터 다음패턴
        }

    }
}