using LocateFriends.Dal;
using LocateFriends.Helper;
using LocateFriends.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocateFriends
{
    class Program
    {
        public static Person Person { get; set; }
        private static DataContext Data = new DataContext();
        private readonly static DL dl = new DL();
        private static string Commmand
        {
            get; set;
        } = "";
        static void Main(string[] args)
        {
            Person = Data.Get();

            try
            {

                Utils.PrintHeader();
                start();


            }
            catch (Exception ex)
            {

                Console.Clear();
                Utils.PrintError(ex.Message);
                start();


            }
            finally
            {

            }
        }

        #region REGISTRAR
        static void Register()
        {
            try
            {
                if (String.IsNullOrEmpty(Person.Name))
                {
                    Utils.Message("Voc� ainda n�o se registrou, por favor se registrar:");
                    Utils.PrintLine(" ");

                    Utils.PrintHeader("Finalizado");
                    var p = RegisterPerson();
                    if (!string.IsNullOrEmpty(p.Name) )
                    {
                        Utils.PrintHeader();
                        Person = p;

                        Register();
                        Data.Save(Person);
                    }

                }
                else
                {
                    Utils.Message(GetMyLocation());
                    Utils.Message("");
                    Utils.Message(String.Format("{0}, registre seus amigos", Person.Name));
                    Utils.PrintLine("*");
                    var f = RegisterPerson();
                    if (!string.IsNullOrEmpty(f.Name))
                    {
                        Person.Friends.Add(f);
                        Data.Save(Person);
                        Utils.PrintHeader("Amigo salvo, com sucesso...");
                        ListFriends();
                    }
                }


            }
            catch (Exception e)
            {

                throw e;
            }

        }
        #endregion


        #region Private Methods

        private static void start()
        {
            while (Commmand.ToUpper() != "F")
            {
                Commmand = "";
                if (string.IsNullOrEmpty(Commmand))
                {
                    Console.Write("Digite o comando: ");
                    Commmand = Console.ReadLine();
                }

                if (Commmand.ToUpper() == "R")
                {
                    Register();
                }
                if (Commmand.ToUpper() == "L")
                {
                    ListFriends();
                }

                if (Commmand.ToUpper() == "G")
                {
                    Utils.PrintHeader();
                    PrintFriendsNear(dl.ListFriendsNear(Person));
                    
                }

                if (Commmand.ToUpper() == "LIMPAR-REGISTROS")
                {
                    Data.Clear();
                    Person = new Person();
                    Utils.PrintHeader();

                }
            }

        }

        private static String GetMyLocation()
        {
            return String.Format("{0}, sua localizacao e: Latitude {1} ,  Longiture {2}", Person.Name, Person.Coordinates.Latitude, Person.Coordinates.Longitude);
        }

        private static Person RegisterPerson()
        {
            Person person = new Person();
            try
            {
                string msg = "Digite o Nome, X para sair";
                if(string.IsNullOrEmpty(Person.Name))
                {
                    msg = "Ola, fa�a seu registro primerio para em seguida registrar seus amigos(as)\n Digite X para sair ou seu nome para continuar....:";
                }
                Utils.Message(msg);

                person.Name = Console.ReadLine();
                if(person.Name.ToUpper() == "X")
                {
                    person.Name = null;
                    Utils.PrintHeader();
                    
                }
                else
                {
                    Utils.Message("Latitude");
                    person.Coordinates.Latitude = Convert.ToDouble(Console.ReadLine());
                    Utils.Message("Longitude");
                    person.Coordinates.Longitude = Convert.ToDouble(Console.ReadLine());
                }
                

            }
            catch (Exception e)
            {

                throw e;
            }

            return person;


        }

        private static void ListFriends()
        {
            int off = 80;
            var offset = Console.CursorLeft;
            
            if (Person.Friends.Count > 0)
            {
                Utils.PrintHeader();
                Console.CursorLeft = off;
                Utils.Message("Nome\tLatitude Longitude");
                foreach (var friend in Person.Friends)
                {
                    Console.CursorLeft = off;
                    Console.WriteLine(string.Format("{0}\t{1}\t{2}",friend.Name, friend.Coordinates.Latitude, friend.Coordinates.Longitude));

                }
                

            }
            Console.CursorLeft = offset;    
        }

        
        private static void PrintFriendsNear(List<Tuple<string, double>> list)
        {
            if (list.Count > 0)
            {
                Utils.Message("Amigos mais pr�ximos:");
                
                list = list.OrderBy(g => g.Item2).ToList();
                foreach (var l in list)
                {
                    Utils.Message(string.Format("{0} {1}", l.Item1, l.Item2));
                }
            }
        }
        


        #endregion
    }
}
