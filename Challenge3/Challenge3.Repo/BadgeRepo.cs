using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3.Repo
{
    public class BadgeRepo
    {
        Dictionary<int, List<string>> _badgeRepo = new Dictionary<int, List<string>>();

        private int _count = 0;

        public bool AddBadge(Badge badge)
        {
            if (badge is null)
            {
                return false;
            }
            _count++;
            badge.BadgeID = _count;
            _badgeRepo.Add(badge.BadgeID, badge.DoorNames);
            return true;
        }
    }
}
