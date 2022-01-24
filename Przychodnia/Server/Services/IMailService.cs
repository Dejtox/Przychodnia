using MailKit;

namespace Przychodnia.Server.Services
{
    public interface IMailService
    {
        Task<bool> findAttachment(string attachmentName);
        Task<IMailFolder> getFolder(string folderName);
        Task sendEmail(string recivingMail, string subject, string body);

        List<string> allAttachmentNames();
    }
}
