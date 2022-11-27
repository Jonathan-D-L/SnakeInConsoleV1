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
        public int[] GetScore(int score, int difficulty)
        {
            var fruit = score;
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
            var fruitAndScore = new int[] { fruit, score };
            
            return fruitAndScore;
        }
    }
}
