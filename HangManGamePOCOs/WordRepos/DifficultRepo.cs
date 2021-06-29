using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangManGamePOCOs.WordRepos
{
    public class DifficultRepo
    {
        private List<DifficultWords> _words = new List<DifficultWords>();

        public void AddWordsToList(DifficultWords word)
        {
            _words.Add(word);
        }

        public DifficultWords GetRandomWord()
        {
            Random ran = new Random();
            int index = ran.Next(_words.Count);
            DifficultWords word = _words[index];

            return word;
        }

    }
}
