using FindRoommate.View;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Sockets;
using System.Threading;

namespace FindRoommate.Model
{
    public class ChattingData : INotifyPropertyChanged
    {
        private string chatText;

        public string ChatText
        {
            get { return chatText; }
            set { chatText = value; OnPropertyChanged("ChatText"); }
        }
               
        public static string myName = null;
        public TcpClient client = null;
        public Thread ReceiveThread = null;
        public ChattingWindow chattingWindow = null;
        public Dictionary<string, ChattingThreadData> chattingThreadDic = new Dictionary<string, ChattingThreadData>();
        public Dictionary<int, ChattingThreadData> groupChattingThreadDic = new Dictionary<int, ChattingThreadData>();

        public string chattingPartner = null;

        public ChattingData()
        {
            myName = null;
            client = null;
            ReceiveThread = null;
            chattingWindow = null;
            chattingThreadDic = new Dictionary<string, ChattingThreadData>();
            groupChattingThreadDic = new Dictionary<int, ChattingThreadData>();
            chattingPartner = null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName)); }
        }
    }
}
