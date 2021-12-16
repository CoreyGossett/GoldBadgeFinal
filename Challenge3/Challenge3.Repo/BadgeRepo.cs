using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3.Repo
{
    public class BadgeRepo
    {
        Dictionary<int, List<string>> _badgeDict = new Dictionary<int, List<string>>();

        private int _count = 0;

        public bool AddBadge(Badge badge)
        {
            if (badge is null)
            {
                return false;
            }
            _count++;
            badge.BadgeID = _count;
            _badgeDict.Add(badge.BadgeID, badge.DoorNames);
            return true;
        }

        public bool AddDoorToList(Badge badge, string door)
        {
            if (door is null)
            {
                return false;
            }
            else
            {
                badge.DoorNames.Add(door);
                return true;
            }
        }
    }
}
