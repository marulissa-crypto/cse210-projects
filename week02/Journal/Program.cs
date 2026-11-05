using System;

// ============================================================================
// EXCEEDING REQUIREMENTS NOTE:
// 1. Added a 'Mood' tracking feature that prompts the user to log their emotional 
//    state alongside each entry, adding valuable depth to personal reflection.
// 2. Implemented full CSV file formatting and parsing (properly handling 
//    commas, quotes, and multi-word fields) so the saved journal file can be 
//    opened seamlessly in Microsoft Excel or Google Sheets.
// ============================================================================
class Program
{
    static void Main(string[] args)
    {
        Journal theJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        int choice = 0;

        Console.WriteLine("Welcome to the Journal Program!");

        while (choice != 5)
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string userInput = Console.ReadLine();
            if (int.TryParse(userInput, out choice))
            {
                switch (choice)
                {
                    case 1:
                        string prompt = promptGenerator.GetRandomPrompt();
                        Console.WriteLine($"\nPrompt: {prompt}");
                        Console.Write("> ");
                        string response = Console.ReadLine();

                        Console.Write("How would you rate your mood today (e.g., Happy, Reflective, Peaceful)? ");
                        string mood = Console.ReadLine();

                        string date = DateTime.Now.ToShortDateString();

                        Entry newEntry = new Entry(date, prompt, response, mood);
                        theJournal.AddEntry(newEntry);
                        Console.WriteLine("Entry added successfully!\n");
                        break;

                    case 2:
                        Console.WriteLine("\n--- Journal Entries ---");
                        theJournal.DisplayJournal();
                        break;

                    case 3:
                        Console.Write("\nEnter filename to save (e.g., journal.csv): ");
                        string saveFile = Console.ReadLine();
                        theJournal.SaveToFile(saveFile);
                        break;

                    case 4:
                        Console.Write("\nEnter filename to load: ");
                        string loadFile = Console.ReadLine();
                        theJournal.LoadFromFile(loadFile);
                        break;

                    case 5:
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please select a number between 1 and 5.\n");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.\n");
            }
        }
    }
}