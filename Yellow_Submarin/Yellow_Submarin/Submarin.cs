using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yellow_Submarin
{
    class Submarin
    {
        public string name { get; set; }
        public int NumberOfTorpedoes { get; set; }
        public int reserve { get; set; }
        public Torpedo[] Boezapas;

        public Submarin(string name, int NumberOfTorpedoes, int reserve)
        {
            this.name = name;
            this.NumberOfTorpedoes = NumberOfTorpedoes;
            this.reserve = reserve;
            Boezapas = new Torpedo[this.NumberOfTorpedoes];
        }

        public void AddTorpedoes(int ind, string Anti, int Dist, int Power)
        {
            if (Anti=="Ship")
                Boezapas[ind] = new Torpedo(new AntishipTorpedoes(Dist), Power);
            if (Anti == "Submarine")
                Boezapas[ind] = new Torpedo(new Anti_submarineTorpedoes(Dist), Power);
            //Boezapas[ind].SpeedOfTorpedo = speed;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("Класс лодки : {0}  Боекомплект : {1}-торпед.  Запас хода : {2}-миль", name, Boezapas.Length, reserve);
            return sb.ToString();
        }

        public void PrintSubmarine(int l=0)
        {
            if (reserve > 0)
            {
                int x = Console.WindowHeight + l;
                int y = Console.WindowWidth / 4;
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("/---|---\\");
                Console.WriteLine("- {0} миль.", reserve);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                int x = Console.WindowHeight + l;
                int y = Console.WindowWidth / 4;
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("буль-буль-буль");
                Console.ForegroundColor = ConsoleColor.White;
            }

        }

        public void AtakSubmarine(int l = 0)
        {
            int x = Console.WindowHeight + l;
            int y = Console.WindowWidth / 4;
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("/---|---\\");
            Console.WriteLine("- {0} миль.", reserve);
            Console.ForegroundColor = ConsoleColor.White;
         }

        public void PrintBoezapas()
        {
            for (int i = 0; i < Boezapas.Length; i++)
            {
                Console.WriteLine(Boezapas[i].ToString());
                Console.Write("Мощность торпеды :"+Boezapas[i].PowerOfTorpedo+" Расстояние для поражения: ");
                Boezapas[i].TypeOfTorpedo.GetDistans();

            }
        }
    }
}
