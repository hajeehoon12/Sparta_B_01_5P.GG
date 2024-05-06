using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace MyDungeon
{
    public class Monster : ICharacter
    {
        //몬스터 정보 (이름, 레벨, 체력, 공격 등)
        public string Name { get; }
        public int Level { get; }
        public int Health { get; set; }
        public int Attack { get; set; }

        public int turn = 0;
        //List<ItemData> Drop_Item;
        public int DropGold { get; set; }   //보상 골드
        public int DropExp { get; set; }    //보상 경험치
        

        public int Avoid { get; set; } // 몬스터 회피율

         // 몬스터의 드랍아이템

        public int increaseAvoid { get; set; } // 몬스터 회피율 증가 난이도에따라 상승, 기본0
        public bool IsDead => Health <= 0;  //전투 중에서 죽었는지

        protected List<ItemData> Drop_Item = new List<ItemData>(); // 이렇게 안하면 아래서 Base를 쓸수가없음
        public Monster(string name, int level, int health, int attack)
        {
            Name = name;
            Level = level;
            Health = new Random().Next(health*17/20, health +23/20); // 몬스터 체력 85%~ 115% 랜덤조정
            Attack = attack;
            Avoid = 10;// 원래 회피율 10%; // 테스트를 위해 회피율 임시 조정
            //turn = 0;
        }

        public void Reward(Player player) // 몬스터의 드랍 아이템
        {
            
            if (Drop_Item != null)
            {
                foreach (ItemData items in Drop_Item)
                {
                    player.ItemAmount_Change(items, 1);
                    Console.WriteLine($"{Name} 이(가) {items.ItemName} 을(를) 드랍했습니다.");
                    if (!player.stage.Drop_Items.ContainsKey(items.ItemName))
                    {
                        player.stage.Drop_Items.Add(items.ItemName, 1); // 없을 경우 드랍 아이템 추가
                    }
                    else
                    {
                        player.stage.Drop_Items[items.ItemName] += 1; // 이미 같은 이름의 아이템이 존재할 경우 수량 추가
                    }
                    
                }
            }
            //경험치 = (레벨) * ((공격10%) + 1)
            DropExp = Level * ((Attack / 10) + 1); // 드랍된 경험치
            player.stat.Exp += DropExp; // 드랍된 경험치를 플레이어게 준다.
            player.stat.isLevelUp(); // 레벨업 검사

            //골드 = (20 * ((레벨 / 2) + 1)) + ((레벨 / 2)+1)
            DropGold = (20 * ((Level / 2) + 1)) + ((Level / 2) + 1); // 몬스터가 드랍한 골드
            player.stat.Gold += DropGold;

            player.stage.stageExp += DropExp;
            player.stage.stageGold += DropGold;
        }


        public void PrintMonster()  //몬스터 정보 출력
        {
            string deadText = IsDead ? "Dead" : $"HP : {Health}"; //몬스터가 죽으면 Dead로 아님 체력표시
            Console.WriteLine($"Lv.{Level} {Name}   {deadText}");
        }

        public void TakeDamage(Player character, int damage)  //플레이어가 몬스터를 가격할 때 , 보상처리도 추가 // 몬스터가 죽는거 검사
        {
            
            int avoidProb;
            avoidProb = new Random().Next(0, 100);

            if (avoidProb < Avoid + increaseAvoid) // 공격 회피
            {
                damage = 0;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"\nLv. {Level} {Name}이(가) 날렵한 몸놀림으로 {character.Name} 의 공격을 회피했습니다..\n\n");
                Console.WriteLine($"Lv.{Level} {Name}");
                //체력 삭감 전
                Console.WriteLine($"HP {Health} -> {Health}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else // 공격 적중
            {
                if (!character.skillUsing) Console.WriteLine($" [데미지 : {damage}]"); // 스킬 사용중에는 다른양식
                
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Lv.{Level} {Name}");
                //체력 삭감 전
                Console.Write($"HP {Health} -> ");
                Health -= damage;
                if (Health <= 0)
                    Health = 0;
                //체력 삭감 이후
                if (IsDead) // 몬스터가 사망시
                {
                    if(Name == "미니언")
                    {
                        character.quest.minionCount++;
                    }
                    character.stat.Mp += 10; // 몬스터 처치시 플레이어 마나회복 + 10
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Dead");

                    Console.WriteLine($"Lv. {Level} {Name} 이(가) {character.Name} 에게 결정적인 일격을 맞고 쓰러졌습니다!!");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Reward(character); // 플레이어에게 보상 증여
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.WriteLine(Health);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                
            }
            Thread.Sleep(500);
        }

        public void HitDamage(Player character, Monster monster)  //몬스터가 플레이어를 가격할 때
        {

            int avoidProb;
            int damage = 0;

            avoidProb = new Random().Next(0, 100);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nLv.{monster.Level} {monster.Name} 의 공격!");
            

            if (avoidProb < character.avoid + increaseAvoid) // 공격 회피
            {
                damage = 0;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{character.Name}이(가) 놀라운 반사신경으로 공격을 회피했습니다.. [데미지 : 0]\n");
                
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\nLv.{character.stat.Level} {character.Name}");
                //체력 삭감 전
                Console.WriteLine($"HP {character.stat.Hp} -> {character.stat.Hp}");
            }
            else // 몬스터의 공격 적중
            {
                Console.WriteLine($"{character.Name} 을(를) 공격했습니다. [데미지 : {monster.Attack}]");

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\nLv.{character.stat.Level} {character.Name}");
                //체력 삭감 전
                Console.Write($"HP {character.stat.Hp} -> ");
                character.stat.Hp -= Attack;
                if (character.stat.Hp <= 0) character.stat.Hp = 0; // 0미만으로 떨어지면 0으로고정
                //체력 삭감 이후
                Console.WriteLine(character.stat.Hp + "\n");
                Console.ForegroundColor = ConsoleColor.White;
            }

        }

        public void GiveDamage(Player character)
        {
            Console.WriteLine($"Lv.{character.stat.Level} {character.Name}의 공격!");
            Console.WriteLine($"{character.Name}을(를) 맞췄습니다. [데미지 : {Attack}");

            Console.WriteLine();
            Console.WriteLine($"Lv. {character.stat.Level} {character.Name}");
            //체력 삭감 전
            Console.Write($"HP {character.stat.Hp} -> ");
            character.stat.Hp -= Attack;
            //체력 삭감 이후
            Console.WriteLine(character.stat.Hp);
        }

        public virtual void add_Drop_Item()
        {
            //Drop_Item.Add(new ItemData(0, "도란의 검", 10, 0, 450, 1, "도란의 검"));
        }

    }
    class Minion : Monster  //미니언
    {
        public Minion(string name) : base(name, 1, 25, 10)
        {    
            add_Drop_Item();
        }

        public override void add_Drop_Item()
        {
            int itemIndex = new Random().Next(0, 6);   //드랍할 아이템 종류
            int dropPercent = new Random().Next(0, 100);    //드랍할 각 아이템종류의 확률

            //미니언이 드랍할 적절한 아이템 (랜덤으로 생성)

            switch(itemIndex)
            {
                case 0: // 무기 : 도란의 검, 칠흑의 양날도끼, 단검
                    if (dropPercent > 60)
                        Drop_Item.Add(new ItemData(0, "도란의 검", 10, 0, 450, 1, "도란의 검"));
                    else if (dropPercent > 50)
                        Drop_Item.Add(new ItemData(0, "단검", 30, 0, 3000, 1, "마법석이 박힌 마법봉"));
                    else if (dropPercent > 40)
                        Drop_Item.Add(new ItemData(0, "칠흑의 양날도끼", 30, 0, 5000, 1, "콜필드의 전투망치와 점화석 롱소드를 조합하여 만든 도끼"));
                    break;
                case 1: // 보조무기 : 도란의 방패, 얼음 방패
                    if (dropPercent > 60)
                        Drop_Item.Add(new ItemData(1, "도란의 방패", 0, 4, 450, 1, "도란의 방패"));
                    else if (dropPercent > 55)
                        Drop_Item.Add(new ItemData(1, "얼음 방패", 0, 20, 950, 1, "천갑옷에서 사파이어 수정과 빛나는 티골로 조합하여 만든 장비"));
                    break;
                case 2: //악세사리 : 도란의 반지, 부서진 팔목 보호대, 
                    if (dropPercent > 60)
                        Drop_Item.Add(new ItemData(2, "도란의 반지", 0, 5, 400, 1, "도란의 반지"));
                    else if (dropPercent > 50)
                        Drop_Item.Add(new ItemData(2, "부서진 팔목 보호대", 0, 25, 1600, 1, "팔목 보호대는 망가졌지만 업그레이드가 가능한 장비"));
                    else if (dropPercent > 45)
                        Drop_Item.Add(new ItemData(2, "수은 장식띠", 0, 30, 1300, 1, "모든 군중 제어 효과를 제거"));
                    break;
                case 3: // 방어구 : 천 갑옷, 가시 갑옷
                    if(dropPercent > 75)
                        Drop_Item.Add(new ItemData(3, "천 갑옷", 0, 15, 300, 1, "천으로 만들어진 갑옷"));
                    else if(dropPercent > 72)   
                        Drop_Item.Add(new ItemData(3, "가시 갑옷", 0, 70, 2700, 1, "덤불조끼와 거인의 허리띠를 조합한 갑옷"));
                    break;
                case 4: // 소모품 : 체력 물약
                    if (dropPercent > 40)
                        Drop_Item.Add(new ItemData(4, "회복물약", 0, 0, 20, new Random().Next(1, 3), "사용자의 상처를 치유하고 활력이 돋게 하는 물약(체력 50회복)"));
                    break;
                case 5: // 잡템 : 미니언의 거적떼기, 루비 수정
                    if (dropPercent > 20)
                        Drop_Item.Add(new ItemData(5, "미니언의 거적떼기", 0, 0, 100, new Random().Next(1, 3), "미니언이 걸치고 다니는 거적떼기"));
                    else
                        Drop_Item.Add(new ItemData(5, "루비 수정", 0, 0, 400, new Random().Next(1, 3), "루비 수정"));
                    break;
            }
            // 아이템 양식 , (아이템타입(0:무기, 1:보조무기 2:악세서리 3: 방어구 4:소모품 5:잡템), 아이템 이름, 공격력, 방어력, 골드, 수량)
            // Drop_Item에 추가
        }
    }

    class Worm : Monster   //공허충
    {
       
        public Worm(string name) : base(name, 3, 35, 15) 
        {    
            add_Drop_Item();
        }

        public override void add_Drop_Item()
        {
            int itemIndex = new Random().Next(0, 6);   //드랍할 아이템 종류 (유일하게 소모품과 잡템만)
            int dropPercent = new Random().Next(0, 100);    //드랍할 각 아이템종류의 확률

            switch(itemIndex)
            {
                case 0: //무기 : 롱소드, 독사의 송곳니
                    if (dropPercent > 65)
                        Drop_Item.Add(new ItemData(0, "롱소드", 10, 0, 350, 1, "길게 만들어진 검"));
                    else if (dropPercent > 63)
                        Drop_Item.Add(new ItemData(0, "독사의 송곳니", 55, 0, 2500, 1, "톱날 단검과 독사의 조합으로 만든 검"));
                    break;
                case 1: //보조 무기 : 도란의 방패, 땅굴 채굴기
                    if (dropPercent > 60)
                        Drop_Item.Add(new ItemData(1, "도란의 방패", 0, 4, 450, 1, "도란의 방패"));
                    else if (dropPercent > 45)
                        Drop_Item.Add(new ItemData(1, "땅굴 채굴기", 15, 0, 1150, 1, "보석을 캘수 있는 채굴기"));
                    break;
                case 2: //악세사리 : 강철 인장, 얼어붙은 심장
                    if (dropPercent > 85)
                        Drop_Item.Add(new ItemData(2, "강철 인장", 15, 30, 1100, 1, "보호와 동시에 공격해줄 도구"));
                    else if (dropPercent > 70)
                        Drop_Item.Add(new ItemData(2, "얼어붙은 심장", 0, 65, 2500, 1, "얼어버린 심장"));
                    break;
                case 3: // 방어구 : 천 갑옷, 
                    if (dropPercent > 75)
                        Drop_Item.Add(new ItemData(3, "천 갑옷", 0, 15, 300, 1, "천으로 만들어진 갑옷"));
                    break;
                case 4: // 소모품 : 체력 물약
                    if (dropPercent > 40)
                        Drop_Item.Add(new ItemData(4, "회복물약", 0, 0, 20, new Random().Next(1, 3), "사용자의 상처를 치유하고 활력이 돋게 하는 물약(체력 50회복)"));
                    break;
                case 5: //잡템 : 사파이어 수정, 새끼 바람돌이
                    if (dropPercent > 80)
                        Drop_Item.Add(new ItemData(5, "사파이어 수정", 0, 0, 350, new Random().Next(1, 4), "사파이어 수정"));
                    else if (dropPercent > 40)
                        Drop_Item.Add(new ItemData(5, "새끼 바람돌이", 0, 0, 450, new Random().Next(1, 3), "플레이어를 도와주는 바람돌이를 소환"));
                    break;
            }
        }
    }

    class CannonMinion : Monster  //대포 미니언
    {
        
        public CannonMinion(string name) : base(name, 5, 50, 20)
        {
            add_Drop_Item();
        }

        public void add_Drop_Item()
        {
            int itemIndex = new Random().Next(0, 6);   //드랍할 아이템 종류
            int dropPercent = new Random().Next(0, 100);    //드랍할 각 아이템종류의 확률

            switch(itemIndex)
            {
                case 0: //무기 : 단검, 나보리 신속검
                    if (dropPercent > 70)
                        Drop_Item.Add(new ItemData(0, "단검", 12, 0, 300, 1, "빠르게 공격할 수 있는 단검"));
                    else if (dropPercent > 60)
                        Drop_Item.Add(new ItemData(0, "나보리 신속검", 65, 0, 3300, 1, "무기중 제일 빠른 공격을 자랑하는 검"));
                    break;
                case 1: //보조무기 : 란두인의 예언
                    if (dropPercent > 65)
                        Drop_Item.Add(new ItemData(1, "란두인의 예언", 0, 55, 2700, 1, "데미지를 입을 때 피해량을 크게 감소시킨다."));
                    break;
                case 2: //악세사리 : 원기 회복의 구슬
                    if (dropPercent > 70)
                        Drop_Item.Add(new ItemData(2, "원기 회복의 구슬", 0, 30, 300, 1, "체력을 보호해 주는 구슬"));
                    break;
                case 3: //방어구 : 기사의 맹세, 
                    if (dropPercent > 70)
                        Drop_Item.Add(new ItemData(3, "기사의 맹세", 0, 45, 2200, 1, "쇠사슬 조끼와 점화석을 조합한 투구"));
                    break;
                case 4: //소모아이템 : 체력 물약
                    if (dropPercent > 40)
                        Drop_Item.Add(new ItemData(4, "회복물약", 0, 0, 20, new Random().Next(1, 5), "사용자의 상처를 치유하고 활력이 돋게 하는 물약(체력 50회복)"));
                    break;
                case 5: //잡템 : 새끼 이끼 쿵쿵이, 새끼 화염발톱
                    if (dropPercent > 70)
                        Drop_Item.Add(new ItemData(5, "새끼 이끼 쿵쿵이", 0, 0, 450, new Random().Next(1, 3), "플레이어를 도와주는 이끼쿵쿵이 소환"));
                    else if (dropPercent > 40)
                        Drop_Item.Add(new ItemData(5, "새끼 화염발톱", 0, 0, 450, new Random().Next(1, 3), "플레이어를 도와주는 화염발톱 소환"));
                    break;
            }
        }

    }


    class baron : Monster // 바론
    {
        public baron(string name) : base(name, 10, 500, 25)
        {

            add_Drop_Item();
            // 디버프 스킬 추가
            //Skills debuffSkill = new Skills("남작의 시선", 0, 3, player => player.stat.Attack -= 5);
            //this.skills.Add(debuffSkill);
        }

        

        public void add_Drop_Item()
        {
            int itemIndex = new Random().Next(0, 6);   //드랍할 아이템 종류
            int dropPercent = new Random().Next(0, 100);    //드랍할 각 아이템종류의 확률

            switch (itemIndex)
            {
                case 0: //무기 : 단검, 그림자 검
                    if (dropPercent > 70)
                        Drop_Item.Add(new ItemData(0, "단검", 12, 0, 300, 1, "빠르게 공격할 수 있는 단검"));
                    else if (dropPercent > 60)
                        Drop_Item.Add(new ItemData(0, "그림자 검", 50, 0, 2600, 1, "근처의 투명한 덫과 와드를 드러내고 무력화 시킴"));
                    break;
                case 1: //보조무기 : 불경한 히드라
                    if (dropPercent > 65)
                        Drop_Item.Add(new ItemData(1, "불경한 히드라", 60, 0, 3300, 1, "티아맷과 야수화를 조합한 무기"));
                    break;
                case 2: //악세사리 : 오만
                    if (dropPercent > 70)
                        Drop_Item.Add(new ItemData(2, "오만", 18, 60, 3000, 1, "몬스터를 관통할 수 있는 머리장식"));
                    break;
                case 3: //방어구 : 파수꾼의 갑옷
                    if (dropPercent > 50)
                        Drop_Item.Add(new ItemData(3, "파수꾼의 갑옷", 0, 40, 1000, 1, "공격을 받는 피해량이 감소"));
                    break;
                case 4: //소모아이템 : 체력 물약
                    if (dropPercent > 40)
                        Drop_Item.Add(new ItemData(4, "회복물약", 0, 0, 20, new Random().Next(1, 5), "사용자의 상처를 치유하고 활력이 돋게 하는 물약(체력 50회복)"));
                    break;
                case 5: //잡템 : 여신의 눈물, 에테르 환영
                    if (dropPercent > 70)
                        Drop_Item.Add(new ItemData(5, "여신의 눈물", 0, 0, 400, new Random().Next(1, 5), "여신의 눈물"));
                    else if (dropPercent > 40)
                        Drop_Item.Add(new ItemData(5, "에테르 환영", 0, 0, 850, new Random().Next(1, 3), "에테르 환영"));
                    break;
            }
        }


    }


}
