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
            mail.To.Add(new MailAddress("globaltechservicesnow@gmail.com"));
            mail.From = new MailAddress("globaltechservicesnow@gmail.com");
            client.Credentials = new System.Net.NetworkCredential("globaltechservicesnow@gmail.com", "haythamfaraz");
            mail.Subject = "test subject";
            client.EnableSsl = true;
            mail.IsBodyHtml = true;
            mail.Body = "<html>"
+ "<body>"
 + "<div> <h2>Email: " + emailModel.Email + " </h2> </br>"
 + "<h2> Name: " + emailModel.Name + "</h2> </br>" +
 "<h2> Phone number: " + emailModel.PhoneNumber + "</h2> </br>" +
 "<h2> More Information: " + emailModel.Message+ "</h2> </br>" 
 + "</div>"
 + "</body>"
 + "</html>";
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