using FindRoommate.Model;
using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace FindRoommate.ViewModel.Commands
{
    public class SendCommand : ICommand
    {
        StudentViewModel VM { get; set; }
        ChattingModel CM { get; set; }
        public SendCommand(StudentViewModel VM)
        {
            this.VM = VM;
            CM = new ChattingModel();
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            CM = new ChattingModel();

            if (string.IsNullOrEmpty(VM.ChattingData.ChatText))
                return;
            string message = VM.ChattingData.ChatText;
            string parsedMessage = "";

            if (message.Contains('<') || message.Contains('>'))
            {
                MessageBox.Show("죄송합니다. >,< 기호는 사용하실수 없습니다.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            parsedMessage = string.Format("{0}<{1}>", VM.ChattingData.chattingPartner, message);
            byte[] byteData = Encoding.Default.GetBytes(parsedMessage);
            VM.ChattingData.client.GetStream().Write(byteData, 0, byteData.Length);

            CM.ChatColor = Brushes.LightYellow;
            CM.ChatTextColor = Brushes.Navy;
            CM.MessageList = "나: " + message;
            CM.ChatTime = DateTime.Now.ToString("HH:mm:ss");
            VM.ChattingData.ChatText = "";
            VM.MessageList.Add(CM);
        }
    }
}
