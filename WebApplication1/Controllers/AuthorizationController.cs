using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Infrastructure.Models;
using System.Net;
using System.Net.Mail;
using WebApplication1.Infrastructure;

namespace WebApplication1.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        public WeatherContext context { get; }

        public AuthorizationController(WeatherContext weatherContext)
        {
            context = weatherContext;
        }
        [HttpGet]
        [Route("login")]

        public Users Login(string usernametxt, string passwordtxt, bool rememberMe)
        {
            Users curruser = (from u in context.Users
                             where u.username == usernametxt
                             && u.password == passwordtxt
                             select u).FirstOrDefault();
            if (curruser == null)
            {

                return null;
            }
            else
            {
                if (rememberMe == true)
                {
                    StreamWriter writerRemember = new StreamWriter(@"C:\Users\1\Desktop\rememberme.txt", false);
                    writerRemember.WriteLine(usernametxt);
                    writerRemember.WriteLine(passwordtxt);
                    writerRemember.Close();
                    writerRemember.Dispose();

                }

                //bazashi shevinaxot - username; auth date; IP; MAC
                StreamWriter writerLog = new StreamWriter(@"C:\Users\1\Desktop\userlog.txt", false);
                writerLog.WriteLine(usernametxt);
                writerLog.WriteLine(passwordtxt);
                writerLog.Close();
                writerLog.Dispose();
                return curruser;
            }
        }

        [HttpGet]
        [Route("register")]
        public bool Registration(string usernametxt, string passwordtxt, string mail)
        {
            //check for existing user!
            if (usernametxt != null && passwordtxt != null)
            {
                Users checkuser = (from u in context.Users
                                  where u.username == usernametxt
                                  && u.password == passwordtxt
                                  select u).FirstOrDefault();
                if (checkuser == null)
                {
                    Users newuser = new Users
                    {
                        username = usernametxt,
                        password = passwordtxt,
                        role_id = 3,
                        mail = mail

                    };
                    context.Users.Add(newuser);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        [HttpGet]
        [Route("validate")]
        public Users ValidateUser(string mail)
        {

            Users curruser = (from u in context.Users
                             where u.mail == mail
                             select u).FirstOrDefault();
            if (curruser != null)
            {
                return curruser;
            }
            else
            {
                return null;
            }

        }

        [HttpGet]
        [Route("sendmail")]
        public bool SendMail(string toEmail, string username, string password)
        {

            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("mishotsiskaridze@gmail.com", "cukrzcimeekbgevl"),
                    EnableSsl = true,
                };

                string mailtext = "Username: " + username + " password: " + password;

                smtpClient.Send("mishotsiskaridze@gmail.com", toEmail, "Your Login info", mailtext);

                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        [HttpPost]
        [Route("verifyadmin")]
        public bool IsAdmin(Users user)
        {

            if (user.role_id == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }


}
