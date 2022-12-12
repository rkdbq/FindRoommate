using System.ComponentModel;

namespace Search.Model //경로 맞춰야 함
{
    public class StudentData:INotifyPropertyChanged
    {

        public StudentData()
        {
            Name = "이름";
            IsNameVisible = true;
            StudentNumber = "학번";
            IsStudentNumberVisible = true;
            Email = "학교 이메일";
            emailCheck = "이메일 인증코드";
            IsEmailVisible = true;
            Password = "비밀번호";
            PasswordCheck = "비밀번호 확인";
            PhoneNumber = "연락처";
            IsPhoneNumberVisible = true;

            Sex = "남";

            DoSmoke = true;
            DidMilitaryService = true;
            HaveLover = true;
            IsKorean = true;

            IsMbtiE = true;
            IsMbtiS = true;
            IsMbtiT = true;
            IsMbtiJ = true;

            BedTime = 21;
            WakeUpTime = 9;
            CleaningPerMonth = 30;

            DoSnore = true;
            DoBruise = true;
            DoSleepTalking = true;
            DoTossAndTurn = true;

            Religion = null;
            College = "Engeering";
        }

        public void Init()
        {
            Name = "이름";
            IsNameVisible = true;
            StudentNumber = "학번";
            IsStudentNumberVisible = true;
            Email = "학교 이메일";
            IsEmailVisible = true;
            Password = "비밀번호";
            PhoneNumber = "연락처";
            IsPhoneNumberVisible = true;

            DoSmoke = true;
            DidMilitaryService = true;
            HaveLover = true;
            IsKorean = true;

            IsMbtiE = true;
            IsMbtiS = true;
            IsMbtiT = true;
            IsMbtiJ = true;

            BedTime = 21;
            WakeUpTime = 9;
            CleaningPerMonth = 30;

            DoSnore = true;
            DoBruise = true;
            DoSleepTalking = true;
            DoTossAndTurn = true;

            Religion = null;
            College = "Engeering";
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }

        private bool isNameVisible;

        public bool IsNameVisible
        {
            get { return isNameVisible; }
            set { isNameVisible = value; OnPropertyChanged("IsNameVisible"); }
        }

        private string studentNumber;

        public string StudentNumber
        {
            get { return studentNumber; }
            set { studentNumber = value; OnPropertyChanged("StudentNumber"); }
        }

        private bool isStudentNumberVisible;

        public bool IsStudentNumberVisible
        {
            get { return isStudentNumberVisible; }
            set { isStudentNumberVisible = value; OnPropertyChanged("IsStudentNumberVisible"); }
        }

        private string sex;

        public string Sex
        {
            get { return sex; }
            set { sex = value; OnPropertyChanged("Sex"); }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged("Email"); }
        }

        private string emailCheck;

        public string EmailCheck
        {
            get { return emailCheck; }
            set { emailCheck = value; OnPropertyChanged("EmailCheck"); }
        }


        private bool isEmailVisible;

        public bool IsEmailVisible
        {
            get { return isEmailVisible; }
            set { isEmailVisible = value; }
        }


        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged("Password"); }
        }

        private string passwordCheck;

        public string PasswordCheck
        {
            get { return passwordCheck; }
            set { passwordCheck = value; OnPropertyChanged("PasswordCheck"); }
        }


        private string phoneNumber;

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; OnPropertyChanged("PhoneNumber"); }
        }

        private bool isPhoneNumberVisible;

        public bool IsPhoneNumberVisible
        {
            get { return isPhoneNumberVisible; }
            set { isPhoneNumberVisible = value; }
        }


        private bool doSmoke;

        public bool DoSmoke
        {
            get { return doSmoke; }
            set { doSmoke = value; OnPropertyChanged("DoSmoke"); }
        }

        private bool didMilitaryService;
                
        public bool DidMilitaryService
        {
            get { return didMilitaryService; }
            set { didMilitaryService = value; OnPropertyChanged("DidMilitaryService"); }
        }

        private bool haveLover;

        public bool HaveLover
        {
            get { return haveLover; }
            set { haveLover = value; OnPropertyChanged("HaveLover"); }
        }

        private bool isKorean;

        public bool IsKorean
        {
            get { return isKorean; }
            set { isKorean = value; OnPropertyChanged("IsKorean"); }
        }

        private bool isMbtiE;

        public bool IsMbtiE
        {
            get { return isMbtiE; }
            set { isMbtiE = value; OnPropertyChanged("IsMbtiE"); }
        }

        private bool isMbtiS;

        public bool IsMbtiS
        {
            get { return isMbtiS; }
            set { isMbtiS = value; OnPropertyChanged("IsMbtiS"); }
        }

        private bool isMbtiT;

        public bool IsMbtiT
        {
            get { return isMbtiT; }
            set { isMbtiT = value; OnPropertyChanged("IsMbtiT"); }
        }

        private bool isMbtiJ;

        public bool IsMbtiJ
        {
            get { return isMbtiJ; }
            set { isMbtiJ = value; OnPropertyChanged("IsMbtiJ"); }
        }

        private int bedTime;

        public int BedTime
        {
            get { return bedTime; }
            set { bedTime = value; OnPropertyChanged("BedTime"); }
        }

        private int wakeUpTime;

        public int WakeUpTime
        {
            get { return wakeUpTime; }
            set { wakeUpTime = value; OnPropertyChanged("WakeUpTime"); }
        }

        private int cleaningPerMonth;

        public int CleaningPerMonth
        {
            get { return cleaningPerMonth; }
            set { cleaningPerMonth = value; OnPropertyChanged("CleaningPerMonth"); }
        }

        private bool doSnore; //코골이

        public bool DoSnore
        {
            get { return doSnore; }
            set { doSnore = value; OnPropertyChanged("DoSnore"); }
        }

        private bool doBruise; //이갈이

        public bool DoBruise
        {
            get { return doBruise; }
            set { doBruise = value; OnPropertyChanged("DoBruise"); }
        }

        private bool doSleepTalking; //잠꼬대

        public bool DoSleepTalking
        {
            get { return doSleepTalking; }
            set { doSleepTalking = value; OnPropertyChanged("DoSleepTalking"); }
        }

        private bool doTossAndTurn; //뒤척임

        public bool DoTossAndTurn
        {
            get { return doTossAndTurn; }
            set { doTossAndTurn = value; OnPropertyChanged("DoTossAndTurn"); }
        }

        private string religion;

        public string Religion
        {
            get { return religion; }
            set { religion = value; OnPropertyChanged("Religion"); }
        }

        private string college;

        public string College
        {
            get { return college; }
            set { college = value; OnPropertyChanged("College"); }
        }

        private string isApplied;

        public string IsApplied
        {
            get { return isApplied; }
            set { isApplied = value; OnPropertyChanged("IsApplied"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName)); }
        }
    }
}
