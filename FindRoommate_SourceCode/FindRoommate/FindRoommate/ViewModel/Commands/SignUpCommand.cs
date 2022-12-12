using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Input;

namespace FindRoommate.ViewModel.Commands
{
    public class SignUpCommand : ICommand
    {
        StudentViewModel VM { get; set; }
        public SignUpCommand(StudentViewModel VM)
        {
            this.VM = VM;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            
            if (VM.StudentDataToSignUp.Email == "학교 이메일" || VM.StudentDataToSignUp.Email == "" || VM.StudentDataToSignUp.EmailCheck == "이메일 인증코드" || VM.StudentDataToSignUp.EmailCheck == "" || VM.StudentDataToSignUp.Password == "비밀번호" || VM.StudentDataToSignUp.Password == "" || VM.StudentDataToSignUp.PasswordCheck == "비밀번호 확인" || VM.StudentDataToSignUp.PasswordCheck == "" || VM.StudentDataToSignUp.PhoneNumber == "연락처" || VM.StudentDataToSignUp.PhoneNumber == "" || VM.StudentDataToSignUp.StudentNumber == "학번" || VM.StudentDataToSignUp.StudentNumber == "") return false;
            else return true;
        }

        public void Execute(object parameter)
        {
            
            if(!VM.LogInData.EmailChecked)
            {
                MessageBox.Show("이메일이 인증되지 않았습니다.");
                return;
            }
            if(VM.StudentDataToSignUp.Password != VM.StudentDataToSignUp.PasswordCheck)
            {
                MessageBox.Show("비밀번호가 다릅니다.");
                return;
            }
            SqlConnection con = new SqlConnection(VM.Cnnstr);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Insert tblStudent(NewSignIn, Email, StudentName, StudentPW, PhoneNum, StudentNumber, Sex, IsApplied, IsNameVisible, IsStudentNumberVisible, IsEmailVisible, IsPhoneNumberVisible, DoSmoke, DidMilitaryService, HaveLover, IsKorean, BedTime, WakeUpTime, CleaningPerMonth, DoSnore, DoBruise, DoSleepTalking, DoTossAndTurn, Religion, College, IsMbtiE, IsMbtiS, IsMbtiT, IsMbtiJ) Values(1, @Email,@StudentName,@StudentPW,@PhoneNum,@StudentNumber, @Sex, @IsApplied, 1, 1, 1, 1, 1, 0, 0, 1, 24, 8, 1, 1, 1, 1, 1, '기타', '공과', 1, 1, 1, 1)";

            cmd.Parameters.AddWithValue("@Email", VM.StudentDataToSignUp.Email);
            cmd.Parameters.AddWithValue("@StudentName", VM.StudentDataToSignUp.Name);
            cmd.Parameters.AddWithValue("@StudentPW", VM.StudentDataToSignUp.Password);
            cmd.Parameters.AddWithValue("@PhoneNum", VM.StudentDataToSignUp.PhoneNumber);
            cmd.Parameters.AddWithValue("@StudentNumber", VM.StudentDataToSignUp.StudentNumber);
            cmd.Parameters.AddWithValue("@Sex", VM.StudentDataToSignUp.Sex);
            cmd.Parameters.AddWithValue("@IsApplied", "신청 없음");
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("회원가입 완료");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
