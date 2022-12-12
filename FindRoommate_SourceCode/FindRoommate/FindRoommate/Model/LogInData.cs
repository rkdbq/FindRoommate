using System.ComponentModel;

namespace FindRoommate.Model
{
    public class LogInData : INotifyPropertyChanged
    {
        private bool emailChecked;

        public bool EmailChecked
        {
            get { return emailChecked; }
            set { emailChecked = value; OnPropertyChanged("EmailChecked"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName)); }
        }
    }
}
