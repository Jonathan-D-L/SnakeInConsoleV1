using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeInConsoleV1
{
    internal class SnakeHiScores
    {
        public List<string> ShowHiScores()
        {
            var scores = new List<string>();
            var directory = "Files";
            var fileName = "Hiscores.txt";
            foreach (var line in File.ReadLines($"{directory}\\{fileName}"))
            {
                scores.Add(line);
            }
            return scores;

        }
        public void AddHiScore(string playerName, int score)
        {
            var directory = "Files";
            var fileName = "Hiscores.txt";
            if (File.Exists($"{directory}\\{fileName}"))
            {
                var playerNameAndScore = $"{playerName} {score}\r\n";
                File.AppendAllText($"{directory}\\{fileName}", playerNameAndScore);
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
