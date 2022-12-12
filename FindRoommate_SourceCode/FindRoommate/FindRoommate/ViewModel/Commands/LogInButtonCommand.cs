using FindRoommate.Model;
using FindRoommate.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace FindRoommate.ViewModel.Commands
{
    public class LogInButtonCommand : ICommand
    {
        MainWindow MainWindow;

        private void RecieveMessage()
        {
            string receiveMessage = "";
            List<string> receiveMessageList = new List<string>();
            while (true)
            {
                try
                {
                    byte[] receiveByte = new byte[1024];
                    VM.ChattingData.client.GetStream().Read(receiveByte, 0, receiveByte.Length);

                    receiveMessage = Encoding.Default.GetString(receiveByte);

                    string[] receiveMessageArray = receiveMessage.Split('>');
                    foreach (var item in receiveMessageArray)
                    {
                        if (!item.Contains('<'))
                            continue;
                        if (item.Contains("관리자<TEST"))
                            continue;

                        receiveMessageList.Add(item);
                    }

                    ParsingReceiveMessage(receiveMessageList);
                }
                catch (Exception e)
                {
                    MessageBox.Show("서버와의 연결이 끊어졌습니다.", "Server Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    MessageBox.Show(e.Message);
                    MessageBox.Show(e.StackTrace);
                    Environment.Exit(1);
                }
                Thread.Sleep(500);
            }
        }

        private void ParsingReceiveMessage(List<string> messageList)
        {
            foreach (var item in messageList)
            {
                string chattingPartner = "";
                string message = "";

                if (item.Contains('<'))
                {
                    string[] splitedMsg = item.Split('<');

                    chattingPartner = splitedMsg[0];
                    message = splitedMsg[1];

                    // 하트비트 
                    if (chattingPartner == "관리자")
                    {
                        ObservableCollection<User> tempUserList = new ObservableCollection<User>();
                        string[] splitedUser = message.Split('$');
                        foreach (var el in splitedUser)
                        {
                            if (string.IsNullOrEmpty(el))
                                continue;
                            tempUserList.Add(new User(el));
                        }
                        messageList.Clear();
                        return;
                    }

                    // 1:1채팅
                    else
                    {
                        if (!VM.ChattingData.chattingThreadDic.ContainsKey(chattingPartner))
                        {
                            if (message == "ChattingStart")
                            {
                                Thread chattingThread = new Thread(() => ThreadStartingPoint(chattingPartner));
                                chattingThread.SetApartmentState(ApartmentState.STA);
                                chattingThread.IsBackground = true;
                                chattingThread.Start();
                            }
                        }
                        else
                        {
                            if (VM.ChattingData.chattingThreadDic[chattingPartner].chattingThread.IsAlive)
                            {
                                VM.ChattingData.chattingThreadDic[chattingPartner].chattingWindow.ReceiveMessage(chattingPartner, message);
                            }
                        }
                        messageList.Clear();
                        return;
                    }
                }
            }
            messageList.Clear();
        }

        private void ThreadStartingPoint(string chattingPartner)
        {
            VM.ChattingData.chattingPartner = chattingPartner;
            VM.ChattingData.chattingWindow = new ChattingWindow(VM);
            VM.ChattingData.chattingThreadDic.Add(chattingPartner, new ChattingThreadData(Thread.CurrentThread, VM.ChattingData.chattingWindow));

            if (VM.ChattingData.chattingWindow.ShowDialog() == true)
            {
                MessageBox.Show("채팅이 종료되었습니다.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                VM.ChattingData.chattingThreadDic.Remove(chattingPartner);
            }
        }

        StudentViewModel VM;
        public LogInButtonCommand(StudentViewModel VM)
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
            if (VM.StudentDataToLogIn.Email == "" ||  VM.StudentDataToLogIn.Password == "" || VM.StudentDataToLogIn.Email == "학교 이메일" || VM.StudentDataToLogIn.Password == "비밀번호") return false;
            else return true;
        }

        public void Execute(object parameter)
        {
            SqlConnection sqlCon = new SqlConnection(VM.Cnnstr);
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                String query = "SELECT COUNT(1) FROM tblStudent WHERE Email=@Email AND StudentPW=@StudentPW";

                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Email", VM.StudentDataToLogIn.Email);
                sqlCmd.Parameters.AddWithValue("@StudentPW", VM.StudentDataToLogIn.Password);
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count == 1)
                {
                    int newSignIn = 0;

                    MessageBox.Show("로그인 성공!");

                    query = "SELECT NewSignIn From tblStudent Where Email=@Email ";
                    sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@Email", VM.StudentDataToLogIn.Email);

                    SqlDataReader dataRead = sqlCmd.ExecuteReader();
                    while (dataRead.Read()) { newSignIn = (int)dataRead["NewSignIn"]; }
                    dataRead.Close();

                    if(newSignIn == 1)
                    {
                        MessageBox.Show("설문조사가 필요합니다.");
                    }

                    query = "SELECT Email From tblStudent Where Email=@Email ";
                    sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@Email", VM.StudentDataToLogIn.Email);

                    dataRead = sqlCmd.ExecuteReader();
                    while (dataRead.Read()) { VM.StudentDataToLogIn.Email = (string)dataRead["Email"]; }
                    dataRead.Close();

                    query = "SELECT StudentName From tblStudent Where Email=@Email ";
                    sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@Email", VM.StudentDataToLogIn.Email);

                    dataRead = sqlCmd.ExecuteReader();
                    while (dataRead.Read()) { VM.StudentDataToLogIn.Name = (string)dataRead["StudentName"]; }
                    dataRead.Close();

                    query = "SELECT PhoneNum From tblStudent Where Email=@Email ";
                    sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@Email", VM.StudentDataToLogIn.Email);
                    
                    dataRead = sqlCmd.ExecuteReader();
                    while (dataRead.Read()) { VM.StudentDataToLogIn.PhoneNumber = (string)dataRead["PhoneNum"]; }
                    dataRead.Close();

                    query = "SELECT StudentNumber From tblStudent Where Email=@Email ";
                    sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@Email", VM.StudentDataToLogIn.Email);

                    dataRead = sqlCmd.ExecuteReader();
                    while (dataRead.Read()) { VM.StudentDataToLogIn.StudentNumber = (string)dataRead["StudentNumber"]; }
                    dataRead.Close();

                    query = "SELECT IsApplied From tblStudent Where Email=@Email ";
                    sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@Email", VM.StudentDataToLogIn.Email);

                    dataRead = sqlCmd.ExecuteReader();
                    while (dataRead.Read()) { VM.StudentDataToLogIn.IsApplied = (string)dataRead["IsApplied"]; }
                    dataRead.Close();

                    if (VM.StudentDataToLogIn.IsApplied != "신청 없음")
                    {
                        MessageBox.Show(VM.StudentDataToLogIn.IsApplied + " 님의 룸메이트 신청이 있습니다.");
                        MessageBoxResult messageBoxResult = MessageBox.Show("신청을 수락하시겠습니까?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);

                        if (messageBoxResult == MessageBoxResult.No)
                        {
                            SqlConnection con = new SqlConnection(VM.Cnnstr);
                            SqlCommand cmd = con.CreateCommand();

                            cmd.CommandText = "Update tblStudent Set IsApplied = '신청 없음' Where Email = @Email";
                            cmd.Parameters.AddWithValue("@Email", VM.StudentDataToLogIn.Email);

                            try
                            {
                                con.Open();
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("거절되었습니다.");
                            }
                            catch (SqlException ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {

                            }
                        }
                        else if(messageBoxResult == MessageBoxResult.Yes)
                        {
                            SqlConnection con = new SqlConnection(VM.Cnnstr);
                            SqlCommand cmd = con.CreateCommand();

                            cmd.CommandText = "Update tblStudent Set IsApplied = @IsApplied Where StudentName = @Name";

                            cmd.Parameters.AddWithValue("@IsApplied", VM.StudentDataToLogIn.Name);
                            cmd.Parameters.AddWithValue("@Name", VM.StudentDataToLogIn.IsApplied);
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
                            finally
                            {

                            }
                        }
                        
                    }

                    if (VM.ChattingData.client != null)
                    {
                        MessageBox.Show("이미 로그인되었습니다.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    try
                    {
                        string ip = "210.117.180.72";
                        string parsedName = "%^&";
                        parsedName += VM.StudentDataToLogIn.Name;


                        VM.ChattingData.client = new TcpClient();
                        VM.ChattingData.client.Connect(ip, 9999);

                        byte[] byteData = new byte[parsedName.Length];
                        byteData = Encoding.Default.GetBytes(parsedName);
                        VM.ChattingData.client.GetStream().Write(byteData, 0, byteData.Length);

                        ChattingData.myName = VM.StudentDataToLogIn.Name;

                        VM.ChattingData.ReceiveThread = new Thread(RecieveMessage);
                        VM.ChattingData.ReceiveThread.Start();
                    }
                    catch
                    {
                        MessageBox.Show("서버연결에 실패하였습니다.", "Server Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        VM.ChattingData.client = null;
                    }
                    MainWindow = new MainWindow();
                    MainWindow.Show();
                }

                else
                {
                    MessageBox.Show("로그인 실패!");
                }      
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }
    }
}
