﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeInConsoleV1.Helpers
{
    internal static class PlayerInputHelper
    {
        public static char GetPLayerInput(char action, List<ConsoleKeyInfo> keyList)
        {
            while (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true);
                if (key.KeyChar != action && keyList.Count < 2 && keyList.Any(k => k == key) == false)
                {
                    keyList.Add(key);
                }
            }
            if (keyList.Count > 0)
            {
                var singleKey = keyList.First();
                switch (singleKey.Key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        if (action != 's')
                            action = 'w';
                        break;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        if (action != 'w')
                            action = 's';
                        break;
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        if (action != 'd')
                            action = 'a';
                        break;
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        if (action != 'a')
                            action = 'd';
                        break;
                }
            }
            return action;
        }
    }
}
