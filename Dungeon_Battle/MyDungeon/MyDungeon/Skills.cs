using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDungeon
{
    internal class Skills
    {
        public string Name { get; }
        public int Attack { get; } 
        public int Cooldown { get; } 
        public int CurrentCooldown { get; set; } 
        public Action<Player> Effect { get; } 
    }
}
