﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaeHoon_s_homework
{
    public class LightShield : Weapon, Shield
    {
        public LightShield(string name, int damage) : base(name, damage)
        {
            this.name = name;
            this.damage = damage;
        }
    }
}
