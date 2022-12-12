using System;
using System.Windows;
using System.Windows.Input;

namespace FindRoommate.ViewModel.Commands
{
    public class EmailCheckCommand : ICommand
    {
        StudentViewModel VM;
        public EmailCheckCommand(StudentViewModel VM)
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
            if (VM.StudentDataToSignUp.EmailCheck == VM.EmailData.serial.ToString())
            {
                VM.LogInData.EmailChecked = true;
                MessageBox.Show("인증 완료!");
            }
            else
            {
                VM.LogInData.EmailChecked = false;
                MessageBox.Show("인증 실패!");
            }
        }
    }
}
