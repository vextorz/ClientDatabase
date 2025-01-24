using System.Net;
using System.Net.Mail;

namespace ClientDatabase
{
    public static class EmailHelper
    {
        public static bool ValidateCredentials(string email, string password, string host, int port)
        {
            try
            {
                using (SmtpClient smtpClient = new SmtpClient(host, port))
                {
                    smtpClient.Credentials = new NetworkCredential(email, password);
                    smtpClient.EnableSsl = true;
                    smtpClient.Send("test@test.com", "test@test.com", "Test email", "This is a test email.");
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void SendEmail(string from, string to, string subject, string body, string wordFilePath,
            string pdfFilePath, string host, int port, string password)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(from);
                mail.To.Add(to);
                mail.Subject = subject;
                mail.Body = body;

                // Attach the Word file
                if (!string.IsNullOrEmpty(wordFilePath))
                    mail.Attachments.Add(new Attachment(wordFilePath));

                // Attach the PDF file
                if (!string.IsNullOrEmpty(pdfFilePath))
                    mail.Attachments.Add(new Attachment(pdfFilePath));

                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = host;
                    smtp.Port = port;
                    smtp.Credentials = new NetworkCredential(from, password);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }
    }
}