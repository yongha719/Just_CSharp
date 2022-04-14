using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaeHoon_s_homework
{
    public class Weapon
    {
        public string name;
        public int damage;
        public Weapon(string name, int damage)
        {
            this.name = name;
            this.damage = damage;
        }
    }

    public interface Sword { }
    public interface Shield { }
}
