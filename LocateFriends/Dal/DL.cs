using LocateFriends.Helper;
using LocateFriends.Repository;

using System;
using System.Collections.Generic;
using System.Linq;

namespace LocateFriends.Dal
{
    public class DL
    {
        public List<Tuple<string, double>> ListFriendsNear(Person person)
        {
            List<Tuple<string, double>> list = new List<Tuple<string, double>>();
            var c1 = person.Coordinates;
            foreach (var f in person.Friends)
            {
                double dist = Utils.GetDistance(c1, f.Coordinates);
                list.Add(new Tuple<string, double>(f.Name, dist));
            }
            
            return list;
        }
    }
}
