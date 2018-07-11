using LocateFriends.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocateFriends
{
    class Program
    {
        static void Main(string[] args)
        {
            string commmand = "";
            try
            {
                
                Utils.Message("REGISTRAR/LOCALIZAR AMIGOS ...");
                Utils.Message("Commandos: (F)inalizar (R)egistrar (L)istar");
                Utils.PrintLine("-");
                while (commmand.ToUpper() != "F")
                {
                    commmand = Console.ReadLine();
                }
                

            }
            catch (Exception ex)
            {

                Utils.Message(ex.Message);
            }
            finally
            {

            }
        }
    }
}
