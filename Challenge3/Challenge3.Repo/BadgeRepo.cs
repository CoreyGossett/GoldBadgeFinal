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

        public bool AddBadge(Badge badge)
        {
            if (badge is null)
            {
                return false;
            }
            _badgeDict.Add(badge.BadgeID, badge.DoorNames);
            return true;
        }

        public List<string> AddDoorToList(Badge badge, string door)
        {
            List<string> newList = new List<string>();

            if (door is null)
            {
                return null;
            }
            else
            {
                newList.Add(door);
            }
            return newList;
        }

        public void ShowAllBadges()
        {
            foreach (KeyValuePair<int, List<string>> badge in _badgeDict)
            {
                Console.WriteLine("Badge #: {0}, Door Access: {1}",
                    badge.Key, string.Join(", ", badge.Value));
                Console.WriteLine("**********************************");
            }
            Console.ReadLine();
        }
    }
}
