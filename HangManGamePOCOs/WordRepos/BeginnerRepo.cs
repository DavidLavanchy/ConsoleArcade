using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangManGamePOCOs.WordRepos
{
    public class BeginnerRepo
    {
        private List<BeginnerWords> _words = new List<BeginnerWords>();

        public void AddWordsToList(BeginnerWords word)
        {
            _words.Add(word);
        }

        public BeginnerWords GetRandomWord()
        {
            Random ran = new Random();
            int index = ran.Next(_words.Count);
            BeginnerWords word = _words[index];

            return word;
        }


    }
}
