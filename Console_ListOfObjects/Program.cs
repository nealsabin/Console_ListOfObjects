using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using System.Linq;

namespace Console_ListOfObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = InitializeAnimalList();

            DisplayMenuScreen(animals);
        }

        static void DisplayMenuScreen(List<Animal> animals)
        {
            bool quitApplication = false;
            string menuChoice;

            do
            {
                Console.Clear();
                Console.WriteLine("---------------");
                Console.WriteLine("---Main Menu---");
                Console.WriteLine("---------------");
                Console.WriteLine();
                Console.WriteLine("a) Add Animal");
                Console.WriteLine("b) Display Animals");
                Console.WriteLine("c) Write Animals to File");
                menuChoice = Console.ReadLine().ToLower();

                switch (menuChoice)
                {
                    case "a":
                        AddAnimal(animals);
                        break;
                    case "b":
                        DisplayAnimals(animals);
                        break;
                    case "c":
                        WriteToDataFile(animals);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t************************************************");
                        Console.WriteLine("\tPlease indicate your choice with a letter shown.");
                        Console.WriteLine("\t************************************************");
                        Console.ForegroundColor = ConsoleColor.Black;

                        Console.WriteLine();
                        Console.CursorVisible = false;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\tPress any key to continue.");
                        Console.ReadKey();
                        Console.CursorVisible = true;
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            } while (!quitApplication);

        }
        static void WriteToDataFile(List<Animal> animals)
        {
            Console.Clear();
            Console.WriteLine("Data writen to file.");

            string[] animalStrings = new string[animals.Count];

            //
            // create the array of ride string
            //
            for (int index = 0; index < animals.Count; index++)
            {
                //
                // create ride string
                //
                string animalString =
                    animals[index].AnimalName + "," +
                    animals[index].SpeciesName + "," +
                    animals[index].AnimalAge + "," +
                    animals[index].Diet + "," +
                    animals[index].Mammal;

                //
                // add ride string to array
                //
                animalStrings[index] = animalString;
            }

            //
            // write array to data file
            //
            File.WriteAllLines("Data\\Data.txt", animalStrings);
            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        static void AddAnimal(List<Animal> animals)
        {
            bool doneAdding = false;

            do
            {
                Console.Clear();
                Console.WriteLine("----------------");
                Console.WriteLine("---Add Animal---");
                Console.WriteLine("----------------");
                Console.WriteLine();
                Animal newAnimal = new Animal();
                bool validResponse;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Animal Name: ");
                Console.ForegroundColor = ConsoleColor.White;
                newAnimal.AnimalName = Console.ReadLine();

                while (string.IsNullOrWhiteSpace(newAnimal.AnimalName))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Animal name can not be empty.");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Animal Name: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    newAnimal.AnimalName = Console.ReadLine();
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Species Name: ");
                Console.ForegroundColor = ConsoleColor.White;
                newAnimal.SpeciesName = Console.ReadLine();


                while (string.IsNullOrWhiteSpace(newAnimal.SpeciesName))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Species name can not be empty.");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Species Name: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    newAnimal.SpeciesName = Console.ReadLine();
                }

                do
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Age: ");
                    Console.ForegroundColor = ConsoleColor.White;

                    if (int.TryParse(Console.ReadLine(), out int inputAge) & inputAge > 0)
                    {
                        newAnimal.AnimalAge = inputAge;
                        validResponse = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a valid number; 2, 88, 55");
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        validResponse = false;
                    }
                } while (!validResponse);

                do
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Diet: ");
                    Console.ForegroundColor = ConsoleColor.White;

                    if (Enum.TryParse(Console.ReadLine().ToLower(), out Animal.AnimalDiet inputDiet))
                    {
                        newAnimal.Diet = inputDiet;
                        validResponse = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a valid diet type; carnivore, herbivore, or omnivore");
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        validResponse = false;
                    }
                } while (!validResponse);

                animals.Add(newAnimal);

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Add another? (yes/no)");
                Console.ForegroundColor = ConsoleColor.White;
                string userResponse = Console.ReadLine().ToLower();
                if (userResponse == "no")
                {
                    doneAdding = true;
                }
                else
                { 
                    Console.Clear();
                }

            } while (!doneAdding);





        }

        //static void AnimalInfo(Animal animal)
        //{

        //}

        static void DisplayAnimals(List<Animal> animals)
        {
            Console.Clear();
            Console.WriteLine("---------------------");
            Console.WriteLine("---Display Animals---");
            Console.WriteLine("---------------------");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(
                "Name".PadLeft(14) +
                "Species Name".PadLeft(18) +
                "Age".PadLeft(9) +
                "Diet".PadLeft(10) +
                "Is Mammal".PadLeft(16)
                );
            Console.WriteLine(
                "----".PadLeft(14) +
                "------------".PadLeft(18) +
                "---".PadLeft(9) +
                "----".PadLeft(10) +
                "---------".PadLeft(16)
                );
            Console.ForegroundColor = ConsoleColor.White;


            foreach (Animal animal in animals)
            {
                //AnimalInfo(animal);
                Console.WriteLine(
                animal.AnimalName.PadLeft(15) +
                animal.SpeciesName.PadLeft(15) +
                animal.AnimalAge.ToString().PadLeft(10) +
                animal.Diet.ToString().PadLeft(13) +
                animal.Mammal.ToString().PadLeft(12)
                );
                Console.WriteLine();
            }

            int count = animals.Count();
            double total = (animals.Sum(item => item.AnimalAge) / count);

            Console.WriteLine();
            Console.WriteLine("---------------------");
            Console.WriteLine("-----Animal Stats----");
            Console.WriteLine("---------------------");
            Console.WriteLine();
            Console.WriteLine("Number of animals: " + count);
            Console.WriteLine("Average Age: " + total);
            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }



        static List<Animal> InitializeAnimalList()
        {
            List<Animal> animals = new List<Animal>()
            {
                new Animal()
                {
                    AnimalName = "George",
                    SpeciesName = "Monkey",
                    AnimalAge = 3,
                    Diet = Animal.AnimalDiet.omnivore,
                    Mammal = true
                },

                new Animal()
                {
                    AnimalName = "Franklin",
                    SpeciesName = "Turtle",
                    AnimalAge = 44,
                    Diet = Animal.AnimalDiet.omnivore,
                    Mammal = false
                }
            };

            return animals;
        }

    }
}
