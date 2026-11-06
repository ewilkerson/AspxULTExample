
    using System;
    using System.Collections.Generic;
    using System.Data;
    using Dapper;
    using System.IO;
    using System.Web;
    using System.Xml.Serialization;
    using System.Linq;
    using AspxULTExample.Models;
    using AspxULTExample.Models.Interface;

    namespace AspxULTExample.Repository
    {

    
    public partial class AdminExampleLogXmlRepository : SerializeDeserializeXmlRepository, IExampleLogRepository
    {

    #region AdminExampleLogXmlRepository

    private readonly string urlMapPath = HttpContext.Current.Server.MapPath("~");
    private string xmlExampleLog;

    public AdminExampleLogXmlRepository()
    {
    string xmlFolder = urlMapPath + "\\Xml";
    xmlExampleLog = xmlFolder + "\\ExampleLogXml.xml";

    if (!Directory.Exists(xmlFolder))
    Directory.CreateDirectory(xmlFolder);

    if (!File.Exists(xmlExampleLog))
    {
    File.WriteAllText(xmlExampleLog, "<?xml version=\"1.0\" encoding=\"utf-8\"?><ExampleLogXml xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ><ExampleLogLists></ExampleLogLists></ExampleLogXml>");
    }


    }

    public IEnumerable<ExampleLog> GetExampleLogs()
    {
    List<ExampleLog> exampleLogLists = new List<ExampleLog>();

    try
    {
    ExampleLogXml exampleLogXml = XmlDeserialize<ExampleLogXml>(xmlExampleLog);
    exampleLogLists = exampleLogXml.ExampleLogLists;
    exampleLogLists.Sort((u1, u2) => u1.ExampleLogID.CompareTo(u2.ExampleLogID));
    }
    catch (Exception exception)
    {
    Log4ExceptionConnDb.ExXml(exception);
    }

    return exampleLogLists;
    }

    public ExampleLog GetExampleLogById(int exampleLogID)
    {
    ExampleLog exampleLog = new ExampleLog();

    try
    {

    if(exampleLogID != 0)
    {

    List<ExampleLog> exampleLogLists = new List<ExampleLog>();

    ExampleLogXml exampleLogXml = XmlDeserialize<ExampleLogXml>(xmlExampleLog);
    exampleLogLists = exampleLogXml.ExampleLogLists.Where(a => a.ExampleLogID == exampleLogID).ToList();
    exampleLogLists.Sort((u1, u2) => u1.ExampleLogID.CompareTo(u2.ExampleLogID));
    exampleLog = exampleLogLists.FirstOrDefault();

    }
    else
    {
    exampleLog.ErrID = 1;
    exampleLog.ErrText = "exampleLogID cannot be zero.";
    }

    }
    catch (Exception exception)
    {
    XmlErrors(exampleLog);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return exampleLog;
    }

    public ExampleLog InsertExampleLog(ExampleLog exampleLog)
    {

    try
    {
    if(exampleLog != null)
    {
    if(exampleLog.ExampleLogID != 0)
    {

    ExampleLogXml exampleLogXml = XmlDeserialize<ExampleLogXml>(xmlExampleLog);

    if (exampleLogXml.ExampleLogLists == null)
    {
    exampleLogXml.ExampleLogLists = new List<ExampleLog>();
    }

    exampleLogXml.ExampleLogLists.Sort((u1, u2) => u1.ExampleLogID.CompareTo(u2.ExampleLogID));
    exampleLog.ExampleLogID = exampleLogXml.ExampleLogLists.Count == 0 ? 1 : exampleLogXml.ExampleLogLists.Max(x => x.ExampleLogID) + 1;
    exampleLogXml.ExampleLogLists.Add(exampleLog);
    XmlSerialize(exampleLogXml, xmlExampleLog);

    }
    else
    {
    exampleLog.ErrID = 1;
    exampleLog.ErrText = "ExampleLogID cannot be zero.";
    }

    }
    else
    {
    exampleLog = new ExampleLog(){
    ErrID = 1,
    ErrText = "ExampleLog cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    XmlErrors(exampleLog);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return exampleLog;
    }

    public ExampleLog UpdateExampleLog(ExampleLog exampleLog)
    {

    try
    {
    if(exampleLog != null)
    {
    if(exampleLog.ExampleLogID != 0)
    {

    ExampleLogXml exampleLogXml = XmlDeserialize<ExampleLogXml>(xmlExampleLog);

    if (exampleLogXml.ExampleLogLists == null)
    {
    exampleLogXml.ExampleLogLists = new List<ExampleLog>();
    }

    foreach (ExampleLog _exampleLog in exampleLogXml.ExampleLogLists)
    {
    if (_exampleLog.ExampleLogID == exampleLog.ExampleLogID)
    {
    _exampleLog.ExampleID = exampleLog.ExampleID;
_exampleLog.LogMessage = exampleLog.LogMessage;

    _exampleLog.UpdateUserName = exampleLog.UpdateUserName;
    _exampleLog.UpdateFullName = exampleLog.UpdateFullName;
    _exampleLog.UpdateDate = exampleLog.UpdateDate;
    XmlSerialize(exampleLogXml, xmlExampleLog);
    break;
    }
    }

    }
    else
    {
    exampleLog.ErrID = 1;
    exampleLog.ErrText = "ExampleLogID cannot be zero.";
    }

    }
    else
    {
    exampleLog = new ExampleLog(){
    ErrID = 1,
    ErrText = "ExampleLog cannot be null."
    };
    }


    }
    catch (Exception exception)
    {
    XmlErrors(exampleLog);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return exampleLog;
    }

    public ExampleLog DeleteExampleLog(int exampleLogID, ExampleLog exampleLog)
    {

    try
    {

    if(exampleLog != null)
    {
    if(exampleLogID != 0)
    {

    ExampleLogXml exampleLogXml = XmlDeserialize<ExampleLogXml>(xmlExampleLog);

    if (exampleLogXml.ExampleLogLists == null)
    {
    exampleLogXml.ExampleLogLists = new List<ExampleLog>();
    }

    exampleLogXml.ExampleLogLists.RemoveAll(x => x.ExampleLogID == exampleLogID);
    XmlSerialize(exampleLogXml, xmlExampleLog);

    exampleLog.DeleteTrueFalse = true;

    }
    else
    {
    exampleLog.ErrID = 1;
    exampleLog.ErrText = "exampleLogID cannot be zero.";
    }
    }
    else
    {
    exampleLog = new ExampleLog(){
    ErrID = 1,
    ErrText = "ExampleLog cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    XmlErrors(exampleLog);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return exampleLog;
    }

    private void XmlErrors(ExampleLog exampleLog)
    {
    exampleLog.ErrID = 1;
    exampleLog.ErrText = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
    }
    #endregion
    }
  

    }
  