using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaeHoon_s_homework
{
    class Class
    {
        static string a = "e";
        static void Main(string[] arg)
        {
            Human yongha = new Human("Yongha", 50);

            yongha.EquipWeapon(new FireSword("전설의 불의 검", 50), Human.HandType.LeftHand);
            yongha.Action();
        }
    }
}