using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace RestaurantManager.Models
{
    public class DataManager
    {
        public DataManager()
        {
            if (dataManager == null)
                dataManager = this;

            OrderItems = new ObservableCollection<string>(
                new List<string>
                {
                    "Steak, Chicken, Peas",
                    "Rice, Chicken",
                    "Hummus, Pita"
                }
            );

            MenuItems = new List<string>
            {
                "Steak",
                "Chicken",
                "Peas",
                "Rice",
                "Hummus",
                "Pita"
            };

            CurrentlySelectedMenuItems = new ObservableCollection<string>
            {
                "Rice",
                "Pita"
            };
        }

        public static DataManager GetDataManager()
        {
            return dataManager;
        }

        public ObservableCollection<string> OrderItems { get; set; }
        public List<string> MenuItems { get; set; }
        public ObservableCollection<string> CurrentlySelectedMenuItems { get; set; }

        private static DataManager dataManager = null;
    }
}
