
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

    
    public partial class ViewExampleFileUpload2XmlRepository : SerializeDeserializeXmlRepository, IViewExampleFileUpload2Repository
    {

    #region ViewExampleFileUpload2XmlRepository

    private readonly string urlMapPath = HttpContext.Current.Server.MapPath("~");
    private string xmlExampleFileUpload2;

    public ViewExampleFileUpload2XmlRepository()
    {
    string xmlFolder = urlMapPath + "\\Xml";
    xmlExampleFileUpload2 = xmlFolder + "\\ExampleFileUpload2Xml.xml";

    if (!Directory.Exists(xmlFolder))
    Directory.CreateDirectory(xmlFolder);

    if (!File.Exists(xmlExampleFileUpload2))
    {
    File.WriteAllText(xmlExampleFileUpload2, "<?xml version=\"1.0\" encoding=\"utf-8\"?><ExampleFileUpload2Xml xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ><ViewExampleFileUpload2Lists></ViewExampleFileUpload2Lists></ExampleFileUpload2Xml>");
    }


    }

    public IEnumerable<ViewExampleFileUpload2> GetViewExampleFileUpload2s()
    {
    List<ViewExampleFileUpload2> viewExampleFileUpload2Lists = new List<ViewExampleFileUpload2>();

    try
    {
    ExampleFileUpload2Xml examplefileupload2Xml = XmlDeserialize<ExampleFileUpload2Xml>(xmlExampleFileUpload2);
    List<ExampleFileUpload2> examplefileupload2Lists = examplefileupload2Xml.ExampleFileUpload2Lists;
    foreach(ExampleFileUpload2 examplefileupload2 in examplefileupload2Lists)
    {
    ViewExampleFileUpload2 viewExampleFileUpload2 = new ViewExampleFileUpload2(){
    ExampleFileUpload2ID = examplefileupload2.ExampleFileUpload2ID,
FileName = examplefileupload2.FileName,
FileContentType = examplefileupload2.FileContentType,
FileContentLength = examplefileupload2.FileContentLength,
FileContentLengthKbMb = examplefileupload2.FileContentLengthKbMb,
FileContentPath = examplefileupload2.FileContentPath,

    };
    viewExampleFileUpload2Lists.Add(viewExampleFileUpload2);
    }

    viewExampleFileUpload2Lists.Sort((u1, u2) => u1.ExampleFileUpload2ID.CompareTo(u2.ExampleFileUpload2ID));
    }
    catch (Exception exception)
    {
    Log4ExceptionConnDb.ExXml(exception);
    }

    return viewExampleFileUpload2Lists;
    }

    public ViewExampleFileUpload2 GetViewExampleFileUpload2ById(int exampleFileUpload2ID)
    {
    ViewExampleFileUpload2 viewExampleFileUpload2 = new ViewExampleFileUpload2();

    try
    {
    List<ViewExampleFileUpload2> viewExampleFileUpload2Lists = new List<ViewExampleFileUpload2>();
    if(exampleFileUpload2ID != 0)
    {

    ExampleFileUpload2Xml examplefileupload2Xml = XmlDeserialize<ExampleFileUpload2Xml>(xmlExampleFileUpload2);
    List<ExampleFileUpload2> examplefileupload2Lists = examplefileupload2Xml.ExampleFileUpload2Lists.Where(a => a.ExampleFileUpload2ID == exampleFileUpload2ID).ToList();
    foreach(ExampleFileUpload2 examplefileupload2 in examplefileupload2Lists)
    {
    ViewExampleFileUpload2 _viewExampleFileUpload2 = new ViewExampleFileUpload2(){
    ExampleFileUpload2ID = examplefileupload2.ExampleFileUpload2ID,
FileName = examplefileupload2.FileName,
FileContentType = examplefileupload2.FileContentType,
FileContentLength = examplefileupload2.FileContentLength,
FileContentLengthKbMb = examplefileupload2.FileContentLengthKbMb,
FileContentPath = examplefileupload2.FileContentPath,

    };
    viewExampleFileUpload2Lists.Add(_viewExampleFileUpload2);

    }

    viewExampleFileUpload2Lists.Sort((u1, u2) => u1.ExampleFileUpload2ID.CompareTo(u2.ExampleFileUpload2ID));
    viewExampleFileUpload2 = viewExampleFileUpload2Lists.FirstOrDefault();

    }
    else
    {
    viewExampleFileUpload2.ErrID = 1;
    viewExampleFileUpload2.ErrText = "exampleFileUpload2ID cannot be zero.";
    }

    }
    catch (Exception exception)
    {
    XmlErrors(viewExampleFileUpload2);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return viewExampleFileUpload2;
    }

    public ViewExampleFileUpload2 InsertViewExampleFileUpload2(ViewExampleFileUpload2 viewExampleFileUpload2)
    {

    try
    {

    if(viewExampleFileUpload2 != null)
    {
    if(viewExampleFileUpload2.ExampleFileUpload2ID != 0)
    {

    ExampleFileUpload2Xml examplefileupload2Xml = XmlDeserialize<ExampleFileUpload2Xml>(xmlExampleFileUpload2);

    if (examplefileupload2Xml.ExampleFileUpload2Lists == null)
    {
    examplefileupload2Xml.ExampleFileUpload2Lists = new List<ExampleFileUpload2>();
    }

    examplefileupload2Xml.ExampleFileUpload2Lists.Sort((u1, u2) => u1.ExampleFileUpload2ID.CompareTo(u2.ExampleFileUpload2ID));
    viewExampleFileUpload2.ExampleFileUpload2ID = examplefileupload2Xml.ExampleFileUpload2Lists.Count == 0 ? 1 : examplefileupload2Xml.ExampleFileUpload2Lists.Max(x => x.ExampleFileUpload2ID) + 1;

    ExampleFileUpload2 examplefileupload2 = new ExampleFileUpload2{
    ExampleFileUpload2ID = viewExampleFileUpload2.ExampleFileUpload2ID,
FileName = viewExampleFileUpload2.FileName,
FileContentType = viewExampleFileUpload2.FileContentType,
FileContentLength = viewExampleFileUpload2.FileContentLength,
FileContentLengthKbMb = viewExampleFileUpload2.FileContentLengthKbMb,
FileContentPath = viewExampleFileUpload2.FileContentPath,

    };

    examplefileupload2Xml.ExampleFileUpload2Lists.Add(examplefileupload2);
    XmlSerialize(examplefileupload2Xml, xmlExampleFileUpload2);

    }
    else
    {
    viewExampleFileUpload2.ErrID = 1;
    viewExampleFileUpload2.ErrText = "ExampleFileUpload2ID cannot be zero.";
    }

    }
    else
    {
    viewExampleFileUpload2 = new ViewExampleFileUpload2(){
    ErrID = 1,
    ErrText = "ViewExampleFileUpload2 cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    XmlErrors(viewExampleFileUpload2);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return viewExampleFileUpload2;
    }

    public ViewExampleFileUpload2 UpdateViewExampleFileUpload2(ViewExampleFileUpload2 viewExampleFileUpload2)
    {

    try
    {
    if(viewExampleFileUpload2 != null)
    {
    if(viewExampleFileUpload2.ExampleFileUpload2ID != 0)
    {

    ExampleFileUpload2Xml examplefileupload2Xml = XmlDeserialize<ExampleFileUpload2Xml>(xmlExampleFileUpload2);

    if (examplefileupload2Xml.ExampleFileUpload2Lists == null)
    {
    examplefileupload2Xml.ExampleFileUpload2Lists = new List<ExampleFileUpload2>();
    }

    foreach (var examplefileupload2 in examplefileupload2Xml.ExampleFileUpload2Lists)
    {
    if (examplefileupload2.ExampleFileUpload2ID == viewExampleFileUpload2.ExampleFileUpload2ID)
    {
    examplefileupload2.FileName = viewExampleFileUpload2.FileName;
examplefileupload2.FileContentType = viewExampleFileUpload2.FileContentType;
examplefileupload2.FileContentLength = viewExampleFileUpload2.FileContentLength;
examplefileupload2.FileContentLengthKbMb = viewExampleFileUpload2.FileContentLengthKbMb;
examplefileupload2.FileContentPath = viewExampleFileUpload2.FileContentPath;

    examplefileupload2.UpdateUserName = viewExampleFileUpload2.UpdateUserName;
    examplefileupload2.UpdateFullName = viewExampleFileUpload2.UpdateFullName;
    examplefileupload2.UpdateDate = viewExampleFileUpload2.UpdateDate;

    XmlSerialize(examplefileupload2Xml, xmlExampleFileUpload2);
    break;
    }
    }

    }
    else
    {
    viewExampleFileUpload2.ErrID = 1;
    viewExampleFileUpload2.ErrText = "ExampleFileUpload2ID cannot be zero.";
    }

    }
    else
    {
    viewExampleFileUpload2 = new ViewExampleFileUpload2(){
    ErrID = 1,
    ErrText = "ViewExampleFileUpload2 cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    XmlErrors(viewExampleFileUpload2);
    Log4ExceptionConnDb.ExXml(exception);
    }


    return viewExampleFileUpload2;
    }

    public ViewExampleFileUpload2 DeleteViewExampleFileUpload2(int exampleFileUpload2ID, ViewExampleFileUpload2 viewExampleFileUpload2)
    {

    try
    {

    if(viewExampleFileUpload2 != null)
    {
    if(exampleFileUpload2ID != 0)
    {

    ExampleFileUpload2Xml examplefileupload2Xml = XmlDeserialize<ExampleFileUpload2Xml>(xmlExampleFileUpload2);

    if (examplefileupload2Xml.ExampleFileUpload2Lists == null)
    {
    examplefileupload2Xml.ExampleFileUpload2Lists = new List<ExampleFileUpload2>();
    }

    examplefileupload2Xml.ExampleFileUpload2Lists.RemoveAll(x => x.ExampleFileUpload2ID == exampleFileUpload2ID);
    XmlSerialize(examplefileupload2Xml, xmlExampleFileUpload2);

    viewExampleFileUpload2.DeleteTrueFalse = true;

    }
    else
    {
    viewExampleFileUpload2.ErrID = 1;
    viewExampleFileUpload2.ErrText = "exampleFileUpload2ID cannot be zero.";
    }
    }
    else
    {
    viewExampleFileUpload2 = new ViewExampleFileUpload2(){
    ErrID = 1,
    ErrText = "ViewExampleFileUpload2 cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    XmlErrors(viewExampleFileUpload2);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return viewExampleFileUpload2;
    }

    private void XmlErrors(ViewExampleFileUpload2 viewExampleFileUpload2)
    {
    viewExampleFileUpload2.ErrID = 1;
    viewExampleFileUpload2.ErrText = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
    }
    #endregion
    }
  

    }
  