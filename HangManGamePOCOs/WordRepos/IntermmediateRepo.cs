using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangManGamePOCOs.WordRepos
{
    public class IntermmediateRepo
    {
        private List<IntermmediateWords> _words = new List<IntermmediateWords>();

        public void AddWordsToList(IntermmediateWords word)
        {
            _words.Add(word);
        }

        public IntermmediateWords GetRandomWord()
        {
            Random ran = new Random();
            int index = ran.Next(_words.Count);
            IntermmediateWords word = _words[index];

            return word;
        }

    }
}
