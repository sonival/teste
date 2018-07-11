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
        public  void Test_Fill_Person_Content()
        {
            v
        }

        [TestMethod]
        public void Test_List_Frineds_Near_Has_Contents()
        {

            var list = dl.ListFriendsNear(data.Get());
            Assert.IsTrue(list.Count() > 0);
        }
    }
}
