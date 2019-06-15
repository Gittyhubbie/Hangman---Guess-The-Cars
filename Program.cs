using System;
using System.Threading;
using static System.Console;

namespace Hangman
{
    class Program
    {

        public static bool finished, success=true; 

        static int faults = 0; 

        static void Main(string[] args)
        {

            finished = false;

        string[] DudesHanging = new string[8];

        DudesHanging = HangDudes;

//Main gameloop *************************************************************************************************************************************************************

            while (true) 
            {

                Clear(); finished = false; faults = 0;

                string word = MakeWord.ToLower(); string[] usedLetters = null;
            
                char[] Solution = new char[word.Length];

                for (int i = 0; i < Solution.Length; i++)
                {
                    Solution[i] = '.';
                }

                WriteLine(DudesHanging[faults]);

                WriteLine("Welcome to Hangman"); WriteLine();

                while (!finished)
                {
                    finished = true;

                    WriteLine("Gjett en bokstav");
                    WriteLine();

                    string inputLetter = ReadLine().ToLower();



                    if (inputLetter.Length == 1) //Input length validation
                    {

                        char inputChar = inputLetter[0];

                        if (word.Contains(inputLetter))
                        {

//Checking if letter is already used ******************************************************************************************************

                            if (usedLetters == null) //checks if no letters are used yet
                            {
                                usedLetters = new string[word.Length];

                                usedLetters[0] = inputLetter;
                            }

                            else
                            {
                                bool add = true;

                                foreach (var item in usedLetters)
                                {

                                    if (item == inputLetter)
                                    { WriteLine(); WriteLine("Already Used");  WriteLine(); add = false; }

                                }

                                if (add) usedLetters[usedLetters.Length - 1] = inputLetter;
                            }

 //*****************************************************************************************************************************************
                            int j = 0;
                            foreach (var item in word)
                            {
                                if (inputChar == item)
                                {

                                    Solution[j] = inputChar;

                                }
                                
                                Write(Solution[j]);

                                j++;
                            }


                        }
                        else { faults++; WriteLine(DudesHanging[faults]);  }

                        foreach (var item in Solution)
                        {
                            if (item == '.') finished = false;
                        }


                        if (faults >= DudesHanging.Length-1)
                        {
                            success = false;

                            for (int i = 0; i < 10; i++)
                            {
                                Thread.Sleep(250);
                                WriteLine("game over man");
                            }
                             finished = true; break;
                        }

                    }

                }

                if (success)
                {

                    for (int i = 0; i < 10; i++)
                    {
                        Thread.Sleep(250);
                        WriteLine();
                        WriteLine("You made it, clever you!");
                    }
                }

            }
//Main gameloop end**********************************************************************************************************************************************************

        }


        public static string MakeWord
        {
            get
            { //Makes an array of words and returns them

                string[] CarBrands = new string[] {
"Alfa Romeo",
"Aston Martin",
"Audi",
"Bentley",
"Benz",
"BMW",
"Bugatti",
"Cadillac",
"Chevrolet",
"Chrysler",
"Citroen",
"Corvette",
"DAF",
"Dacia",
"Daewoo",
"Daihatsu",
"Datsun",
"De Lorean",
"Dino",
"Dodge",
"Farboud",
"Ferrari",
"Fiat",
"Ford",
"Honda",
"Hummer",
"Hyundai",
"Jaguar",
"Jeep",
"KIA",
"Koenigsegg",
"Lada",
"Lamborghini",
"Lancia",
"Land Rover",
"Lexus",
"Ligier",
"Lincoln",
"Lotus",
"Martini",
"Maserati",
"Maybach",
"Mazda",
"McLaren",
"Mercedes",
"Mercedes Benz",
"Mini",
"Mitsubishi",
"Nissan",
"Noble",
"Opel",
"Peugeot",
"Pontiac",
"Porsche",
"Renault",
"Rolls-Royce",
"Rover",
"Saab",
"Seat",
"Skoda",
"Smart",
"Spyker",
"Subaru",
"Suzuki",
"Tesla",
"Think",
"Toyota",
"Vauxhall",
"Volkswagen",
"Volvo"
            };


                Random random = new Random();

                int i = random.Next(CarBrands.Length);

                string CarBrand = CarBrands[i];

                return CarBrand;

            }
        }

        public static string[] HangDudes
        {
            get
            {


                string[] dudes = { @"
 +---+
     |
     |
     |
     |
     |
=========", @"
 +---+
 |   |
     |
     |
     |
     |
=========", @"
 +---+
 |   |
 O   |
     |
     |
     |
=========", @"
 +---+
 |   |
 O   |
 |   |
     |
     |
=========", @"
 +---+
 |   |
 O   |
/|   |
     |
     |
=========", @"
 +---+
 |   |
 O   |
/|\  |
     |
     |
=========", @"
 +---+
 |   |
 O   |
/|\  |
/    |
     |
=========", @"
 +---+
 |   |
 O   |
/|\  |
/ \  |
     |
=========" };
                return dudes;
            }
        }
    }
}
