using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaeHoon_s_homework
{
    class Hand
    {
        public int Attack;
        public int Defense;
        public Weapon Weapon;
        public bool Equip = false;
        public int SetPower(int playerpower, Weapon Weapon)
        {

            if (Weapon is Sword)
                Attack = (playerpower + Weapon.damage);
            else if (Weapon is Shield)
                Attack = (playerpower + Weapon.damage) / 2;

            return Attack;
        }

    }

    public class Human
    {
        string Name;
        int AttackPower, CombatPower, PlayerPower;

        public Human(string name, int power)
        {
            this.Name = name;
            this.PlayerPower = power;

            LeftHand = new Hand();
            RightHand = new Hand();
        }
        public enum HandType
        {
            LeftHand = 0, RightHand = 1, end = 2
        }

        public bool ALEquip, AREquip;

        string[] WeaponKinds = new string[(int)HandType.end];

        string NewWeaponName;
        Hand LeftHand, RightHand;


        bool LeftCall, RightCall, UnEquipCall;

        string Job = "Empty_Job", stat = "";

        public void EquipWeapon(Weapon weapon, HandType handType)
        {
            int value = (int)handType;

            WeaponKinds[value] = weapon.GetType().Name;

            if (value == 0)
            {
                if (!LeftHand.Equip)
                {
                    LeftHand.Weapon = weapon;
                    stat = (weapon is Sword) ? "공격력" : "방어력";
                }
                else
                {
                    NewWeaponName = weapon.name;
                    ALEquip = true;
                }
                LeftCall = true;
            }
            else
            {
                if (!RightHand.Equip)
                {
                    RightHand.Weapon = weapon;
                    stat = (weapon is Sword) ? "공격력" : "방어력";
                }
                else
                {
                    NewWeaponName = weapon.name;
                    AREquip = true;
                }
                RightCall = true;
            }
        }

        public void Test(Weapon weapon)
        {
            if (weapon is Sword) Console.WriteLine("sword");
            else if (weapon is Shield) Console.WriteLine("shield");
        }

        private string SetJob()
        {
            if ((LeftHand.Weapon is Sword && RightHand.Weapon is Shield) || (LeftHand.Weapon is Shield && RightHand.Weapon is Sword))
            {
                Job = "병사띠";
            }
            else if ((LeftHand.Weapon is Sword || RightHand.Weapon is Sword) || (LeftHand.Weapon is Sword && RightHand.Weapon is Sword))
            {
                Job = "검사띠";
            }
            else if ((LeftHand.Weapon is Shield || RightHand.Weapon is Shield) || (LeftHand.Weapon is Shield && RightHand.Weapon is Shield))
            {
                Job = "탱커띠";
            }
            else
            {
                Job = "Empty_Job";
            }
            return Job;
        }

        public void UnEquipWeapon(HandType handType)
        {
            int value = (int)handType;

            if (value == 0)
            {
                LeftHand.Weapon = null;
                ALEquip = false;
            }
            else
            {
                RightHand.Weapon = null;
                AREquip = false;
            }

            WeaponKinds[value] = "";
            UnEquipCall = true;
        }


        public void Action()
        {

            if (ALEquip)
            {
                Console.WriteLine($"{HandType.LeftHand}에 {NewWeaponName} 무기 장착 시도 : 실패");
                Console.WriteLine($"이미 {HandType.LeftHand}에 {LeftHand.Weapon.name}이(가) 있어서, {NewWeaponName}을(를) 장착할 수 없습니다.");
                LeftCall = false;
                ALEquip = false;
                return;
            }
            else if (AREquip)
            {
                Console.WriteLine($"{HandType.RightHand}에 {NewWeaponName} 무기 장착 시도 : 실패");
                Console.WriteLine($"이미 {HandType.RightHand}에 {RightHand.Weapon.name}이(가) 있어서, {NewWeaponName}을(를) 장착할 수 없습니다.");
                RightCall = false;
                AREquip = false;
                return;
            }

            if (UnEquipCall)
            {
                if (LeftHand.Equip)
                {
                    Console.WriteLine($"{HandType.LeftHand}에 무기 해제 시도 : 성공");
                    Console.WriteLine($"직업 갱신 : {Job} -> {SetJob()}");
                }
                else
                {
                    Console.Write($"{HandType.LeftHand}에 무기 해제 시도 : 실패 ");
                    Console.WriteLine($"이미 빈손입니다");
                    
                }

                if (RightHand.Equip)
                {
                    Console.WriteLine($"{HandType.RightHand}에 무기 해제 시도 : 성공");
                    Console.WriteLine($"직업 갱신 : {Job} -> {SetJob()}");
                }
                else
                {
                    Console.Write($"{HandType.RightHand}에 무기 해제 시도 : 실패 ");
                    Console.WriteLine($"이미 빈손입니다");
                    RightHand.Equip = false;
                }
                return;
            }


            if (LeftCall)
            {
                if (!LeftHand.Equip)
                {
                    Console.WriteLine($"{HandType.LeftHand}에 {LeftHand.Weapon.name} 장착 시도 : 성공");
                    Console.WriteLine($"전투력 : {CombatPower} -> {SetPower(PlayerPower, LeftHand.Weapon)}");
                    Console.WriteLine("유저 공격력(방어력) 갱신");
                    Console.WriteLine($"{stat}: {AttackPower} -> {LeftHand.Weapon.damage}");
                    Console.WriteLine($"직업 갱신 : {Job} -> {SetJob()}");
                    Attack();
                    AttackPower = LeftHand.Weapon.damage;
                    LeftHand.Equip = true;
                }
                else
                {
                    Console.WriteLine($"{HandType.LeftHand}에 {LeftHand.Weapon.name} 장착 시도 : 실패");
                }
                LeftCall = false;
                return;
            }
            if (RightCall)
            {
                if (!RightHand.Equip)
                {
                    Console.WriteLine($"{HandType.RightHand}에 {RightHand.Weapon.name} 장착 시도 : 성공");
                    Console.WriteLine($"전투력 : {CombatPower} -> {SetPower(PlayerPower , RightHand.Weapon)}");
                    Console.WriteLine("유저 공격력(방어력) 갱신");
                    Console.WriteLine($"{stat} : {AttackPower} -> {RightHand.Weapon.damage}");
                    Console.WriteLine($"직업 갱신 : {Job} -> {SetJob()}");
                    Attack();
                    RightHand.Equip = true;
                }
                else
                {
                    Console.WriteLine($"{HandType.RightHand}에 {RightHand.Weapon.name} 장착 시도 : 실패");
                }
                RightCall = false;
                return;
            }

            if (!LeftHand.Equip && !RightHand.Equip)
            {
                Console.WriteLine($@"공격 시도..{Name}[{Job}] : 무기가 읎다 자식아");
                return;
            }

        }

        public int SetPower(int playerpower, Weapon Weapon)
        {

            if (Weapon is Sword)
                CombatPower += (playerpower + Weapon.damage);
            else if (Weapon is Shield)
                CombatPower += (playerpower + Weapon.damage) / 2;


            return CombatPower;
        }

        void Attack()
        {

        }
    }
}
