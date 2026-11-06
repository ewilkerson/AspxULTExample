
using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Web;
using System.Text;
using System.IO;
using MailKit.Net.Smtp;
using MimeKit;
using MailKit.Security;
using AspxULTExample.Models;
using AspxULTExample.Models.Interface;

namespace AspxULTExample.Repository
{

    public class Log4ExceptionConnDb : SmtpClientMailBaseObject
    {

        public Log4ExceptionConnDb() { }

        private static string connString = ConfigurationManager.ConnectionStrings["Log4Exception"].ConnectionString;

        public static SqlConnectionStringBuilder ConnectionString => new SqlConnectionStringBuilder(connString);

        public static DbConnection LiveConnection()
        {
            if (string.IsNullOrWhiteSpace(connString))
            {
                //throw new Exception("Connection String is null or empty.");
                return null;
            }

            var conn = new SqlConnection(connString);
            conn.Open();
            return conn;
        }

        public static bool CloseConnection(DbConnection conn)
        {
            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
                // connection.Dispose();
            }
            return true;
        }

        private static void ClearPool()
        {
            SqlConnection.ClearAllPools();
        }

        public static void Dispose()
        {
            ClearPool();
        }

        public enum LogErrorDatabaseEnum
        {
            All,
            Sql,
            Xml
        }

        public static void Ex(Exception ex)
        {

            LogErrorDatabaseEnum logErrorDatabaseEnum = LogErrorDatabaseEnum.Xml;

            if (logErrorDatabaseEnum == LogErrorDatabaseEnum.Xml)
            {
                ErrorText(ex);
                ErrorSql(ex);
                ErrorEmail(ex);
            }
            else if (logErrorDatabaseEnum == LogErrorDatabaseEnum.Sql)
            {
                ErrorSql(ex);
                ErrorEmail(ex);
            }
            else if (logErrorDatabaseEnum == LogErrorDatabaseEnum.Xml)
            {
                ErrorText(ex);
                ErrorEmail(ex);
            }

        }

        public static void ExXml(Exception ex)
        {
            ErrorText(ex);
            ErrorEmail(ex);
        }

