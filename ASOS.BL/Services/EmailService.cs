using MailKit.Net.Smtp;
using MimeKit;

namespace ASOS.BL.Services
{
	public class EmailService: IEmailService
	{
		public EmailService()
		{
			
		}
		public async Task SendEmailAsync(string toEmail, string subject, string body)
		{
			var email = new MimeMessage();
			email.From.Add(MailboxAddress.Parse("asoswebsite06@gmail.com"));
			email.To.Add(MailboxAddress.Parse(toEmail));
			email.Subject = subject;
			email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = body };

			using var smtp = new SmtpClient();
			await smtp.ConnectAsync("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTlsWhenAvailable);
			await smtp.AuthenticateAsync("asoswebsite06@gmail.com", "pfatgmjgpgmzcnjn");
			await smtp.SendAsync(email);
			await smtp.DisconnectAsync(true);
		}
	}
}
