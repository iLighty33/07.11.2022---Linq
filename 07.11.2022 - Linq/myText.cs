using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07._11._2022___Linq
{
    public class myText
    {
        public string _myTextString {
            get { return _myTextString; }
            set { } 
        }

        public myText(string myText)
        {

            //char[] separators = new char[] { ' ', '.', ',' };

            //string[] subs = myText.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            //foreach (var sub in subs)
            //{
            //    Console.WriteLine($"Substring: {sub}");
            //}

            this._myTextString = myText;

        }
    }


}
