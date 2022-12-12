using Search.Model;

namespace FindRoommate.Model
{
    public class StudentDataToSearch : StudentData
    {
        private string searchText;

        public string SearchText
        {
            get { return searchText; }
            set { searchText = value; OnPropertyChanged("SearchText"); }
            
        }
                
        public StudentDataToSearch() : base()
        {
            SearchText = "검색어를 입력하세요.(이름, 학번 등)";
            CatholicChecked = true;
            ChristianityChecked = true;
            BuddhismChecked = true;
            OtherChecked = true;
            간호Checked = true;
            농업생명과학Checked = true;
            상과Checked = true;
            약학Checked = true;
            인문Checked = true;
            환경생명자원Checked = true;
            공과Checked = true;
            사범Checked = true;
            생활과학Checked = true;
            예술Checked = true;
            자연과학Checked = true;
            스마트팜학과Checked = true;
            글로벌융합Checked = true;
            사회과학Checked = true;
            수의과Checked = true;
            의과Checked = true;
            치과Checked = true;
        }
        public new void Init()
        {
            base.Init();
            SearchText = "검색어를 입력하세요.(이름, 학번 등)";
            CatholicChecked = true;
            ChristianityChecked = true;
            BuddhismChecked = true;
            OtherChecked = true;
            간호Checked = true;
            농업생명과학Checked = true;
            상과Checked = true;
            약학Checked = true;
            인문Checked = true;
            환경생명자원Checked = true;
            공과Checked = true;
            사범Checked = true;
            생활과학Checked = true;
            예술Checked = true;
            자연과학Checked = true;
            스마트팜학과Checked = true;
            글로벌융합Checked = true;
            사회과학Checked = true;
            수의과Checked = true;
            의과Checked = true;
            치과Checked = true;
            
        }
        private string profileButtonString;

        public string ProfileButtonString
        {
            get { return profileButtonString; }
            set { profileButtonString = value; OnPropertyChanged("ProfileButtonString"); }
        }

        private bool catholicChecked;
        
        public bool CatholicChecked
        {
            get { return catholicChecked; }
            set { catholicChecked = value; OnPropertyChanged("CatholicChecked"); }
        }

        private bool christianityChecked;

        public bool ChristianityChecked
        {
            get { return christianityChecked; }
            set { christianityChecked = value; OnPropertyChanged("ChristianityChecked"); }
        }

        private bool buddhismChecked;

        public bool BuddhismChecked
        {
            get { return buddhismChecked; }
            set { buddhismChecked = value; OnPropertyChanged("BuddhismChecked"); }
        }

        private bool otherChecked;

        public bool OtherChecked
        {
            get { return otherChecked; }
            set { otherChecked = value; OnPropertyChanged("OtherChecked"); }
        }

        private bool _간호Checked;

        public bool 간호Checked
        {
            get { return _간호Checked; }
            set { _간호Checked = value; OnPropertyChanged("간호Checked"); }
        }

        private bool _농업생명과학Checked;

        public bool 농업생명과학Checked
        {
            get { return _농업생명과학Checked; }
            set { _농업생명과학Checked = value; OnPropertyChanged("농업생명과학Checked"); }
        }

        private bool _상과Checked;

        public bool 상과Checked
        {
            get { return _상과Checked; }
            set { _상과Checked = value; OnPropertyChanged("상과Checked"); }
        }

        private bool _약학Checked;

        public bool 약학Checked
        {
            get { return _약학Checked; }
            set { _약학Checked = value; OnPropertyChanged("약학Checked"); }
        }

        private bool _인문Checked;

        public bool 인문Checked
        {
            get { return _인문Checked; }
            set { _인문Checked = value; OnPropertyChanged("인문Checked"); }
        }
        private bool _환경생명자원Checked;

        public bool 환경생명자원Checked
        {
            get { return _환경생명자원Checked; }
            set { _환경생명자원Checked = value; OnPropertyChanged("환경생명자원Checked"); }
        }
        private bool _공과Checked;

        public bool 공과Checked
        {
            get { return _공과Checked; }
            set { _공과Checked = value; OnPropertyChanged("공과Checked"); }
        }
        private bool _사범Checked;

        public bool 사범Checked
        {
            get { return _사범Checked; }
            set { _사범Checked = value; OnPropertyChanged("사범Checked"); }
        }
        private bool _생활과학Checked;

        public bool 생활과학Checked
        {
            get { return _생활과학Checked; }
            set { _생활과학Checked = value; OnPropertyChanged("생활과학Checked"); }
        }
        private bool _예술Checked;

        public bool 예술Checked
        {
            get { return _예술Checked; }
            set { _예술Checked = value; OnPropertyChanged("예술Checked"); }
        }
        private bool _자연과학Checked;

        public bool 자연과학Checked
        {
            get { return _자연과학Checked; }
            set { _자연과학Checked = value; OnPropertyChanged("자연과학Checked"); }
        }
        private bool _스마트팜학과Checked;

        public bool 스마트팜학과Checked
        {
            get { return _스마트팜학과Checked; }
            set { _스마트팜학과Checked = value; OnPropertyChanged("스마트팜학과Checked"); }
        }
        private bool _글로벌융합Checked;

        public bool 글로벌융합Checked
        {
            get { return _글로벌융합Checked; }
            set { _글로벌융합Checked = value; OnPropertyChanged("글로벌융합Checked"); }
        }
        private bool _사회과학Checked;

        public bool 사회과학Checked
        {
            get { return _사회과학Checked; }
            set { _사회과학Checked = value; OnPropertyChanged("사회과학Checked"); }
        }
        private bool _수의과Checked;

        public bool 수의과Checked
        {
            get { return _수의과Checked; }
            set { _수의과Checked = value; OnPropertyChanged("수의과Checked"); }
        }
        private bool _의과Checked;

        public bool 의과Checked
        {
            get { return _의과Checked; }
            set { _의과Checked = value; OnPropertyChanged("의과Checked"); }
        }
        private bool _치과Checked;

        public bool 치과Checked
        {
            get { return _치과Checked; }
            set { _치과Checked = value; OnPropertyChanged("치과Checked"); }
        }
    }
}
