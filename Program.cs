using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ежедневник_1
{
   public class Program
    {
        
            static int kur = 1;
        static void Main(string[] args)
        {
            int thisday = 19;
            Daily Task1 = new Daily();
            Daily Task2 = new Daily();
            Daily Task3 = new Daily();
            Daily Task4 = new Daily();
            Daily Task5 = new Daily();
            Task1.day = 19;
            Task2.day = 20;
            Task3.day = 21;
            Task4.day = 19;
            Task5.day = 20;
            Task1.name = "Сходить на тренировку по боксу";
            Task1.description = "была силовая тренировка и мне понравилось";
            Task2.name = "сходил в басейн";
            Task2.description = "кайф плюс баня";
            Task3.name = "день рождения скинхеда";
            Task3.description = "напились";
            Task4.name = "Целый день спал";
            Task4.description = "Отдохнул";
            Task5.name = "учёба в мпт";
            Task5.description = "хочу отдохнуть";
            Daily[] dela = new Daily[5] {Task1,Task2,Task3,Task4,Task5};
                Console.WriteLine("Нажми для просмотра на любую кнопку кроме Enter");
            while (true)
            {
                ConsoleKeyInfo knopka = Console.ReadKey(true);
                thisday = Readclawish(knopka,thisday, dela);
                Console.Clear();
                Calendaring(dela,thisday);
            }


        }

        private static int Readclawish(ConsoleKeyInfo knopka, int day, Daily[] dela)
        {
            switch (knopka.Key)
            {
                case ConsoleKey.RightArrow:
                    day++;
                    break;
                case ConsoleKey.LeftArrow:
                    day--;
                    break;
                case ConsoleKey.DownArrow:
                    kur++;
                    break;
                case ConsoleKey.UpArrow:
                    kur--;
                    break;
                case ConsoleKey.Enter:
                    Entering(dela, day);
                    break;
            }

            return day;
        }

        private static void Entering(Daily[] dela, int sk)
        {
            Console.Clear();
            int d = 0;
            List<Daily> list = dela.Where(t => t.day == sk).ToList();
            foreach (var item in list)
            {

                if (item.day == sk && d!=1)
                {
                    Console.WriteLine($"{list[kur - 1].name}:\n  {list[kur-1].description}");
                    d = d + 1;
                }
            }
            Console.ReadKey();
        }

        private static void Calendaring(Daily[] dela,int skip)
        {
            Console.WriteLine($"Дата: {skip}.10.2022");
            int y = 0;
            Console.SetCursorPosition(0, 1);
            for (int i = 0; i < dela.Length; i++)
            {
                if (dela[i].day == skip)
                {
                    y++;
                Console.WriteLine("     "+y + "." + dela[i].name);
                }

            }
            Curs(kur);
            
        }

        private static void Curs(int kur)
        {
            Console.SetCursorPosition(0, kur);
            Console.WriteLine(" >>");

        }
    }
}
