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
    internal class Monster
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
            string deadText = IsDead ? "Dead" : $"HP {Health}"; //몬스터가 죽으면 Dead로 아님 체력표시
            Console.WriteLine($"Lv.{Level} {Name}\t {deadText}");
        }

    }
    class Minion : Monster  //미니온
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
