using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using MimeKit;
using MailKit;
using Przychodnia.Server.Models;
using Przychodnia.Shared;

namespace Przychodnia.Server.Services
{
    public class MailService : IMailService
    {
        string _email;
        string _password;
        ImapClient _imapClient;
        SmtpClient _smtpClient;
        private readonly IVisitsRepository _visitsRepository;

        public MailService(IVisitsRepository visitsRepository)
        {
            _visitsRepository = visitsRepository;
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
                // var inbox = _imapClient.Inbox;
                //inbox.CountChanged += OnNewMessageRecived;
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

        //public async void OnNewMessageRecived(object sender, EventArgs e)
        //{
        //    var folder = (ImapFolder)sender;
        //    folder.Open(FolderAccess.ReadOnly);
        //    List<MimeMessage> messages = folder.ToList();
        //    List<MimeEntity> attachments = messages.First().Attachments.Where(a => a.ToString().Contains("FR")).ToList();
        //    if (attachments.Count() > 0)
        //    {
        //        string invoice = attachments.First().ToString();
        //        IEnumerable<Visit> visits = await _visitsRepository.GetVisits();
        //        visits = visits.Where(v => v.InvoiceNumber() == invoice).ToList();
        //        if(visits.Count() > 0)
        //        {
        //            Visit v = visits.First();
        //            v.Paid = true;
        //            await _visitsRepository.UpdateVisit(v);
        //        }
        //    }
        //}

        public async Task<bool> findAttachment(string attachmentName)
        {
            IMailFolder folder = _imapClient.Inbox;
            folder.Open(FolderAccess.ReadOnly);
            return folder.Where(m => m.Attachments.Where(a => a.ContentType.Name.Contains(attachmentName)).Any()).Any();
        }

        public List<string> allAttachmentNames()
        {
            List<string> result = new List<string>();
            IMailFolder folder = _imapClient.Inbox;
            folder.Open(FolderAccess.ReadOnly);
            foreach(var m in folder)
            {
                foreach(var a in m.Attachments)
                {
                    result.Add(a.ContentType.Name);
                }
            }
            return result;
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
                case MessageTypes.CreatedAccount:
                    return $"Witaj {moreInfo}, jesteśmy szczśliwi że założyłeś u nas konto";
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
    CancelVisitToPatient,
    CreatedAccount
}
