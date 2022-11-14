using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Collections;


namespace _07._11._2022___Linq
{

    internal class Program
    {
        static void Main(string[] args)
        {
            // Task 1
            Console.WriteLine("Задание 1: ");
            Console.Write("Введите дату начала недели: ");
            int counter = 0;

            try
            {
                counter = int.Parse(Console.ReadLine()) - 1;
                if (counter < 0)
                {
                    Console.WriteLine("Ошибка ввода");
                    return;
                }
            }
            catch
            {
                Console.WriteLine("Ошибка ввода");
            }

            // Создадим массив объектов типа myTemp
            var _myTemperatureArray = new List<myTemp>();

            var MyTemperature = new TextIO("myTemperature.txt");
            var _myTemperature = new List<string>();
            //myTemp myTmp = new myTemp();

            var _text = new TextAnalyzer();
            var _text2 = new TextAnalyzer();

            MatchCollection _tmp;
            MatchCollection _tmp2;

            // Создадим наши Regex'ы

            Regex myDayOfWeek = new Regex(@"[А-я]+");
            MatchCollection matchDaysOfWeek = myDayOfWeek.Matches(_myTemperature.ToString());

            Regex myTemperature = new Regex(@"[\-\+]{0,1}\d{1,2}");
            MatchCollection matchMyTemperature = myTemperature.Matches(_myTemperature.ToString());

            // Заполнили нашу коллекцию строками (день недели со значениями температуры)
            _myTemperature = MyTemperature.ReadString();

            string myDayOfWeekRegex = @"[А-я]+", myMyTemperatureRegex = @"[\-\+]{0,1}\d{1,2}";

            foreach (var item in _myTemperature)
            {
                _text.Search(item, myDayOfWeekRegex, out _tmp);
                _text2.Search(item, myMyTemperatureRegex, out _tmp2);

                try
                {
                    counter++;

                    try
                    {
                        MatchCollection matches = myDayOfWeek.Matches(_myTemperature.ToString());
                        _text.Search(_tmp[0].ToString(), myDayOfWeekRegex, out _tmp);

                        var temp1 = _tmp[0].ToString();

                        MatchCollection matches2 = myTemperature.Matches(_myTemperature.ToString());
                        _text2.Search(_tmp2[0].ToString(), myMyTemperatureRegex, out _tmp2);

                        var temp2 = _tmp2[0].ToString();

                        var temp0 = counter;

                        // Заполним наш массив объектами

                        myTemp myTemperatureArr = new myTemp(counter, temp1, temp2);
                        _myTemperatureArray.Add(myTemperatureArr);

                    }
                    catch
                    {
                    }

                }
                catch
                {
                    Console.WriteLine($"Cтрока № {counter}: совпадений нет");
                }
            }

            // Linq
            var mostHot = from item in _myTemperatureArray
                          where item._myTemperature >= 4
                          select item;
            var mostCold = from item in _myTemperatureArray
                           where item._myTemperature <= -9
                           select item;

            Console.WriteLine();

            foreach (var item in mostHot)
            {
                Console.WriteLine($"Самая жаркая погода. Неделя №: {item._numberOfWeek}, день недели: {item._dayOfWeek}, температура: {item._myTemperature}");
            }

            foreach (var item in mostCold)
            {
                Console.WriteLine($"Самая холодная погода. Неделя №: {item._numberOfWeek}, день недели: {item._dayOfWeek}, температура: {item._myTemperature}");
            }

            //Console.ReadKey();

            // Task 2
            Console.WriteLine("\nЗадание 2: ");

            var MyText1 = new TextIO("myText1.txt");
            var MyText2 = new TextIO("myText2.txt");

            var _myText1 = new List<string>();
            var _myText2 = new List<string>();

            List<string> _myTextObjects1 = new List<string>();
            List<string> _myTextObjects2 = new List<string>();

            var _Mytext1 = new TextAnalyzer();
            var _Mytext2 = new TextAnalyzer();

            MatchCollection _tmpText;
            MatchCollection _tmpText2;

            Regex myText1 = new Regex(@"[А-я]+");
            MatchCollection matchMyText1 = myText1.Matches(_myText1.ToString());

            Regex myText2 = new Regex(@"[А-я]+");
            MatchCollection matchMyText2 = myText2.Matches(_myText2.ToString());

            _myText1 = MyText1.ReadString();
            _myText2 = MyText2.ReadString();

            string myText1Regex = @"\b[А-я]+\b", myText2Regex = @"\b[А-я]+\b";


            int wordCounterText1 = 0;
            int wordCounterText2 = 0;

            foreach (var item in _myText1)
            {

                // Удалим пробелы, точки, двоеточия и запятые из текста. Заполним нашу коллекцию

                char[] separators = new char[] { ' ', '.', ',', ':' };
                string[] subs = item.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                foreach (var sub in subs)
                {
                    _Mytext1.Search(sub, myText1Regex, out _tmpText);
                    _myTextObjects1.Add(sub.ToString().ToLower());
                    wordCounterText1++;
                }

            }

            foreach (var item in _myText2)
            {

                // Удалим пробелы, точки, двоеточия и запятые из текста. Заполним нашу коллекцию

                char[] separators = new char[] { ' ', '.', ',', ':' };
                string[] subs = item.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                foreach (var sub in subs)
                {
                    _Mytext2.Search(sub, myText2Regex, out _tmpText2);
                    _myTextObjects2.Add(sub.ToString().ToLower());
                    wordCounterText2++;
                }
            }

            Console.WriteLine($"Количество слов в тексте 1: {wordCounterText1}");
            Console.WriteLine($"Количество слов в тексте 2: {wordCounterText2}");

            List<string> _myMatches = new List<string>();

            _myMatches = _myTextObjects1.Intersect(_myTextObjects2).ToList();

            //var result = _myTextObjects1.GroupBy(g => g).Where(g => g.Count() > 1).Select(g => g.Key);
            var result = _myMatches.GroupBy(g => g).Select(g => new {Matches = g.Key, Count = g.Count()}).ToList();
            result.ForEach(x => Console.WriteLine(x));

            var wr = new StreamWriter("result.txt", false);
            result.ForEach(x => wr.WriteLine(x));
            wr.Close();

            Console.WriteLine("Записано");
            Console.ReadKey();
        }
    }
}
