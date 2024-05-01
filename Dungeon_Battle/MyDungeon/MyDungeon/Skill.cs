using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDungeon
{
    public class Skills
    {
        public string Name { get; }
        public int Attack { get; }
        public int Cooldown { get; }
        public int Currentcooldown { get; set; }
        public Action<Player> Effect { get; }

        public Skills(string name, int attack, int cooldown, Action<Player> effect = null)
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
}