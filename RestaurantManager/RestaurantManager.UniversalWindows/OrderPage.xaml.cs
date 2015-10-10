using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using RestaurantManager.Models;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace RestaurantManager.UniversalWindows
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OrderPage : Page
    {
        public OrderPage()
        {
            InitializeComponent();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void AddToOrderButton_Click(object sender, RoutedEventArgs e)
        {
            if (MenuListView.SelectedItem != null)
            {
                DataManager dataManager = DataContext as DataManager;
                string selectedItem = MenuListView.SelectedItem as string;
                if (!dataManager.CurrentlySelectedMenuItems.Contains(selectedItem))
                    dataManager.CurrentlySelectedMenuItems.Add(selectedItem);
            }
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedListView.Items.Count > 0)
            {
                DataManager dataManager = DataContext as DataManager;
                dataManager.OrderItems.Add(string.Join(", ", SelectedListView.Items));
                dataManager.CurrentlySelectedMenuItems.Clear();
            }
        }
    }
}
