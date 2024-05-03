using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDungeon
{
    public class Skills // 몬스터 패턴 저장용 클래스
    {
        static Random rand = new Random();
        static public void WormPattern(Player player, Monster monster)
        {
            int monsterAct = rand.Next(0, 3);

            switch (monsterAct)
            {

                case 0:
                    player.stat.Hp -= 20;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine();
                    Console.WriteLine($"\"공허충\" 이 플레이어에게 [몸통박치기]을(를) 합니다!");
                    Console.WriteLine($"{player.Name} 에게 고정데미지가 들어옵니다.");
                    Console.WriteLine($"{player.Name} 의 체력 {player.stat.Hp + 20} -> {player.stat.Hp}");
                    break;
                case 1:
                    monster.Health += 10;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\"공허충\" 이 [웅크리기]을(를) 합니다!");
                    Console.WriteLine("\"공허충\" 이 최대 체력을 증가시킵니다.");
                    break;
                default:
                    monster.HitDamage(player, monster);
                    break;


            }
            monster.turn++; // 몬스터 다음패턴
        }
        static public void CannonPattern(Player player, Monster monster)
        {
            int monsterAct = 0;

            monsterAct = monster.turn % 4;

            switch (monsterAct)
            {
                case 0:
                    player.stat.Hp -= 30;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine();
                    Console.WriteLine($"\"머포미니언\" 이 플레이어에게 [대포 발사]을(를) 합니다!");
                    Console.WriteLine($"{player.Name} 에게 고정데미지가 들어옵니다.");
                    Console.WriteLine($"{player.Name} 의 체력 {player.stat.Hp + 30} -> {player.stat.Hp}");
                    break;
                case 1:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\"머포미니언\" 이 [에너지]을(를) 모으기 시작합니다!!");

                    break;
                case 2:
                    Console.WriteLine("\"머포미니언\" 의 에너지포!");
                    monster.Attack *= 3;
                    monster.HitDamage(player, monster);
                    monster.Attack /= 3;
                    break;
                default:
                    Console.WriteLine("\"머포미니언\" 의 2연타 공격!!");
                    monster.HitDamage(player, monster);
                    monster.HitDamage(player, monster);
                    break;


            }
            monster.turn++; // 몬스터 다음패턴
        }
        static public void MinionPattern(Player player, Monster monster)
        {
            int monsterAct = 0;
            bool attackbuff = false;
            monsterAct = rand.Next(0, 4);

            switch (monsterAct)
            {
                case 0:
                    
                    monster.Attack *= 2;
                    
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.WriteLine($"\"미니언\" 이 플레이어에게 분노합니다!");
                    Console.WriteLine($"미니언의 공격력이 다음턴까지 두배 증가합니다.");
                    if (attackbuff)
                    {
                        monster.Attack /= 2;
                        attackbuff = false;
                    }
                    attackbuff = true;
                    break;
                case 1:
                    
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"\"미니언\"이 한눈 팔려 공격을 하지 않습니다!");
                    if (attackbuff)
                    {
                        monster.Attack /= 2;
                    }
                    break;
                case 2:
                    
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\"미니언\" 의 회심의 연속 공격!!");
                    monster.HitDamage(player, monster);
                    monster.HitDamage(player, monster);
                    if (attackbuff)
                    {
                        monster.Attack /= 2;
                    }
                    break;
                default:
                   
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