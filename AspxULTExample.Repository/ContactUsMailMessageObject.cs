
    using AspxULTExample.Models;
    using MimeKit;
    using System;
    using System.Configuration;
    using System.IO;

    namespace AspxULTExample.Repository
    {
    public class ContactUsMailMessageObject : SmtpClientMailBaseObject
    {
    private string exceptionMsg = string.Empty;
    private readonly string messageProjectNameBase = "Aspx ULT Example";

    private string PopulateBody(string projectNameBase, ContactUs contactUs)
    {
    string body = string.Empty;
    string emailTemplate = System.Web.Hosting.HostingEnvironment.MapPath("~/Template/ContactUsEmailTemplate.html");

    if (contactUs != null && File.Exists(emailTemplate))
    {
    using (StreamReader reader = new StreamReader(emailTemplate))
    {
    body = reader.ReadToEnd();
    }
    body = body.Replace("{0}", projectNameBase);
    body = body.Replace("{1}", contactUs.FullName);
    body = body.Replace("{2}", contactUs.EmailAddress);
    body = body.Replace("{3}", contactUs.Comments);
    body = body.Replace("{4}", DateTime.Now.Year.ToString());
    }
    else
    {
    exceptionMsg = "PopulateBody error - ContactUs contactUs or ~/Template/EmailTemplate.html";
    Log4Ex(exceptionMsg);
    }

    return body;
    }

    public void ContactUsMailMessage(ContactUs contactUs)
    {
    if (contactUs != null)
    {
    string messageSubject = string.Format("{0} Web Application =>  Contact Us", messageProjectNameBase);
    string messageHtml = this.PopulateBody(messageProjectNameBase,
    contactUs);

    if (!string.IsNullOrWhiteSpace(messageHtml))
    {
    string smtpClientDisplayName = ConfigurationManager.AppSettings.Get("SmtpClientDisplayName");
    string smtpClientUserName = ConfigurationManager.AppSettings.Get("SmtpClientUserName");

    MimeMessage mimeMessage = new MimeMessage();
    mimeMessage.From.Add(new MailboxAddress(smtpClientDisplayName, smtpClientUserName));

    mimeMessage.To.Add(new MailboxAddress(contactUs.FullName, contactUs.EmailAddress));

    mimeMessage.Subject = messageSubject;
    var bodyBuilder = new BodyBuilder { HtmlBody = messageHtml };
    mimeMessage.Body = bodyBuilder.ToMessageBody();

    SmtpClientMimeMessage(mimeMessage);

    }

    }
    else
    {
    exceptionMsg = "MailMessage error - ContactUs contactUs";
    Log4Ex(exceptionMsg);
    }

    }

    private void Log4Ex(string eMsg)
    {
    if (!string.IsNullOrWhiteSpace(eMsg))
    {
    Exception exception = new Exception(eMsg);
    Log4ExceptionConnDb.Ex(exception);
    }
    }
    }
    }
  