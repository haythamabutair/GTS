using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using FireSharp;
using FireSharp.Config;
using FireSharp.Response;
using System.Net.Mail;
using System.Net;

namespace Support.Models
{
    public class SupportModel
    {
        public SupportModel()
        {
            
        }

        public async Task<string> retrieveSupportStringForId(int id)
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "WtyRxZxUb94IPMpd0ho9VlCdvpTDz7yO7dGCY42F",
                BasePath = "https://globaltechsupport.firebaseio.com/"
            };

            FirebaseClient firebase = new FirebaseClient(config);
            string url = "https://globaltechsupport.firebaseio.com/" + id;
            FirebaseResponse response = await firebase.GetAsync(id.ToString());
            return response.ResultAs<string>();
        }

        public bool sendMail(EmailModel emailModel)
        {
            MailMessage mail = new MailMessage();
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "smtp.gmail.com";
            mail.To.Add(new MailAddress(emailModel.Email));
            mail.From = new MailAddress("haytham.abutair@gmail.com");
            mail.Subject = "this is a test email.";
            client.EnableSsl = true;
            mail.Body = "this is my test email body";
            try
            {
                client.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}