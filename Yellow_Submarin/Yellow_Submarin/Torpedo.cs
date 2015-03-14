using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yellow_Submarin
{
    class Torpedo
    {
        public ITypeOfTorpedoes TypeOfTorpedo { get; set; }
        public int PowerOfTorpedo { get; set; }

        public Torpedo(ITypeOfTorpedoes Type, int Power)
        {
            TypeOfTorpedo = Type;
            PowerOfTorpedo = Power;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat(TypeOfTorpedo.Charget());
            return sb.ToString();
       }
    }
}
