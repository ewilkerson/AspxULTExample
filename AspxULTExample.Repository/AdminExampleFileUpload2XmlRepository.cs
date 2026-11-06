
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

    
    public partial class AdminExampleFileUpload2XmlRepository : SerializeDeserializeXmlRepository, IExampleFileUpload2Repository
    {

    #region AdminExampleFileUpload2XmlRepository

    private readonly string urlMapPath = HttpContext.Current.Server.MapPath("~");
    private string xmlExampleFileUpload2;

    public AdminExampleFileUpload2XmlRepository()
    {
    string xmlFolder = urlMapPath + "\\Xml";
    xmlExampleFileUpload2 = xmlFolder + "\\ExampleFileUpload2Xml.xml";

    if (!Directory.Exists(xmlFolder))
    Directory.CreateDirectory(xmlFolder);

    if (!File.Exists(xmlExampleFileUpload2))
    {
    File.WriteAllText(xmlExampleFileUpload2, "<?xml version=\"1.0\" encoding=\"utf-8\"?><ExampleFileUpload2Xml xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ><ExampleFileUpload2Lists></ExampleFileUpload2Lists></ExampleFileUpload2Xml>");
    }


    }

    public IEnumerable<ExampleFileUpload2> GetExampleFileUpload2s()
    {
    List<ExampleFileUpload2> exampleFileUpload2Lists = new List<ExampleFileUpload2>();

    try
    {
    ExampleFileUpload2Xml exampleFileUpload2Xml = XmlDeserialize<ExampleFileUpload2Xml>(xmlExampleFileUpload2);
    exampleFileUpload2Lists = exampleFileUpload2Xml.ExampleFileUpload2Lists;
    exampleFileUpload2Lists.Sort((u1, u2) => u1.ExampleFileUpload2ID.CompareTo(u2.ExampleFileUpload2ID));
    }
    catch (Exception exception)
    {
    Log4ExceptionConnDb.ExXml(exception);
    }

    return exampleFileUpload2Lists;
    }

    public ExampleFileUpload2 GetExampleFileUpload2ById(int exampleFileUpload2ID)
    {
    ExampleFileUpload2 exampleFileUpload2 = new ExampleFileUpload2();

    try
    {

    if(exampleFileUpload2ID != 0)
    {

    List<ExampleFileUpload2> exampleFileUpload2Lists = new List<ExampleFileUpload2>();

    ExampleFileUpload2Xml exampleFileUpload2Xml = XmlDeserialize<ExampleFileUpload2Xml>(xmlExampleFileUpload2);
    exampleFileUpload2Lists = exampleFileUpload2Xml.ExampleFileUpload2Lists.Where(a => a.ExampleFileUpload2ID == exampleFileUpload2ID).ToList();
    exampleFileUpload2Lists.Sort((u1, u2) => u1.ExampleFileUpload2ID.CompareTo(u2.ExampleFileUpload2ID));
    exampleFileUpload2 = exampleFileUpload2Lists.FirstOrDefault();

    }
    else
    {
    exampleFileUpload2.ErrID = 1;
    exampleFileUpload2.ErrText = "exampleFileUpload2ID cannot be zero.";
    }

    }
    catch (Exception exception)
    {
    XmlErrors(exampleFileUpload2);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return exampleFileUpload2;
    }

    public ExampleFileUpload2 InsertExampleFileUpload2(ExampleFileUpload2 exampleFileUpload2)
    {

    try
    {
    if(exampleFileUpload2 != null)
    {
    if(exampleFileUpload2.ExampleFileUpload2ID != 0)
    {

    ExampleFileUpload2Xml exampleFileUpload2Xml = XmlDeserialize<ExampleFileUpload2Xml>(xmlExampleFileUpload2);

    if (exampleFileUpload2Xml.ExampleFileUpload2Lists == null)
    {
    exampleFileUpload2Xml.ExampleFileUpload2Lists = new List<ExampleFileUpload2>();
    }

    exampleFileUpload2Xml.ExampleFileUpload2Lists.Sort((u1, u2) => u1.ExampleFileUpload2ID.CompareTo(u2.ExampleFileUpload2ID));
    exampleFileUpload2.ExampleFileUpload2ID = exampleFileUpload2Xml.ExampleFileUpload2Lists.Count == 0 ? 1 : exampleFileUpload2Xml.ExampleFileUpload2Lists.Max(x => x.ExampleFileUpload2ID) + 1;
    exampleFileUpload2Xml.ExampleFileUpload2Lists.Add(exampleFileUpload2);
    XmlSerialize(exampleFileUpload2Xml, xmlExampleFileUpload2);

    }
    else
    {
    exampleFileUpload2.ErrID = 1;
    exampleFileUpload2.ErrText = "ExampleFileUpload2ID cannot be zero.";
    }

    }
    else
    {
    exampleFileUpload2 = new ExampleFileUpload2(){
    ErrID = 1,
    ErrText = "ExampleFileUpload2 cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    XmlErrors(exampleFileUpload2);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return exampleFileUpload2;
    }

    public ExampleFileUpload2 UpdateExampleFileUpload2(ExampleFileUpload2 exampleFileUpload2)
    {

    try
    {
    if(exampleFileUpload2 != null)
    {
    if(exampleFileUpload2.ExampleFileUpload2ID != 0)
    {

    ExampleFileUpload2Xml exampleFileUpload2Xml = XmlDeserialize<ExampleFileUpload2Xml>(xmlExampleFileUpload2);

    if (exampleFileUpload2Xml.ExampleFileUpload2Lists == null)
    {
    exampleFileUpload2Xml.ExampleFileUpload2Lists = new List<ExampleFileUpload2>();
    }

    foreach (ExampleFileUpload2 _exampleFileUpload2 in exampleFileUpload2Xml.ExampleFileUpload2Lists)
    {
    if (_exampleFileUpload2.ExampleFileUpload2ID == exampleFileUpload2.ExampleFileUpload2ID)
    {
    _exampleFileUpload2.FileName = exampleFileUpload2.FileName;
_exampleFileUpload2.FileContentType = exampleFileUpload2.FileContentType;
_exampleFileUpload2.FileContentLength = exampleFileUpload2.FileContentLength;
_exampleFileUpload2.FileContentLengthKbMb = exampleFileUpload2.FileContentLengthKbMb;
_exampleFileUpload2.FileContentPath = exampleFileUpload2.FileContentPath;

    _exampleFileUpload2.UpdateUserName = exampleFileUpload2.UpdateUserName;
    _exampleFileUpload2.UpdateFullName = exampleFileUpload2.UpdateFullName;
    _exampleFileUpload2.UpdateDate = exampleFileUpload2.UpdateDate;
    XmlSerialize(exampleFileUpload2Xml, xmlExampleFileUpload2);
    break;
    }
    }

    }
    else
    {
    exampleFileUpload2.ErrID = 1;
    exampleFileUpload2.ErrText = "ExampleFileUpload2ID cannot be zero.";
    }

    }
    else
    {
    exampleFileUpload2 = new ExampleFileUpload2(){
    ErrID = 1,
    ErrText = "ExampleFileUpload2 cannot be null."
    };
    }


    }
    catch (Exception exception)
    {
    XmlErrors(exampleFileUpload2);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return exampleFileUpload2;
    }

    public ExampleFileUpload2 DeleteExampleFileUpload2(int exampleFileUpload2ID, ExampleFileUpload2 exampleFileUpload2)
    {

    try
    {

    if(exampleFileUpload2 != null)
    {
    if(exampleFileUpload2ID != 0)
    {

    ExampleFileUpload2Xml exampleFileUpload2Xml = XmlDeserialize<ExampleFileUpload2Xml>(xmlExampleFileUpload2);

    if (exampleFileUpload2Xml.ExampleFileUpload2Lists == null)
    {
    exampleFileUpload2Xml.ExampleFileUpload2Lists = new List<ExampleFileUpload2>();
    }

    exampleFileUpload2Xml.ExampleFileUpload2Lists.RemoveAll(x => x.ExampleFileUpload2ID == exampleFileUpload2ID);
    XmlSerialize(exampleFileUpload2Xml, xmlExampleFileUpload2);

    exampleFileUpload2.DeleteTrueFalse = true;

    }
    else
    {
    exampleFileUpload2.ErrID = 1;
    exampleFileUpload2.ErrText = "exampleFileUpload2ID cannot be zero.";
    }
    }
    else
    {
    exampleFileUpload2 = new ExampleFileUpload2(){
    ErrID = 1,
    ErrText = "ExampleFileUpload2 cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    XmlErrors(exampleFileUpload2);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return exampleFileUpload2;
    }

    private void XmlErrors(ExampleFileUpload2 exampleFileUpload2)
    {
    exampleFileUpload2.ErrID = 1;
    exampleFileUpload2.ErrText = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
    }
    #endregion
    }
  

    }
  