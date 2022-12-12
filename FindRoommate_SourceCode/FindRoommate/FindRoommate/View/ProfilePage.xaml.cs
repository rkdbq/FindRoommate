using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace FindRoommate.View
{
    /// <summary>
    /// ProfilePage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ProfilePage : Page
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/SearchPage.xaml", UriKind.Relative));
        }
    }
}
