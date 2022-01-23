using MailKit;

namespace Przychodnia.Server.Services
{
    public interface IMailService
    {
        Task<bool> findAttachment(string attachmentName);
        Task<IMailFolder> getFolder(string folderName);
        void test();
        Task sendEmail(string recivingMail, string subject, string body);
    }
}
