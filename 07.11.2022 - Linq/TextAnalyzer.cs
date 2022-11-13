using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _07._11._2022___Linq
{
    public class TextAnalyzer
    {
        public string firstargAndOperation { get; }
        public string numbers { get; }
        public string operation { get; }
        public string secondargAndOperation { get; }
        public TextAnalyzer()
        {
            this.firstargAndOperation = @"\d+\s*(\+|\-|\*|\/)";
            this.numbers = @"\d+";
            this.operation = @"\+|\-|\*|\/";
            this.secondargAndOperation = @"(\+|\-|\*|\/)\s*\d+";
        }
        public void Search(string _input, string _pattern, out MatchCollection _matches)
        {
            var _regex = new Regex(_pattern);
            _matches = _regex.Matches(_input);
        }
    }
}
