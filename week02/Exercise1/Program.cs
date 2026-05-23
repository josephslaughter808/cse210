using System;

class Program
{
    static void Main(string[] args)
    {
        // Exceeded requirements by also asking the user for their mood
        // and saving it as part of each journal entry.
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Write");
            Console.WriteLine("  2. Display");
            Console.WriteLine("  3. Load");
            Console.WriteLine("  4. Save");
            Console.WriteLine("  5. Quit");
            Console.Write("Select a choice from the menu: ");

            choice = int.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine();

            if (choice == 1)
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine(prompt);
                Console.Write("> ");
                string response = Console.ReadLine() ?? "";
                Console.Write("How are you feeling today? ");
                string mood = Console.ReadLine() ?? "";

                string date = DateTime.Now.ToShortDateString();
                Entry entry = new Entry(date, prompt, response, mood);
                journal.AddEntry(entry);
                Console.WriteLine();
            }
            else if (choice == 2)
            {
                journal.DisplayAll();
            }
            else if (choice == 3)
            {
                Console.Write("What is the filename? ");
                string fileName = Console.ReadLine() ?? "";
                journal.LoadFromFile(fileName);
                Console.WriteLine();
            }
            else if (choice == 4)
            {
                Console.Write("What is the filename? ");
                string fileName = Console.ReadLine() ?? "";
                journal.SaveToFile(fileName);
                Console.WriteLine();
            }
            else if (choice != 5)
            {
                Console.WriteLine("Invalid choice.");
                Console.WriteLine();
            }
        }
    }
}
