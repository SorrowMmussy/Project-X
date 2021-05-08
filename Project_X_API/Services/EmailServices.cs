using System;
using System.IdentityModel.Tokens.Jwt;
using Project_X_API.DataBase.Repositories;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Project_X_API.Properties;

namespace Project_X_API.Services
{
    public class EmailServices
    {
        private readonly UserRepository _userRepository;
        private readonly IConfiguration _configuration;


        public EmailServices(UserRepository userRepository, IConfiguration config)
        {
            _userRepository = userRepository;
            _configuration = config;
        }

        public string GenerateToken()
        {
            return "";
        }

        public void SendToken(string email)
        {
            using (MailMessage mail = new MailMessage())
            {
                var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("Email", email)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var jwtToken = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);
                var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
                
                mail.From = new MailAddress("projectxtestemail@gmail.com");
                mail.To.Add(email);
                mail.Subject = "Test email subject";
                mail.Body = "<br/><br/>We are excited to tell you that your account is" +
                            " successfully created. Please click on the below link to verify your account : \n" + "http://localhost:3000/registration/" + token;
                mail.IsBodyHtml = true;
                //mail.Attachments.Add(new Attachment("C:\\file.zip"));

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("projectxtestemail@gmail.com", Resources.TestEmailPassword);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }
    }
}