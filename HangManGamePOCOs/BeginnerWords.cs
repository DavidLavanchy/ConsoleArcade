using HangManGamePOCOs.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangManGamePOCOs
{
    public class BeginnerWords : IWords
    {
        public BeginnerWords(){}
        public BeginnerWords(string word, string clue)
        {
            Word = word;
            Clue = clue;
        }
        public string Word { get; set; }
        public string Clue { get; set; }

    }
}
