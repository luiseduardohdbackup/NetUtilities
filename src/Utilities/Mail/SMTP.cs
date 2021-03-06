﻿using System.Net;
using System.Net.Mail;

namespace Utilities.Mail
{
    public static class SMTP
    {
        public static void Send(MailOptions mail)
        {
            var message        = new MailMessage();
            message.To.Add(mail.To);
            message.From       = new MailAddress(mail.From);
            message.Subject    = mail.Subject;
            message.Body       = mail.Body;
            message.IsBodyHtml = mail.UseHtml;

            var smtp = new SmtpClient
            {
                Credentials = new NetworkCredential(mail.Username, mail.Password),
                EnableSsl   = mail.UseSsl,
                Host        = mail.SMTPHost,
                Port        = mail.SMTPPort
            };
            smtp.Send(message);
        }
    }
}