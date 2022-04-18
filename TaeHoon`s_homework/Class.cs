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
            Human yongha = new Human("Yongha", 50);


            yongha.EquipWeapon(new FireSword("전설의 불의 검", 50), Human.HandType.LeftHand);
            yongha.Action();
            Console.WriteLine();

            yongha.EquipWeapon(new WaterSword("전설의 불의 방패", 50), Human.HandType.LeftHand);
            yongha.Action();
            Console.WriteLine();

            yongha.EquipWeapon(new HeavyShield("전설의 무거운 방패", 50), Human.HandType.RightHand);
            yongha.Action();
            Console.WriteLine();

            yongha.UnEquipWeapon(Human.HandType.LeftHand);
            yongha.Action();
        }
    }
}