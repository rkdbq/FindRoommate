using FindRoommate.Model;
using System;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace FindRoommate.ViewModel.Commands
{
    public class ChattingButtonCommand : ICommand
    {
        StudentViewModel VM { get; set; }
        public ChattingButtonCommand(StudentViewModel VM)
        {
            this.VM = VM;
        }

        public event EventHandler CanExecuteChanged;


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string name = parameter as string;
            if (VM.ChattingData.client == null)
            {
                MessageBox.Show("먼저 로그인해주세요.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            string getUserProtocol = ChattingData.myName + "<GiveMeUserList>";
            byte[] byteData = new byte[getUserProtocol.Length];
            byteData = Encoding.Default.GetBytes(getUserProtocol);

            VM.ChattingData.client.GetStream().Write(byteData, 0, byteData.Length);

            User selectedUser = new User(name);
            if (ChattingData.myName == selectedUser.userName)
            {
                MessageBox.Show("자기 자신과는 채팅할 수 없습니다.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            string msg = string.Format("{0}님에게 요청을 하시겠습니까?", selectedUser.userName);
            MessageBoxResult messageBoxResult = MessageBox.Show(msg, "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.No)
            {
                return;
            }

            if (VM.ChattingData.chattingThreadDic.ContainsKey(name))
            {
                MessageBox.Show("해당유저와는 이미 채팅중입니다.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            string chattingStartMessage = string.Format("{0}<ChattingStart>", name);
            byte[] chattingStartByte = Encoding.Default.GetBytes(chattingStartMessage);

            VM.ChattingData.client.GetStream().Write(chattingStartByte, 0, chattingStartByte.Length);
        }
    }
}
