using System.Collections.Generic;

namespace RestaurantManager.Models
{
    public class OrderDataManager : DataManager
    {
        protected List<MenuItem> menuItems;

        protected List<MenuItem> currentlySelectedMenuItems;

        protected override void OnDataLoaded()
        {
            this.MenuItems = base.Repository.StandardMenuItems;

            this.CurrentlySelectedMenuItems = new List<MenuItem>
            {
                this.MenuItems[3],
                this.MenuItems[5]
            };
        }

        public List<MenuItem> MenuItems
        {
            get
            {
                return menuItems;
            }
            set
            {
                if (menuItems != value)
                {
                    menuItems = value;
                    FirePropertyChanged();
                }
            }
        }

        public List<MenuItem> CurrentlySelectedMenuItems
        {
            get
            {
                return currentlySelectedMenuItems;
            }
            set
            {
                if (currentlySelectedMenuItems != value)
                {
                    currentlySelectedMenuItems = value;
                    FirePropertyChanged();
                }
            }
        }
    }
}
