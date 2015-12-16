using RestaurantManager.Models;
using System.Collections.Generic;

namespace RestaurantManager.ViewModels
{
    public sealed class ExpediteViewModel : ViewModel
    {
        protected override void OnDataLoaded()
        {
            OnPropertyChanged("OrderItems");
        }

        public List<Order> OrderItems
        {
            get { return Repository?.Orders; }
        }
    }
}
