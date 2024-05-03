using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDungeon
{
    public class Skills // 몬스터 패턴 저장용 클래스
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

            monsterAct = monster.turn % 7;

            Console.WriteLine(""); // 한줄띄우기 용

            switch (monsterAct)
            {
                case 0: // 1턴 디버프 적용
                    player.stat.AttackInc -= 5;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine();
                    Console.WriteLine($"Boss[바론] 이 [{player.Name}] 에게 [위압감] 을(를) 사용합니다!"); Thread.Sleep(1000);
                    Console.WriteLine($"{player.Name} 이(가) {monster.Name} 에게 위압되어 이번 전투동안 공격력이 큰 폭으로 감소합니다."); Thread.Sleep(1000);
                    Console.WriteLine($"{player.Name} 의 공격력 {player.stat.Attack + 5} -> {player.stat.Attack}");

                    break;
                case 1:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Boss[바론] 이 엄청강력한 스킬을 준비중입니다..");
                    Console.Write("."); Thread.Sleep(500);
                    Console.Write("."); Thread.Sleep(500);
                    Console.Write("."); Thread.Sleep(500);
                    Console.Write("."); Thread.Sleep(500);
                    Console.WriteLine("조심하세요..");

                    break;
     

                
                case 2:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Boss[바론] 이 [석화의 응시] 을(를) 사용!!"); Thread.Sleep(1000);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{player.Name} 의 현재체력이 절반으로 감소하고 {player.Name} 한턴동안 행동불가 상태에 걸립니다."); Thread.Sleep(1000);
                    Console.WriteLine($"{player.Name} 의 체력 {player.stat.Hp} -> {player.stat.Hp/2}");
                    player.stat.Hp /= 2;
                    player.skipTurn = true; // 플레이어 턴 스킵용 변수
                   

                    break;
                case 3:
                    
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine();
                    Console.WriteLine($"Boss[바론] 의 [강화 꼬리 내려치기]!!"); Thread.Sleep(800);
                    Console.WriteLine($"Boss[바론] 의 공격력이 크게 증가합니다!!"); Thread.Sleep(800);
                    Console.WriteLine($"{player.Name} 에게 강력한 데미지를 입힙니다!!"); Thread.Sleep(800);

                    player.skipTurn = false; // 플레이어 턴 스킵 해제

                    monster.Attack *= 2;
                    monster.HitDamage(player, monster);
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine();
                    Console.WriteLine($"Boss[바론] 의 [2연타 공격]!!"); Thread.Sleep(800);

                    Console.WriteLine($"{player.Name} 에게 데미지를 2번 입힙니다!!"); Thread.Sleep(800);

                    player.skipTurn = false; // 플레이어 턴 스킵 해제

                    monster.HitDamage(player, monster); Thread.Sleep(800);
                    monster.HitDamage(player, monster); Thread.Sleep(800);

                    break;

                case 5:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine();
                    Console.WriteLine($"Boss[바론] 의 [자가 수복]"); Thread.Sleep(800);

                    Console.WriteLine($"{monster.Name} 이 자신의 잃은 체력의 절반만큼 회복합니다!"); Thread.Sleep(800);
                    Console.WriteLine($"{monster.Name} 의 체력 {monster.Health} -> {(70-monster.Health)/2 + monster.Health}"); Thread.Sleep(800);

                    monster.Health += (70 - monster.Health) / 2; 

                    break;
                case 6:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine();
                    Console.WriteLine($"Boss[바론] 의 [2연타 공격]!!"); Thread.Sleep(800);

                    Console.WriteLine($"{player.Name} 에게 데미지를 2번 입힙니다!!"); Thread.Sleep(800);

                    monster.HitDamage(player, monster); Thread.Sleep(800);
                    monster.HitDamage(player, monster); Thread.Sleep(800);
                    break;
                case 7:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine();
                    Console.WriteLine($"Boss[바론] 의 [꼬리 휘두르기]!!"); Thread.Sleep(800);

                    Console.WriteLine($"{player.Name} 에게 강력한 데미지를 입힙니다!!"); Thread.Sleep(800);

                    monster.HitDamage(player, monster); Thread.Sleep(800);  
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