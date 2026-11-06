
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

    
    public partial class AdminExampleXmlRepository : SerializeDeserializeXmlRepository, IExampleRepository
    {

    #region AdminExampleXmlRepository

    private readonly string urlMapPath = HttpContext.Current.Server.MapPath("~");
    private string xmlExample;

    public AdminExampleXmlRepository()
    {
    string xmlFolder = urlMapPath + "\\Xml";
    xmlExample = xmlFolder + "\\ExampleXml.xml";

    if (!Directory.Exists(xmlFolder))
    Directory.CreateDirectory(xmlFolder);

    if (!File.Exists(xmlExample))
    {
    File.WriteAllText(xmlExample, "<?xml version=\"1.0\" encoding=\"utf-8\"?><ExampleXml xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ><ExampleLists></ExampleLists></ExampleXml>");
    }


    }

    public IEnumerable<Example> GetExamples()
    {
    List<Example> exampleLists = new List<Example>();

    try
    {
    ExampleXml exampleXml = XmlDeserialize<ExampleXml>(xmlExample);
    exampleLists = exampleXml.ExampleLists;
    exampleLists.Sort((u1, u2) => u1.ExampleID.CompareTo(u2.ExampleID));
    }
    catch (Exception exception)
    {
    Log4ExceptionConnDb.ExXml(exception);
    }

    return exampleLists;
    }

    public Example GetExampleById(int exampleID)
    {
    Example example = new Example();

    try
    {

    if(exampleID != 0)
    {

    List<Example> exampleLists = new List<Example>();

    ExampleXml exampleXml = XmlDeserialize<ExampleXml>(xmlExample);
    exampleLists = exampleXml.ExampleLists.Where(a => a.ExampleID == exampleID).ToList();
    exampleLists.Sort((u1, u2) => u1.ExampleID.CompareTo(u2.ExampleID));
    example = exampleLists.FirstOrDefault();

    }
    else
    {
    example.ErrID = 1;
    example.ErrText = "exampleID cannot be zero.";
    }

    }
    catch (Exception exception)
    {
    XmlErrors(example);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return example;
    }

    public Example InsertExample(Example example)
    {

    try
    {
    if(example != null)
    {
    if(example.ExampleID != 0)
    {

    ExampleXml exampleXml = XmlDeserialize<ExampleXml>(xmlExample);

    if (exampleXml.ExampleLists == null)
    {
    exampleXml.ExampleLists = new List<Example>();
    }

    exampleXml.ExampleLists.Sort((u1, u2) => u1.ExampleID.CompareTo(u2.ExampleID));
    example.ExampleID = exampleXml.ExampleLists.Count == 0 ? 1 : exampleXml.ExampleLists.Max(x => x.ExampleID) + 1;
    exampleXml.ExampleLists.Add(example);
    XmlSerialize(exampleXml, xmlExample);

    }
    else
    {
    example.ErrID = 1;
    example.ErrText = "ExampleID cannot be zero.";
    }

    }
    else
    {
    example = new Example(){
    ErrID = 1,
    ErrText = "Example cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    XmlErrors(example);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return example;
    }

    public Example UpdateExample(Example example)
    {

    try
    {
    if(example != null)
    {
    if(example.ExampleID != 0)
    {

    ExampleXml exampleXml = XmlDeserialize<ExampleXml>(xmlExample);

    if (exampleXml.ExampleLists == null)
    {
    exampleXml.ExampleLists = new List<Example>();
    }

    foreach (Example _example in exampleXml.ExampleLists)
    {
    if (_example.ExampleID == example.ExampleID)
    {
    _example.ExampleUserInfoStatusID = example.ExampleUserInfoStatusID;
_example.ExampleUserInfoCompanyID = example.ExampleUserInfoCompanyID;
_example.Title = example.Title;
_example.Release = example.Release;
_example.ReleaseDateTime = example.ReleaseDateTime;
_example.Genre = example.Genre;
_example.Price = example.Price;
_example.PriceYesNo = example.PriceYesNo;
_example.ReleaseDate = example.ReleaseDate;
_example.ReleaseTime = example.ReleaseTime;
_example.Message = example.Message;
_example.Message2 = example.Message2;
_example.PhoneNumber = example.PhoneNumber;
_example.EmailAddress = example.EmailAddress;
_example.CreditCard = example.CreditCard;
_example.Password = example.Password;
_example.Url = example.Url;
_example.ExampleActiveYesNo = example.ExampleActiveYesNo;

    _example.UpdateUserName = example.UpdateUserName;
    _example.UpdateFullName = example.UpdateFullName;
    _example.UpdateDate = example.UpdateDate;
    XmlSerialize(exampleXml, xmlExample);
    break;
    }
    }

    }
    else
    {
    example.ErrID = 1;
    example.ErrText = "ExampleID cannot be zero.";
    }

    }
    else
    {
    example = new Example(){
    ErrID = 1,
    ErrText = "Example cannot be null."
    };
    }


    }
    catch (Exception exception)
    {
    XmlErrors(example);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return example;
    }

    public Example DeleteExample(int exampleID, Example example)
    {

    try
    {

    if(example != null)
    {
    if(exampleID != 0)
    {

    ExampleXml exampleXml = XmlDeserialize<ExampleXml>(xmlExample);

    if (exampleXml.ExampleLists == null)
    {
    exampleXml.ExampleLists = new List<Example>();
    }

    exampleXml.ExampleLists.RemoveAll(x => x.ExampleID == exampleID);
    XmlSerialize(exampleXml, xmlExample);

    example.DeleteTrueFalse = true;

    }
    else
    {
    example.ErrID = 1;
    example.ErrText = "exampleID cannot be zero.";
    }
    }
    else
    {
    example = new Example(){
    ErrID = 1,
    ErrText = "Example cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    XmlErrors(example);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return example;
    }

    private void XmlErrors(Example example)
    {
    example.ErrID = 1;
    example.ErrText = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
    }
    #endregion
    }
  

    }
  