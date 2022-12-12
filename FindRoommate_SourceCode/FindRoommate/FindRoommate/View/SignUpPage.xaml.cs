using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace FindRoommate.View
{
    /// <summary>
    /// SignUpPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SignUpPage : Page
    {
        public SignUpPage()
        {
            InitializeComponent();
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

        private void emailcheckcode_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBox SearchString = sender as TextBox;
            if (SearchString.Text == "이메일 인증코드")
            {
                SearchString.Text = null;
                SearchString.Select(0, 0);
            }
        }

        private void nametxb_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBox SearchString = sender as TextBox;
            if (SearchString.Text == "이름")
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

        private void pwchecktxb_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBox SearchString = sender as TextBox;
            if (SearchString.Text == "비밀번호 확인")
            {
                SearchString.Text = null;
                SearchString.Select(0, 0);
            }
        }

        private void phonenumtxb_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBox SearchString = sender as TextBox;
            if (SearchString.Text == "연락처")
            {
                SearchString.Text = null;
                SearchString.Select(0, 0);
            }
        }

        private void phonecheckcode_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBox SearchString = sender as TextBox;
            if (SearchString.Text == "전화번호 인증코드")
            {
                SearchString.Text = null;
                SearchString.Select(0, 0);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/LogInPage.xaml", UriKind.Relative));
        }

        private void Studentnumtxb_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBox SearchString = sender as TextBox;
            if (SearchString.Text == "학번")
            {
                SearchString.Text = null;
                SearchString.Select(0, 0);
            }
        }

    }
}
