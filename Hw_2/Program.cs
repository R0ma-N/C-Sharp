using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Написать метод, возвращающий минимальное из трех чисел.

            Console.Write("Число 1: ");
            var n1 = int.Parse(Console.ReadLine());

            Console.Write("Число 2: ");
            var n2 = int.Parse(Console.ReadLine());

            Console.Write("Число 3: ");
            var n3 = int.Parse(Console.ReadLine());

            var min = Minimum(n1, n2, n3);

            Console.WriteLine("Наименьшее число :" + min);


            //2. Написать метод подсчета количества цифр числа.

            Console.Write("Введите число : ");

            var N = int.Parse(Console.ReadLine());
            var dgts = AmountOfDigits(N);

            Console.WriteLine("колличество цифр: " + dgts);


            //3. С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных положительных чисел.

            int num = 0;
            int sum = 0;

            do
            {
                num = int.Parse(Console.ReadLine());
                if (num > 0 && num % 2 != 0)
                {
                    sum += num;
                }
            } while (num != 0);

            Console.WriteLine("Сумма нечетных чисел: " + sum);


            //4. Реализовать метод проверки логина и пароля. На вход подается логин и пароль. На выходе истина, 
            // если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains). Используя метод проверки 
            // логина и пароля, написать программу: пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает. 
            // С помощью цикла do while ограничить ввод пароля тремя попытками.

            byte i = 1;

            do
            {
                Console.Write ("Введите логин: ");
                string lgn = Console.ReadLine();

                Console.Write ("Введите пароль: ");
                string pswd = Console.ReadLine();

                if (AuthorizationCheck(lgn, pswd) == true)
                {
                    Console.WriteLine("\nВы авторизованы!");
                    break;
                }
                else
                {
                    Console.WriteLine("\nОшибка авторизации.");
                    i++;
                }
            }
            while (i <= 3);


            //5. а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы и сообщает, нужно ли человеку похудеть, набрать вес или все в норме;

            Console.Write("Введите Ваш рост в метрах: ");
            double height = double.Parse(Console.ReadLine());

            Console.Write("Введите Ваш вес в килограммах: ");
            double weight = double.Parse(Console.ReadLine());

            double I = (double)(weight / (height * height));
            Console.WriteLine("\n" + I);


            if (I > 18.5 && I < 24.99)
            {
                Console.WriteLine("Ваш вес в норме");
            } else
            {
                if (I < 18.5)
                {
                    Console.WriteLine("Вам нужно набрать вес");
                }
                else
                {
                    Console.WriteLine("Вам нужно сбросить вес");
                }
            }

            //7. a) Разработать рекурсивный метод, который выводит на экран числа от a до b (a<b)

            Console.Write("Введите число a: ");
            var a = int.Parse(Console.ReadLine());

            Console.Write("Введите число b: ");
            var b = int.Parse(Console.ReadLine());

            Recursive(a, b);

            Console.ReadKey();
                        
        }

        /// <summary>
        /// Находит минимальное из 3х чисел
        /// </summary>
        /// <param name="n1">1ое число</param>
        /// <param name="n2">2ое число</param>
        /// <param name="n3">3ее число</param>
        /// <returns>минимальное число</returns>
        static int Minimum(int n1, int n2, int n3)
        { if (n1 < n2 && n1 < n3)
            {
                return n1;
            }
            else
            {
                if (n2 < n1 && n2 < n3)
                {
                    return n2;
                }
                else
                {
                    return n3;
                }
            }
        }

        /// <summary>
        /// Подсчитывает колличество цифр числа
        /// </summary>
        /// <param name="num">число</param>
        /// <returns>колличество цифр</returns>
        static int AmountOfDigits(int num)
        {
            int digits = 0;
            while (num > 0)
            {
                digits++;
                num /= 10;
            }

            return digits;
        }

        /// <summary>
        /// Проверка логина и пароля
        /// </summary>
        /// <param name="login">логин</param>
        /// <param name="password">пароль</param>
        /// <returns>прошел/не прошел</returns>
        static bool AuthorizationCheck(string login, string password)
        {
            if (login == "root" && password == "GeekBrains")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// рекурсивный метод, который выводит на экран числа от a до b
        /// </summary>
        /// <param name="a">1ое число</param>
        /// <param name="b">2ое число</param>
        static void Recursive(int a, int b)
        {
            for (int i = a; i <= b; i++)
            {
                Console.Write(i + " ");
            }
        } 
    }
}