        private static ErrorMsg ErrorString(Exception ex)
        {
            ErrorMsg errorMsg = new ErrorMsg
            {
                Source = HttpContext.Current.Request.Url.AbsoluteUri
            };

            errorMsg.SourceSubject = errorMsg.Source;

            if (errorMsg.SourceSubject.Contains("/"))
            {
                string SourceSubject = errorMsg.SourceSubject;
                errorMsg.SourceSubject = SourceSubject.Substring(SourceSubject.LastIndexOf("/") + 1,
                length: (SourceSubject.Length - SourceSubject.LastIndexOf("/")) - 1);
            }

            errorMsg.Source = string.Format("AspxULTExample => {0}", errorMsg.Source);
            errorMsg.SourceSubject = string.Format("Aspx ULT Example Web Application => {0} - A Exception has Occurred.", errorMsg.SourceSubject);

            if (errorMsg.Source == "favicon.ico")
            {
                HttpContext.Current.Server.ClearError();
            }
            else
            {
                StringBuilder stringBuilder = new StringBuilder(2000);

                string userInfoUserName = HttpContext.Current.User.Identity.Name;
                //string userInfoUserName = "blakler1";

                ILoadUserInfoStringRepository bl = new LoadUserInfoStringSqlXmlRepository();
                LoadUserInfo loadUserInfo = bl.GetLoadUserInfoByString(userInfoUserName);

                errorMsg.UpdateUserName = userInfoUserName;

                if (loadUserInfo.UserInfoID != 0)
                {
                    errorMsg.UserInfoID = loadUserInfo.UserInfoID;
                    errorMsg.UserInfoUserIdentityName = loadUserInfo.UserInfoUserIdentityName;
                    errorMsg.UpdateUserName = loadUserInfo.UserInfoUserName;
                    errorMsg.UpdateFullName = loadUserInfo.UserInfoFullName;
                    errorMsg.UpdateEmailAddress = loadUserInfo.UserInfoEmailAddress;
                    errorMsg.UpdateJobTitle = loadUserInfo.UserInfoJobTitle;
                    errorMsg.UserInfoAccessLevelID = loadUserInfo.UserInfoAccessLevelID;
                    errorMsg.UserInfoAccessLevelName = loadUserInfo.UserInfoAccessLevelName;
                }

                stringBuilder.Append("Date: " + DateTime.Now + Environment.NewLine + Environment.NewLine +
                "User Info ID: " + errorMsg.UserInfoID + Environment.NewLine + Environment.NewLine +
                "User Info User Identity Name: " + errorMsg.UserInfoUserIdentityName + Environment.NewLine + Environment.NewLine +
                "Update User Name: " + errorMsg.UpdateUserName + Environment.NewLine + Environment.NewLine +
                "Update Full Name: " + errorMsg.UpdateFullName + Environment.NewLine + Environment.NewLine +
                "Update Email Address: " + errorMsg.UpdateEmailAddress + Environment.NewLine + Environment.NewLine +
                "Update Job Title: " + errorMsg.UpdateJobTitle + Environment.NewLine + Environment.NewLine +
                "User Info Access Level ID: " + errorMsg.UserInfoAccessLevelID + Environment.NewLine + Environment.NewLine +
                "User Info Access Level Name: " + errorMsg.UserInfoAccessLevelName + Environment.NewLine + Environment.NewLine +
                "Source: " + errorMsg.Source + Environment.NewLine + Environment.NewLine +
                "Err Msg: " + ex.Message + Environment.NewLine + Environment.NewLine +
                "Stack Trace: " + ex.StackTrace + Environment.NewLine + Environment.NewLine);

                if (ex.InnerException != null)
                {
                    int x = 1;
                    StringBuilder stringBuilder2 = new StringBuilder(2000);

                    var ies = ex.GetInnerExceptions();

                    stringBuilder2.Append("*** All Inner Err Msg ***" + Environment.NewLine + Environment.NewLine);

                    foreach (var ie in ies)
                    {

                        stringBuilder2.Append("Inner Err Msg " + x + ": " + ie.Message + Environment.NewLine +
                        Environment.NewLine);

                        if (ie.StackTrace != null)
                            stringBuilder2.Append("Inner Stack Trace " + x + ": " + ie.StackTrace +
                            Environment.NewLine + Environment.NewLine);
                        x++;

                    }

                    if (x > 3)
                    {
                        stringBuilder2.Clear();

                        int y = x - 4;
                        ies.RemoveRange(0, y);
                        y++;

                        stringBuilder2.Append("*** 3's Inner Err Msg ***" + Environment.NewLine + Environment.NewLine);
                        foreach (var ie in ies)
                        {

                            stringBuilder2.Append("Inner Err Msg " + y + ": " + ie.Message + Environment.NewLine +
                            Environment.NewLine);

                            if (ie.StackTrace != null)
                                stringBuilder2.Append("Inner Stack Trace " + y + ": " + ie.StackTrace +
                                Environment.NewLine + Environment.NewLine);
                            y++;

                        }
                    }

                    stringBuilder.Append(stringBuilder2);
                    stringBuilder2.Clear();

                }

                errorMsg.HttpEx = stringBuilder.ToString();
            }

            return errorMsg;

        }

        private static void ErrorText(Exception ex)
        {
            ErrorMsg errorMsg = ErrorString(ex);

            if (errorMsg.HttpEx != string.Empty)
            {
                //Error Text
                string urlMapPath = HttpContext.Current.Server.MapPath("~");
                string saveFolder = urlMapPath + "\\ErrorText";

                if (!Directory.Exists(saveFolder))
                    Directory.CreateDirectory(saveFolder);

                string fileName = saveFolder + "\\AspxULTExample.txt";

                string httpEx2 = "***********************************************************************************" +
                Environment.NewLine +
                errorMsg.HttpEx +
                "***********************************************************************************";

                if (!File.Exists(fileName))
                {
                    File.WriteAllText(fileName, httpEx2);
                }
                else
                {
                    File.AppendAllText(fileName, httpEx2);
                }
            }
        }

        private static void ErrorSql(Exception ex)
        {
            ErrorMsg errorMsg = ErrorString(ex);

            if (errorMsg.HttpEx != string.Empty)
            {

                //Error Sql
                using (var connection = Log4ExceptionConnDb.LiveConnection())
                {
                    try
                    {
                        DynamicParameters parameters = new DynamicParameters();
                        parameters.Add("@UpdateUserName", errorMsg.UpdateUserName);
                        parameters.Add("@UpdateFullName", errorMsg.UpdateFullName);
                        parameters.Add("@SourceSubject", errorMsg.SourceSubject);
                        parameters.Add("@Source", errorMsg.Source);
                        parameters.Add("@ErrMsg", errorMsg.HttpEx);
                        parameters.Add("@Id", errorMsg.Id, DbType.Int32, direction: ParameterDirection.Output);

                        connection.Execute(sql: "usp_LogErrorMessageWeb", param: parameters,
                        commandType: CommandType.StoredProcedure);
                    }
                    catch (Exception exception)
                    {
                        Log4Ex(exception.Message);
                    }
                    finally
                    {
                        Log4ExceptionConnDb.CloseConnection(connection);
                    }
                }
            }
        }

