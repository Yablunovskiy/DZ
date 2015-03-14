using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yellow_Submarin
{
    class AntishipTorpedoes : ITypeOfTorpedoes
    {
        public int DistanceToDefeat { get; set; }

        public string Charget()
        {
            return "Класс ЛинКор.";
        }

        public AntishipTorpedoes()
        {
            DistanceToDefeat = 0;
        }

        public AntishipTorpedoes(int Distance)
        {
            DistanceToDefeat = Distance;
        }

        public void GetDistans()
        {
            Console.WriteLine(DistanceToDefeat);
        }


    }
}
