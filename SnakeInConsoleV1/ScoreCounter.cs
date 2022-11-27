using SnakeInConsoleV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeInConsoleV1
{
    internal class ScoreCounter
    {
        public Array GetScore(int score, int difficulty)
        {
            var apples = score;
            if (difficulty == 0)
            {
                score *= 1;
            }
            if (difficulty == 1)
            {
                score *= 2;
            }
            if (difficulty == 2)
            {
                score *= 4;
            }
            var applesAndScore = new int[] { apples, score };
            var a = apples.ToString();
            var s = score.ToString();
            var spacesNededFirst = 23 - a.Length;
            var spacesNededLast = 12 - s.Length;
            var appleSpace = "";
            var scoreSpace = "";
            for (int i = 0; i < spacesNededFirst; i++)
            {
                appleSpace += " ";
            }
            for (int i = 0; i < spacesNededLast; i++)
            {
                scoreSpace += " ";
            }
            var scoreString = $"        FRUITS: {apples}{appleSpace}  SCORE: {score}{scoreSpace}";
            return applesAndScore;
        }
    }
}
