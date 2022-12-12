using FindRoommate.Model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Input;

namespace FindRoommate.ViewModel.Commands
{
    public class SearchButtonCommand : ICommand
    {
        public StudentViewModel VM { get; set; }
        public SearchButtonCommand(StudentViewModel VM) { this.VM = VM; }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string searchedBy = parameter as string;
            VM.StudentDataToShowProfiles.Clear();
            SqlConnection sqlCon = new SqlConnection(VM.Cnnstr);

            if (searchedBy == null || searchedBy == "입력하세요.")
            {
                try
                {
                    if (sqlCon.State == ConnectionState.Closed)
                        sqlCon.Open();
                    string query = "SELECT * From tblStudent Where IsApplied = @IsApplied And Sex = @Sex And DoSmoke = @DoSmoke And DidMilitaryService = @DidMilitaryService And HaveLover = @HaveLover And IsKorean = @IsKorean And DoSnore = @DoSnore And DoBruise = @DoBruise And DoSleepTalking = @DoSleepTalking And DoTossAndTurn = @DoTossAndTurn And (Religion = @Religion1 Or Religion = @Religion2 Or Religion = @Religion3 Or Religion = @Religion4) And (College = @간호 Or College = @농업생명과학 Or College = @상과 Or College = @약학 Or College = @인문 Or College = @환경생명자원 Or College = @공과 Or College = @사범 Or College = @생활과학 Or College = @예술 Or College = @자연과학 Or College = @스마트팜학과 Or College = @글로벌융합 Or College = @사회과학 Or College = @수의과 Or College = @의과 Or College = @치과) And IsMbtiE = @IsMbtiE And IsMbtiS = @IsMbtiS And IsMbtiT = @IsMbtiT And IsMbtiJ = @IsMbtiJ And BedTime >= @BedTime And WakeUpTime <= @WakeUpTime And CleaningPerMonth >= @CleaningPerMonth";

                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                    sqlCmd.Parameters.AddWithValue("@IsApplied", "신청 없음");

                    sqlCmd.Parameters.AddWithValue("@Email", VM.StudentDataToLogIn.Email);
                    sqlCmd.Parameters.AddWithValue("@Sex", VM.StudentDataToLogIn.Sex);

                    sqlCmd.Parameters.AddWithValue("@BedTime", VM.StudentDataToSearch.BedTime);
                    sqlCmd.Parameters.AddWithValue("@WakeUpTime", VM.StudentDataToSearch.WakeUpTime);
                    sqlCmd.Parameters.AddWithValue("@CleaningPerMonth", VM.StudentDataToSearch.CleaningPerMonth);

                    sqlCmd.Parameters.AddWithValue("@DoSmoke", VM.StudentDataToSearch.DoSmoke);
                    sqlCmd.Parameters.AddWithValue("@DidMilitaryService", VM.StudentDataToSearch.DidMilitaryService);
                    sqlCmd.Parameters.AddWithValue("@HaveLover", VM.StudentDataToSearch.HaveLover);
                    sqlCmd.Parameters.AddWithValue("@IsKorean", VM.StudentDataToSearch.IsKorean);
                    sqlCmd.Parameters.AddWithValue("@DoSnore", VM.StudentDataToSearch.DoSnore);
                    sqlCmd.Parameters.AddWithValue("@DoBruise", VM.StudentDataToSearch.DoBruise);
                    sqlCmd.Parameters.AddWithValue("@DoSleepTalking", VM.StudentDataToSearch.DoSleepTalking);
                    sqlCmd.Parameters.AddWithValue("@DoTossAndTurn", VM.StudentDataToSearch.DoTossAndTurn);

                    sqlCmd.Parameters.AddWithValue("@IsMbtiE", VM.StudentDataToSearch.IsMbtiE);
                    sqlCmd.Parameters.AddWithValue("@IsMbtiS", VM.StudentDataToSearch.IsMbtiS);
                    sqlCmd.Parameters.AddWithValue("@IsMbtiT", VM.StudentDataToSearch.IsMbtiT);
                    sqlCmd.Parameters.AddWithValue("@IsMbtiJ", VM.StudentDataToSearch.IsMbtiJ);

                    if (VM.StudentDataToSearch.BuddhismChecked) sqlCmd.Parameters.AddWithValue("@Religion1", "불교");
                    else sqlCmd.Parameters.AddWithValue("@Religion1", "");
                    if (VM.StudentDataToSearch.ChristianityChecked) sqlCmd.Parameters.AddWithValue("@Religion2", "기독교");
                    else sqlCmd.Parameters.AddWithValue("@Religion2", "");
                    if (VM.StudentDataToSearch.CatholicChecked) sqlCmd.Parameters.AddWithValue("@Religion3", "천주교");
                    else sqlCmd.Parameters.AddWithValue("@Religion3", "");
                    if (VM.StudentDataToSearch.OtherChecked) sqlCmd.Parameters.AddWithValue("@Religion4", "기타");
                    else sqlCmd.Parameters.AddWithValue("@Religion4", "");

                    if (VM.StudentDataToSearch.간호Checked) sqlCmd.Parameters.AddWithValue("@간호", "간호");
                    else sqlCmd.Parameters.AddWithValue("@간호", "");
                    if (VM.StudentDataToSearch.농업생명과학Checked) sqlCmd.Parameters.AddWithValue("@농업생명과학", "농업생명과학");
                    else sqlCmd.Parameters.AddWithValue("@농업생명과학", "");
                    if (VM.StudentDataToSearch.상과Checked) sqlCmd.Parameters.AddWithValue("@상과", "상과");
                    else sqlCmd.Parameters.AddWithValue("@상과", "");
                    if (VM.StudentDataToSearch.약학Checked) sqlCmd.Parameters.AddWithValue("@약학", "약학");
                    else sqlCmd.Parameters.AddWithValue("@약학", "");
                    if (VM.StudentDataToSearch.인문Checked) sqlCmd.Parameters.AddWithValue("@인문", "인문");
                    else sqlCmd.Parameters.AddWithValue("@인문", "");
                    if (VM.StudentDataToSearch.환경생명자원Checked) sqlCmd.Parameters.AddWithValue("@환경생명자원", "환경생명자원");
                    else sqlCmd.Parameters.AddWithValue("@환경생명자원", "");
                    if (VM.StudentDataToSearch.공과Checked) sqlCmd.Parameters.AddWithValue("@공과", "공과");
                    else sqlCmd.Parameters.AddWithValue("@공과", "");
                    if (VM.StudentDataToSearch.사범Checked) sqlCmd.Parameters.AddWithValue("@사범", "사범");
                    else sqlCmd.Parameters.AddWithValue("@사범", "");
                    if (VM.StudentDataToSearch.생활과학Checked) sqlCmd.Parameters.AddWithValue("@생활과학", "생활과학");
                    else sqlCmd.Parameters.AddWithValue("@생활과학", "");
                    if (VM.StudentDataToSearch.예술Checked) sqlCmd.Parameters.AddWithValue("@예술", "예술");
                    else sqlCmd.Parameters.AddWithValue("@예술", "");
                    if (VM.StudentDataToSearch.자연과학Checked) sqlCmd.Parameters.AddWithValue("@자연과학", "자연과학");
                    else sqlCmd.Parameters.AddWithValue("@자연과학", "");
                    if (VM.StudentDataToSearch.스마트팜학과Checked) sqlCmd.Parameters.AddWithValue("@스마트팜학과", "스마트팜학과");
                    else sqlCmd.Parameters.AddWithValue("@스마트팜학과", "");
                    if (VM.StudentDataToSearch.글로벌융합Checked) sqlCmd.Parameters.AddWithValue("@글로벌융합", "글로벌융합");
                    else sqlCmd.Parameters.AddWithValue("@글로벌융합", "");
                    if (VM.StudentDataToSearch.사회과학Checked) sqlCmd.Parameters.AddWithValue("@사회과학", "사회과학");
                    else sqlCmd.Parameters.AddWithValue("@사회과학", "");
                    if (VM.StudentDataToSearch.수의과Checked) sqlCmd.Parameters.AddWithValue("@수의과", "수의과");
                    else sqlCmd.Parameters.AddWithValue("@수의과", "");
                    if (VM.StudentDataToSearch.의과Checked) sqlCmd.Parameters.AddWithValue("@의과", "의과");
                    else sqlCmd.Parameters.AddWithValue("@의과", "");
                    if (VM.StudentDataToSearch.치과Checked) sqlCmd.Parameters.AddWithValue("@치과", "치과");
                    else sqlCmd.Parameters.AddWithValue("@치과", "");

                    SqlDataReader dataRead = sqlCmd.ExecuteReader();
                    
                    while (dataRead.Read())
                    {
                        StudentDataToSearch dataToAdd = new StudentDataToSearch();

                        dataToAdd.Email = (string)dataRead["Email"];
                        dataToAdd.Name = (string)dataRead["StudentName"];
                        dataToAdd.PhoneNumber = (string)dataRead["PhoneNum"];
                        dataToAdd.IsNameVisible = Convert.ToBoolean(dataRead["IsNameVisible"]);
                        dataToAdd.StudentNumber = (string)dataRead["StudentNumber"];
                        dataToAdd.IsStudentNumberVisible = Convert.ToBoolean(dataRead["IsStudentNumberVisible"]);
                        dataToAdd.IsEmailVisible = Convert.ToBoolean(dataRead["IsEmailVisible"]);
                        dataToAdd.IsPhoneNumberVisible = Convert.ToBoolean(dataRead["IsPhoneNumberVisible"]);
                        dataToAdd.DoSmoke = Convert.ToBoolean(dataRead["DoSmoke"]);
                        dataToAdd.DidMilitaryService = Convert.ToBoolean(dataRead["DidMilitaryService"]);
                        dataToAdd.HaveLover = Convert.ToBoolean(dataRead["HaveLover"]);
                        dataToAdd.IsKorean = Convert.ToBoolean(dataRead["IsKorean"]);
                        dataToAdd.BedTime = (int)dataRead["BedTime"];
                        dataToAdd.WakeUpTime = (int)dataRead["WakeUpTime"];
                        dataToAdd.CleaningPerMonth = (int)dataRead["CleaningPerMonth"];
                        dataToAdd.DoSnore = Convert.ToBoolean(dataRead["DoSnore"]);
                        dataToAdd.DoBruise = Convert.ToBoolean(dataRead["DoBruise"]);
                        dataToAdd.DoSleepTalking = Convert.ToBoolean(dataRead["DoSleepTalking"]);
                        dataToAdd.DoTossAndTurn = Convert.ToBoolean(dataRead["DoTossAndTurn"]);
                        dataToAdd.Religion = (string)dataRead["Religion"];
                        dataToAdd.College = (string)dataRead["College"];
                        dataToAdd.IsMbtiE = Convert.ToBoolean(dataRead["IsMbtiE"]);
                        dataToAdd.IsMbtiS = Convert.ToBoolean(dataRead["IsMbtiS"]);
                        dataToAdd.IsMbtiT = Convert.ToBoolean(dataRead["IsMbtiT"]);
                        dataToAdd.IsMbtiJ = Convert.ToBoolean(dataRead["IsMbtiJ"]);
                        dataToAdd.Sex = (string)dataRead["Sex"];
                        dataToAdd.ProfileButtonString = (string)dataToAdd.StudentNumber+ " " + dataToAdd.Name;
                        VM.StudentDataToShowProfiles.Add(dataToAdd);
                    }
                    dataRead.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    if (sqlCon.State == ConnectionState.Closed)
                        sqlCon.Open();
                    string query = "SELECT * From tblStudent Where IsApplied = @IsApplied And Sex = @Sex And ((Email = @Email And IsEmailVisible = 1) Or (StudentName = @StudentName And IsNameVisible = 1) Or (PhoneNum = @PhoneNum And IsPhoneNumberVisible = 1) Or (StudentNumber = @StudentNumber And IsStudentNumberVisible = 1))";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@IsApplied", "신청 없음");
                    sqlCmd.Parameters.AddWithValue("@Sex", VM.StudentDataToLogIn.Sex);
                    sqlCmd.Parameters.AddWithValue("@Email", searchedBy);
                    sqlCmd.Parameters.AddWithValue("@PhoneNum", searchedBy);
                    sqlCmd.Parameters.AddWithValue("@StudentNumber", searchedBy);
                    sqlCmd.Parameters.AddWithValue("@StudentName", searchedBy);

                    SqlDataReader dataRead = sqlCmd.ExecuteReader();

                    StudentDataToSearch dataToAdd = new StudentDataToSearch();
                    while (dataRead.Read())
                    {
                        dataToAdd.Email = (string)dataRead["Email"];
                        dataToAdd.Name = (string)dataRead["StudentName"];
                        dataToAdd.PhoneNumber = (string)dataRead["PhoneNum"];
                        dataToAdd.IsNameVisible = Convert.ToBoolean(dataRead["IsNameVisible"]);
                        dataToAdd.StudentNumber = (string)dataRead["StudentNumber"];
                        dataToAdd.IsStudentNumberVisible = Convert.ToBoolean(dataRead["IsStudentNumberVisible"]);
                        dataToAdd.IsEmailVisible = Convert.ToBoolean(dataRead["IsEmailVisible"]);
                        dataToAdd.IsPhoneNumberVisible = Convert.ToBoolean(dataRead["IsPhoneNumberVisible"]);
                        dataToAdd.DoSmoke = Convert.ToBoolean(dataRead["DoSmoke"]);
                        dataToAdd.DidMilitaryService = Convert.ToBoolean(dataRead["DidMilitaryService"]);
                        dataToAdd.HaveLover = Convert.ToBoolean(dataRead["HaveLover"]);
                        dataToAdd.IsKorean = Convert.ToBoolean(dataRead["IsKorean"]);
                        dataToAdd.BedTime = (int)dataRead["BedTime"];
                        dataToAdd.WakeUpTime = (int)dataRead["WakeUpTime"];
                        dataToAdd.CleaningPerMonth = (int)dataRead["CleaningPerMonth"];
                        dataToAdd.DoSnore = Convert.ToBoolean(dataRead["DoSnore"]);
                        dataToAdd.DoBruise = Convert.ToBoolean(dataRead["DoBruise"]);
                        dataToAdd.DoSleepTalking = Convert.ToBoolean(dataRead["DoSleepTalking"]);
                        dataToAdd.DoTossAndTurn = Convert.ToBoolean(dataRead["DoTossAndTurn"]);
                        dataToAdd.Religion = (string)dataRead["Religion"];
                        dataToAdd.College = (string)dataRead["College"];
                        dataToAdd.IsMbtiE = Convert.ToBoolean(dataRead["IsMbtiE"]);
                        dataToAdd.IsMbtiS = Convert.ToBoolean(dataRead["IsMbtiS"]);
                        dataToAdd.IsMbtiT = Convert.ToBoolean(dataRead["IsMbtiT"]);
                        dataToAdd.IsMbtiJ = Convert.ToBoolean(dataRead["IsMbtiJ"]);
                        dataToAdd.Sex = (string)dataRead["Sex"];
                        dataToAdd.ProfileButtonString = (string)dataToAdd.StudentNumber +" "+ dataToAdd.Name;
                        VM.StudentDataToShowProfiles.Add(dataToAdd);
                    }
                    dataRead.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("설문조사를 먼저 해주세요.");
                    MessageBox.Show(ex.Message);
                }
            }
        }        
    }
}
