using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace FindRoommate.View
{
    /// <summary>
    /// SearchPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SearchPage : Page
    {
        public SearchPage()
        {
            InitializeComponent();
 
        }
        private void SearchString_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBox SearchString = sender as TextBox;
            if (SearchString.Text == "검색어를 입력하세요.(이름, 학번 등)")
            {
                SearchString.Text = null;
                SearchString.Select(0, 0);
            }
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/ProfilePage.xaml", UriKind.Relative));
        }
    }
}
