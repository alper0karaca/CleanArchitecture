using CleanArchitecture.Application.Services;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace CleanArchitecture.Infrastructure.Email;

public sealed class MailService : IMailService
{
    private readonly MailSettings _mailSettings;

    public MailService(IOptions<MailSettings> mailSettings)
    {
        _mailSettings = mailSettings.Value;
    }
    
    public async Task SendMailAsync(string to, string subject, string body, bool isHtml = true)
    {
        var email = new MimeMessage();
        email.From.Add(new MailboxAddress(_mailSettings.SenderName, _mailSettings.SenderEmail));
        email.To.Add(MailboxAddress.Parse(to));
        email.Subject = subject;

        email.Body = new TextPart(isHtml ? "html" : "plain") { Text = body };

        using var smtp = new SmtpClient();
        await smtp.ConnectAsync(_mailSettings.SmtpServer, _mailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
        await smtp.AuthenticateAsync(_mailSettings.Username, _mailSettings.Password);
        await smtp.SendAsync(email);
        await smtp.DisconnectAsync(true);
    }
}