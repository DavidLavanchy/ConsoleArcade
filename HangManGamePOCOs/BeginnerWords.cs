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
        public BeginnerWords(string word, string clue, int numberOfLettersInWord)
        {
            Word = word;
            Clue = clue;
            NumberOfLettersInWord = numberOfLettersInWord;
        }
        public string Word { get; set; }
        public string Clue { get; set; }
        public int NumberOfLettersInWord { get; set; }
    }
}
