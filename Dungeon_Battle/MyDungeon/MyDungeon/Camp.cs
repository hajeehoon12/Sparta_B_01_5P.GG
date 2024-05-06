using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDungeon
{
    public class Camp
    {
        Program program = new Program();
        int act = 0;
        bool actIsNum = false;
        int price = 1000;

        public Camp()
        {
            price = 1000;
        }
            
        public void Camping(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\r\n ######     ###    ##     ## ########  \r\n##    ##   ## ##   ###   ### ##     ## \r\n##        ##   ##  #### #### ##     ## \r\n##       ##     ## ## ### ## ########  \r\n##       ######### ##     ## ##        \r\n##    ## ##     ## ##     ## ##        \r\n ######  ##     ## ##     ## ##        \r\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n==================================================================================\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("★[휴식하기]★\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{price} G 를 내면 체력을 회복할 수 있습니다.");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"(보유 골드 : {player.stat.Gold} G) \n\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"체력 : {player.stat.Hp} / {player.stat.MaxHp}\n");
            Console.WriteLine("-1. 나가기");
            Console.WriteLine("0. 휴식하기 (잃은 체력의 절반 회복)");
            Console.WriteLine("1. 회복물약 사용 (체력을 최대 50회복) , 회복물약 1개 소모");
            
            


            Console.WriteLine("\n\n==================================================================================\n\n");

            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n원하시는 행동을 숫자로 입력해주세요 : ");
                Console.Write(">>");
                
                actIsNum = int.TryParse(Console.ReadLine(), out act);
                Console.Clear();
            } while (!actIsNum);


            switch (act)
            {
                case -1: // 나가기
                    program.SelectAct(player);
                    break;
                case 0: // 휴식하기

                    if (player.stat.Gold >= price)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n\n==================================================================================\n");
                        Console.WriteLine($"{price} G 를 내고 휴식을 진행합니다. : 잃은 체력의 절반 회복");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n[휴식 결과]\n");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"체력 {player.stat.Hp} -> {player.stat.MaxHp}");
                        Console.WriteLine($"Gold {player.stat.Gold} G-> {player.stat.Gold - price} ");
                        player.stat.Hp += (player.stat.MaxHp-player.stat.Hp)/2;
                        player.stat.Gold -= price;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n\n==================================================================================\n");
                        Camping(player);
                        
                    }
                    else
                    {
                        Console.WriteLine("\n\n==================================================================================\n");
                        Console.WriteLine("돈이 부족합니다!! 거지뇨속");
                        Console.WriteLine("\n\n==================================================================================\n");
                    }
            
                    break;
                case 1: // 물약 사용

                    Console.ForegroundColor = ConsoleColor.Yellow;

                    for (int i = 0; i < player.inven.ItemInfo.Count; i++)
                    {
                        if (player.inven.ItemInfo[i].ItemType == 4)
                        {
                            if (player.inven.ItemInfo[i].Amount >= 1 && player.inven.ItemInfo[i].ItemName == "회복물약")
                            {
                                Console.WriteLine($"{player.Name} 이(가) 현재 {player.inven.ItemInfo[i].ItemName} 을(를) {player.inven.ItemInfo[i].Amount} 개 소지하고 있습니다. 1개를 소비합니다.");
                                player.inven.ItemInfo[i].Amount -= 1;

                                if (player.stat.Hp + 50 < player.stat.MaxHp)
                                {
                                    Console.WriteLine($"{player.inven.ItemInfo[i].ItemName} 을(를) 사용하여 체력을 50 만큼 회복했습니다. (남은 포션 : {player.inven.ItemInfo[i].Amount})");
                                    player.stat.Hp += 50;
                                }
                                else
                                {
                                    Console.WriteLine($"{player.inven.ItemInfo[i].ItemName} 을(를) 사용하여 체력을 {player.stat.MaxHp - player.stat.Hp} 만큼 회복했습니다. (남은 포션 : {player.inven.ItemInfo[i].Amount})");
                                    player.stat.Hp = player.stat.MaxHp;
                                }
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write($"현재 체력 : {player.stat.Hp}, 최대 체력 : {player.stat.MaxHp}");
                                Console.WriteLine();
                                Camping(player); // 물약 사용후 종료
                            }
                            else // 물약개수 동남
                            {
                                break;
                            }
                        }
                        
                    }
                    Console.WriteLine($"현재 인벤토리에 회복물약 이(가) 없습니다. 회복물약 사용이 취소됩니다.");


                    Console.WriteLine("\n\n==================================================================================\n");
                    
                    break;
                
                default:
                    Console.WriteLine("\n====잘못된 입력입니다. 다시 입력해주세요====");
                    Camping(player);
                    break;

            }

        }
   
    }
}
