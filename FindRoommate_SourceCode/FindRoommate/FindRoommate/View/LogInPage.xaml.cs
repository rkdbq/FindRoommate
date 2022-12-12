using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace FindRoommate.View
{
    /// <summary>
    /// LogInPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LogInPage : Page
    {
        public LogInPage()
        {
            InitializeComponent();
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate (new Uri("/View/SignUpPage.xaml", UriKind.Relative));
        }

        private void emailtxb_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBox SearchString = sender as TextBox;
            if (SearchString.Text == "학교 이메일")
            {
                SearchString.Text = null;
                SearchString.Select(0, 0);
            }
        }

        private void pwtxb_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBox SearchString = sender as TextBox;
            if (SearchString.Text == "비밀번호")
            {
                SearchString.Text = null;
                SearchString.Select(0, 0);
            }
        }
    }
}
