using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1.Repo
{
    public class MenuRepo
    {
        private readonly List<Menu> _menuItemRepo = new List<Menu>();

        public bool AddMenuItem(Menu menuItem)
        {
            if (menuItem is null)
            {
                return false;
            }
            else
            {
                menuItem.Ingredients = new List<Ingredients>();
                _menuItemRepo.Add(menuItem);
                return true;
            }
        }

        public List<Menu> ReturnMenuItems()
        {
            return _menuItemRepo;
        }

        public bool DeleteMenuItem(Menu item)
        {
            if (item == null)
            {
                return false;
            }
            else
            {
                _menuItemRepo.Remove(item);
                return true;
            }
        }

        public Menu GetMenuItemByMealNumber(int mealNumber)
        {
            foreach (Menu item in _menuItemRepo)
            {
                if (mealNumber == item.MealNumber)
                {
                    return item;
                }
            }
            return null;
        }


    }
}
