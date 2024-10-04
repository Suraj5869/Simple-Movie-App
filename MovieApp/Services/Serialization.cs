using MovieApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MovieApp.Services
{
    internal class Serialization
    {
        static string filePath = ConfigurationManager.AppSettings["filePath"];

        public static void MovieSerializer(Movie[] movies)
        {
            string data = JsonSerializer.Serialize(movies);
            File.WriteAllText(filePath, data);
        }

        public static Movie[] MovieDeserializer()
        {
            if (!File.Exists(filePath)) 
            {
                return new Movie[] {};
            }
            var moviesData = File.ReadAllText(filePath);
            var movies = JsonSerializer.Deserialize<Movie[]>(moviesData);
            return movies;
        }
    }
}
