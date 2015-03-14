using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yellow_Submarin
{
    class Ship : ITarget, Iship
    {
        public void Targ()
        {
            Console.Write("\\__|__/");
        }

        public void Info()
        {
            Console.Write("Цель линкорн.");
        }
    }
}
