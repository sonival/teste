
using LocateFriends.Repository;
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
            Utils.Message("Commandos: (F)inalizar (R)egistrar (L)istar (G)Lista amigos por proximidade (LIMPAR-REGISTROS)");            
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

        public static double GetDistance(Coordinates c1, Coordinates c2)
        {

            double resp = 0;
            double d = c1.Latitude * 0.017453292519943295;
            double num3 = c1.Longitude * 0.017453292519943295;
            double num4 = c2.Latitude * 0.017453292519943295;
            double num5 = c2.Longitude * 0.017453292519943295;
            double num6 = num5 - num3;
            double num7 = num4 - d;
            double num8 = Math.Pow(Math.Sin(num7 / 2.0), 2.0) + ((Math.Cos(d) * Math.Cos(num4)) * Math.Pow(Math.Sin(num6 / 2.0), 2.0));
            double num9 = 2.0 * Math.Atan2(Math.Sqrt(num8), Math.Sqrt(1.0 - num8));
            resp = (6376500.0 * num9);
            return resp;
        }
    }
}
