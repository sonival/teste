
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

        public static void PrintHeader(string msg="")
        {
            ConsoleColor foreColor = Console.ForegroundColor;
            ConsoleColor BackColor = Console.BackgroundColor;
            Console.Clear();
            
            Utils.Message("REGISTRAR/LOCALIZAR AMIGOS ...");
            Utils.Message("Commandos: (F)inalizar (R)egistrar (L)istar (LIMPAR-REGISTROS)");            
            Utils.PrintLine("-");
            if (!string.IsNullOrEmpty(msg))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Message(msg);
                Console.ForegroundColor = foreColor;
            }
            
        }

        public static void PrintError(string msg)
        {
            ConsoleColor foreColor = Console.ForegroundColor;
            ConsoleColor BackColor = Console.BackgroundColor;
            PrintHeader();
            Console.ForegroundColor = ConsoleColor.Red;
            Message(msg);
            Console.ForegroundColor = foreColor;

        }
    }
}
