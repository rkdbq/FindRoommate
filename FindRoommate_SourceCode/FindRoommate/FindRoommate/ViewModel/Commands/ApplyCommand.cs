using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Input;

namespace FindRoommate.ViewModel.Commands
{
    public class ApplyCommand : ICommand
    {
        StudentViewModel VM;
        public ApplyCommand(StudentViewModel VM)
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
            string partnerEmail = parameter as string;

            SqlConnection con = new SqlConnection(VM.Cnnstr);
            SqlCommand cmd = con.CreateCommand();            
            cmd.CommandText = "Update tblStudent Set IsApplied = @IsApplied Where Email = @Email";
            cmd.Parameters.AddWithValue("@IsApplied", VM.StudentDataToLogIn.Name);
            cmd.Parameters.AddWithValue("@Email", partnerEmail);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("신청되었습니다.");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
