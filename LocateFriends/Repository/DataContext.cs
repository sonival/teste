
using Newtonsoft.Json;
using System.Linq;
using System.IO;

namespace LocateFriends.Repository
{

    public class DataContext
    {
        public Person Person { get; set; }
        
        private string Fname = string.Format("{0}", System.Environment.CurrentDirectory+ "\\Person.Json");

        #region Construtores
        public DataContext()
        {

            if (Person == null)
            {

            }
        }
        #endregion

        #region Metodos Publicos
        public Person Get()
        {
            return getPerson();
        }

        

        public void Save(Person person)
        {
            var txt = JsonConvert.SerializeObject(person);
            
            SaveFile(txt);
        }

        public void Clear()
        {
            File.Delete(Fname);            
            
        }


        #endregion



        private void  SaveFile(string txt)
        {
            using (System.IO.StreamWriter file = new StreamWriter(Fname))
            {
                file.Write(txt);
            }
        }
        private Person getPerson()
        {
            if (!File.Exists(Fname))
            {
                return new Person();
            }
            try
            {
                var person = File.ReadAllText(Fname);
                if(person.Length > 0)
                {
                    return JsonConvert.DeserializeObject<Person>(person);
                }
                return new Person();
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
