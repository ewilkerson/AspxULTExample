
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Configuration;
    using MailKit.Net.Smtp;
    using MimeKit;
    using MailKit.Security;
    using System.IO;
    using System.Web;
    using AspxULTExample.Models;

    namespace AspxULTExample.Repository
    {
    public class MailMessageObject: SmtpClientMailBaseObject
    {

    private string exceptionMsg = string.Empty;
    private readonly string messageProjectNameBase = "Aspx ULT Example";
    private readonly string messageSubjectBase = "{0} Web Application => {1}, ID: {2}";
    private  string messageUrlAbsoluteUri = string.Format("{0}", HttpContext.Current.Request.Url.AbsoluteUri);
    private  string messageUrlLocalPath = string.Format("{0}", HttpContext.Current.Request.Url.LocalPath);
    //  private readonly string strPathAndQuery = HttpContext.Current.Request.Url.PathAndQuery;
    //  private readonly string strUrl = HttpContext.Current.Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/");

    private string PopulateBody(string projectNameBase, string procedureName, string id, string messageUrl, string noteMessage)
    {
    string body = string.Empty;
    string emailTemplate = System.Web.Hosting.HostingEnvironment.MapPath("~/Template/EmailTemplate.html");

    if (File.Exists(emailTemplate))
    {
    using (StreamReader reader = new StreamReader(emailTemplate))
    {
    body = reader.ReadToEnd();
    }
    body = body.Replace("{0}", projectNameBase);
    body = body.Replace("{1}", procedureName);
    body = body.Replace("{2}", id);
    body = body.Replace("{3}", messageUrl);
    body = body.Replace("{4}", noteMessage);
    body = body.Replace("{5}", DateTime.Now.Year.ToString());
    }
    else
    {
    exceptionMsg = "PopulateBody error - ~/Template/EmailTemplate.html";
    Log4Ex(exceptionMsg);
    }

    return body;
    }

    public void MailMessage(int id, int companyID, string noteMessage)
    {
    if (id != 0 && companyID != 0)
    {

    if (messageUrlAbsoluteUri.Contains("Edit_ApproveCompeteRejectRevoke"))
    {
    messageUrlAbsoluteUri = messageUrlAbsoluteUri.Replace("Edit_ApproveCompeteRejectRevoke", "Edit/" + id);
    messageUrlLocalPath = messageUrlLocalPath.Replace("Edit_ApproveCompeteRejectRevoke", "Edit");
    }

    string messageSubject = string.Format(messageSubjectBase, messageProjectNameBase, messageUrlLocalPath, id);
    string messageBody = this.PopulateBody(messageProjectNameBase,
    messageUrlLocalPath,
    id.ToString(),
    messageUrlAbsoluteUri,
    noteMessage);

    if (!string.IsNullOrWhiteSpace(messageBody))
    {

    LoadUserInfoStringSqlXmlRepository loadUserInfoStringSqlXmlRepository = new LoadUserInfoStringSqlXmlRepository();
    IEnumerable<LoadUserInfo> loadUserInfoEmailAddressLists = loadUserInfoStringSqlXmlRepository.GetLoadUserInfoEmailAddressByCompanyID(companyID);

    if (loadUserInfoEmailAddressLists != null && loadUserInfoEmailAddressLists.First().UserInfoCompanyID == companyID)
    {

    string smtpClientDisplayName = ConfigurationManager.AppSettings.Get("SmtpClientDisplayName");
    string smtpClientUserName = ConfigurationManager.AppSettings.Get("SmtpClientUserName");

    MimeMessage mimeMessage = new MimeMessage();
    mimeMessage.From.Add(new MailboxAddress(smtpClientDisplayName, smtpClientUserName));

    mimeMessage.Subject = messageSubject;
    var bodyBuilder = new BodyBuilder { HtmlBody = messageBody };
    mimeMessage.Body = bodyBuilder.ToMessageBody();

    IEnumerable<LoadUserInfo> loadUserInfoToEmailAddressLists = loadUserInfoEmailAddressLists.Where(x => x.UserInfoAccessLevelID == 4);
    foreach (LoadUserInfo loadUserInfoEmailAddress in loadUserInfoToEmailAddressLists)
    {
    var to = new MailboxAddress(loadUserInfoEmailAddress.UserInfoFullName, loadUserInfoEmailAddress.UserInfoEmailAddress);
    mimeMessage.To.Add(to);
    }

    IEnumerable<LoadUserInfo> loadUserInfoCCEmailAddressLists = loadUserInfoEmailAddressLists.Where(x => x.UserInfoAccessLevelID == 1 || x.UserInfoAccessLevelID == 2 || x.UserInfoAccessLevelID == 3);
    foreach (LoadUserInfo loadUserInfoEmailAddress in loadUserInfoCCEmailAddressLists)
    {
    var cc = new MailboxAddress(loadUserInfoEmailAddress.UserInfoFullName, loadUserInfoEmailAddress.UserInfoEmailAddress);
    mimeMessage.Cc.Add(cc);
    }


    // Add the alternate body to the message.
    // ContentType mimeType = new System.Net.Mime.ContentType("text/html");
    // AlternateView alternate = AlternateView.CreateAlternateViewFromString(mailMessageBody, mimeType);
    //  mailMessage.AlternateViews.Add(alternate);

    SmtpClientMimeMessage(mimeMessage);
    }
    else
    {
    exceptionMsg = "MailMessage error -  IEnumerable<LoadUserInfo> loadUserInfoEmailAddressLists";
    Log4Ex(exceptionMsg);
    }

    }

    }
    else
    {
    exceptionMsg = "MailMessage error - int id, int companyID";
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
  