using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Назаров Роман
            
            //1. Написать программу «Анкета». Последовательно задаются вопросы (имя, фамилия, возраст, рост, вес). В результате вся информация выводится в одну строчку.

            Console.Write("Введите Ваше имя: ");
            var name = Console.ReadLine();

            Console.Write("Введите Вашу фамилию: ");
            var surname = Console.ReadLine();

            Console.Write("Введите Ваш возраст: ");
            var age = Console.ReadLine();

            Console.Write("Введите Ваш рост в метрах: ");
            var height = double.Parse(Console.ReadLine());

            Console.Write("Введите Ваш вес в килограммах: ");
            var weight = double.Parse(Console.ReadLine());

                //а. используя склеивание

                Console.WriteLine("\nВас зовут " + surname + " " + name + ", Вам " + age + ", Ваш рост " + height + "см" + ", Ваш вес " + weight + "кг.");

                //б. используя форматированный вывод

                Console.WriteLine(string.Format("Вас зовут {0} {1}, Вам {2}, Ваш рост {3}см, Ваш вес {4}кг.", surname, name, age, height, weight));

                //в. используя вывод со знаком $

                Console.WriteLine($"Вас зовут {surname} {name}, Вам {age}, Ваш рост {height}см, Ваш вес {weight}кг.");



            //2. Ввести вес и рост человека. Рассчитать и вывести индекс массы тела (ИМТ) по формуле I=m/(h*h); где m — масса тела в килограммах, h — рост в метрах

            double I = weight / (height * height);
            Console.WriteLine("\nИндекс массы Вашего тела: " + Math.Round(I, 2));


            //3. Написать программу, которая подсчитывает расстояние между точками с координатами x1, y1 и x2,y2 по формуле r=Math.Sqrt(Math.Pow(x2-x1,2)+Math.Pow(y2-y1,2).

            Console.Write("x1: ");
            double x1 = double.Parse(Console.ReadLine());

            Console.Write("x2: ");
            double x2 = double.Parse(Console.ReadLine());

            Console.Write("y1: ");
            double y1 = double.Parse(Console.ReadLine());

            Console.Write("y2: ");
            double y2 = double.Parse(Console.ReadLine());

                //а. Вывести результат, используя спецификатор формата .2f (с двумя знаками после запятой)
                double r = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
                Console.WriteLine("Расстояние между точками: {0:F}", r);

                //б. Выполните предыдущее задание, оформив вычисления расстояния между точками в виде метода
                Console.WriteLine("Расстояние между точками: {0:F}", R(x1, x2, y1, y2));


            //4. Программа обмена значениями двух переменных

            int a, b, c;
            a = 10;
            b = 20;

                //а. С использованием третьей переменной
                c = a;
                a = b;
                b = c;

                Console.WriteLine("a = " + a + ", b = " + b);

                //б. Без использования третьей переменной
                a = a + b;
                b = b - a;
                b = -b;
                a = a - b;

                Console.WriteLine("\na = " + a + ", b = " + b);


            //5. Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.

            Console.Write("Город, в котором Вы проживаете: ");
            string city = Console.ReadLine();
            Console.WriteLine($"\n\t\tВас зовут:\n\t\t {surname} {name}\n\t\tВы проживаете в городе:\n\t\t {city}");

            Console.ReadKey();

        }

        //Метоод для задания 3-б

        static double R(double x1, double x2, double y1, double y2)
        {
            double r = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            return r;
        }
    }
}
}
