using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw_3
{
    //Назаров Роман
    //3. *Описать класс дробей - рациональных чисел, являющихся отношением двух целых чисел.
    //Предусмотреть методы сложения, вычитания, умножения и деления дробей.Написать
    //программу, демонстрирующую все разработанные элементы класса.

    class Program
    {
        static void Main(string[] args)
        {
            #region Инициализация дробей
            Drob drobRes = new Drob();

            Console.WriteLine("Введите числитель и знаменатель 1ой дроби: ");

            Drob drob1 = new Drob(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
            Console.WriteLine($"\nПервая дробь: {drob1.delimoe} / {drob1.delitel}\n");

            Console.WriteLine("Введите числитель и знаменатель 2ой дроби: ");

            Drob drob2 = new Drob(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
            Console.WriteLine($"\nВторая дробь: {drob2.delimoe} / {drob2.delitel}\n");
            #endregion

            #region Демонстрация

            drobRes = drob1.Plus(drob2);
            Console.WriteLine($"\n1ая дробь + 2ая дробь = {drobRes.delimoe} / {drobRes.delitel}\n");

            drobRes = drob1.PlusUpr(drob2);
            Console.WriteLine($"\nУрощенный вид = {drobRes.delimoe} / {drobRes.delitel}\n");

            drobRes = drob1.Minus(drob2);
            Console.WriteLine($"\n1ая дробь - 2ая = {drobRes.delimoe} / {drobRes.delitel}\n");

            drobRes = drob1.MinusUpr(drob2);
            Console.WriteLine($"\nУрощенный вид: {drobRes.delimoe} / {drobRes.delitel}\n");

            drobRes = drob1.Umnog(drob2);
            Console.WriteLine($"\n1ая дробь * 2ая дробь = {drobRes.delimoe} / {drobRes.delitel}\n");

            drobRes = drob1.UmnogUpr(drob2);
            Console.WriteLine($"\nУрощенный вид: {drobRes.delimoe} / {drobRes.delitel}\n");

            drobRes = drob1.Deli(drob2);
            Console.WriteLine($"\n1ая дробь / 2ая дробь = {drobRes.delimoe} / {drobRes.delitel}\n");

            drobRes = drob1.DeliUpr(drob2);
            Console.WriteLine($"\nУрощенный вид: {drobRes.delimoe} / {drobRes.delitel}\n");

            #endregion

            Console.ReadLine();
        }
    }

    /// <summary>
    /// Представляет обычную дробь, состоящую из делимого и делителя.
    /// Также может возвращать результат вычисления дроби.
    /// </summary>
    public class Drob
    {
        public int delimoe;
        public int delitel;
        public int obmnog = 1; //общий множитель, исчисляется при упрощении дроби, может быть использован для ее восстановления после упрощения

        /// <summary>
        /// Создает объект с делимым 1 и частным 1
        /// </summary>
        public Drob()
        {
            delimoe = 1;
            delitel = 1;
        }

        /// <summary>
        /// Создает объект с присвоением параметров другого экземпляра
        /// </summary>
        /// <param name="Дробь"></param>
        public Drob(Drob drob)
        {
            delimoe = drob.delimoe;
            delitel = drob.delitel;
        }

        /// <summary>
        /// Создает объект с указанием делимого и делителя
        /// </summary>
        /// <param name="delimoe">Делимое</param>
        /// <param name="delitel">Делитель</param>
        public Drob(int delimoe, int delitel)
        {
            this.delimoe = delimoe;
            this.delitel = delitel;
        }

        /// <summary>
        /// Создает дробь вида 1/х
        /// </summary>
        /// <param name="delitel">Делитель</param>
        public Drob(int delitel)
        {
            delimoe = 1;
            this.delitel = delitel;
        }

        #region Операции

        /// <summary>
        /// Упрощает дробь и возвращает ее упрощенный вид
        /// </summary>
        public Drob Upr()
        {
            if ((delimoe < 0) && (delitel < 0))
            {
                delimoe *= -1;
                delitel *= -1;
            }
            int min = Math.Abs(delimoe) <= Math.Abs(delitel) ? delimoe : delitel;
            bool flag = true;
            if ((delimoe != 0) && (Math.Abs(delimoe) != 1))
            {
                while (flag)
                {
                    for (int i = 2; i <= Math.Abs(min); i++)
                    {
                        if ((delimoe % i == 0) && (delitel % i == 0))
                        {
                            obmnog *= i;
                            delimoe /= i;
                            delitel /= i;
                            min = delimoe <= delitel ? delimoe : delitel;
                            if (Math.Abs(min) == 1) flag = false;
                            break;
                        }
                        else if (i == Math.Abs(min))
                        {
                            flag = false;
                        }
                    }
                }
            }
            Drob drob = new Drob(delimoe, delitel);
            return drob;
        }

        /// <summary>
        /// Складывает дроби
        /// </summary>
        /// <param name="drob"></param>
        /// <returns>Возвращает результат сложения</returns>
        public Drob Plus(Drob drob)
        {
            Drob temp1 = new Drob(this);
            Drob temp2 = new Drob(drob);

            if (temp1.delitel == temp2.delitel)
            {
                temp2.delimoe += temp1.delimoe;
            }
            else
            {
                temp1.delimoe *= temp2.delitel;
                temp2.delimoe *= temp1.delitel;
                temp2.delitel *= temp1.delitel;
                temp2.delimoe += temp1.delimoe;
            }
            return temp2;
        }

        /// <summary>
        /// Складывает дроби и упрощает результат
        /// </summary>
        /// <param name="drob"></param>
        /// <returns>Возвращает упрощенный результат сложения</returns>
        public Drob PlusUpr(Drob drob)
        {
            Drob res = new Drob(drob);
            res = Plus(drob);
            res.Upr();
            return res;
        }

        /// <summary>
        /// Вычитает дроби
        /// </summary>
        /// <param name="drob"></param>
        /// <returns>Возвращает результат вычитания</returns>
        public Drob Minus(Drob drob)
        {
            Drob temp1 = new Drob(this);
            Drob temp2 = new Drob(drob);

            if (temp1.delitel == temp2.delitel)
            {
                temp2.delimoe -= temp1.delimoe;
            }
            else
            {
                temp1.delimoe *= temp2.delitel;
                temp2.delimoe *= temp1.delitel;
                temp2.delitel *= temp1.delitel;
                temp2.delimoe -= temp1.delimoe;
            }
            return temp2;
        }

        /// <summary>
        /// Вычитает дроби и упрощает результат
        /// </summary>
        /// <param name="drob"></param>
        /// <returns>Возвращает упрощенный результат вычитания</returns>
        public Drob MinusUpr(Drob drob)
        {
            Drob res = new Drob(drob);
            res = Minus(drob);
            res.Upr();
            return res;
        }

        /// <summary>
        /// Умножает дроби
        /// </summary>
        /// <param name="drob"></param>
        /// <returns>Возвращает результат умножения</returns>
        public Drob Umnog(Drob drob)
        {
            Drob temp1 = new Drob(this);
            Drob temp2 = new Drob(drob);

            temp2.delimoe *= temp1.delimoe;
            temp2.delitel *= temp1.delitel;

            return temp2;
        }

        /// <summary>
        /// Умножает дроби и упрощает результат
        /// </summary>
        /// <param name="drob"></param>
        /// <returns>Возвращает упрощенный результат умножение</returns>
        public Drob UmnogUpr(Drob drob)
        {
            Drob res = new Drob(drob);
            res = Umnog(drob);
            res.Upr();
            return res;
        }

        /// <summary>
        /// Делит дроби
        /// </summary>
        /// <param name="drob"></param>
        /// <returns>Возвращает результат деления</returns>
        public Drob Deli(Drob drob)
        {
            Drob temp1 = new Drob(this);
            Drob temp2 = new Drob(drob);

            temp2.delimoe *= temp1.delitel;
            temp2.delitel *= temp1.delimoe;

            return temp2;
        }

        /// <summary>
        /// Делит дроби и упрощает результат
        /// </summary>
        /// <param name="drob"></param>
        /// <returns>Возвращает упрощенный результат деления</returns>
        public Drob DeliUpr(Drob drob)
        {
            Drob res = new Drob(drob);
            res = Deli(drob);
            res.Upr();
            return res;
        }

        #endregion
    }
}

