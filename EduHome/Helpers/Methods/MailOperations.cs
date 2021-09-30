using EduHome.Models.Base;
using EduHome.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EduHome.Helpers.Methods
{
    public static class MailOperations
    {
        public static void SendMessage(BaseMessage myMessage)
        {
          
            var client = new SmtpClient();

            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Port = 587;
            client.Credentials = new System.Net.NetworkCredential("orkhanaib@code.edu.az", "Orxan620");

            var message = new System.Net.Mail.MailMessage("orkhanaib@code.edu.az",myMessage.Email);

            message.Subject = myMessage.Subject;
            message.Body = myMessage.Message;
            message.Priority = MailPriority.High;
            message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;

            client.Send(message);

            client.Dispose();

            Console.WriteLine("Message Sent");

        }
    }
}
