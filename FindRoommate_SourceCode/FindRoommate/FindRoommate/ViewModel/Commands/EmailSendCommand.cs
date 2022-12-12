using System;
using System.Net;
using System.Net.Mail;
using System.Windows;
using System.Windows.Input;

namespace FindRoommate.ViewModel.Commands
{
    public class EmailSendCommand : ICommand
    {
        StudentViewModel VM;
        public EmailSendCommand(StudentViewModel VM)
        {
            this.VM = VM;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.EmailData.rnd = new Random();
            VM.EmailData.serial = VM.EmailData.rnd.Next(10000, 50001);
            var message = new MailMessage("********@jbnu.ac.kr", VM.StudentDataToSignUp.Email);
            message.Subject = "이메일 인증번호 발송";    //메일의 제목
            message.Body = VM.EmailData.serial.ToString();
            using (SmtpClient mailer = new SmtpClient("smtp.gmail.com", 587))
            {
                mailer.Credentials = new NetworkCredential("********@jbnu.ac.kr", "********");
                mailer.EnableSsl = true;
                mailer.Send(message);
            }
            MessageBox.Show("인증번호 발송");
        }
    }
}
