using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FindRoommate.ViewModel.Commands
{
    public class RefreshCommand : ICommand
    {
        public StudentViewModel VM { get; set; }
        public RefreshCommand(StudentViewModel VM) { this.VM = VM; }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.StudentDataToSearch.Init();
        }
    }
}
