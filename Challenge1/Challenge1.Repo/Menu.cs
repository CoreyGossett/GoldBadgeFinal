using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1.Repo
{
    public class Menu
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public List<Ingredients> Ingredients { get; set; }
        public decimal Price { get; set; }

        public Menu(int mealNumber, string mealName, string mealDescription, decimal price)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            Price = price;
        }

        public Menu(int mealNumber, string mealName, string mealDescription)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
        }

        public Menu(int mealNumber, string mealName)
        {
            MealNumber = mealNumber;
            MealName = mealName;
        }

        public Menu(int mealNumber)
        {
            MealNumber = mealNumber;
        }

        public Menu()
        {

        }
    }
}