        private static void ErrorEmail(Exception exception)
        {
            ErrorMsg errorMsg = ErrorString(exception);

            if (errorMsg.HttpEx != string.Empty)
            {
                string messageHtml = PopulateBodyLogError(errorMsg);

                if (!string.IsNullOrWhiteSpace(messageHtml))
                {
                    string smtpClientDisplayName = ConfigurationManager.AppSettings.Get("SmtpClientDisplayName");
                    string smtpClientUserName = ConfigurationManager.AppSettings.Get("SmtpClientUserName");
                    string smtpClientPort = ConfigurationManager.AppSettings.Get("SmtpClientPort");
                    string smtpClientHost = ConfigurationManager.AppSettings.Get("SmtpClientHost");
                    string smtpClientPassword = ConfigurationManager.AppSettings.Get("SmtpClientPassword");

                    MimeMessage mimeMessage = new MimeMessage();
                    mimeMessage.From.Add(new MailboxAddress(smtpClientDisplayName, smtpClientUserName));

                    mimeMessage.To.Add(new MailboxAddress(smtpClientDisplayName, smtpClientUserName));

                    mimeMessage.Subject = errorMsg.SourceSubject;
                    var bodyBuilder = new BodyBuilder { HtmlBody = messageHtml };
                    mimeMessage.Body = bodyBuilder.ToMessageBody();

                    SmtpClientMimeMessage(mimeMessage);

                }

            }
        }

        private static string PopulateBodyLogError(ErrorMsg errorMsg)
        {
            string body = string.Empty;
            string emailTemplate = System.Web.Hosting.HostingEnvironment.MapPath("~/Template/LogErrorEmailTemplate.html");

            if (File.Exists(emailTemplate) && errorMsg != null)
            {
                using (StreamReader reader = new StreamReader(emailTemplate))
                {
                    body = reader.ReadToEnd();
                }
                body = body.Replace("{0}", errorMsg.SourceSubject);
                body = body.Replace("{1}", errorMsg.UpdateUserName);
                body = body.Replace("{2}", errorMsg.UpdateFullName);
                body = body.Replace("{3}", errorMsg.Source);
                body = body.Replace("{4}", errorMsg.HttpEx);
            }
            else
            {
                string exceptionMsg = "PopulateBody error - ~/Template/LogErrorEmailTemplate.html or ErrorMsg errorMsg";
                Log4Ex(exceptionMsg);
            }

            return body;
        }

        private static void Log4Ex(string eMsg)
        {
            if (!string.IsNullOrWhiteSpace(eMsg))
            {
                Exception exception = new Exception(eMsg);
                Log4ExceptionConnDb.Ex(exception);
            }
        }

    }

    public static class ExceptionExtensions
    {
        public static List<Exception> GetInnerExceptions(this Exception e)
        {
            List<Exception> eList = new List<Exception>();

            if (e is AggregateException)
            {
                eList.AddRange((e as AggregateException).InnerExceptions);
            }
            else
            {
                eList.Add(e);
            }

            List<Exception> ieList = eList
            .Where(i => i.InnerException != null)
            .SelectMany(i => i.InnerException.GetInnerExceptions())
            .ToList();

            eList.AddRange(ieList);

            return eList;
        }

    }

    public class ErrorMsg
    {
        public int Id { get; set; }

        public int UserInfoID { get; set; }
        public string UserInfoUserIdentityName { get; set; }
        public string UpdateUserName { get; set; }
        public string UpdateFullName { get; set; }
        public string UpdateEmailAddress { get; set; }
        public string UpdateJobTitle { get; set; }
        public int UserInfoAccessLevelID { get; set; }
        public string UserInfoAccessLevelName { get; set; }
        public string SourceSubject { get; set; }
        public string Source { get; set; }
        public string HttpEx { get; set; }


        public ErrorMsg()
        {
            Id = 0;
            UserInfoID = 0;
            UserInfoUserIdentityName = string.Empty;
            UpdateUserName = string.Empty;
            UpdateFullName = string.Empty;
            UpdateEmailAddress = string.Empty;
            UpdateJobTitle = string.Empty;
            UserInfoAccessLevelID = 0;
            UserInfoAccessLevelName = string.Empty;
            SourceSubject = string.Empty;
            Source = string.Empty;
            HttpEx = string.Empty;

        }
    }


}
