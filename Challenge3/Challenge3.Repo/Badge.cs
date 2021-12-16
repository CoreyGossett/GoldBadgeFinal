using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3.Repo
{
    public class Badge
    {
        public int BadgeID { get; set; }

        public List<string> DoorNames { get; set; }

        public string Name { get; set; }

        public Badge()
        {

        }

        public Badge(int badgeID, List<string> doorNames)
        {
            BadgeID = badgeID;
            DoorNames = doorNames;
        }
    }
}
