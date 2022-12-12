using System.ComponentModel;
using System.Windows.Media;

namespace FindRoommate.Model
{
    public class ChattingModel : INotifyPropertyChanged
    {
        public ChattingModel()
        {
            ChatColor = Brushes.White;
            ChatTextColor = Brushes.Black;
        }

        private string messageList;

        public string MessageList
        {
            get { return messageList; }
            set { messageList = value; OnPropertyChanged("MessageList"); }
        }

        private string chatTime;

        public string ChatTime
        {
            get { return chatTime; }
            set { chatTime = value; OnPropertyChanged("ChatTime"); }
        }

        private Brush chatColor;

        public Brush ChatColor
        {
            get { return chatColor; }
            set { chatColor = value; OnPropertyChanged("ChatColor"); }
        }

        private Brush chatTextColor;

        public Brush ChatTextColor
        {
            get { return chatTextColor; }
            set { chatTextColor = value; OnPropertyChanged("ChatTextColor"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName)); }
        }
    }
}
