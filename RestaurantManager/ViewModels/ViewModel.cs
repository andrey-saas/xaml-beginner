﻿using RestaurantManager.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RestaurantManager.ViewModels
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        protected RestaurantContext Repository { get; private set; }

        public ViewModel()
        {
            LoadData();
        }

        private async void LoadData()
        {
            Repository = await RestaurantContextFactory.GetRestaurantContextAsync();
            OnDataLoaded();
        }

        protected abstract void OnDataLoaded();
    }
}