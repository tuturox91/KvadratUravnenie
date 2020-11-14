using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwadratnoeUrovnenie
{
    //Решатор полных квадратных выражений
    class Program
    {
        public static int PushInInt(string Tested, int i, out int j)
        {
            string ChastOne = "";
            int l = 0;
            string to = "";

            if (Char.IsDigit(Tested[i])) { l = 1; }
            if (Tested[i] == 'x') { l = 1; to += '1'; }
            for (; i < Tested.Length; i++)
            {

                if (Tested[i] != '+' && Tested[i] != '-' && Tested[i] != '=')
                {
                    ChastOne += Tested[i];
                }
                else if(Tested[i] == '+' || Tested[i] == '-')
                {
                    if (l == 0)
                    {
                        if (Tested[i] == '+')
                        {
                            l = 1;
                            continue;
                        }
                        else
                        {
                            ChastOne += Tested[i];
                            l = 1;
                            continue;
                        }
                    }
                    break;
                }
                else
                {

                    break;
                }

            }

            j = i;

           
            for (int k = 0; k < ChastOne.Length; k++)
            {
                if (ChastOne[k] == 'x')
                {
                    if(to.Length == 1 && !Char.IsDigit(to[0]))
                    {
                        to = "1";
                    }
                    break;
                }
                else
                {
                    to += ChastOne[k];
                }
            }
            int temp = Convert.ToInt32(to);

            return temp;
        }

        public static void CalculateKvadrat(string Primer)
        {
            int j;
            int a = PushInInt(Primer, 0, out j);
            int b = PushInInt(Primer, j, out j);
            int c = PushInInt(Primer, j, out j);
            //Console.WriteLine(a);
            //Console.WriteLine(b);
            //Console.WriteLine(c);

            double D = Math.Pow(b, 2) - 4 * a * c;
            Console.WriteLine("Найдем дискриминант выражения: {0}, \nпо формуле D = b^2-4ac, D = {1}", Primer, D);

            if (D < 0) { Console.WriteLine("Квадратное уравнение не имеет корней"); }
            else if (D == 0)
            {
                Console.WriteLine("Квадратное уравнение имеет один корень");
                double x = (-b) / (2 * a);
                Console.WriteLine("x = {0}", x);
            }
            else if (D > 0)
            {
                Console.WriteLine("Квадратное уравнение имеет два корня");
                double x1;
                double x2;
                if (b < 0)
                {
                    x1 = ((-b) + Math.Sqrt(D)) / (2 * a);
                    x2 = ((-b) - Math.Sqrt(D)) / (2 * a);
                }
                else
                {
                    x1 = ((-b) + Math.Sqrt(D)) / (2 * a);
                    x2 = ((-b) - Math.Sqrt(D)) / (2 * a);
                }

                Console.WriteLine("x1 = {0}", x1);
                Console.WriteLine("x2 = {0}", x2);
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Введите полное квадратное уравнение где (x в квадрате записывается так: x^2) например: x^2+4x-5=0");
            string Tested = Console.ReadLine();
            //string Tested = "x^2+4x-5=0";

            CalculateKvadrat(Tested);
            
            Console.ReadLine();
        }
    }
}
