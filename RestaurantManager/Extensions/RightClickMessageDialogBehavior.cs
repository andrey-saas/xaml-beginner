using System;
using Microsoft.Xaml.Interactivity;
using Windows.UI.Xaml;
using Windows.UI.Popups;

namespace Extensions
{
    public class RightClickMessageDialogBehavior : DependencyObject, IBehavior
    {
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(RightClickMessageDialogBehavior), new PropertyMetadata("You have right tapped!"));

        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(RightClickMessageDialogBehavior), new PropertyMetadata("Right tap"));

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public DependencyObject AssociatedObject { get; private set; }

        public void Attach(DependencyObject associatedObject)
        {
            AssociatedObject = associatedObject;
            if (AssociatedObject is UIElement)
                (AssociatedObject as UIElement).RightTapped += RightClickMessageDialogBehavior_RightTapped;
        }

        private async void RightClickMessageDialogBehavior_RightTapped(object sender, Windows.UI.Xaml.Input.RightTappedRoutedEventArgs e)
        {
            await new MessageDialog(Message, Title).ShowAsync();
        }

        public void Detach()
        {
            throw new NotImplementedException();
        }
    }
}
