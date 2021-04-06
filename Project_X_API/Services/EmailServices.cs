using Project_X_API.DataBase.Repositories;
using System.Net;
using System.Net.Mail;

namespace Project_X_API.Services
{
    public class EmailServices
    {
        private readonly UserRepository _userRepository;

        public EmailServices(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public string GenerateToken()
        {
            return "";
        }

        public void SendToken()
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("projectxtestemail@gmail.com");
                mail.To.Add("denas.kinderis@gmail.com");
                mail.Subject = "Test email subject";
                mail.Body = "<br/><br/>We are excited to tell you that your account is" +
                            " successfully created. Please click on the below link to verify your account";
                mail.IsBodyHtml = true;
                //mail.Attachments.Add(new Attachment("C:\\file.zip"));

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("projectxtestemail@gmail.com", "P11%%&*945Swoof&");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }
    }
}