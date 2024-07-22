using CollectFourCore;
using CollectFourCore.Score;
using System;
using System.Collections.Generic;

namespace CollectFour
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowOfField = 6;
            int columnOfField = 7;

            Field field = new Field(rowOfField, columnOfField);
            var start = new ConsoleUI(field);
            start.Menu();
            start.ReadingUserInput();

        }

    }
}
