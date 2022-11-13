using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07._11._2022___Linq
{
    public class Week
    {

    }
    public class myTemp
    {
        public int _numberOfWeek { get; set; }

        // Week

        public string _dayOfWeek  { get; set; }


        public int _myTemperature { get; set; }


        public myTemp(int numberOfWeek, string dayOfWeek, string myTemp)
        {
            this._numberOfWeek = numberOfWeek;
            this._dayOfWeek = dayOfWeek;
            this._myTemperature = int.Parse(myTemp);
        }


        public myTemp()
        {
            Console.WriteLine("Задайте день недели: ");
            this._dayOfWeek = Console.ReadLine();
        }
    }
}
