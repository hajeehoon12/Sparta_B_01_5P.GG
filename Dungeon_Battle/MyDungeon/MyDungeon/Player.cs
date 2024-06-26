﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MyDungeon
{

    public interface ICharacter
    { 
        string Name { get; }
        int Health { get; set; }
        int Attack { get; }
        bool IsDead  { get; }
        void TakeDamage(Player player, int damage);

    }


    [Serializable] public class Player : ICharacter
    {
        public string Name { get; set; } // 저장용
        public Status stat; // 상태창 저장용
        Market market;
        Dungeon dungeon;
        Camp camp;
        public Quest quest;
        public Program program;
        public Inventory inven; // 플레이어 인벤토리
        public Stage stage;

        public bool skipTurn = false; // 플레이어 턴 스킵용 변수

        public bool skillUsing = false; // 스킬사용중 여부


        public int critical { get; set; }                  // 크리티컬 확률 // 기본은 15%
        public float criticalDmg { get; set; }       // 크리티컬 데미지
        public int increaseCritical { get; set; }       // 크리티컬 확률 추가
        public float increaseCriticalDmg { get; set; } // 크리티컬 데미지추가

        public int avoid = 10;
        public int increaseAvoid = 0;

        public int CurStage = 1; // 플레이어가 현재 해금가능한 스테이지 저장용


        public int Health { get; set; }
        public int AttackPower { get; set; }
        public bool IsDead =>Health <= 0; 
        public int Attack => Critical();    // 신던전에서 사용할 공격력 적용 방법
                                      // AttackPower = 임시공격력 상승, AttackInc =  플레이어 장비 총합, Attack.stat = 플레이어 기본 공격력

        int atkinc = 0;
        int definc = 0;// name, stat, market, 


        public void TakeDamage(Player player, int damage) // 현재로서는 적용안하는 함수 나중에 쓰일지도.. Monster.HitDamage 로 대체됨 매개변수 이슈로
        {
            int avoidProb;
            
            avoidProb = new Random().Next(0, 100);

            if (avoidProb < avoid + increaseAvoid) // 공격 회피
            {
                damage = 0;
                Console.WriteLine($"{player.Name}이(가) 놀라운 반사신경으로 공격을 회피했습니다!!\n\n");
            }
            else
            {

                Health -= damage;
                if (Health <= 0)
                {
                    Health = 0; // 0이하로 떨어질 경우 0으로고정

                } 
                
                else Console.WriteLine($"{Name}이(가) {damage}의 데미지를 받았습니다. 남은 체력: {Health}");
            }
            Wait(); // 다음 버튼용 함수
        }

        public int Critical() // 크리티컬 계산식 및 데미지 계산식 (int 값 출력)
        {
            int dmgresult;
            int criticalProb;
            dmgresult = new Random().Next((int)((AttackPower + stat.Attack + stat.AttackInc)*0.9), (int)((AttackPower + stat.Attack + stat.AttackInc)*1.1)); 
            criticalProb = new Random().Next(0, 100);

            if (criticalProb < critical + increaseCritical)
            {
                // 크리티컬이 터진다.
                dmgresult = (int)(dmgresult * (criticalDmg + increaseCriticalDmg / 100.0f)); // 크리티컬 확률 및 크리티컬 데미지 계산식
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"\n{Name} 이(가) 적의 급소를 노려 치명적인 일격이 적용!!  ");
                
            }
            
            return dmgresult; // 최종 데미지
        }


        public Player(string name)
        {
            Name = name;
            stat = new Status(Name, this);
            
            inven = new Inventory(name);
            stage = new Stage();

            market = new Market("초보자상점");
            dungeon = new Dungeon();
            camp = new Camp();
            program = new Program();
            quest = new Quest();


            critical = 15;                  // 크리티컬 확률 // 기본은 15%
            criticalDmg = 1.6f;          // 크리티컬 데미지
            increaseCritical = 0;         // 크리티컬 확률 추가
            increaseCriticalDmg = 0f;  // 크리티컬 데미지추가

        //stat.Show_stat(); // 생성할 때, 캐릭터 정보를 출력 //현재 기능 비활성화

    }

        public void PlayerSet()
        {
            if (stat.job == "전사") // 전사일 경우 세팅
            {
                stat.MaxHp += 20;
                stat.Hp += 20;
                stat.Defense += 3;
            }
            else if (stat.job == "마법사") // 마법사일 경우 세팅
            {
                stat.Attack += 10;
                critical += 10;
                stat.Hp -= 20;
                stat.MaxHp -= 20;
                stat.MaxMp += 20;
            }
            else if (stat.job == "도적") // 도적일 경우 세팅
            {
                critical += 10;
                criticalDmg += 0.10f;
                avoid += 10;
            }
            else if (stat.job == "궁수") // 궁수일 경우 세팅
            {
                stat.Attack += 5;
                critical += 15;
                criticalDmg += 0.15f;
            }
            else
            {
                Console.WriteLine("직업선택오류발생 수정바람");
            }
        }

        public void Wait() // 0번 입력대기용 함수
        {
            int input;
            bool IsinputNum;

            do
            {
                Console.WriteLine("0. 다음");
                IsinputNum = int.TryParse(Console.ReadLine(), out input);

            } while (IsinputNum);

            switch (input)
            {
                case 1: // 상태보기

                    break;
                default:
                    Console.WriteLine("올바른 입력을 해주세요.");
                    Wait();
                    break;
            }
        }


        

        public void CharInfo() // 캐릭터 상태창 정보
        {
            // 캐릭터 상태창을 띄우기전에 장비한 아이템의 정보가 반영되어야함

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\r\n ######  ########    ###    ######## ##     ##  ######  \r\n##    ##    ##      ## ##      ##    ##     ## ##    ## \r\n##          ##     ##   ##     ##    ##     ## ##       \r\n ######     ##    ##     ##    ##    ##     ##  ######  \r\n      ##    ##    #########    ##    ##     ##       ## \r\n##    ##    ##    ##     ##    ##    ##     ## ##    ## \r\n ######     ##    ##     ##    ##     #######   ######  \r\n");


            (atkinc,definc) = inven.Item_Ability_Total(); // 상태창을 보여주기 전에 아이템 능력치의 총합을 반영함

            if (atkinc == 0 && definc == 0) // 아이템으로 인한 능력치 변화가 없을 때
            {
                stat.Show_stat(0, 0);   // 상태창
            }
            else
            {
                
                stat.Show_stat(atkinc, definc, this); // 능력치 변화의 존재
            }

            
            stat.Stat_menu();   // 상태창 관리 메뉴
        }
        public void InvenInfo(Player player) // 캐릭터 인벤토리 정보
        {
            //Program.instance.SelectAct();
            inven.Show_Inven(player);
        }

        public void MarketVisit(Player player) // 상점 방문
        {
            market.Show_Market(player) ;
        }

        public void ItemAmount_Change(ItemData itemData, int amt_change) // 플레이어가 획득한 아이템 추가
        {
            for (int i = 0; i < inven.ItemInfo.Count; i++) // 인벤토리 표시
            {
                if (inven.ItemInfo[i].ItemName == itemData.ItemName) // 같은 것이 존재한다면 수량만 추가
                {
                    inven.ItemInfo[i].Amount += amt_change;
                    if (inven.ItemInfo[i].Amount == 0)
                    {
                        inven.ItemInfo[i].IsEquip = false;
                    }
                    return;
                }
                

            }
            inven.ItemInfo.Add(itemData);

        }
        public void GoDungeon(Player player)
        {
            dungeon.Dungeon_Menu(player);
        }
        public void DoCamping(Player player)
        {
            camp.Camping(player);
            
        }

        public void BattleDungeon(Player player)
        {
            stage.Start(player);
        }

        public void QuestAccept(Player player)
        {
            Console.Clear();
            quest.QuestScroll(player);
        }

    }
}
