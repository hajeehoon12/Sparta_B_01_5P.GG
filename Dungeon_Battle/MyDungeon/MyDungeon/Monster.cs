using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyDungeon
{
    public class Skill
    {
        public string Name { get; }
        public int Attack { get; }
        public int Cooldown { get; }
        public int Currentcooldown { get; set; }
        public Action<Player> Effect { get; }

        public Skill(string name, int attack, int cooldown, Action<Player> effect = null)
        {
            Name = name;
            Attack = attack;
            Cooldown = cooldown;
            Currentcooldown = 0;
            Effect = effect;
        }

        public bool IsReady()
        {
            if (Currentcooldown <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void UseSkill(Player player)
        {
            if (IsReady())
            {
                Console.WriteLine($"스킬 {Name}을(를) 사용했습니다!");
                if (Effect != null) // 특수효과가 있다면 적용
                {
                    Effect(player);
                }

                Currentcooldown = Cooldown;
            }
        }
        public void TickCooldown()
        {
            if (Currentcooldown > 0)
            {
                Currentcooldown = Currentcooldown - 1; // 쿨다운 감소
            }
        }

    }

    public class Monster : ICharacter
    {
        //몬스터 정보 (이름, 레벨, 체력, 공격 등)
        public string Name { get; }
        public int Level { get; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public List<Skill> skills { get; set; }
        public bool IsDead => Health <= 0;  //전투 중에서 죽었는지


        public Monster(string name, int level, int health, int attack)
        {
            Name = name;
            Level = level;
            Health = health;
            Attack = attack;
            skills = new List<Skill>();
        }

        public void UseSkill(Player Player)
        {
            Random rand = new Random();
            var readySkills = skills.FindAll(skill => skill.IsReady());

            if (readySkills.Count == 0)
            {
                return;
            }

            var sellectSkill = readySkills[rand.Next(readySkills.Count)];
            sellectSkill.UseSkill(Player);
        }

        public void PrintMonster()  //몬스터 정보 출력
        {
            string deadText = IsDead ? "Dead" : $"HP {Health}"; //몬스터가 죽으면 Dead로 아님 체력표시
            Console.WriteLine($"Lv.{Level} {Name}\t {deadText}");
        }

        public void TakeDamage(Player character, int damage)  //플레이어가 몬스터를 가격할 때
        {
            Console.WriteLine($"Lv.{Level} {Name}을(를) 맞췄습니다. [데미지 : {character.stat.Attack}]");

            Console.WriteLine();
            Console.WriteLine($"Lv.{Level} {Name}");
            //체력 삭감 전
            Console.Write($"HP {Health} -> ");
            Health -= (int)character.stat.Attack;
            if (Health <= 0)
                Health = 0;
            //체력 삭감 이후
            if (IsDead) Console.WriteLine("Dead");
            else Console.WriteLine(Health);
        }

        public void HitDamage(Player character)  //몬스터가 플레이어를 가격할 때
        {
            Console.WriteLine($"Lv.{Level} {Name}의 공격!");
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

    class baron : Monster // 바론
    {
        public baron(string name) : base(name, 10, 50, 10)
        {
            // 디버프 스킬 추가
            Skill debuffSkill = new Skill("남작의 시선", 0, 3, player => player.stat.Attack -= 5);
            this.skills.Add(debuffSkill);
        }
    }
}

