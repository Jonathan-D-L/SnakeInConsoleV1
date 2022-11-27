﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace SnakeInConsoleV1
{
    internal class RenderScore
    {
        public string ScoreToRendableString(int[] fruitAndScore)
        {
            var fruit = fruitAndScore[0];
            var score = fruitAndScore[1];
            var a = fruit.ToString();
            var s = score.ToString();
            var spacesNededFirst = 23 - a.Length;
            var spacesNededLast = 12 - s.Length;
            var fruitSpace = "";
            var scoreSpace = "";
            for (int i = 0; i < spacesNededFirst; i++)
            {
                fruitSpace += " ";
            }
            for (int i = 0; i < spacesNededLast; i++)
            {
                scoreSpace += " ";
            }
            var scoreString = $"        FRUITS: {fruit}{fruitSpace}  SCORE: {score}{scoreSpace}";
            return scoreString;
        }
    }
}
