using System;

class Program
{
    static void Main(string[] args)
    {
        // Exceeded requirements by adding a simple menu option that lets
        // the user see how many activities they completed in this session.
        int completedActivities = 0;
        int choice = 0;

        while (choice != 5)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflection activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. View completed activities");
            Console.WriteLine("  5. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = int.Parse(Console.ReadLine() ?? "0");

            if (choice == 1)
            {
                BreathingActivity activity = new BreathingActivity();
                activity.Run();
                completedActivities++;
            }
            else if (choice == 2)
            {
                ReflectionActivity activity = new ReflectionActivity();
                activity.Run();
                completedActivities++;
            }
            else if (choice == 3)
            {
                ListingActivity activity = new ListingActivity();
                activity.Run();
                completedActivities++;
            }
            else if (choice == 4)
            {
                Console.Clear();
                Console.WriteLine($"You have completed {completedActivities} activities in this session.");
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();
            }
        }
    }
}
