using System;
using System.ComponentModel;
using System.Windows;

namespace FindRoommate.View
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
