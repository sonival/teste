
using System.Collections.Generic;

namespace LocateFriends.Repository
{
    public class Person
    {
        public string Name { get; set; }
        public Coordinates Coordinates { get; set; }
        public List<Person> Friends { get; set; } = new List<Person>();
    }
}
