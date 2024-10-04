using MovieApp.Models;
using MovieApp.Services;

namespace MovieApp
{
    internal class Program
    {
        static Movie[] movies;
        static int empty = 0;
        static int size = 0;
        static int fullSize = 5;
        static void Main(string[] args)
        {
            Console.WriteLine("========= Welcome to the Movie App =========");
            //Deserializing the data from json file
            var deserializedMovies = Serialization.MovieDeserializer();

            //checks if the json file is empty or not
            if (deserializedMovies.Count() == 0)
            {
                movies = new Movie[size]; 
            }
            else
            {
                //If the json file contain data it get store in variable along with its size
                movies = deserializedMovies;
                size = movies.Length;
            }

            while (true) 
            {
                Console.WriteLine($"Select option:\n" +
                    $"1. Display Movies\n" +
                    $"2. Add Movies\n" +
                    $"3. Remove all\n" +
                    $"4. Exit\n");

                int choice = int.Parse( Console.ReadLine());
                Console.WriteLine();
                SwitchMenu(choice);
            }   
        }

        private static void SwitchMenu(int choice)
        {
            switch (choice)
            {
                case 1:
                    DisplayMovies(movies);
                    break;
                case 2:
                    AddMovie();
                    break;
                case 3:
                    movies = new Movie[] { };//clear all data from the array with initializing a new instance of the array
                    Serialization.MovieSerializer(movies);
                    break;
                case 4:
                    Serialization.MovieSerializer(movies);
                    Environment.Exit(0);
                    break;
            }
        }

        static void AddMovie()
        {
            if (size == fullSize)//checks if the size of the array is equal to full size (5)
            {
                Console.WriteLine("Movies App is full you cannot insert further!!\n");
            }
            else
            {
                Console.WriteLine("Enter Movie ID:");
                int id = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Movie Name");
                string name = Console.ReadLine();

                Console.WriteLine("Enter Movie Genre:");
                string genre = Console.ReadLine();

                Console.WriteLine("Enter Movie Release Year:");
                int year = int.Parse(Console.ReadLine());
                Console.WriteLine();
                size++;
                Array.Resize(ref movies, size);
                movies[size - 1] = new Movie(id, name, genre, year); //adding into array
            }
        }

        static void DisplayMovies(Movie[] movies)
        {
            foreach (var movie in movies)
            {
                Console.WriteLine(movie);
            } 
        }
    }
}
