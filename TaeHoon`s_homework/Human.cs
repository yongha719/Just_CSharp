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

        public bool LeftEquip, RightEquip, AlreadyEquip;

        string[] WeaponKinds = new string[(int)HandType.end];

        string WeaponName;
        int WeaponDamage;

        bool sword = false, shield = false;

        bool EquipCall, UnEquipCall;
        string Job = "Empty_Job";

        public void EquipWeapon(Weapon weapon, HandType handType)
        {
            int value = (int)handType;

            WeaponName = weapon.name;
            WeaponDamage = weapon.damage;

            WeaponKinds[value] = weapon.GetType().Name;

            if (value == 0)
            {
                if (!LeftEquip)
                    LeftEquip = true;
                else
                    AlreadyEquip = true;
            }
            else
            {
                RightEquip = true;
            }
            if (weapon is Sword) sword = true;
            else if (weapon is Shield) shield = true;

            EquipCall = true;
        }
        public void Test(Weapon weapon)
        {
            if (weapon is Sword) Console.WriteLine("sword");
            else if (weapon is Shield) Console.WriteLine("shield");
        }

        private string SetJob()
        {
            if ((LeftEquip || RightEquip) && sword)
            {
                Job = "검사띠";
                return Job;
            }
            else if ((LeftEquip || RightEquip) && shield)
            {
                Job = "탱커띠";
                return Job;
            }
            else if ((LeftEquip && RightEquip) && (sword && shield))
            {
                Job = "병사띠";
                return Job;
            }
            else
            {
                Job = "Empty_Job";
                return Job;
            }
        }
        public void UnEquipWeapon(HandType handType)
        {
            int value = (int)handType;

            if (value == 1) RightEquip = false;
            else LeftEquip = false;

            WeaponKinds[value] = "";
            UnEquipCall = true;
        }


        public void Action()
        {
            if (!LeftEquip && !RightEquip)
            {
                Console.WriteLine($@"공격 시도..{Name}[{Job}] : 무기가 읎다 자식아");
                return;
            }

            if (LeftEquip)
            {
                Console.WriteLine($"{HandType.LeftHand}에 {WeaponName} 장착 시도 : 성공");
                Console.WriteLine($"전투력 갱신 : {Power} -> {WeaponDamage}");
            }
            else if (RightEquip)
            {
                Console.WriteLine($"{HandType.RightHand}에 {WeaponName} 장착 시도 : 성공");
            }

            AlreadyEquip = false;

            Power += WeaponDamage;
            WeaponDamage = 0;
        }
    }
}
