using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MimeKit;
using MailKit.Net.Smtp;
using System.Security.Policy;

namespace Example.Model
{
    public interface IEmailServise
    {
        void SendEmail(Email email,int id);
        void SendEmail(Email email);
    }
    public class EmailServise : IEmailServise
    {
        public void SendEmail(Email email,int id)
        {
            var emailMessage = new MimeMessage();
            var link = $"https://localhost:52712/main/reaciveemailresponse/{id}";
            emailMessage.From.Add(new MailboxAddress("Администрация сайта", "kalinus2775@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("", email.To));
            emailMessage.Subject = email.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = $"If you want subscript quotes click <a href='{ link }'>here</a>"
            };
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate("kalinus2775@gmail.com", "milliyunversitet");
                client.Send(emailMessage);
                client.Disconnect(true);
            }
        }

        public void SendEmail(Email email)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Администрация сайта", "kalinus2775@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("", email.To));
            emailMessage.Subject = email.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = email.Body
            };
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate("kalinus2775@gmail.com", "milliyunversitet");
                client.Send(emailMessage);
                client.Disconnect(true);
            }
        }
    }
}
