using System;
using System.Net.NetworkInformation;

namespace ConsoleApp164
{
    struct MyTime
    {
        public int hour, minute, second;
        public MyTime(int h, int m, int s)
        {
            this.hour = h;
            this.minute = m;
            this.second = s;
        }
        public override string ToString()
        {
            return string.Format(hour + ":" + minute.ToString("00") + ":" + second.ToString("00"));
        }
    }
    class Program
    {
        static void Inp(out int h, out int m, out int s)// Для вводу часу через пробіл
        {
            int[] arr = Array.ConvertAll(Console.ReadLine().Trim().Split(), int.Parse);
            h = arr[0];
            m = arr[1];
            s = arr[2];
        }
        static int TimeSinceMidnight(MyTime time)
        {
            int secInDay = 86400;
            int sec = (((time.second + time.minute * 60 + time.hour * 3600) % secInDay) + secInDay) % secInDay;
            return sec;
        }
        static MyTime FormatedTimeSinceMidnight(int time)
        {
            int secInDay = 86400;
            time = ((time % secInDay) + secInDay) % secInDay;
            int h = time / 3600;
            int m = (time / 60) % 60;
            int s = time % 60;
            return new MyTime(h, m, s);
        }
        static MyTime AddOneMinute(ref MyTime time)
        {
            int temp = (((time.second + (time.minute + 1) * 60 + time.hour * 3600) % 86400) + 86400) % 86400;
            time.hour = temp / 3600;
            time.minute = (temp / 60) % 60;
            time.second = temp % 60;
            return time;
        }
        static MyTime AddOneHour(ref MyTime time)
        {
            int temp = (((time.second + time.minute * 60 + (time.hour + 1) * 3600) % 86400) + 86400) % 86400;
            time.hour = temp / 3600;
            time.minute = (temp / 60) % 60;
            time.second = temp % 60;
            return time;
        }
        static MyTime AddOneSecond(ref MyTime time)
        {
            int temp = (((time.second + 1 + time.minute * 60 + time.hour * 3600) % 86400) + 86400) % 86400;
            time.hour = temp / 3600;
            time.minute = (temp / 60) % 60;
            time.second = temp % 60;
            return time;
        }
        static MyTime AddSeconds(MyTime time, int s)
        {
            int T = (((time.second + s + time.minute * 60 + time.hour * 3600) % 86400) + 86400) % 86400;
            time.hour = T / 3600;
            time.minute = (T / 60) % 60;
            time.second = T % 60;
            return time;
        }
        static int Difference(MyTime mt1, MyTime mt2)
        {
            return TimeSinceMidnight(mt1) - TimeSinceMidnight(mt2);
        }
        static string WhatLesson(MyTime mt)
        {
            //НЕ ДУМАЮ, ЩО ЦЕ НАЙЕФЕКТИВНІШИЙ МЕТОД, АЛЕ ІНШИМ СПОСОБОМ, НА ЖАЛЬ, НЕ ВИЙШЛО =(
            int seconds = TimeSinceMidnight(mt);
            if (seconds > 0 && seconds < 28800)
            {
                return "Пари не почались";
            }
            else if (seconds >= 28800 && seconds < 33600)
            {
                return "1-ша пара";
            }
            else if (seconds >= 33600 && seconds < 34800)
            {
                return "перерва мiж 1-ою та 2-гою парами";
            }
            else if (seconds >= 34800 && seconds < 39600)
            {
                return "2-га пара";
            }
            else if (seconds >= 39600 && seconds < 40800)
            {
                return "перерва мiж 2-гою та 3-ю парами";
            }
            else if (seconds >= 40800 && seconds < 45600)
            {
                return "3-тя пара";
            }
            else if (seconds >= 45600 && seconds < 46800)
            {
                return "перерва мiж 3-ю та 4-ю парами";
            }
            else if (seconds >= 46800 && seconds < 51600)
            {
                return "4-та пара";
            }
            else if (seconds >= 51600 && seconds < 52800)
            {
                return "перерва мiж 4 та 5 парами";
            }
            else if (seconds >= 52800 && seconds < 57600)
            {
                return "5-та пара";
            }
            else if (seconds >= 57600 && seconds < 58200)
            {
                return "перерва мiж 5 та 6 парами";
            }
            else if (seconds >= 58200 && seconds < 63000)
            {
                return "6-та пара";
            }
            else if (seconds >= 63000 && seconds < 86400)
            {
                return "пари закiнчились";
            }
            else return "Помилка";
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введiть час через пробiл");
            int h, m, s;
            Inp(out h, out m, out s);
            MyTime time = new MyTime(h, m, s);
            Console.WriteLine(time.ToString());
            Console.WriteLine("Секунд пiсля 0:00:00");
            Console.WriteLine(TimeSinceMidnight(time));
            Console.WriteLine("Додаємо 1 секунду:  {0}", AddOneSecond(ref time));
            Console.WriteLine("Додаємо 1 хвилину:  {0}", AddOneMinute(ref time));
            Console.WriteLine("Додаємо 1 годину:  {0}", AddOneHour(ref time));
            Console.WriteLine("Введiть к-сть секунд якi потрiбно додати:");
            int sec = int.Parse(Console.ReadLine());
            Console.WriteLine(AddSeconds(time, sec));
            Console.WriteLine("Введiть к-сть секунд щоб визначити час");
            int sec1 = int.Parse(Console.ReadLine());
            Console.WriteLine(FormatedTimeSinceMidnight(sec1));
            Console.WriteLine("Введiть перший момент часу");
            Inp(out h, out m, out s);
            MyTime time1 = new MyTime(h, m, s);
            Console.WriteLine("Введiть другий момент часу");
            Inp(out h, out m, out s);
            MyTime time2 = new MyTime(h, m, s);
            Console.WriteLine("Рiзниця =: {0}", Difference(time1, time2) + "секунд");
            Console.WriteLine("Для того, щоб визначити розклад дзвiнкiв введiть час через пробiл");
            Inp(out h, out m, out s);
            MyTime time3 = new MyTime(h, m, s);
            Console.WriteLine(WhatLesson(time3));
            Console.ReadKey();
        }
    }
}
