using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyDungeon
{
    public class Monster : ICharacter
    {
        //몬스터 정보 (이름, 레벨, 체력, 공격 등)
        public string Name { get; }
        public int Level { get; }
        public int Health { get; set; }
        public int Attack { get; }
        public bool IsDead => Health <= 0;  //전투 중에서 죽었는지
        public Monster(string name, int level, int health, int attack)
        {
            Name = name;
            Level = level;
            Health = health;
            Attack = attack;
        }

        public void PrintMonster()  //몬스터 정보 출력
        {
            string deadText = IsDead ? "Dead" : $"HP : {Health}"; //몬스터가 죽으면 Dead로 아님 체력표시
            Console.WriteLine($"Lv.{Level} {Name}   {deadText}");
        }

        public void TakeDamage(Player character, int damage)  //플레이어가 몬스터를 가격할 때
        {
            Console.WriteLine($" [데미지 : {damage}]");

            Console.WriteLine();
            Console.WriteLine($"Lv.{Level} {Name}");
            //체력 삭감 전
            Console.Write($"HP {Health} -> ");  
            Health -= damage;
            if(Health <= 0)
                Health = 0;
            //체력 삭감 이후
            if (IsDead)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Dead");

                Console.WriteLine($"{Name} 이(가) {character.Name} 에게 결정적인 일격을 맞고 쓰러졌습니다!!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else Console.WriteLine(Health);
        }

        public void HitDamage(Player character, Monster monster)  //몬스터가 플레이어를 가격할 때
        {
            Console.WriteLine($"Lv.{monster.Level} {monster.Name}의 공격!");
            Console.WriteLine($"{character.Name}을(를) 맞췄습니다. [데미지 : {monster.Attack}");

            Console.WriteLine();
            Console.WriteLine($"Lv. {character.stat.Level} {character.Name}");
            //체력 삭감 전
            Console.Write($"HP {character.stat.Hp} -> ");
            character.stat.Hp -= Attack;
            //체력 삭감 이후
            Console.WriteLine(character.stat.Hp);
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
        public Minion(string name) : base(name, 2, 15, 5) { }
    }

    class Worm : Monster   //공허충
    {
        public Worm(string name) : base(name, 3, 10, 9) { }
    }

    class CannonMinion : Monster  //대포 미니언
    {
        public CannonMinion(string name) : base(name, 5, 25, 8) { }
    }
}
