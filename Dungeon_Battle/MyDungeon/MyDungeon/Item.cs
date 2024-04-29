using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyDungeon
{
    public interface Consume_Item // 소모아이템
    {
        string Name { get; }
        void Use(Player player); // 플레이어가 소모품 아이템을 사용하는 메서드
    }

    // 체력 포션 클래스
    public class HealthPotion : Consume_Item
    {
        public string Name => "회복물약";

        public void Use(Player player) // 회복 물약 사용시 캐릭터 인벤에서 회복 물약을 한개 차감
        {
            Console.WriteLine("회복물약을 사용합니다. 체력이 50 증가합니다.");

            for (int i = 0; i < player.inven.ItemInfo.Count; i++)
            {
                if (player.inven.ItemInfo[i].ItemType == 4 && player.inven.ItemInfo[i].ItemName == "회복물약") // 선택한 아이템 타입이 소모품이고 아이템 이름이 회복물약이면 실행
                {
                    if (player.inven.ItemInfo[i].Amount >= 1)
                    {
                        Console.WriteLine($"{player.Name} 이(가) 현재 {player.inven.ItemInfo[i].ItemName} 을(를) {player.inven.ItemInfo[i].Amount} 개 소지하고 있습니다. 1개를 소비합니다.");
                        player.inven.ItemInfo[i].Amount -= 1;

                        if (player.stat.Hp + 50 < player.stat.MaxHp)
                        {
                            Console.WriteLine($"{player.inven.ItemInfo[i].ItemName} 을(를) 사용하여 체력을 50 만큼 회복했습니다.");
                            player.stat.Hp += 50;
                        }
                        else
                        {
                            Console.WriteLine($"{player.inven.ItemInfo[i].ItemName} 을(를) 사용하여 체력을 {player.stat.MaxHp - player.stat.Hp} 만큼 회복했습니다.");
                            player.stat.Hp = player.stat.MaxHp;
                        }
                        Console.Write($"현재 체력 : {player.stat.Hp}, 최대 체력 : {player.stat.MaxHp}");
                        
                    }
                    else
                    {
                        Console.WriteLine($"현재 인벤토리에 {player.inven.ItemInfo[i].ItemName} 이(가) 모자랍니다. {player.inven.ItemInfo[i].ItemName} 사용이 취소됩니다.");
                    }
                }

            }
            Console.WriteLine($"현재 인벤토리에 회복물약 이(가) 없습니다. 회복물약 사용이 취소됩니다.");


        }
    }

    // 공격력 포션 클래스
    public class StrengthPotion : Consume_Item
    {
        public string Name => "공격력 상승의 비약";

        public void Use(Player player)
        {
            Console.WriteLine("\"공격력 상승의 비약\"을 사용합니다. 공격력이 이번 탐험동안 10 증가합니다."); // 캐릭터의 공격력을 10증가시킴
            player.AttackPower += 10; // player.AttackPower 해당 던전의 공격력 증가
        }
    }
}
