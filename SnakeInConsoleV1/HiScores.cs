using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void AddHiScore(string playerName, int score, int difficulty)
        {
            var directory = "Files";
            var fileName = "Hiscores.txt";
            if(difficulty == 0)
            {
                score *= 1;
            }
            if(difficulty == 1)
            {
                score = Convert.ToInt32(Math.Floor(score * 1.5));
            }
            if(difficulty == 2)
            {
                score *= 2;
            }
            if (File.Exists($"{directory}\\{fileName}"))
            {
                if (playerName != string.Empty)
                {
                    var playerNameAndScore = $"{playerName}|{score}\r\n";
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
