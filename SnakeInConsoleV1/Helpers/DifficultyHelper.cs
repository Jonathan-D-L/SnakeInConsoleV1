﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SnakeInConsoleV1.Helpers
{
    internal static class DifficultyHelper
    {
        public static void CurrentDifficultySpeed(int difficulty, int level)
        {
            if (difficulty == 0)
            {
                if (level == 0)
                    Thread.Sleep(250);
                if (level == 1)
                    Thread.Sleep(225);
                if (level == 2)
                    Thread.Sleep(175);
                if (level >= 3)
                    Thread.Sleep(150);
            }
            else if (difficulty == 1)
            {
                if (level == 0)
                    Thread.Sleep(150);
                if (level == 1)
                    Thread.Sleep(125);
                if (level == 2)
                    Thread.Sleep(100);
                if (level >= 3)
                    Thread.Sleep(75);

            }
            else if (difficulty == 2)
            {
                if (level == 0)
                    Thread.Sleep(75);
                if (level == 1)
                    Thread.Sleep(60);
                if (level == 2)
                    Thread.Sleep(45);
                if (level >= 3)
                    Thread.Sleep(30);
            }
        }
    }
}
