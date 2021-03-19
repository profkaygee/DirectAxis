using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailSending
{
    class Program
    {
        static void Main(string[] args)
        {
            //var emails = new string[]{"profkagiso@gmail.com" };
            var emails = new string[]
            {
                "pes@labour.gov.za",
                "wslvacancy@wearcheck.co.za", // Subject: WearCheck Vacancy - WSL Despatch Assistant
                "reception@lfelectronics.co.za",
                "marketing@mprtc.co.za",
                "sumanrie@francolerouxminingkld.co.za",
                "cv.vistaseroka@gmail.com",
                "rosemary@sfgenginering.co.za",
                "admin@gijimadeliveries.co.za",
                "recruitment@afrimat.co.za",
                "cv@burnabys.co.za",
                "rudy@tarpcover.co.za",
                "tshwane.hr@gauteng.gov.za",
                "recruitment9@brmo.co.za",
                "enquiries@sectech.co.za",
              "fortunate@carolinaebt.co.za",
              "profkagiso@gmail.com"
            };

            foreach (var email in emails)
            {
                var mailMessage = new MailMessage();
                mailMessage.Subject = "Please find attached my CV.";
                mailMessage.From = new MailAddress("matutuleboti@gmail.com", "Rebotile Matutule");
                mailMessage.To.Add(new MailAddress(email));
                mailMessage.Body = "To whom it may concern<br /><br />Please find attached my CV for your consideration. <br/><br/>Yours faithfully<br/>Rebotile Matutule<br/>072 851 8813";
                mailMessage.IsBodyHtml = true;

                if (email == "wslvacancy@wearcheck.co.za")
                {
                    mailMessage.Subject = "WearCheck Vacancy - WSL Despatch Assistant";
                }

                mailMessage.Attachments.Add(new Attachment("C:\\Users\\KagisoM\\Downloads\\pta cv.pdf"));

                var client = new SmtpClient();
                client.Host = "mail.corevasion.co.za";
                client.Port = 25;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential()
                {
                    UserName = "kmahlobogoane@corevasion.co.za",
                    Password = "Password1234"
                };

                try
                {
                    client.Send(mailMessage);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Email sent successfully to [{email}]");
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Email not sent to [{email}]. Exception: [{ex.Message.ToString()}]");
                }
            }
        }
    }
}
