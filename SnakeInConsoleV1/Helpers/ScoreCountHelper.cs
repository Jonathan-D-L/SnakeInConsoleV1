using SnakeInConsoleV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace SnakeInConsoleV1.Helpers
{
    internal static class ScoreCountHelper
    {
        public static int[] GetScore(int score, int difficulty, int level)
        {
            var fruit = score;
            if (difficulty == 0)
            {
                if (level == 0)
                    score *= 1;
                if (level == 1)
                    score *= 2;
                if (level == 2)
                    score *= 3;
                if (level >= 3)
                    score *= 3;
            }
            if (difficulty == 1)
            {
                if (level == 0)
                    score *= 2;
                if (level == 1)
                    score *= 4;
                if (level == 2)
                    score *= 6;
                if (level >= 3)
                    score *= 8;
            }
            if (difficulty == 2)
            {
                if (level == 0)
                    score *= 4;
                if (level == 1)
                    score *= 8;
                if (level == 2)
                    score *= 12;
                if (level >= 3)
                    score *= 16;

            }
            var fruitAndScore = new int[] { fruit, score };
            return fruitAndScore;
        }
    }
}
