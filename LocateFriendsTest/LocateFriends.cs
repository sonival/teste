using LocateFriends.Dal;
using LocateFriends.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace LocateFriendsTest
{
    [TestClass]
    public class LocateFriends
    {
        private readonly DL dl = new DL();

        private DataContext data = new DataContext();

        [TestMethod]
        public void Test_Clear_Person_Content()
        {
            data.Clear();
            var p = data.Get();
            if (string.IsNullOrEmpty(p.Name) && !p.Friends.Any()) ;
        }


        [TestMethod]
        public  void Test_Fill_Person_Content()
        {
            data.Person = new Person() { Name = "Teste Unit" };
            data.Person.Friends.Add(new Person() { Name = "Teste unit 1" });
            data.Save(data.Person);
            var p= data.Get();
            
            Assert.IsTrue(!string.IsNullOrEmpty(p.Name) && p.Friends.Count > 0);
        }

        [TestMethod]
        public void Test_List_Frineds_Near_Has_Contents()
        {
            var p = data.Get();
            var list = dl.ListFriendsNear(p);
            
            Assert.IsTrue(list.Count() > 0);
            

        }
    }
}
