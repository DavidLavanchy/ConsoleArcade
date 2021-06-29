using HangManGamePOCOs;
using HangManGamePOCOs.WordRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangManGame
{
    public class ProgramUI
    {
        private BeginnerRepo _repo = new BeginnerRepo();
        private IntermmediateRepo _repoIntermmediate = new IntermmediateRepo();
        private DifficultRepo _repoDifficult = new DifficultRepo();
        internal void Run()
        {
            Menu();
        }

        internal void Menu()
        {
            SeedBeginnerWords();
            SeedIntermmediateWords();
            SeedDifficultWords();

            bool isTrue = true;
            while (isTrue)
            {
                Console.Clear();
                Console.WriteLine("-----HangMan-----\n" +
                    "\n" +
                    "1. Play!\n" +
                    "2. Rules\n" +
                    "3. Exit HangMan\n");
                Console.WriteLine();
                Console.WriteLine(
                "   ______            \n" +
                "  |     |            \n" +
                "  |     o            \n" +
                "  |    -|-           \n" +
                "  |    ( )           \n" +
                " _|_                 \n");
                string input = Console.ReadLine();
                string dashes = "-------------------";

                switch (input)
                {
                    case "1":
                        SelectDifficulty();
                        break;
                    case "2":
                        Rules();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("See you again soon!\n" +
                            "----------\n" +
                            "Press any key to continue.\n" +
                            $"{dashes}\n");
                        isTrue = false;
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Oops! Please select a valid option.\n" +
                            "----------\n" +
                            "Press any key to continue.\n" +
                            $"{dashes}\n");
                        break;
                }
            }
        }

        private void SelectDifficulty()
        {
            string dashes = "-------------------";
            Console.Clear();
            Console.WriteLine("-----Select Your Difficulty-----\n" +
                $"{dashes}\n" +
                $"1. Beginner\n" +
                $"2. Intermmediate\n" +
                $"3. Expert\n" +
                $"{dashes}\n" +
                $"4. Exit To Main Menu\n");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Beginner();
                    break;
                case "2":
                    Intermmediate();
                    break;
                case "3":
                    Expert();
                    break;
                case "4":
                    Menu();
                    break;
                default:
                    Console.WriteLine("Please enter a valid menu option...");
                    Console.ReadKey();
                    break;
            }

        }

        private void Beginner()
        {
            HangManRepo HangMan = new HangManRepo();
            int chances = 7;
            Console.Clear();

            BeginnerWords word = _repo.GetRandomWord();
            Console.WriteLine("You have 7 guesses to uncover the secret word.\n" +
                $"The secret word is {word.NumberOfLettersInWord} letters long.\n" +
                $"Clue: {word.Clue}\n");
            Console.WriteLine("");

            List<string> listOfLetters = new List<string>(word.Word.Length);
            bool hasWon = false;
            string input;

            for (int i = 0; i < word.Word.Length; i++)
            {
                listOfLetters.Add("_ ");
            }

            while (hasWon == false)
            {
                Console.WriteLine("Guess a letter:");
                foreach (string letter in listOfLetters)
                {
                    Console.Write(letter);
                }

                Console.WriteLine();


                input = Console.ReadLine().ToLower();

                if (word.Word.Contains(input) == true)
                {
                    Console.WriteLine("" +
                        "Correct!");
                    char guess = input[0];
                    HangManDrawings(chances);


                    for (int i = 0; i < word.Word.Length; i++)
                    {
                        if (word.Word[i].Equals(guess) == true)
                        {
                            listOfLetters[i] = input;
                        }

                    }


                    if (listOfLetters.Contains("_ ") == false)
                    {
                        hasWon = true;
                        Console.WriteLine("" +
                            $"YOU WON! The secret word was {word.Word}.\n" +
                            $" Would you like to play again? (y/n).");
                        string input1 = Console.ReadLine().ToLower();

                        if (input1 == "y")
                        {
                            Beginner();
                        }
                        else if (input1 == "n")
                        {
                            Menu();
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid choice.");
                        }
                    }
                }

                else
                {
                    --chances;
                    Console.WriteLine($"" +
                        $"Incorrect! You now have {chances} guesses remaining.\n" +
                        $"Clue: {word.Clue}");
                    HangManDrawings(chances);
                }
                if (chances == 0)
                {
                    hasWon = true;
                    Console.WriteLine($"" +
                        $"YOU LOST! The secret word was:{word.Word}.\n" +
                        $"Would you like to play again? (y/n)");
                    HangMan.HangMan07();
                    string input1 = Console.ReadLine().ToLower();

                    if (input1 == "y")
                    {
                        Beginner();
                    }
                    else if (input1 == "n")
                    {
                        Menu();
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid choice.");
                    }
                }
            }

        }

        private void Intermmediate()
        {
            HangManRepo HangMan = new HangManRepo();
            int chances = 7;
            Console.Clear();

            IntermmediateWords word = _repoIntermmediate.GetRandomWord();
            Console.WriteLine("You have 7 guesses to uncover the secret word.\n" +
                $"The secret word is {word.Word.Length} letters long.\n" +
                $"Clue: {word.Clue}\n");
            Console.WriteLine("");

            List<string> listOfLetters = new List<string>(word.Word.Length);
            bool hasWon = false;
            string input;

            for (int i = 0; i < word.Word.Length; i++)
            {
                listOfLetters.Add("_ ");
            }

            while (hasWon == false)
            {
                Console.WriteLine("Guess a letter:");
                foreach (string letter in listOfLetters)
                {
                    Console.Write(letter);
                }

                Console.WriteLine();


                input = Console.ReadLine().ToLower();

                if (word.Word.Contains(input) == true)
                {
                    Console.WriteLine("" +
                        "Correct!");
                    char guess = input[0];
                    HangManDrawings(chances);


                    for (int i = 0; i < word.Word.Length; i++)
                    {
                        if (word.Word[i].Equals(guess) == true)
                        {
                            listOfLetters[i] = input;
                        }

                    }


                    if (listOfLetters.Contains("_ ") == false)
                    {
                        hasWon = true;
                        Console.WriteLine("" +
                            $"YOU WON! The secret word was {word.Word}.\n" +
                            $" Would you like to play again? (y/n).");
                        string input1 = Console.ReadLine().ToLower();

                        if (input1 == "y")
                        {
                            Beginner();
                        }
                        else if (input1 == "n")
                        {
                            Menu();
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid choice.");
                        }
                    }
                }

                else
                {
                    --chances;
                    Console.WriteLine($"" +
                        $"Incorrect! You now have {chances} guesses remaining.\n" +
                        $"Clue: {word.Clue}");
                    HangManDrawings(chances);
                }
                if (chances == 0)
                {
                    hasWon = true;
                    Console.WriteLine($"" +
                        $"YOU LOST! The secret word was:{word.Word}.\n" +
                        $"Would you like to play again? (y/n)");
                    HangMan.HangMan07();
                    string input1 = Console.ReadLine().ToLower();

                    if (input1 == "y")
                    {
                        Beginner();
                    }
                    else if (input1 == "n")
                    {
                        Menu();
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid choice.");
                    }
                }
            }

        }

        private void Expert()
        {
            HangManRepo HangMan = new HangManRepo();
            int chances = 7;
            Console.Clear();

            DifficultWords word = _repoDifficult.GetRandomWord();
            Console.WriteLine("You have 7 guesses to uncover the secret word.\n" +
                $"The secret word is {word.Word.Length} letters long.\n" +
                $"Clue: {word.Clue}\n");
            Console.WriteLine("");

            List<string> listOfLetters = new List<string>(word.Word.Length);
            bool hasWon = false;
            string input;

            for (int i = 0; i < word.Word.Length; i++)
            {
                listOfLetters.Add("_ ");
            }

            while (hasWon == false)
            {
                Console.WriteLine("Guess a letter:");
                foreach (string letter in listOfLetters)
                {
                    Console.Write(letter);
                }

                Console.WriteLine();


                input = Console.ReadLine().ToLower();

                if (word.Word.Contains(input) == true)
                {
                    Console.WriteLine("" +
                        "Correct!");
                    char guess = input[0];
                    HangManDrawings(chances);


                    for (int i = 0; i < word.Word.Length; i++)
                    {
                        if (word.Word[i].Equals(guess) == true)
                        {
                            listOfLetters[i] = input;
                        }

                    }


                    if (listOfLetters.Contains("_ ") == false)
                    {
                        hasWon = true;
                        Console.WriteLine("" +
                            $"YOU WON! The secret word was {word.Word}.\n" +
                            $" Would you like to play again? (y/n).");
                        string input1 = Console.ReadLine().ToLower();

                        if (input1 == "y")
                        {
                            Beginner();
                        }
                        else if (input1 == "n")
                        {
                            Menu();
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid choice.");
                        }
                    }
                }

                else
                {
                    --chances;
                    Console.WriteLine($"" +
                        $"Incorrect! You now have {chances} guesses remaining.\n" +
                        $"Clue: {word.Clue}");
                    HangManDrawings(chances);
                }
                if (chances == 0)
                {
                    hasWon = true;
                    Console.WriteLine($"" +
                        $"YOU LOST! The secret word was:{word.Word}.\n" +
                        $"Would you like to play again? (y/n)");
                    HangMan.HangMan07();
                    string input1 = Console.ReadLine().ToLower();

                    if (input1 == "y")
                    {
                        Beginner();
                    }
                    else if (input1 == "n")
                    {
                        Menu();
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid choice.");
                    }
                }
            }
        }

        private void Rules()
        {
            string dashes = "-------------------";
            Console.Clear();
            Console.WriteLine("-----HangMan-----\n" +
                "The rules of HangMan are simple:\n" +
                "" +
                "You must guess the word before the stickman is hanged.\n" +
                "It is your responsibility to save the stickman from his untimely death!\n" +
                "You have 7 guesses to guess to word correctly.\n" +
                "If you do not guess the word within those 7 guesses, the stickman will meet his stick maker.\n" +
                "If you do guess the word within the allotted amount of guesses, the stickman is saved and you win the game!\n" +
                $"{dashes}\n" +
                $"If you guess a correct letter, a portion of the stickman will not be drawn.\n" +
                $"If you guess incorrectly, then a portion of the stickman's body will be added to the gallow.\n" +
                $"{dashes}\n" +
                $"Press any key if you are finished reading the rules:");
            Console.ReadKey();
        }
        private void SeedBeginnerWords()
        {
            BeginnerWords word1 = new BeginnerWords("indiana", "State", 7);
            BeginnerWords word2 = new BeginnerWords("pizza", "Food", 5);
            BeginnerWords word3 = new BeginnerWords("golf", "Sport", 4);
            BeginnerWords word4 = new BeginnerWords("fish", "Pet", 5);
            BeginnerWords word5 = new BeginnerWords("france", "Country", 6);
            BeginnerWords word6 = new BeginnerWords("snake", "Animal", 5);
            BeginnerWords word7 = new BeginnerWords("pacific", "Ocean", 7);
            BeginnerWords word8 = new BeginnerWords("everest", "Mountain", 7);
            BeginnerWords word9 = new BeginnerWords("willow", "Tree", 6);
            BeginnerWords word10 = new BeginnerWords("pacers", "NBA Team", 6);
            BeginnerWords word11 = new BeginnerWords("trumpet", "Musical Instrument", 7);
            BeginnerWords word12 = new BeginnerWords("arizona", "State", 7);
            BeginnerWords word13 = new BeginnerWords("piano", "Musical Instrument", 5);
            BeginnerWords word14 = new BeginnerWords("noodles", "Food", 7);
            BeginnerWords word15 = new BeginnerWords("china", "Country", 5);
            BeginnerWords word16 = new BeginnerWords("ford", "Car Make", 4);
            BeginnerWords word17 = new BeginnerWords("zion", "National Park", 4);
            BeginnerWords word18 = new BeginnerWords("maine", "State", 5);
            BeginnerWords word19 = new BeginnerWords("tacos", "Food", 5);
            BeginnerWords word20 = new BeginnerWords("ostrich", "Type of Bird", 7);

            _repo.AddWordsToList(word1);
            _repo.AddWordsToList(word2);
            _repo.AddWordsToList(word3);
            _repo.AddWordsToList(word4);
            _repo.AddWordsToList(word5);
            _repo.AddWordsToList(word6);
            _repo.AddWordsToList(word7);
            _repo.AddWordsToList(word8);
            _repo.AddWordsToList(word9);
            _repo.AddWordsToList(word10);
            _repo.AddWordsToList(word11);
            _repo.AddWordsToList(word12);
            _repo.AddWordsToList(word13);
            _repo.AddWordsToList(word14);
            _repo.AddWordsToList(word15);
            _repo.AddWordsToList(word16);
            _repo.AddWordsToList(word17);
            _repo.AddWordsToList(word18);
            _repo.AddWordsToList(word19);
            _repo.AddWordsToList(word20);
        }
        private void HangManDrawings(int chances)
        {
            HangManRepo Hangman = new HangManRepo();

            switch (chances)
            {
                case 7: 
                    Hangman.HangMan00();
                    break;
                case 6:
                    Hangman.HangMan01();
                    break;
                case 5:
                    Hangman.HangMan02();
                    break;
                case 4:
                    Hangman.HangMan03();
                    break;
                case 3:
                    Hangman.HangMan04();
                    break;
                case 2:
                    Hangman.HangMan05();
                    break;
                case 1:
                    Hangman.HangMan06();
                    break;
            }
        }
        private void SeedIntermmediateWords()
        {
            IntermmediateWords word1 = new IntermmediateWords("croquet", "Yard Game");
            IntermmediateWords word2 = new IntermmediateWords("snickerdoodle", "Type of Cookie");
            IntermmediateWords word3 = new IntermmediateWords("carribean", "Vacation Destination");
            IntermmediateWords word4 = new IntermmediateWords("philadelphia", "City (American)");
            IntermmediateWords word5 = new IntermmediateWords("dumbbell", "Exercise equipment");
           IntermmediateWords word6 = new IntermmediateWords("valporaiso", "University in Indiana");
           IntermmediateWords word7 = new IntermmediateWords("yesterday", "Beatle's Song");
           IntermmediateWords word8 = new IntermmediateWords("denali", "Mountain");
            IntermmediateWords word9 = new IntermmediateWords("monet", "Artist");
            IntermmediateWords word10 = new IntermmediateWords("mitochondria", "Part of the Cell");
            IntermmediateWords word11 = new IntermmediateWords("triangle", "Musical Instrument");
            IntermmediateWords word12 = new IntermmediateWords("delaware", "State");
            IntermmediateWords word13 = new IntermmediateWords("hockey", "Sport");
            IntermmediateWords word14 = new IntermmediateWords("hamlet", "Shakesperean Play");
            IntermmediateWords word15 = new IntermmediateWords("panther", "Animal");
            IntermmediateWords word16 = new IntermmediateWords("titanic", "Movie");
           IntermmediateWords word17 = new IntermmediateWords("madagascar", "Island");
            IntermmediateWords word18 = new IntermmediateWords("zimbabwe", "Country");
           IntermmediateWords word19 = new IntermmediateWords("kidney", "Organ");
           IntermmediateWords word20 = new IntermmediateWords("dodo", "Type of Bird");

            _repoIntermmediate.AddWordsToList(word1);
            _repoIntermmediate.AddWordsToList(word2);
            _repoIntermmediate.AddWordsToList(word3);
            _repoIntermmediate.AddWordsToList(word4);
            _repoIntermmediate.AddWordsToList(word5);
            _repoIntermmediate.AddWordsToList(word6);
            _repoIntermmediate.AddWordsToList(word7);
            _repoIntermmediate.AddWordsToList(word8);
            _repoIntermmediate.AddWordsToList(word9);
            _repoIntermmediate.AddWordsToList(word10);
            _repoIntermmediate.AddWordsToList(word11);
            _repoIntermmediate.AddWordsToList(word12);
            _repoIntermmediate.AddWordsToList(word13);
            _repoIntermmediate.AddWordsToList(word14);
            _repoIntermmediate.AddWordsToList(word15);
            _repoIntermmediate.AddWordsToList(word16);
            _repoIntermmediate.AddWordsToList(word17);
            _repoIntermmediate.AddWordsToList(word18);
            _repoIntermmediate.AddWordsToList(word19);
            _repoIntermmediate.AddWordsToList(word20);
        }
        private void SeedDifficultWords() 
        { 
            DifficultWords word1 = new DifficultWords("maserati", "Car Make");
            DifficultWords word2 = new DifficultWords("twix", "Candy Bar");
            DifficultWords word3 = new DifficultWords("carribean", "Vacation Destination");
            DifficultWords word4 = new DifficultWords("spongebob", "Cartoon Character");
            DifficultWords word5 = new DifficultWords("ghana", "Country");
            DifficultWords word6 = new DifficultWords("valporaiso", "University in Indiana");
            DifficultWords word7 = new DifficultWords("yesterday", "Beatle's Song");
            DifficultWords word8 = new DifficultWords("denali", "Mountain");
            DifficultWords word9 = new DifficultWords("monet", "Artist");
            DifficultWords word10 = new DifficultWords("mitochondria", "Part of the Cell");
            DifficultWords word11 = new DifficultWords("triangle", "Musical Instrument");
            DifficultWords word12 = new DifficultWords("delaware", "State");
            DifficultWords word13 = new DifficultWords("hockey", "Sport");
            DifficultWords word14 = new DifficultWords("hamlet", "Shakesperean Play");
            DifficultWords word15 = new DifficultWords("panther", "Animal");
            DifficultWords word16 = new DifficultWords("titanic", "Movie");
            DifficultWords word17 = new DifficultWords("madagascar", "Island");
            DifficultWords word18 = new DifficultWords("zimbabwe", "Country");
            DifficultWords word19 = new DifficultWords("kidney", "Organ");
            DifficultWords word20 = new DifficultWords("dodo", "Type of Bird");

            _repoDifficult.AddWordsToList(word1);
            _repoDifficult.AddWordsToList(word2);
            _repoDifficult.AddWordsToList(word3);
            _repoDifficult.AddWordsToList(word4);
            _repoDifficult.AddWordsToList(word5);
            _repoDifficult.AddWordsToList(word6);
            _repoDifficult.AddWordsToList(word7);
            _repoDifficult.AddWordsToList(word8);
            _repoDifficult.AddWordsToList(word9);
            _repoDifficult.AddWordsToList(word10);
            _repoDifficult.AddWordsToList(word11);
            _repoDifficult.AddWordsToList(word12);
            _repoDifficult.AddWordsToList(word13);
            _repoDifficult.AddWordsToList(word14);
            _repoDifficult.AddWordsToList(word15);
            _repoDifficult.AddWordsToList(word16);
            _repoDifficult.AddWordsToList(word17);
            _repoDifficult.AddWordsToList(word18);
            _repoDifficult.AddWordsToList(word19);
            _repoDifficult.AddWordsToList(word20);
        }
    }
}
