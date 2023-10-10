namespace Notizenverwaltungssystem.interfaces{
    public interface IEmailSender{
        Task SendEmailAsync(string email,string subject,string message);
    }
}
