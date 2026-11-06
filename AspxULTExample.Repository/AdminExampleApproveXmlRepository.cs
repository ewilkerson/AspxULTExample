
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

    
    public partial class AdminExampleApproveXmlRepository : SerializeDeserializeXmlRepository, IExampleApproveRepository
    {

    #region AdminExampleApproveXmlRepository

    private readonly string urlMapPath = HttpContext.Current.Server.MapPath("~");
    private string xmlExampleApprove;

    public AdminExampleApproveXmlRepository()
    {
    string xmlFolder = urlMapPath + "\\Xml";
    xmlExampleApprove = xmlFolder + "\\ExampleApproveXml.xml";

    if (!Directory.Exists(xmlFolder))
    Directory.CreateDirectory(xmlFolder);

    if (!File.Exists(xmlExampleApprove))
    {
    File.WriteAllText(xmlExampleApprove, "<?xml version=\"1.0\" encoding=\"utf-8\"?><ExampleApproveXml xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ><ExampleApproveLists></ExampleApproveLists></ExampleApproveXml>");
    }


    }

    public IEnumerable<ExampleApprove> GetExampleApproves()
    {
    List<ExampleApprove> exampleApproveLists = new List<ExampleApprove>();

    try
    {
    ExampleApproveXml exampleApproveXml = XmlDeserialize<ExampleApproveXml>(xmlExampleApprove);
    exampleApproveLists = exampleApproveXml.ExampleApproveLists;
    exampleApproveLists.Sort((u1, u2) => u1.ExampleApproveID.CompareTo(u2.ExampleApproveID));
    }
    catch (Exception exception)
    {
    Log4ExceptionConnDb.ExXml(exception);
    }

    return exampleApproveLists;
    }

    public ExampleApprove GetExampleApproveById(int exampleApproveID)
    {
    ExampleApprove exampleApprove = new ExampleApprove();

    try
    {

    if(exampleApproveID != 0)
    {

    List<ExampleApprove> exampleApproveLists = new List<ExampleApprove>();

    ExampleApproveXml exampleApproveXml = XmlDeserialize<ExampleApproveXml>(xmlExampleApprove);
    exampleApproveLists = exampleApproveXml.ExampleApproveLists.Where(a => a.ExampleApproveID == exampleApproveID).ToList();
    exampleApproveLists.Sort((u1, u2) => u1.ExampleApproveID.CompareTo(u2.ExampleApproveID));
    exampleApprove = exampleApproveLists.FirstOrDefault();

    }
    else
    {
    exampleApprove.ErrID = 1;
    exampleApprove.ErrText = "exampleApproveID cannot be zero.";
    }

    }
    catch (Exception exception)
    {
    XmlErrors(exampleApprove);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return exampleApprove;
    }

    public ExampleApprove InsertExampleApprove(ExampleApprove exampleApprove)
    {

    try
    {
    if(exampleApprove != null)
    {
    if(exampleApprove.ExampleApproveID != 0)
    {

    ExampleApproveXml exampleApproveXml = XmlDeserialize<ExampleApproveXml>(xmlExampleApprove);

    if (exampleApproveXml.ExampleApproveLists == null)
    {
    exampleApproveXml.ExampleApproveLists = new List<ExampleApprove>();
    }

    exampleApproveXml.ExampleApproveLists.Sort((u1, u2) => u1.ExampleApproveID.CompareTo(u2.ExampleApproveID));
    exampleApprove.ExampleApproveID = exampleApproveXml.ExampleApproveLists.Count == 0 ? 1 : exampleApproveXml.ExampleApproveLists.Max(x => x.ExampleApproveID) + 1;
    exampleApproveXml.ExampleApproveLists.Add(exampleApprove);
    XmlSerialize(exampleApproveXml, xmlExampleApprove);

    }
    else
    {
    exampleApprove.ErrID = 1;
    exampleApprove.ErrText = "ExampleApproveID cannot be zero.";
    }

    }
    else
    {
    exampleApprove = new ExampleApprove(){
    ErrID = 1,
    ErrText = "ExampleApprove cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    XmlErrors(exampleApprove);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return exampleApprove;
    }

    public ExampleApprove UpdateExampleApprove(ExampleApprove exampleApprove)
    {

    try
    {
    if(exampleApprove != null)
    {
    if(exampleApprove.ExampleApproveID != 0)
    {

    ExampleApproveXml exampleApproveXml = XmlDeserialize<ExampleApproveXml>(xmlExampleApprove);

    if (exampleApproveXml.ExampleApproveLists == null)
    {
    exampleApproveXml.ExampleApproveLists = new List<ExampleApprove>();
    }

    foreach (ExampleApprove _exampleApprove in exampleApproveXml.ExampleApproveLists)
    {
    if (_exampleApprove.ExampleApproveID == exampleApprove.ExampleApproveID)
    {
    _exampleApprove.ExampleID = exampleApprove.ExampleID;
_exampleApprove.UserInfoID = exampleApprove.UserInfoID;
_exampleApprove.UserInfoJobTitle = exampleApprove.UserInfoJobTitle;

    _exampleApprove.UpdateUserName = exampleApprove.UpdateUserName;
    _exampleApprove.UpdateFullName = exampleApprove.UpdateFullName;
    _exampleApprove.UpdateDate = exampleApprove.UpdateDate;
    XmlSerialize(exampleApproveXml, xmlExampleApprove);
    break;
    }
    }

    }
    else
    {
    exampleApprove.ErrID = 1;
    exampleApprove.ErrText = "ExampleApproveID cannot be zero.";
    }

    }
    else
    {
    exampleApprove = new ExampleApprove(){
    ErrID = 1,
    ErrText = "ExampleApprove cannot be null."
    };
    }


    }
    catch (Exception exception)
    {
    XmlErrors(exampleApprove);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return exampleApprove;
    }

    public ExampleApprove DeleteExampleApprove(int exampleApproveID, ExampleApprove exampleApprove)
    {

    try
    {

    if(exampleApprove != null)
    {
    if(exampleApproveID != 0)
    {

    ExampleApproveXml exampleApproveXml = XmlDeserialize<ExampleApproveXml>(xmlExampleApprove);

    if (exampleApproveXml.ExampleApproveLists == null)
    {
    exampleApproveXml.ExampleApproveLists = new List<ExampleApprove>();
    }

    exampleApproveXml.ExampleApproveLists.RemoveAll(x => x.ExampleApproveID == exampleApproveID);
    XmlSerialize(exampleApproveXml, xmlExampleApprove);

    exampleApprove.DeleteTrueFalse = true;

    }
    else
    {
    exampleApprove.ErrID = 1;
    exampleApprove.ErrText = "exampleApproveID cannot be zero.";
    }
    }
    else
    {
    exampleApprove = new ExampleApprove(){
    ErrID = 1,
    ErrText = "ExampleApprove cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    XmlErrors(exampleApprove);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return exampleApprove;
    }

    private void XmlErrors(ExampleApprove exampleApprove)
    {
    exampleApprove.ErrID = 1;
    exampleApprove.ErrText = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
    }
    #endregion
    }
  

    }
  