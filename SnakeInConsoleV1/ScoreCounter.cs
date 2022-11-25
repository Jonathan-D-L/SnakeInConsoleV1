using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeInConsoleV1
{
    internal class ScoreCounter
    {
        public string GetScore(int score)
        {

            var s = score.ToString();
            var spacesNeded = 49 - s.Length;
            var scoreSpace = "";
            for (int i = 0; i < spacesNeded; i++)
            {
                scoreSpace += " ";
            }
            var scoreString = $"    SCORE: {score}{scoreSpace}";
            return scoreString;
        }
    }
}
