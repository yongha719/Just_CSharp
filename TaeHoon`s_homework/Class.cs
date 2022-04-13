using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaeHoon_s_homework
{
    class Class
    {
        static void Main(string[] arg)
        {

        }
    }
    class Human
    {
        string Name;
        int Power;

        public Human(string name, int power)
        {
            this.Name = name;
            this.Power = power;
        }
        public enum HandType
        {
            LeftHand = -1, RightHand = 1
        }

        public HandType Handtype;

        string WeaponName;
        int WeaponDamage;

        public void EquipWeapon(Weapon shield, HandType handType)
        {
            WeaponName = shield.name;
            WeaponDamage = shield.damage;

            Handtype = handType;
        }

        public void Action()
        {

        }
    }
    class FireSword : Weapon
    {
        public FireSword(string name, int damage) : base(name, damage)
        {
            this.name = name;
            this.damage = damage;
        }
    }

    class WaterSword : Weapon
    {
        public WaterSword(string name, int damage) : base(name, damage)
        {
            this.name = name;
            this.damage = damage;
        }
    }

    class HeavyShield : Weapon
    {
        public HeavyShield(string name, int damage) : base(name, damage)
        {
            this.name = name;
            this.damage = damage;
        }
    }

    class LightShield : Weapon
    {
        public LightShield(string name, int damage) : base(name, damage)
        {
            this.name = name;
            this.damage = damage;
        }
    }
    class Weapon
    {
        public string name;
        public int damage;
        public Weapon(string name, int damage)
        {
            this.name = name;
            this.damage = damage;
        }
    }
    interface Sword { }
    interface Shield { }
}
