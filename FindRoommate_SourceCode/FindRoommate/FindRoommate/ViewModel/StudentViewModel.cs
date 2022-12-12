using FindRoommate.Model;
using FindRoommate.ViewModel.Commands;
using Search.Model;
using System.Collections.ObjectModel;

namespace FindRoommate.ViewModel
{
    public class StudentViewModel
    {
        public string Cnnstr = "Server=210.117.180.72,****;Database=LogIn_DB;User Id=findroommate;Password=********;";
        
        public ObservableCollection<ChattingModel> MessageList { get; set; }

        public EmailData EmailData { get; set; }
        public LogInData LogInData { get; set; }
        public ChattingData ChattingData { get; set; }
        public StudentData StudentDataToSignUp { get; set; }
        public StudentData StudentDataToLogIn { get; set; }
        public StudentDataToSearch StudentDataToSearch { get; set; }
        public StudentData StudentDataToShowPartner { get; set; }

        public ObservableCollection<StudentDataToSearch> StudentDataToShowProfiles { get; set; }
        public LogInButtonCommand LogInButtonCommand { get; set; }
        public SaveButtonCommand SaveButtonCommand { get; set; }
        public SearchButtonCommand SearchButtonCommand { get; set; }
        public SignUpCommand SignUpCommand { get; set; }
        public RefreshCommand RefreshCommand { get; set; }
        public ChattingButtonCommand ChattingButtonCommand { get; set; }
        public EmailSendCommand EmailSendCommand { get; set; }
        public EmailCheckCommand EmailCheckCommand { get; set; }
        public PartnerProfileButtonCommand PartnerProfileButtonCommand { get; set; }
        public SendCommand SendCommand { get; set; }
        public ApplyCommand ApplyCommand { get; set; }
        
        public StudentViewModel()
        {            
            MessageList = new ObservableCollection<ChattingModel>();

            EmailData = new EmailData();
            LogInData = new LogInData();
            ChattingData = new ChattingData();

            StudentDataToSignUp = new StudentData();
            StudentDataToLogIn = new StudentData();
            StudentDataToSearch = new StudentDataToSearch();
            StudentDataToShowPartner = new StudentData();
            StudentDataToShowProfiles = new ObservableCollection<StudentDataToSearch>();

            LogInButtonCommand = new LogInButtonCommand(this);
            SaveButtonCommand = new SaveButtonCommand(this);
            SearchButtonCommand = new SearchButtonCommand(this);
            SignUpCommand = new SignUpCommand(this);
            RefreshCommand = new RefreshCommand(this);
            ChattingButtonCommand = new ChattingButtonCommand(this);
            EmailSendCommand = new EmailSendCommand(this);
            EmailCheckCommand = new EmailCheckCommand(this);
            PartnerProfileButtonCommand = new PartnerProfileButtonCommand(this);
            SendCommand = new SendCommand(this);
            ApplyCommand = new ApplyCommand(this);
        }
    }
}
