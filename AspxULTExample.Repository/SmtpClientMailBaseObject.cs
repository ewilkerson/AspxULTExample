
    using System;
    using System.Configuration;
    using MailKit.Net.Smtp;
    using MimeKit;
    using MailKit.Security;

    namespace AspxULTExample.Repository
    {
    public class SmtpClientMailBaseObject
    {

    private static string exceptionMsg = string.Empty;

    public static void SmtpClientMimeMessage(MimeMessage mimeMessage)
    {
    if (mimeMessage != null)
    {
    string smtpClientDisplayName = ConfigurationManager.AppSettings.Get("SmtpClientDisplayName");
    string smtpClientUserName = ConfigurationManager.AppSettings.Get("SmtpClientUserName");
    string smtpClientPort = ConfigurationManager.AppSettings.Get("SmtpClientPort");
    string smtpClientHost = ConfigurationManager.AppSettings.Get("SmtpClientHost");
    string smtpClientPassword = ConfigurationManager.AppSettings.Get("SmtpClientPassword");

    using (var client = new SmtpClient())
    {
    int port;
    bool successSmtpClientPort = int.TryParse(smtpClientPort, out port);
    if (!successSmtpClientPort)
    {
    port = 0;
    }

    try
    {
    client.Connect(smtpClientHost, port, SecureSocketOptions.StartTls);
    }
    catch (SmtpCommandException ex)
    {
    string errMsg = string.Format("Error trying to connect: {0}", ex.Message);
    errMsg += errMsg + string.Format("\tStatusCode: {0}", ex.StatusCode);
    Log4Ex2(errMsg, ex);
    return;
    }
    catch (SmtpProtocolException ex)
    {
    string errMsg = string.Format("Protocol error while trying to connect: {0}", ex.Message);
    Log4Ex2(errMsg, ex);
    return;
    }

    try
    {
    client.Authenticate(smtpClientUserName, smtpClientPassword);
    }
    catch (AuthenticationException ex)
    {
    string errMsg = "Invalid user name or password.";
    Log4Ex2(errMsg, ex);

    return;
    }

    try
    {
    client.Send(mimeMessage);
    }
    catch (SmtpCommandException ex)
    {
    string errMsg = string.Format("Error sending message: {0}", ex.Message);
    errMsg += errMsg + string.Format("\tStatusCode: {0}", ex.StatusCode);

    switch (ex.ErrorCode)
    {
    case SmtpErrorCode.RecipientNotAccepted:
    errMsg += errMsg + string.Format("\tRecipient not accepted: {0}", ex.Mailbox);
    break;
    case SmtpErrorCode.SenderNotAccepted:
    errMsg += errMsg + string.Format("\tSender not accepted: {0}", ex.Mailbox);
    break;
    case SmtpErrorCode.MessageNotAccepted:
    errMsg += errMsg + "\tMessage not accepted.";
    break;
    }

    Log4Ex2(errMsg, ex);
    }
    catch (SmtpProtocolException ex)
    {
    string errMsg = string.Format("Protocol error while sending message: {0}", ex.Message);
    Log4Ex2(errMsg, ex);
    }

    client.Disconnect(true);
    }
    }
    else
    {
    exceptionMsg = "mimeMessage == null";
    Log4Ex(exceptionMsg);
    }

    }

    private static void Log4Ex(string eMsg)
    {
    if (!string.IsNullOrWhiteSpace(eMsg))
    {
    Exception exception = new Exception(eMsg);
    Log4ExceptionConnDb.Ex(exception);
    }
    }

    private static void Log4Ex2(string eMsg, Exception ex)
    {
    if (!string.IsNullOrWhiteSpace(eMsg) || ex != null)
    {
    Exception exception = new Exception(eMsg, ex);
    Log4ExceptionConnDb.Ex(exception);
    }
    }

    }
    }
  