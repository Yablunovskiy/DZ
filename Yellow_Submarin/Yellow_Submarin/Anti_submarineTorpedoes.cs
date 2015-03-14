using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yellow_Submarin
{
    class Anti_submarineTorpedoes : ITypeOfTorpedoes
    {
        public int DistanceToDefeat { get; set; }

        public string Charget()
        {
            return "Класс ПодЛод.";
        }

        
        public Anti_submarineTorpedoes()
        {
            DistanceToDefeat = 0;
        }

        public Anti_submarineTorpedoes(int Distance)
        {
            DistanceToDefeat = Distance;
        }

        public void GetDistans()
        {
            Console.WriteLine(DistanceToDefeat);
        }
    }
}
