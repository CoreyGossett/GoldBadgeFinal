using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3.Repo
{
    public class BadgeRepo
    {
        public Dictionary<int, List<string>> _badgeDict = new Dictionary<int, List<string>>();
        public List<Badge> _badges = new List<Badge>();
        
        public bool AddBadge(Badge badge)
        {
            if (badge is null)
            {
                return false;
            }
            _badges.Add(badge);
            _badgeDict.Add(badge.BadgeID, badge.DoorNames);
            return true;
        }

        public bool RemoveBadgeFromDictionary(int id)
        {
            if (id == 0)
            {
                return false;
            }
            else
            {
                _badgeDict.Remove(id);
                return true;
            }
        }

        public Badge GetBadgeById(int id)
        {
            foreach (Badge badge in _badges)
            {
                if (id == badge.BadgeID)
                {
                    return badge;
                }
            }
            return null;
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
