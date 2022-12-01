using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeInConsoleV1.Helpers
{
    internal static class ColorSetHelper
    {
        public static List<string> GetGreenSet()
        {
            var colours = new List<string>();
            string snakeAndBorder = "78,95,39";
            string background = "191,221,114";
            string fruit = "200,30,30";
            colours.Add(snakeAndBorder);
            colours.Add(background);
            colours.Add(fruit);
            return colours;
        }
        public static List<string> GetBlueSet()
        {
            var colours = new List<string>();
            string snakeAndBorder = "39,69,94";
            string background = "114,172,221";
            string fruit = "200,117,30";
            colours.Add(snakeAndBorder);
            colours.Add(background);
            colours.Add(fruit);
            return colours;
        }
        public static List<string> GetPurpleSet()
        {
            var colours = new List<string>();
            string snakeAndBorder = "69,39,94";
            string background = "172,114,221";
            string fruit = "200,186,30";
            colours.Add(snakeAndBorder);
            colours.Add(background);
            colours.Add(fruit);
            return colours;
        }
        public static List<string> GetRedSet()
        {
            var colours = new List<string>();
            string snakeAndBorder = "94,39,39";
            string background = "221,114,114";
            string fruit = "113,200,30";
            colours.Add(snakeAndBorder);
            colours.Add(background);
            colours.Add(fruit);
            return colours;
        }

    }
}
