using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yellow_Submarin
{
    class Subm : ITarget
    {
        public void Targ()
        {
            Console.Write("/--|--\\");
        }

        public void Info()
        {
            Console.Write("Цель пoдводная лодка.");
        }
    }
}
