using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaeHoon_s_homework
{
    public class FireSword : Weapon, Sword
    {
        public FireSword(string name, int damage) : base(name, damage)
        {
            this.name = name;
            this.damage = damage;
        }
    }
}
