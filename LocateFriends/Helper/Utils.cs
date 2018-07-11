
using System;

namespace LocateFriends.Helper
{
    public static class Utils
    {
        public static void Message(string msg)
        {
            Console.WriteLine(msg);
        }

        public static void PrintLine(string line)
        {
            //Console.CursorTop = Console.WindowHeight - 1;
            //Console.SetCursorPosition(0, Console.CursorTop);
            Console.BufferWidth = Console.WindowWidth;
            //Console.BufferHeight = Console.WindowHeight;

            for (int i = 0; i < Console.BufferWidth; i++)
            {
                Console.Write(line);
            }
                
            
            //Console.CursorTop = 0;
            //Console.BufferWidth = Console.WindowWidth;
            //Console.BufferHeight = Console.WindowHeight;
        }
    }
}
