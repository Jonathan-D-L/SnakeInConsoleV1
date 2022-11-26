using Spectre.Console;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace SnakeInConsoleV1
{
    internal class HiScores
    {
        public List<string> ShowHiScores()
        {
            var scores = new List<string>();
            var directory = "Files";
            var fileName = "Hiscores.txt";
            CheckHiscoresFile();
            foreach (var line in File.ReadLines($"{directory}\\{fileName}"))
            {
                scores.Add(line);
            }
            return scores;

        }
        public void AddHiScore(string playerName, int playerScore, int difficulty)
        {
            var directory = "Files";
            var fileName = "Hiscores.txt";
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
            var scores = new List<string>();
            foreach (var line in File.ReadLines($"{directory}\\{fileName}"))
            {
                scores.Add(line);
            }
            foreach (var s in scores)
            {
                var name = s.Split('|')[0];
                var score = s.Split('|')[1];
                if (playerName == name && playerScore > Convert.ToInt32(score))
                {
                    scores.Remove(score.Where(s => s == name))..;
                }
            }
            if (File.Exists($"{directory}\\{fileName}"))
            {
                if (playerName != string.Empty)
                {
                    var playerNameAndScore = $"{playerName}|{playerScore}\r\n";
                    File.AppendAllText($"{directory}\\{fileName}", playerNameAndScore);
                }
            }
        }
        public void CheckHiscoresFile()
        {
            var directory = "Files";
            var fileName = "Hiscores.txt";
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
