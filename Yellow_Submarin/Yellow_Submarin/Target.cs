using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yellow_Submarin
{
    public struct Position
    {
        public int x;
        public int y;
    }

    class Target
    {
        public Position p;
        public int soundness { get; set; }
        public ConsoleColor CurColor;
        public ITarget Tar;

        public Target ()
        { }

        public Target(int x, int y, int soun, ITarget Tar, ConsoleColor CurColor = ConsoleColor.White)
        {
            p.x = x;
            p.y = y;
            soundness = soun;
            this.Tar = Tar;
            this.CurColor = CurColor;
        }

        public void Lesion (int s)
        {
            soundness -= s;
        }

        public void PrintTarget(ConsoleColor CurColor = ConsoleColor.White)
        {
            if (this.soundness > 0)
            {
                this.CurColor = CurColor;
                Console.ForegroundColor = CurColor;
                Console.SetCursorPosition(p.x, p.y);
                Tar.Targ();
                Console.WriteLine("- {0}L", soundness);
            }
        }

        public void Print()
        {
            if (this.soundness > 0)
            {
                Console.ForegroundColor = CurColor;
                Console.SetCursorPosition(p.x, p.y);
                Tar.Targ();
                Console.WriteLine("- {0}L", soundness);
            }
        }

        public void InfoTarget()
        {
            Tar.Info();
            Console.WriteLine(" Запас прочности : {0}L", soundness);
        }

    }
}
