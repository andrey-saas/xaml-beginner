using RestaurantManager.Models;
using System.Collections.Generic;

namespace RestaurantManager.ViewModels
{
    public sealed class OrderViewModel : ViewModel
    {
        private List<MenuItem> menuItems;

        private List<MenuItem> currentlySelectedMenuItems;

        protected override void OnDataLoaded()
        {
            this.MenuItems = Repository.StandardMenuItems;

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
                    OnPropertyChanged();
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
                    OnPropertyChanged();
                }
            }
        }
    }
}
