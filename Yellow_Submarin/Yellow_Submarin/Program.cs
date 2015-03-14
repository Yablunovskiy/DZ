using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yellow_Submarin
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = 50;
            Console.WindowWidth = 100;
            Target[] T= new Target[4];
            ITarget SH = new Ship();
            ITarget SU = new Subm();
            Random rand = new Random();
            Fone();
            myTargets(ref T);
            Submarin a = new Submarin("Yellow Submarine", 8, 200);
            Ammunition(ref a);
            //t=Menu1(a,T);                 
            int t = -1, l=0;
            while (true)
            {
                switch (Menu1(a, T , l))//  Выбираем плыть или выбрать цель. и возвращаем 1-выбрать цель  2-плыть.
                {
                    case 1:
                        t = Range(ref T, ref a);
                        Console.WriteLine(t);
                        break;
                    case 2:
                        Move(ref l, T, a);

                        t = Range(ref T, ref a, l);
                        Console.WriteLine(t);
                        break;
                }
                Fire(l, ref T, ref a, t);
            }
        }

        static void Fire(int l, ref Target[] T, ref Submarin a, int t)
        {
            ConsoleKeyInfo key;
            ITarget SH = new Ship();
            ITarget SU = new Subm();
            ITypeOfTorpedoes AnSH = new AntishipTorpedoes();
            ITypeOfTorpedoes AnSU = new Anti_submarineTorpedoes();
            for (int i = 0; i < T.Length; i++)
                T[i].Print();
            bool v = false;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n\n\t\t\t\t\t АТАКА.");
                Console.WriteLine("\n\n\t F - огонь");
                a.AtakSubmarine(l);
                for (int i = 0; i < T.Length; i++)
                {
                    T[i].Print();
                }
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.F)
                {
                    //
                    int k = 0;
                    for (int i = 0; i < T.Length; i++)
                    {
                        if (T[i].CurColor == ConsoleColor.Red)
                        {
                            if ((T[i].Tar.GetType() == SH.GetType() && a.Boezapas[i].TypeOfTorpedo.GetType() == AnSH.GetType()) || (T[i].Tar.GetType() == SU.GetType() && a.Boezapas[i].TypeOfTorpedo.GetType() == AnSU.GetType()))
                            {
                                T[i].soundness -= a.Boezapas[t].PowerOfTorpedo;
                                if (T[i].soundness <= 0)
                                {
                                    k = i;
                                    v = true;
                                }
                            }
                            else
                            {
                                int x = Console.WindowHeight/2;
                                Console.SetCursorPosition(20, x);
                                Console.WriteLine("Kак можно класс ракеты и тип карабля не совпадают");
                                Console.ReadKey();
                            }

                        }
                    }
                    if(v)
                    {
                        Console.WriteLine(T[k].soundness);
                        MinOdin(ref T);
                        a.Boezapas[t] = null;
                        MinOdinAB(ref a);
                    }
                    break;
                }
            }
        }

        static void MinOdin(ref Target[] T)
        {
            int n = 0;
            Target[] temp = new Target[T.Length - 1];
            for (int i = 0; i < T.Length; i++)
            {
                if (T[i].soundness > 0)
                {
                    temp[n] = T[i];
                    n++;
                }
            }
            Array.Resize(ref T, temp.Length);

            for (int i = 0; i < temp.Length; i++)
            {
                T[i] = temp[i];
            }
        }

        static void MinOdinAB(ref Submarin A)
        {
            int n = 0;
            Torpedo[] temp = new Torpedo[A.Boezapas.Length - 1];
            for (int i = 0; i < A.Boezapas.Length; i++)
            {
                if (A.Boezapas[i] != null)
                {
                    temp[n] = A.Boezapas[i];
                    n += 1;
                }
            }
            Array.Resize(ref A.Boezapas, temp.Length);
            for (int i = 0; i < temp.Length; i++)
            {
                A.Boezapas[i] = temp[i];
            }
        }

        static void Move(ref int l, Target[] T, Submarin a)
        {
            ConsoleKeyInfo key;
            for (int i = 0; i < T.Length; i++)
                T[i].PrintTarget();
            int j = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n\n\t\t\t\t\t ДВИЖЕНИЕ СУБМАРИНЫ.(стрелками клавиатуры)");
                Console.WriteLine("\n\n\t D - дозоправка");
                a.PrintSubmarine(l);
                for (int i = 0; i < T.Length; i++)
                {
                    if (T[i].CurColor == ConsoleColor.White)
                        T[i].PrintTarget();
                    else T[i].PrintTarget(ConsoleColor.Red);
                }
                key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow :
                        l--;
                        if (l < -(Console.WindowWidth/2)) l = Console.WindowWidth - 13;
                        a.PrintSubmarine(l);
                        a.reserve -= 2;
                        Console.Beep();
                        break;
                    case ConsoleKey.RightArrow :
                        l++;
                        if (l > Console.WindowWidth-12) l=0;
                        a.PrintSubmarine(l);
                        a.reserve -= 3;
                        Console.Beep();
                        break;
                }
                if (key.Key == ConsoleKey.D)
                {
                    a.reserve = 200;
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
        }

        static int Range (ref Target []T, ref Submarin a, int l=0)
        {
            int t = -1, j = 0;
            ConsoleKeyInfo key;
            t = TakeoverTarget(a, ref T, l);
            Console.Clear();
            ITarget SH = new Ship();
            ITarget SU = new Subm();
            Fone();

            while (true)
            {
                //Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\n\t\t\t Выбор торпеды для поражения цели.(стрелками клавиатуры)");
                Console.Write("\n\n\t\t\t\t");
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Red;
                T[t].InfoTarget();
                Fone();
                Console.WriteLine("\n");
                if (T[t].Tar.GetType() == SH.GetType())
                    Console.WriteLine("\t\t\t\tНеобходима торпеда для корабля");
                if (T[t].Tar.GetType() == SU.GetType())
                    Console.WriteLine("\t\t\t\tНеобходима торбеда для подлотки");

                //
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n Зарядить следующую торпеду-> ");
                Console.Write("\t" + a.Boezapas[j].TypeOfTorpedo.Charget());
                Console.Write("\tМощность торпеды :" + a.Boezapas[j].PowerOfTorpedo + " Расстояние для поражения: ");
                a.Boezapas[j].TypeOfTorpedo.GetDistans();
                Console.ForegroundColor = ConsoleColor.White;
                //

                Console.WriteLine("\n");
                for (int i = 0; i < a.Boezapas.Length; i++)
                {
                    Console.WriteLine("\t" + a.Boezapas[i].TypeOfTorpedo.Charget());
                    Console.Write("\t\tМощность торпеды :" + a.Boezapas[i].PowerOfTorpedo + " Расстояние для поражения: ");
                    a.Boezapas[i].TypeOfTorpedo.GetDistans();
                    Console.WriteLine("\n");
                }
                key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        Console.Clear();
                        j--;
                        if (j > a.Boezapas.Length - 1) j = 0;
                        if (j < 0) j = a.Boezapas.Length - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        Console.Clear();
                        j++;
                        if (j < 0) j = a.Boezapas.Length - 1;
                        if (j >= a.Boezapas.Length) j = 0;
                        break;
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("\n Торпеда -> ");
                    Console.Write("\t" + a.Boezapas[j].TypeOfTorpedo.Charget());
                    Console.Write("\tМощность торпеды :" + a.Boezapas[j].PowerOfTorpedo + " Расстояние для поражения: ");
                    a.Boezapas[j].TypeOfTorpedo.GetDistans();
                    Console.Write("-- ЗАРЯЖЕНА \n");
                    Console.ForegroundColor = ConsoleColor.White;
                    return j;
                }
            }
        }

        static void Ammunition(ref Submarin a)
        {
            a.AddTorpedoes(0, "Ship", 100, 100);
            a.AddTorpedoes(1, "Ship", 50, 90);
            a.AddTorpedoes(2, "Ship", 80, 80);
            a.AddTorpedoes(3, "Ship", 90, 70);
            a.AddTorpedoes(4, "Submarine", 100, 100);
            a.AddTorpedoes(5, "Submarine", 50, 90);
            a.AddTorpedoes(6, "Submarine", 80, 80);
            a.AddTorpedoes(7, "Submarine", 90, 80);
        }

        static void myTargets(ref Target []t)
        {
            Random rand = new Random();
            int Height = Console.WindowHeight;
            int Widht = Console.WindowWidth;
            t[0] = new Target(rand.Next(4, Widht/2-13), rand.Next(10, Height/2-1), rand.Next(50, 100), new Ship());
            t[1] = new Target(rand.Next(Widht / 2 + 1, Widht - 13), rand.Next(Height / 2+1, Height - 1), rand.Next(50, 100), new Ship());

            t[2] = new Target(rand.Next(Widht / 2, Widht - 13), rand.Next(10, Height / 2 - 1), rand.Next(50, 100), new Subm());
            t[3] = new Target(rand.Next(4, Widht / 2 - 13), rand.Next(Height / 2 + 1, Height - 1), rand.Next(50, 100), new Subm());
        }

        static void PrintMySubmarine(ref Submarin a, int l=0)
        {
            a.PrintSubmarine();
        }

        static int Menu1(Submarin s, Target[] t, int l=0)
        {
            string[] v = new string[] { "В АТАКУ!!!" , "Плыть."};
            ConsoleKeyInfo key;
            ConsoleColor BC1 = ConsoleColor.Yellow;
            ConsoleColor FC1 = ConsoleColor.Red;
            ConsoleColor BC2 = ConsoleColor.White;
            ConsoleColor FC2 = ConsoleColor.Blue;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("\t" + s.ToString());
                Console.WriteLine(); Console.WriteLine();
                Console.Write("\t\t\t\t");
                Menu1Vib1(v[0], BC1, FC1);
                Menu1Vib2(v[1], BC2, FC2);

                s.PrintSubmarine(l);
                for (int i = 0; i < t.Length; i++)
                    t[i].PrintTarget();
                key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        BC2 = ConsoleColor.White;
                        FC2 = ConsoleColor.Blue;
                        BC1 = ConsoleColor.Yellow;
                        FC1 = ConsoleColor.Red;
                        break;
                    case ConsoleKey.RightArrow:
                        BC1 = ConsoleColor.White;
                        FC1 = ConsoleColor.Blue;
                        BC2 = ConsoleColor.Yellow;
                        FC2 = ConsoleColor.Red;
                        break;
                 }
                if (key.Key == ConsoleKey.Enter)
                {
                    if (FC1 == ConsoleColor.Red)
                        return 1;
                    if (FC2 == ConsoleColor.Red)
                        return 2;
                }
            }
        }

        static void Menu1Vib1(string k, ConsoleColor BC = ConsoleColor.White, ConsoleColor FC = ConsoleColor.Blue)
        {
            Console.BackgroundColor = BC;
            Console.ForegroundColor = FC;
            Console.Write(k);
            Fone();
        }
        static void Menu1Vib2(string k, ConsoleColor BC = ConsoleColor.White, ConsoleColor FC = ConsoleColor.Blue)
        {

            Console.Write("\t\t");
            Console.BackgroundColor = BC;
            Console.ForegroundColor = FC;
            Console.Write(k);
            Fone();
        }

        static void Fone()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
        }

        static int TakeoverTarget(Submarin s, ref Target[] t, int l=0)
        {
            ConsoleKeyInfo key;
            for (int i = 0; i < t.Length; i++)
                t[i].PrintTarget();
            int j = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n\n\t\t\t\t\t Выбор цели.(стрелками клавиатуры)");
                s.PrintSubmarine(l);
                for (int i = 0; i < t.Length; i++)
                {
                    if (t[i].CurColor == ConsoleColor.White)
                        t[i].PrintTarget();
                    else t[i].PrintTarget(ConsoleColor.Red);
                }
                key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        j--;
                        if (j + 1 > t.Length - 1) j = 0;
                        t[j + 1].PrintTarget(ConsoleColor.White);
                        if (j < 0) j = t.Length - 1;
                        t[j].PrintTarget(ConsoleColor.Red);
                        Console.Beep();
                        break;
                    case ConsoleKey.DownArrow:
                        j++;
                        if (j - 1 < 0) j = t.Length - 1;
                        t[j - 1].PrintTarget(ConsoleColor.White);
                        if (j >= t.Length) j = 0;
                        t[j].PrintTarget(ConsoleColor.Red);
                        Console.Beep();
                        break;
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    for (int i = 0; i < t.Length; i++)
                        if (t[i].CurColor == ConsoleColor.Red)
                        {
                            //Console.Clear();
                            //t[i].InfoTarget();
                            return i;
                        }
                }
            }

            
        }  // выбираем цель и возвращаем инфо о цели, возвращаем момер цели
    
    }
}
