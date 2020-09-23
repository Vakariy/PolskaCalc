using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcInputString
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true) //Бесконечный цикл
            {
                Console.Write("Введите выражение: "); //Предлагаем ввести выражение
                Console.WriteLine(CalcLogic.Calculate(Console.ReadLine())); //Считываем, и выводим результат
            }
        }
    }
}