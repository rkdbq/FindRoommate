using FindRoommate.Model;
using FindRoommate.ViewModel;
using System;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace FindRoommate.View
{
    /// <summary>
    /// ChattingWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ChattingWindow : Window
    {
        public StudentViewModel VM { get; set; }
        public ChattingModel CM { get; set; }

        public ChattingWindow(StudentViewModel VM)
        {
            InitializeComponent();
            CM = new ChattingModel();
            this.VM = VM;
            messageListView.ItemsSource = VM.MessageList;
            CM.MessageList = string.Format("{0}님이 입장하였습니다.", VM.ChattingData.chattingPartner);

            VM.MessageList.Add(CM);
            this.Title = VM.ChattingData.chattingPartner + "님과의 채팅방";
        }

        public void ReceiveMessage(string sender, string message)
        {
            CM = new ChattingModel();

            if (message == "ChattingStart")
            {
                return;
            }

            if (message == "상대방이 채팅방을 나갔습니다.")
            {
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                {
                    string parsedMessage = string.Format("{0}님이 채팅방을 나갔습니다.", sender);
                    CM.MessageList = parsedMessage;
                    VM.MessageList.Insert(VM.MessageList.Count, CM);
                    ScrollToBot(messageListView);
                }));
                return;
            }

            Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
            {
                CM.ChatColor = Brushes.Navy;
                CM.ChatTextColor = Brushes.LightYellow;
                CM.MessageList = string.Format("{0}: {1}", sender, message);
                CM.ChatTime = DateTime.Now.ToString("HH:mm:ss");

                VM.MessageList.Insert(VM.MessageList.Count, CM);

                messageListView.ScrollIntoView(messageListView.Items[messageListView.Items.Count - 1]);

                ScrollToBot(messageListView);
            }));
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            string message = string.Format("{0}님과의 채팅을 종료하시겠습니까?", VM.ChattingData.chattingPartner);

            MessageBoxResult messageBoxResult = MessageBox.Show(message, "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.No)
            {
                e.Cancel = true;
                return;
            }

            string exitMessage = "상대방이 채팅방을 나갔습니다.";
            string parsedMessage = string.Format("{0}<{1}>", VM.ChattingData.chattingPartner, exitMessage);
            byte[] byteData = Encoding.Default.GetBytes(parsedMessage);
            VM.ChattingData.client.GetStream().Write(byteData, 0, byteData.Length);

            this.DialogResult = true;
        }

        private void ScrollToBot(ListView messageListView)
        {
            if (VisualTreeHelper.GetChildrenCount(messageListView) > 1)
            {
                Border border = (Border)VisualTreeHelper.GetChild(messageListView, messageListView.Items.Count - 2);
                ScrollViewer scrollViewer = (ScrollViewer)VisualTreeHelper.GetChild(border, messageListView.Items.Count - 2);
                scrollViewer.ScrollToBottom();
            }
        }
    }
}
