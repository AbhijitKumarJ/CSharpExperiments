namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //show users with  choices from a string array like 1. Show git status 2. Show git log 3. Exit
            string[] options = { "Show git status", "Show git log", "Exit" };
            while (true)
            {
                Console.WriteLine("Choose an option:");
                for (int i = 0; i < options.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {options[i]}");
                }
                string input = Console.ReadLine();
                int choice;
                if (int.TryParse(input, out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            GitUtils.ShowGitStatus(".");
                            break;
                        case 2:
                            GitUtils.ShowGitLog(".");
                            break;
                        case 3:
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }
    }
}