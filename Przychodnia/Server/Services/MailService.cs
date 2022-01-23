using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using MimeKit;
using MailKit;
using Przychodnia.Server.Models;


namespace Przychodnia.Server.Services
{
    public class MailService : IMailService
    {
        string _email;
        string _password;
        ImapClient _imapClient;
        SmtpClient _smtpClient;

        public MailService()
        {
            try
            {
                _email = "wziimgr4@gmail.com";
                _password = "zaq1@WSX";
                _imapClient = new ImapClient();
                _smtpClient = new SmtpClient();
                _imapClient.Connect("imap.gmail.com", 993, true);
                _imapClient.Authenticate(_email, _password);
                _smtpClient.Connect("smtp.gmail.com", 465, true);
                _smtpClient.Authenticate(_email, _password);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void test()
        {
            Console.Write("hejo");
        }

        public async Task<bool> findAttachment(string attachmentName)
        {
            IMailFolder folder = await getFolder("INBOX");
            return folder.Where(m => m.Attachments.ToString() == attachmentName).Any();
        }

        public async Task<IMailFolder> getFolder(string folderName)
        {
                IList<IMailFolder>? folders = await _imapClient.GetFoldersAsync(new FolderNamespace('.', ""));
                return folders.Where(f => f.FullName == folderName).Single();
            
        }

        public async Task sendEmail(string recivingMail, string subject, string body)
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress(_email, _email));
            message.To.Add(MailboxAddress.Parse(recivingMail));
            message.Subject = subject;
            message.Body = new TextPart("plain") { Text = body };
            try
            {
                await _smtpClient.SendAsync(message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static string getMessageBody(MessageTypes messageType, string moreInfo)
        {
            switch (messageType)
            {
                case MessageTypes.NewVisitToDoctor:
                    return $"Nowa wizyta z pacjentem {moreInfo}";
                case MessageTypes.NewVisitToPatient:
                    return $"Nowa wizyta z lekarzem {moreInfo}";
                case MessageTypes.CancelVisitToDoctor:
                    return $"Anulowano wizytę z {moreInfo}";
                case MessageTypes.CancelVisitToPatient:
                    return $"Anulowano wizytę z {moreInfo}";
                default:
                    return "";
            }
        }
    }
}

public enum MessageTypes
{
    NewVisitToDoctor,
    NewVisitToPatient,
    CancelVisitToDoctor,
    CancelVisitToPatient
}
