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
using static System.Formats.Asn1.AsnWriter;

namespace SnakeInConsoleV1
{
    internal class HiScores
    {
        public List<playerScore> GetHiScoresFromFile()
        {
            var scores = new List<playerScore>();
            var directory = "Files";
            var fileName = "HiScores.json";
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
        public void AddHiScore(string playerName, int playerScore, int difficulty)
        {
            var directory = "Files";
            var fileName = "HiScores.json";
            if (difficulty == 0)
            {
                playerScore *= 1;
            }
            if (difficulty == 1)
            {
                playerScore = Convert.ToInt32(Math.Floor(playerScore * 1.5));
            }
            if (difficulty == 2)
            {
                playerScore *= 2;
            }
            var scores = new List<playerScore>();
            scores = GetHiScoresFromFile();
            bool newHiScore = scores.Any(s => s.Name == playerName && s.Score > playerScore);
            if (newHiScore == true)
            {
                scores.Find(n => n.Name == playerName).Score = playerScore;
            }
            else
            {
                scores.Add(new playerScore(playerName, playerScore));
            }
            while(scores.Count > 10)
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
        public void CheckForHiScoresFile()
        {
            var directory = "Files";
            var fileName = "HiScores.json";
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
