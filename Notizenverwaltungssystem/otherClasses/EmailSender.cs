using Notizenverwaltungssystem.interfaces;
using System.Net;
using System.Net.Mail;

namespace Notizenverwaltungssystem.otherClasses{
    public class EmailSender : IEmailSender{
        #region Fields
        string _yourEMail = "notemanagementsystem@gmail.com";
        string _EMailPW = "vcol vyyr byip ovyr";   
        #endregion
        #region Methods
        public Task SendEmailAsync(string email, string subject, string message){
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_yourEMail, _EMailPW)
            };
            return client.SendMailAsync(new MailMessage(from: _yourEMail,
                                                        to: email,
                                                        subject,
                                                        message
                                                        ));
        }
        #endregion
    }
}
