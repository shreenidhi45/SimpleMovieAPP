using System.Configuration;

namespace MovieDisplay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] movies = new string[5];
            int count = 0;
            string filePath = ConfigurationManager.AppSettings["textFile"];

            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null && count < movies.Length)
                    {
                        movies[count] = line;
                        count++;
                    }
                }
            }
            

            while (true)
            {
                Console.WriteLine("1. Add a movie");
                Console.WriteLine("2. Display movies");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter the movie name: ");
                            string movieName = Console.ReadLine();
                            if (count < movies.Length)
                            {
                                movies[count] = movieName;
                                count++;

                                using (StreamWriter writer = new StreamWriter(filePath))
                                {
                                    for (int i = 0; i < count; i++)
                                    {
                                        writer.WriteLine(movies[i]);
                                    }
                                }
                                Console.WriteLine("Movie added successfully!");
                            }
                            else
                            {
                                Console.WriteLine("Movie list is full. Cannot add more movies.");
                            }
                            break;

                        case 2:
                            Console.WriteLine("Movies:");
                            for (int i = 0; i < count; i++)
                            {
                                Console.WriteLine(movies[i]);
                            }
                            break;
                        case 3:
                            Console.WriteLine("Exiting the program...");
                            return;

                        default:
                            Console.WriteLine("Invalid choice. Please enter a valid option.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }
            }
        }
    }
}









 