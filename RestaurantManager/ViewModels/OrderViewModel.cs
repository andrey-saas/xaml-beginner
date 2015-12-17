using RestaurantManager.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Popups;
using System;

namespace RestaurantManager.ViewModels
{
    public sealed class OrderViewModel : ViewModel
    {
        protected override void OnDataLoaded()
        {
            this.MenuItems = Repository?.StandardMenuItems;

            this.CurrentlySelectedMenuItems = new ObservableCollection<MenuItem>();

            AddToOrderCommand = new DelegateCommand(AddToOrderAction, IsAddToOrderActionEnabled);
            SubmitOrderCommand = new DelegateCommand(SubmitOrderAction, IsSubmitOrderActionEnabled);

            AddToOrderCommand.UpdateState();
            SubmitOrderCommand.UpdateState();
        }

        private List<MenuItem> menuItems;

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

        private ObservableCollection<MenuItem> currentlySelectedMenuItems;

        public ObservableCollection<MenuItem> CurrentlySelectedMenuItems
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

        private MenuItem selectedMenuItem;

        public MenuItem SelectedMenuItem
        {
            get
            {
                return selectedMenuItem;
            }
            set
            {
                if (selectedMenuItem != value)
                {
                    selectedMenuItem = value;
                    OnPropertyChanged();

                    AddToOrderCommand.UpdateState();
                }
            }
        }

        public IUpdatableCommand AddToOrderCommand { get; private set; }

        private void AddToOrderAction()
        {
            if (!currentlySelectedMenuItems.Contains(selectedMenuItem))
            {
                currentlySelectedMenuItems.Add(selectedMenuItem);
                SubmitOrderCommand.UpdateState();
            }
        }

        private bool IsAddToOrderActionEnabled()
        {
            return selectedMenuItem != null;
        }

        public IUpdatableCommand SubmitOrderCommand { get; private set; }

        private async void SubmitOrderAction()
        {
            Repository.AddOrder(new Order()
            {
                Id = Repository.GetNextOrderId(),
                Items = new List<MenuItem>(currentlySelectedMenuItems),
                Complete = false,
                Expedite = false
            });

            currentlySelectedMenuItems.Clear();
            await new MessageDialog("Order has been submitted!").ShowAsync();
        }

        private bool IsSubmitOrderActionEnabled()
        {
            return currentlySelectedMenuItems.Count > 0;
        }
    }
}
