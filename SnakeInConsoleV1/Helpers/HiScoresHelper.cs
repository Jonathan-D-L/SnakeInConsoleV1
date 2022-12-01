using Newtonsoft.Json;
using SnakeInConsoleV1.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SnakeInConsoleV1.Helpers
{
    internal static class HiScoresHelper
    {
        static readonly string directory = "Files";
        static readonly string fileName = "HiScoresHelper.json";
        public static List<playerScore> GetHiScoresFromFile()
        {
            var scores = new List<playerScore>();
            if (File.Exists($"{directory}\\{fileName}"))
            {
                string jsonProductsFile = File.ReadAllText($"{directory}\\{fileName}");
                var productsInFile = JsonConvert.DeserializeObject<IEnumerable<playerScore>>(jsonProductsFile);
                if (productsInFile != null)
                    scores.AddRange(productsInFile);
            }
            if (scores.Any())
            {
                var orderedScore = scores.OrderByDescending(s => s.Score).ToList();
                return orderedScore;
            }
            return scores;

        }
        public static void AddHiScore(string playerName, int[] fruitAndScore)
        {
            var scores = new List<playerScore>();
            scores = GetHiScoresFromFile();
            bool newHiScore = scores.Any(s => s.Name == playerName && s.Score <= fruitAndScore[1]);
            if (newHiScore == true)
            {
                scores.First(n => n.Name == playerName).Score = fruitAndScore[1];
            }
            bool newHiScoreAndPlayer = scores.Any(s => s.Name == playerName);
            if (newHiScoreAndPlayer == false && playerName != string.Empty)
            {
                scores.Add(new playerScore(playerName, fruitAndScore[1]));
            }
            scores = scores.OrderByDescending(s => s.Score).ToList();
            while (scores.Count > 10)
            {
                scores.RemoveAt(scores.Count - 1);
            }
            if (File.Exists($"{directory}\\{fileName}"))
            {
                string HiscoresFile = $"{directory}\\{fileName}";
                string addHiScores = JsonConvert.SerializeObject(scores, Formatting.Indented);
                File.WriteAllText(HiscoresFile, addHiScores);
            }
        }
        public static void CheckForHiScoresFile()
        {
            if (!File.Exists($"{directory}\\{fileName}"))
            {
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                var createFile = File.Create($"{directory}\\{fileName}");
                createFile.Close();
            }

        }

    }
}
