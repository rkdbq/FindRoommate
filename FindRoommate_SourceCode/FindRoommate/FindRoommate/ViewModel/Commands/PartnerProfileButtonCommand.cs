using FindRoommate.View;
using Search.Model;
using System;
using System.Windows.Input;

namespace FindRoommate.ViewModel.Commands
{
    public class PartnerProfileButtonCommand : ICommand
    {
        StudentViewModel VM;
        public PartnerProfileButtonCommand(StudentViewModel VM)
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
            StudentData ShowPartnerProfile = (StudentData)parameter;
            VM.StudentDataToShowPartner = ShowPartnerProfile;
            PartnerProfileWindow partnerProfileWindow = new PartnerProfileWindow();
            partnerProfileWindow.Show();
        }
    }
}
