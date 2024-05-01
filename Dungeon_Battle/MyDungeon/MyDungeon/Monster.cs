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
        public int Attack { get; }

        //List<ItemData> Drop_Item;

        

        public int Avoid { get; set; } // 몬스터 회피율

         // 몬스터의 드랍아이템

        public int increaseAvoid { get; set; } // 몬스터 회피율 증가 난이도에따라 상승, 기본0
        public bool IsDead => Health <= 0;  //전투 중에서 죽었는지

        protected List<ItemData> Drop_Item = new List<ItemData>(); // 이렇게 안하면 아래서 Base를 쓸수가없음
        public Monster(string name, int level, int health, int attack)
        {
            Name = name;
            Level = level;
            Health = health;
            Attack = attack;
            Avoid = 10;// 원래 회피율 10%; // 테스트를 위해 회피율 임시 조정
        }

        public void Reward(Player player) // 몬스터의 드랍 아이템
        {
            
            if (Drop_Item != null)
            {
                foreach (ItemData items in Drop_Item)
                {
                    player.ItemAmount_Change(items, 1);
                    Console.WriteLine($"{Name} 이(가) {items.ItemName} 을(를) 드랍했습니다.");
                }
            }
            //경험치
            //골드
        }


        public void PrintMonster()  //몬스터 정보 출력
        {
            string deadText = IsDead ? "Dead" : $"HP : {Health}"; //몬스터가 죽으면 Dead로 아님 체력표시
            Console.WriteLine($"Lv.{Level} {Name}   {deadText}");
        }

        public void TakeDamage(Player character, int damage)  //플레이어가 몬스터를 가격할 때 , 보상처리도 추가
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

    }
    class Minion : Monster  //미니언
    {
        public Minion(string name) : base(name, 2, 15, 5)
        {    
            add_Drop_Item();
        }

        public void add_Drop_Item()
        {
            int index = new Random().Next(0, 100);

            //미니언이 드랍할 적절한 아이템 (랜덤으로 생성)

            // 무기 : 칠흑의 양날도끼, 낡은 단검, 방망이형 몽둥이
            if (index > 60) 
                Drop_Item.Add(new ItemData(0, "방망이형 몽둥이", 10, 0, 800, 1, "나무를 깎아 방망이처럼 만든 몽둥이 맞으면 좀 아프다"));
            else if (index > 20) 
                Drop_Item.Add(new ItemData(0, "낡은 단검", 10, 0, 1000, 1, "칼날을 고철로 갈아 만들어 오래 사용한 느낌의 단검"));
            else 
                Drop_Item.Add(new ItemData(0, "칠흑의 양날도끼", 30, 0, 5000, 1, "콜필드의 전투망치와 점화석 롱소드를 조합하여 만든 도끼"));
            // 보조무기 : 
            // 악세서리 : 이빨 목걸이, 황동 팔찌
            if (index > 25)
                Drop_Item.Add(new ItemData(2, "이빨 목걸이", 0, 5, 200, 1, "동물의 치아로 만들어 엮은 목걸이"));
            else
                Drop_Item.Add(new ItemData(2, "황동 팔찌", 5, 10, 3500, 1, "황동으로 만들었으나 전투에 쓸만한 팔찌"));
            // 방어구 : 가죽 조끼, 가죽 너클
            if(index > 50)
                Drop_Item.Add(new ItemData(3, "가죽 조끼", 0, 8, 1200, 1, "두꺼운 가죽으로 만든 조끼 찢어질 우려가 없다"));
            else
                Drop_Item.Add(new ItemData(3, "가죽 너클", 2, 4, 700, 1, "가죽으로 만든 너클형 장갑이며 전투할 때 다칠 우려가 없다"));
            // 소모품 : 체력 포션, 공격 포션(?)
            Drop_Item.Add(new ItemData(4, "체력 포션", 0, 0, 500, 1, "마시면 체력을 10만큼 회복"));
            Drop_Item.Add(new ItemData(4, "공격 포션", 0, 0, 300, 1, "마시면 전투중에 공격력 증가"));
            // 잡템 : 미니언의 거적떼기
            Drop_Item.Add(new ItemData(5, "미니언의 거적떼기", 0, 0, 100, 1, "미니언이 걸치고 다니는 거적떼기"));

            // 아이템 양식 , (아이템타입(0:무기, 1:보조무기 2:악세서리 3: 방어구 4:소모품 5:잡템), 아이템 이름, 공격력, 방어력, 골드, 수량)
            // Drop_Item에 추가
        }
    }

    class Worm : Monster   //공허충
    {
       
        public Worm(string name) : base(name, 3, 10, 9) 
        {    
            add_Drop_Item();
        }

        public void add_Drop_Item()
        {
            //Drop_Item.Add(new ItemData(0, "칠흑의 양날도끼", 30, 0, 5000, 1, "콜필드의 전투망치와 점화석 롱소드를 조합하여 만든 도끼")); // 추가하고 싶은 아이템 추가
            //Drop_Item.Add(new ItemData(5, "미니언의 거적떼기", 0, 0, 100, 1, "미니언이 걸치고 다니는 거적떼기"));
        }
    }

    class CannonMinion : Monster  //대포 미니언
    {
        
        public CannonMinion(string name) : base(name, 5, 25, 8)
        {
            add_Drop_Item();
        }

        public void add_Drop_Item()
        {
            //Drop_Item.Add(new ItemData(0, "칠흑의 양날도끼", 30, 0, 5000, 1, "콜필드의 전투망치와 점화석 롱소드를 조합하여 만든 도끼"));
            //Drop_Item.Add(new ItemData(5, "미니언의 거적떼기", 0, 0, 100, 1, "미니언이 걸치고 다니는 거적떼기"));
        }

    }


    class baron : Monster // 바론
    {
        public baron(string name) : base(name, 10, 50, 10)
        {

            add_Drop_Item();
            // 디버프 스킬 추가
            Skills debuffSkill = new Skills("남작의 시선", 0, 3, player => player.stat.Attack -= 5);
            //this.skills.Add(debuffSkill);
        }
        public void add_Drop_Item()
        {
            //Drop_Item.Add(new ItemData(0, "칠흑의 양날도끼", 30, 0, 5000, 1, "콜필드의 전투망치와 점화석 롱소드를 조합하여 만든 도끼"));
            //Drop_Item.Add(new ItemData(5, "미니언의 거적떼기", 0, 0, 100, 1, "미니언이 걸치고 다니는 거적떼기"));
        }


    }


}
