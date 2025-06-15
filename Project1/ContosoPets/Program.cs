using System;

class Program
{
    static void Main()
    {
        // Declare the 2D array to store up to 10 animals, each with 6 fields
        string[,] ourAnimals = new string[10, 6];

        // Sample data for testing
        ourAnimals[0, 0] = "D001";
        ourAnimals[0, 1] = "dog";
        ourAnimals[0, 2] = "2";
        ourAnimals[0, 3] = "Golden retriever, healthy";
        ourAnimals[0, 4] = "Friendly, playful";
        ourAnimals[0, 5] = "Buddy";

        ourAnimals[1, 0] = "C001";
        ourAnimals[1, 1] = "cat";
        ourAnimals[1, 2] = "3";
        ourAnimals[1, 3] = "Short hair, white";
        ourAnimals[1, 4] = "Calm, loves laps";
        ourAnimals[1, 5] = "Whiskers";

        // Display menu and call functions (Add more features here)
        string menuSelection = "";
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n=== Contoso Pets - Main Menu ===");
            Console.WriteLine("1. List all of our current pet information.");
            Console.WriteLine("2. Assign values to the ourAnimals array fields.");
            Console.WriteLine("Type 'exit' to quit.\n");
            Console.Write("Your selection: ");
            menuSelection = Console.ReadLine().ToLower();

            switch (menuSelection)
            {
                case "1":
                    ListAllAnimals(ourAnimals);
                    break;
                case "2":
                    AddNewAnimal(ourAnimals);
                    break;
                case "exit":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid selection. Try again.");
                    break;
            }
        }
        Console.WriteLine("Thank you for using Contoso Pets. Goodbye!");
    }

    static void ListAllAnimals(string[,] animals)
    {
        Console.WriteLine("\n--- All Current Pets ---");
        Console.WriteLine("ID    | Species | Age | Physical Description       | Personality        | Nickname");
        Console.WriteLine("----------------------------------------------------------------------");

        for (int i = 0; i < animals.GetLength(0); i++)
        {
            if (!string.IsNullOrEmpty(animals[i, 0]))
            {
                Console.WriteLine($"{animals[i, 0],-5} | {animals[i, 1],-7} | {animals[i, 2],-3} | {animals[i, 3],-25} | {animals[i, 4],-17} | {animals[i, 5]}");
            }
        }
    }

    static void AddNewAnimal(string[,] animals)
    {
        for (int i = 0; i < animals.GetLength(0); i++)
        {
            if (string.IsNullOrEmpty(animals[i, 0])) // Find the first empty slot
            {
                Console.Write("\nEnter species (dog or cat): ");
                string species = Console.ReadLine().ToLower();

                while (species != "dog" && species != "cat")
                {
                    Console.Write("Invalid species. Please enter 'dog' or 'cat': ");
                    species = Console.ReadLine().ToLower();
                }

                string idPrefix = (species == "dog") ? "D" : "C";
                string petId = idPrefix + (100 + i).ToString(); // Generate ID

                Console.Write("Enter age (or leave blank if unknown): ");
                string age = Console.ReadLine();

                Console.Write("Enter physical description (or leave blank): ");
                string physical = Console.ReadLine();

                Console.Write("Enter personality description (or leave blank): ");
                string personality = Console.ReadLine();

                Console.Write("Enter nickname (or leave blank): ");
                string nickname = Console.ReadLine();

                // Assigning to the array
                animals[i, 0] = petId;
                animals[i, 1] = species;
                animals[i, 2] = age;
                animals[i, 3] = physical;
                animals[i, 4] = personality;
                animals[i, 5] = nickname;

                Console.WriteLine($"\n✅ Pet added successfully with ID: {petId}");
                return;
            }
        }
        Console.WriteLine("⚠️ Sorry, we cannot accept more animals at this time.");
    }
}
