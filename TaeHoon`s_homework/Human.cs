using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaeHoon_s_homework
{
    public class Human
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
            LeftHand = 0, RightHand = 1, end = 2
        }

        public bool LeftEquip, RightEquip;

        string[] WeaponKinds = new string[(int)HandType.end];

        string WeaponName;
        int WeaponDamage;

        bool sword = false, shield = false;

        string CurJob = "Enpty_Job";
        string PrevJob = "";

        public void EquipWeapon(Weapon weapon, HandType handType)
        {
            int value = (int)handType;

            WeaponName = weapon.name;
            WeaponDamage = weapon.damage;

            WeaponKinds[value] = weapon.GetType().Name;


            if (value == 1)
            {
                if (!RightEquip)
                    RightEquip = true;
                else RightEquip = false;
            }
            else LeftEquip = true;

            if (weapon is Sword) sword = true;
            else if (weapon is Shield) shield = true;

            SetJob();
        }
        void SetJob()
        {
            if ((LeftEquip || RightEquip) && sword)
                CurJob = "검사띠";
            else if ((LeftEquip || RightEquip) && shield)
                CurJob = "탱커띠";
            else if ((LeftEquip && RightEquip) && (sword && shield))
                CurJob = "병사띠";
        }
        public void DisamountWeapon(HandType handType)
        {
            int value = (int)handType;

            if (value == 1) RightEquip = false;
            else LeftEquip = false;
            WeaponKinds[value] = "";

            SetJob(sword, shield);
        }

        public void Action()
        {

            Console.WriteLine($"{CurJob} : {WeaponName}으로 ");
        }
    }
}
