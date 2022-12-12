using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Input;

namespace FindRoommate.ViewModel.Commands
{
    public class SaveButtonCommand : ICommand
    {
        public StudentViewModel VM { get; set; }
        public SaveButtonCommand(StudentViewModel VM) { this.VM = VM; }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {

            return true;
        }

        public void Execute(object parameter)
        {

            string saveButtonPosition = parameter as string;

            SqlConnection con = new SqlConnection(VM.Cnnstr);
            SqlCommand cmd = con.CreateCommand();

            if (saveButtonPosition == "topBox")
            {
                cmd.CommandText = "Update tblStudent Set NewSignIn = 0, IsNameVisible = @IsNameVisible, IsStudentNumberVisible = @IsStudentNumberVisible, IsEmailVisible = @IsEmailVisible, IsPhoneNumberVisible = @IsPhoneNumberVisible Where Email = @Email";

                cmd.Parameters.AddWithValue("@Email", VM.StudentDataToLogIn.Email);

                cmd.Parameters.AddWithValue("@IsNameVisible", VM.StudentDataToLogIn.IsNameVisible);
                cmd.Parameters.AddWithValue("@IsStudentNumberVisible", VM.StudentDataToLogIn.IsStudentNumberVisible);
                cmd.Parameters.AddWithValue("@IsEmailVisible", VM.StudentDataToLogIn.IsEmailVisible);
                cmd.Parameters.AddWithValue("@IsPhoneNumberVisible", VM.StudentDataToLogIn.IsPhoneNumberVisible);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("공개여부가 저장되었습니다.");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (saveButtonPosition == "bottomBox")
            {
                cmd.CommandText = "Update tblStudent Set NewSignIn = 0, DoSmoke = @DoSmoke, DidMilitaryService = @DidMilitaryService, HaveLover = @HaveLover, IsKorean = @IsKorean, DoSnore = @DoSnore, DoBruise = @DoBruise, DoSleepTalking = @DoSleepTalking, DoTossAndTurn = @DoTossAndTurn, Religion = @Religion, College = @College, IsMbtiE = @IsMbtiE, IsMbtiS = @IsMbtiS, IsMbtiT = @IsMbtiT, IsMbtiJ = @IsMbtiJ, BedTime = @BedTime, WakeUpTime = @WakeUpTime, CleaningPerMonth = @CleaningPerMonth Where Email = @Email";

                cmd.Parameters.AddWithValue("@Email", VM.StudentDataToLogIn.Email);

                cmd.Parameters.AddWithValue("@BedTime", VM.StudentDataToLogIn.BedTime);
                cmd.Parameters.AddWithValue("@WakeUpTime", VM.StudentDataToLogIn.WakeUpTime);
                cmd.Parameters.AddWithValue("@CleaningPerMonth", VM.StudentDataToLogIn.CleaningPerMonth);

                cmd.Parameters.AddWithValue("@DoSmoke", VM.StudentDataToLogIn.DoSmoke);
                cmd.Parameters.AddWithValue("@DidMilitaryService", VM.StudentDataToLogIn.DidMilitaryService);
                cmd.Parameters.AddWithValue("@HaveLover", VM.StudentDataToLogIn.HaveLover);
                cmd.Parameters.AddWithValue("@IsKorean", VM.StudentDataToLogIn.IsKorean);
                cmd.Parameters.AddWithValue("@DoSnore", VM.StudentDataToLogIn.DoSnore);
                cmd.Parameters.AddWithValue("@DoBruise", VM.StudentDataToLogIn.DoBruise);
                cmd.Parameters.AddWithValue("@DoSleepTalking", VM.StudentDataToLogIn.DoSleepTalking);
                cmd.Parameters.AddWithValue("@DoTossAndTurn", VM.StudentDataToLogIn.DoTossAndTurn);
                cmd.Parameters.AddWithValue("@Religion", VM.StudentDataToLogIn.Religion);
                cmd.Parameters.AddWithValue("@College", VM.StudentDataToLogIn.College);
                cmd.Parameters.AddWithValue("@IsMbtiE", VM.StudentDataToLogIn.IsMbtiE);
                cmd.Parameters.AddWithValue("@IsMbtiS", VM.StudentDataToLogIn.IsMbtiS);
                cmd.Parameters.AddWithValue("@IsMbtiT", VM.StudentDataToLogIn.IsMbtiT);
                cmd.Parameters.AddWithValue("@IsMbtiJ", VM.StudentDataToLogIn.IsMbtiJ);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("설문정보가 저장되었습니다.");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}