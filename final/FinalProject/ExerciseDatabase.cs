using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace FinalProject
{
    public class ExerciseDatabase
    {
        public List<Exercise> Exercises { get; set; }

        public ExerciseDatabase()
        {
            Exercises = new List<Exercise>();
        }

        public void LoadExercises(string filePath = "exercises.json")
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    Exercises = JsonSerializer.Deserialize<List<Exercise>>(json, options) ?? new List<Exercise>();
                }
            }
            catch (System.Exception ex)
            {
                // Handle or log error as needed
                System.Console.WriteLine($"Error loading exercises: {ex.Message}");
                Exercises = new List<Exercise>();
            }
        }

        public List<Exercise> GetExercises()
        {
            return Exercises;
        }
    }
} 