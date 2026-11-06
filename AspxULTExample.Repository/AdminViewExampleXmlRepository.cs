
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

    
    public partial class AdminViewExampleXmlRepository : SerializeDeserializeXmlRepository, IViewExampleRepository, IViewExampleXmlRepository
    {

    #region AdminViewExampleXmlRepository

    private readonly string urlMapPath = HttpContext.Current.Server.MapPath("~");
    private string xmlExample;
    private string xmlExampleApprove;
    private string xmlExampleLog;
    private string xmlUserInfoCompany;
    private string xmlUserInfoUserInfoCompanyXref;
    private string xmlUserInfoStatus;

    public AdminViewExampleXmlRepository()
    {
    string xmlFolder = urlMapPath + "\\Xml";

    if (!Directory.Exists(xmlFolder))
    Directory.CreateDirectory(xmlFolder);

    xmlExample = xmlFolder + "\\ExampleXml.xml";
    if (!File.Exists(xmlExample))
    {
    File.WriteAllText(xmlExample, "<?xml version=\"1.0\" encoding=\"utf-8\"?><ExampleXml xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ><ViewExampleLists></ViewExampleLists></ExampleXml>");
    }

    xmlExampleApprove = xmlFolder + "\\ExampleApproveXml.xml";
    if (!File.Exists(xmlExampleApprove))
    {
    File.WriteAllText(xmlExampleApprove, "<?xml version=\"1.0\" encoding=\"utf-8\"?><ExampleApproveXml xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ><ExampleApproveLists></ExampleApproveLists></ExampleApproveXml>");
    }

    xmlExampleLog = xmlFolder + "\\ExampleLogXml.xml";
    if (!File.Exists(xmlExampleLog))
    {
    File.WriteAllText(xmlExampleLog, "<?xml version=\"1.0\" encoding=\"utf-8\"?><ExampleLogXml xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ><ExampleLogLists></ExampleLogLists></ExampleLogXml>");
    }

    xmlUserInfoCompany = xmlFolder + "\\UserInfoCompanyXml.xml";
    if (!System.IO.File.Exists(xmlUserInfoCompany))
    {
    System.IO.File.WriteAllText(xmlUserInfoCompany, "<?xml version=\"1.0\" encoding=\"utf-8\"?><UserInfoCompanyXml xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ><UserInfoCompanyLists></UserInfoCompanyLists></UserInfoCompanyXml>");
    }

    xmlUserInfoUserInfoCompanyXref = xmlFolder + "\\UserInfoUserInfoCompanyXrefXml.xml";
    if (!System.IO.File.Exists(xmlUserInfoUserInfoCompanyXref))
    {
    System.IO.File.WriteAllText(xmlUserInfoUserInfoCompanyXref, "<?xml version=\"1.0\" encoding=\"utf-8\"?><UserInfoUserInfoCompanyXrefXml xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ><UserInfoUserInfoCompanyXrefLists></UserInfoUserInfoCompanyXrefLists></UserInfoUserInfoCompanyXrefXml>");
    }

    xmlUserInfoStatus = xmlFolder + "\\UserInfoStatusXml.xml";
    if (!System.IO.File.Exists(xmlUserInfoStatus))
    {
    System.IO.File.WriteAllText(xmlUserInfoStatus, "<?xml version=\"1.0\" encoding=\"utf-8\"?><UserInfoStatusXml xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ><UserInfoStatusLists></UserInfoStatusLists></UserInfoStatusXml>");
    }

    }

    public IEnumerable<ViewExample> GetViewExamples(int userInfoID)
    {
    List<ViewExample> viewExampleLists = new List<ViewExample>();
    try
    {
    if (userInfoID != 0)
    {

    List<UserInfoCompany> userInfoCompanyLists = new List<UserInfoCompany>();
    List<UserInfoUserInfoCompanyXref> userInfoUserInfoCompanyXrefLists = new List<UserInfoUserInfoCompanyXref>();
    List<UserInfoStatus> userInfoStatusLists = new List<UserInfoStatus>();
    List<Example> vExampleLists = new List<Example>();

    UserInfoCompanyXml userInfoCompanyXml = XmlDeserialize<UserInfoCompanyXml>(xmlUserInfoCompany);
    userInfoCompanyLists = userInfoCompanyXml.UserInfoCompanyLists.ToList();

    UserInfoUserInfoCompanyXrefXml userInfoUserInfoCompanyXrefXml = XmlDeserialize<UserInfoUserInfoCompanyXrefXml>(xmlUserInfoUserInfoCompanyXref);
    userInfoUserInfoCompanyXrefLists = userInfoUserInfoCompanyXrefXml.UserInfoUserInfoCompanyXrefLists.ToList();

    UserInfoStatusXml userInfoStatusXml = XmlDeserialize<UserInfoStatusXml>(xmlUserInfoStatus);
    userInfoStatusLists = userInfoStatusXml.UserInfoStatusLists.ToList();

    ExampleXml exampleXml = XmlDeserialize<ExampleXml>(xmlExample);

    vExampleLists = exampleXml.ExampleLists.ToList();

    var vViewExampleLists =
    (from VExample in vExampleLists
    join UUC in userInfoUserInfoCompanyXrefLists on VExample.ExampleUserInfoCompanyID equals UUC.UserInfoCompanyID
    join UC in userInfoCompanyLists on UUC.UserInfoCompanyID equals UC.UserInfoCompanyID
    join US in userInfoStatusLists on VExample.ExampleUserInfoStatusID equals US.UserInfoStatusID
    where UUC.UserInfoID == userInfoID
    orderby VExample.ExampleID
    select new ViewExample()
    {
    ExampleID = VExample.ExampleID,
ExampleUserInfoStatusID = VExample.ExampleUserInfoStatusID,
ExampleUserInfoCompanyID = VExample.ExampleUserInfoCompanyID,
Title = VExample.Title,
Release = VExample.Release,
ReleaseDateTime = VExample.ReleaseDateTime,
Genre = VExample.Genre,
Price = VExample.Price,
PriceYesNo = VExample.PriceYesNo,
ReleaseDate = VExample.ReleaseDate,
ReleaseTime = VExample.ReleaseTime,
Message = VExample.Message,
Message2 = VExample.Message2,
PhoneNumber = VExample.PhoneNumber,
EmailAddress = VExample.EmailAddress,
CreditCard = VExample.CreditCard,
Password = VExample.Password,
Url = VExample.Url,
ExampleActiveYesNo = VExample.ExampleActiveYesNo,

    UserInfoStatusName = US.UserInfoStatusName,
    UserInfoCompanyName = UC.UserInfoCompanyName
    });

    viewExampleLists = vViewExampleLists.ToList();

    }
    }
    catch (Exception exception)
    {
    Log4ExceptionConnDb.ExXml(exception);
    }

    return viewExampleLists;
    }

    public IEnumerable<ExampleApprove> GetViewExampleApprovesById(int exampleID)
    {

    List<ExampleApprove> exampleApproveLists = new List<ExampleApprove>();

    try
    {
    if (exampleID != 0)
    {

    ExampleApproveXml exampleApproveXml = XmlDeserialize<ExampleApproveXml>(xmlExampleApprove);
    exampleApproveLists = exampleApproveXml.ExampleApproveLists.Where(a => a.ExampleID == exampleID).ToList();
    exampleApproveLists.Sort((u1, u2) => u1.ExampleApproveID.CompareTo(u2.ExampleApproveID));

    int x = 0;
    foreach (var exampleApprove in exampleApproveLists)
    {
    exampleApprove.ExampleApproveID = ++x;
    }

    }
    }
    catch (Exception exception)
    {
    Log4ExceptionConnDb.ExXml(exception);
    }

    return exampleApproveLists;

    }

    public IEnumerable<ExampleLog> GetViewExampleLogsById(int exampleID)
    {

    List<ExampleLog> exampleLogLists = new List<ExampleLog>();

    try
    {
    if (exampleID != 0)
    {


    ExampleLogXml exampleLogXml = XmlDeserialize<ExampleLogXml>(xmlExampleLog);
    exampleLogLists = exampleLogXml.ExampleLogLists.Where(a => a.ExampleID == exampleID).ToList();
    exampleLogLists.Sort((u1, u2) => u1.ExampleLogID.CompareTo(u2.ExampleLogID));

    int y = 0;
    foreach (var exampleLog in exampleLogLists)
    {
    exampleLog.ExampleLogID = ++y;
    }

    }
    }
    catch (Exception exception)
    {
    Log4ExceptionConnDb.ExXml(exception);
    }

    return exampleLogLists;

    }

    public IEnumerable<UserInfoUserInfoCompanyXref> GetLoadUserInfoUserInfoCompanyXrefsById(int userInfoID)
    {
    IEnumerable<UserInfoUserInfoCompanyXref> userInfoUserInfoCompanyXrefList = new List<UserInfoUserInfoCompanyXref>();

    if (userInfoID != 0)
    {
    LoadUserInfoXmlStringRepository loadUserInfoXmlStringRepository = new LoadUserInfoXmlStringRepository();
    userInfoUserInfoCompanyXrefList = loadUserInfoXmlStringRepository.GetLoadUserInfoUserInfoCompanyXrefsById(userInfoID);
    }

    return userInfoUserInfoCompanyXrefList;

    }


    public ViewExample GetViewExampleById(int exampleID)
    {
    ViewExample viewExample = new ViewExample();

    try
    {
    if(exampleID != 0)
    {

    List<UserInfoCompany> userInfoCompanyLists = new List<UserInfoCompany>();
    List<UserInfoUserInfoCompanyXref> userInfoUserInfoCompanyXrefLists = new List<UserInfoUserInfoCompanyXref>();
    List<UserInfoStatus> userInfoStatusLists = new List<UserInfoStatus>();
    List<Example> vExampleLists = new List<Example>();

    UserInfoCompanyXml userInfoCompanyXml = XmlDeserialize<UserInfoCompanyXml>(xmlUserInfoCompany);
    userInfoCompanyLists = userInfoCompanyXml.UserInfoCompanyLists.ToList();

    UserInfoUserInfoCompanyXrefXml userInfoUserInfoCompanyXrefXml = XmlDeserialize<UserInfoUserInfoCompanyXrefXml>(xmlUserInfoUserInfoCompanyXref);
    userInfoUserInfoCompanyXrefLists = userInfoUserInfoCompanyXrefXml.UserInfoUserInfoCompanyXrefLists.ToList();

    UserInfoStatusXml userInfoStatusXml = XmlDeserialize<UserInfoStatusXml>(xmlUserInfoStatus);
    userInfoStatusLists = userInfoStatusXml.UserInfoStatusLists.ToList();

    ExampleXml exampleXml = XmlDeserialize<ExampleXml>(xmlExample);

    vExampleLists = exampleXml.ExampleLists.ToList();

    var vViewExampleLists =
    (from VExample in vExampleLists
    join UUC in userInfoUserInfoCompanyXrefLists on VExample.ExampleUserInfoCompanyID equals UUC.UserInfoCompanyID
    join UC in userInfoCompanyLists on UUC.UserInfoCompanyID equals UC.UserInfoCompanyID
    join US in userInfoStatusLists on VExample.ExampleUserInfoStatusID equals US.UserInfoStatusID
    where VExample.ExampleID == exampleID
    select new ViewExample()
    {
    ExampleID = VExample.ExampleID,
ExampleUserInfoStatusID = VExample.ExampleUserInfoStatusID,
ExampleUserInfoCompanyID = VExample.ExampleUserInfoCompanyID,
Title = VExample.Title,
Release = VExample.Release,
ReleaseDateTime = VExample.ReleaseDateTime,
Genre = VExample.Genre,
Price = VExample.Price,
PriceYesNo = VExample.PriceYesNo,
ReleaseDate = VExample.ReleaseDate,
ReleaseTime = VExample.ReleaseTime,
Message = VExample.Message,
Message2 = VExample.Message2,
PhoneNumber = VExample.PhoneNumber,
EmailAddress = VExample.EmailAddress,
CreditCard = VExample.CreditCard,
Password = VExample.Password,
Url = VExample.Url,
ExampleActiveYesNo = VExample.ExampleActiveYesNo,

    UserInfoStatusName = US.UserInfoStatusName,
    UserInfoCompanyName = UC.UserInfoCompanyName
    });

    viewExample = vViewExampleLists.FirstOrDefault();

    }
    else
    {
    viewExample.ErrID = 1;
    viewExample.ErrText = "exampleID cannot be zero.";
    }

    }
    catch (Exception exception)
    {
    XmlErrors(viewExample);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return viewExample;
    }

    public ViewExample InsertViewExample(ViewExample viewExample)
    {

    try
    {
    if(viewExample != null)
    {
    if(viewExample.ExampleID != 0)
    {

    ExampleXml exampleXml = XmlDeserialize<ExampleXml>(xmlExample);

    if (exampleXml.ExampleLists == null)
    {
    exampleXml.ExampleLists = new List<Example>();
    }
    exampleXml.ExampleLists.Sort((u1, u2) => u1.ExampleID.CompareTo(u2.ExampleID));

    viewExample.ExampleID = exampleXml.ExampleLists.Count == 0 ? 1 : exampleXml.ExampleLists.Max(x => x.ExampleID) + 1;

    Example example = new Example()
    {
    ExampleID = viewExample.ExampleID,
ExampleUserInfoStatusID = viewExample.ExampleUserInfoStatusID,
ExampleUserInfoCompanyID = viewExample.ExampleUserInfoCompanyID,
Title = viewExample.Title,
Release = viewExample.Release,
ReleaseDateTime = viewExample.ReleaseDateTime,
Genre = viewExample.Genre,
Price = viewExample.Price,
PriceYesNo = viewExample.PriceYesNo,
ReleaseDate = viewExample.ReleaseDate,
ReleaseTime = viewExample.ReleaseTime,
Message = viewExample.Message,
Message2 = viewExample.Message2,
PhoneNumber = viewExample.PhoneNumber,
EmailAddress = viewExample.EmailAddress,
CreditCard = viewExample.CreditCard,
Password = viewExample.Password,
Url = viewExample.Url,
ExampleActiveYesNo = viewExample.ExampleActiveYesNo,

    };

    exampleXml.ExampleLists.Add(example);
    XmlSerialize(exampleXml, xmlExample);

    InsertViewExampleLogXml(viewExample.ExampleID, "Created");

    }
    else
    {
    viewExample.ErrID = 1;
    viewExample.ErrText = "ExampleID cannot be zero.";
    }

    }
    else
    {
    viewExample = new ViewExample(){
    ErrID = 1,
    ErrText = "ViewExample cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    XmlErrors(viewExample);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return viewExample;
    }

    public ViewExample UpdateViewExample(ViewExample viewExample)
    {

    try
    {
    if(viewExample != null)
    {

    if(viewExample.ExampleID != 0)
    {

    ExampleXml exampleXml = XmlDeserialize<ExampleXml>(xmlExample);

    if (exampleXml.ExampleLists == null)
    {
    exampleXml.ExampleLists = new List<Example>();
    }

    foreach (var example in exampleXml.ExampleLists)
    {
    if (example.ExampleID == viewExample.ExampleID)
    {
    example.ExampleUserInfoStatusID = viewExample.ExampleUserInfoStatusID;
example.ExampleUserInfoCompanyID = viewExample.ExampleUserInfoCompanyID;
example.Title = viewExample.Title;
example.Release = viewExample.Release;
example.ReleaseDateTime = viewExample.ReleaseDateTime;
example.Genre = viewExample.Genre;
example.Price = viewExample.Price;
example.PriceYesNo = viewExample.PriceYesNo;
example.ReleaseDate = viewExample.ReleaseDate;
example.ReleaseTime = viewExample.ReleaseTime;
example.Message = viewExample.Message;
example.Message2 = viewExample.Message2;
example.PhoneNumber = viewExample.PhoneNumber;
example.EmailAddress = viewExample.EmailAddress;
example.CreditCard = viewExample.CreditCard;
example.Password = viewExample.Password;
example.Url = viewExample.Url;
example.ExampleActiveYesNo = viewExample.ExampleActiveYesNo;

    example.UpdateUserName = viewExample.UpdateUserName;
    example.UpdateFullName = viewExample.UpdateFullName;
    example.UpdateDate = viewExample.UpdateDate;

    XmlSerialize(exampleXml, xmlExample);
    InsertViewExampleLogXml(viewExample.ExampleID, Enum.GetName(typeof(EnumUserInfoStatus), EnumUserInfoStatus.Created));
    break;
    }
    }
    }
    else
    {
    viewExample.ErrID = 1;
    viewExample.ErrText = "ExampleID cannot be zero.";
    }

    }
    else
    {
    viewExample = new ViewExample(){
    ErrID = 1,
    ErrText = "ViewExample cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    XmlErrors(viewExample);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return viewExample;
    }

    public ViewExample SignedUnsignedUpdateViewExample(ViewExample viewExample)
    {

    try
    {
    if (viewExample != null)
    {
    if(viewExample.ExampleID != 0)
    {

    ExampleXml exampleXml = XmlDeserialize<ExampleXml>(xmlExample);

    if (exampleXml.ExampleLists == null)
    {
    exampleXml.ExampleLists = new List<Example>();
    }

    foreach (var example in exampleXml.ExampleLists)
    {
    if (example.ExampleID == viewExample.ExampleID)
    {

    string noteMessage = Enum.GetName(typeof(EnumUserInfoStatus), EnumUserInfoStatus.Signed);

    noteMessage = viewExample.ExampleUserInfoStatusID == (int)EnumUserInfoStatus.Unsigned ? Enum.GetName(typeof(EnumUserInfoStatus), EnumUserInfoStatus.Unsigned) : noteMessage;

    if (viewExample.ExampleUserInfoStatusID == (int)EnumUserInfoStatus.Unsigned)
    {
    viewExample.ExampleUserInfoStatusID = (int)EnumUserInfoStatus.Created;
    }

    example.ExampleUserInfoStatusID = viewExample.ExampleUserInfoStatusID;
example.ExampleUserInfoCompanyID = viewExample.ExampleUserInfoCompanyID;
example.Title = viewExample.Title;
example.Release = viewExample.Release;
example.ReleaseDateTime = viewExample.ReleaseDateTime;
example.Genre = viewExample.Genre;
example.Price = viewExample.Price;
example.PriceYesNo = viewExample.PriceYesNo;
example.ReleaseDate = viewExample.ReleaseDate;
example.ReleaseTime = viewExample.ReleaseTime;
example.Message = viewExample.Message;
example.Message2 = viewExample.Message2;
example.PhoneNumber = viewExample.PhoneNumber;
example.EmailAddress = viewExample.EmailAddress;
example.CreditCard = viewExample.CreditCard;
example.Password = viewExample.Password;
example.Url = viewExample.Url;
example.ExampleActiveYesNo = viewExample.ExampleActiveYesNo;

    example.UpdateUserName = viewExample.UpdateUserName;
    example.UpdateFullName = viewExample.UpdateFullName;
    example.UpdateDate = viewExample.UpdateDate;

    XmlSerialize(exampleXml, xmlExample);
    InsertViewExampleLogXml(viewExample.ExampleID, noteMessage);

    viewExample.NoteMessage =  noteMessage;
    break;
    }
    }
    }
    else
    {
    viewExample.ErrID = 1;
    viewExample.ErrText = "ExampleID cannot be zero.";
    }

    }
    else
    {
    viewExample = new ViewExample()
    {
    ErrID = 1,
    ErrText = "ViewExample cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    XmlErrors(viewExample);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return viewExample;
    }

    public ViewExample ApproveCompeteRejectRevokeViewExample(ViewExample viewExample, string noteMessage)
    {

    try
    {
    if (viewExample != null)
    {
    if(viewExample.ExampleID != 0)
    {

    ExampleXml exampleXml = XmlDeserialize<ExampleXml>(xmlExample);

    if (exampleXml.ExampleLists == null)
    {
    exampleXml.ExampleLists = new List<Example>();
    }

    foreach (var example in exampleXml.ExampleLists)
    {
    if (example.ExampleID == viewExample.ExampleID)
    {

    if (viewExample.ExampleUserInfoStatusID == (int)EnumUserInfoStatus.Approved || viewExample.ExampleUserInfoStatusID == (int)EnumUserInfoStatus.Complete || viewExample.ExampleUserInfoStatusID == (int)EnumUserInfoStatus.Rejected || viewExample.ExampleUserInfoStatusID == (int)EnumUserInfoStatus.Revoked)
    {
    string memoMessage = Enum.GetName(typeof(EnumUserInfoStatus), EnumUserInfoStatus.Approved);

    memoMessage = viewExample.ExampleUserInfoStatusID == (int)EnumUserInfoStatus.Rejected ? Enum.GetName(typeof(EnumUserInfoStatus), EnumUserInfoStatus.Rejected) : viewExample.ExampleUserInfoStatusID == (int)EnumUserInfoStatus.Complete ? Enum.GetName(typeof(EnumUserInfoStatus), EnumUserInfoStatus.Complete) : viewExample.ExampleUserInfoStatusID == (int)EnumUserInfoStatus.Revoked ? Enum.GetName(typeof(EnumUserInfoStatus), EnumUserInfoStatus.Revoked) : memoMessage;

    if (!string.IsNullOrWhiteSpace(noteMessage))
    {
    memoMessage = memoMessage + " - " + noteMessage;
    }

    if (viewExample.ExampleUserInfoStatusID == (int)EnumUserInfoStatus.Approved || viewExample.ExampleUserInfoStatusID == (int)EnumUserInfoStatus.Complete ||viewExample.ExampleUserInfoStatusID == (int)EnumUserInfoStatus.Revoked)
    {
    example.ExampleUserInfoStatusID = viewExample.ExampleUserInfoStatusID;
    example.UpdateUserName = viewExample.UpdateUserName;
    example.UpdateFullName = viewExample.UpdateFullName;
    example.UpdateDate = viewExample.UpdateDate;
    XmlSerialize(exampleXml, xmlExample);
    InsertViewExampleApprove(viewExample.ExampleID);
    }
    else if (viewExample.ExampleUserInfoStatusID == (int)EnumUserInfoStatus.Rejected)
    {
    example.ExampleUserInfoStatusID = (int)EnumUserInfoStatus.Created;
    example.UpdateUserName = viewExample.UpdateUserName;
    example.UpdateFullName = viewExample.UpdateFullName;
    example.UpdateDate = viewExample.UpdateDate;
    XmlSerialize(exampleXml, xmlExample);
    DeleteViewExampleApprove(viewExample.ExampleID);
    }

    InsertViewExampleLogXml(viewExample.ExampleID, memoMessage);
    viewExample.NoteMessage =  memoMessage;
    break;
    }

    }
    }

    }
    else
    {
    viewExample.ErrID = 1;
    viewExample.ErrText = "ExampleID cannot be zero.";
    }

    }
    else
    {
    viewExample = new ViewExample()
    {
    ErrID = 1,
    ErrText = "ViewExample cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    XmlErrors(viewExample);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return viewExample;

    }


    public ViewExample DeleteViewExample(int exampleID, ViewExample viewExample)
    {

    try
    {
    if(viewExample != null)
    {
    if(exampleID != 0)
    {

    ExampleApproveXml exampleApproveXml = XmlDeserialize<ExampleApproveXml>(xmlExampleApprove);
    if (exampleApproveXml.ExampleApproveLists == null)
    {
    exampleApproveXml.ExampleApproveLists = new List<ExampleApprove>();
    }

    ExampleLogXml exampleLogXml = XmlDeserialize<ExampleLogXml>(xmlExampleLog);
    if (exampleLogXml.ExampleLogLists == null)
    {
    exampleLogXml.ExampleLogLists = new List<ExampleLog>();
    }

    ExampleXml exampleXml = XmlDeserialize<ExampleXml>(xmlExample);

    if (exampleXml.ExampleLists == null)
    {
    exampleXml.ExampleLists = new List<Example>();
    }

    exampleApproveXml.ExampleApproveLists.RemoveAll(x => x.ExampleID == exampleID);
    XmlSerialize(exampleApproveXml, xmlExampleApprove);

    exampleLogXml.ExampleLogLists.RemoveAll(x => x.ExampleID == exampleID);
    XmlSerialize(exampleLogXml, xmlExampleLog);


    exampleXml.ExampleLists.RemoveAll(x => x.ExampleID == exampleID);
    XmlSerialize(exampleXml, xmlExample);

    viewExample.DeleteTrueFalse = true;

    }
    else
    {
    viewExample.ErrID = 1;
    viewExample.ErrText = "exampleID cannot be zero.";
    }
    }
    else
    {
    viewExample = new ViewExample(){
    ErrID = 1,
    ErrText = "ViewExample cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    XmlErrors(viewExample);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return viewExample;
    }

    public ExampleApprove InsertViewExampleApprove(int exampleID)
    {

    ExampleApprove exampleApprove = new ExampleApprove();

    try
    {
    if(exampleID != 0)
    {

    ExampleApproveXml exampleApproveXml = XmlDeserialize<ExampleApproveXml>(xmlExampleApprove);

    if (exampleApproveXml.ExampleApproveLists == null)
    {
    exampleApproveXml.ExampleApproveLists = new List<ExampleApprove>();
    }

    exampleApproveXml.ExampleApproveLists.Sort((u1, u2) => u1.ExampleID.CompareTo(u2.ExampleID));

    List<ExampleApprove> exampleApproveLists = exampleApproveXml.ExampleApproveLists.Where(a => a.UserInfoID == exampleApprove._UserInfoID).ToList();
    if (exampleApproveLists.Count == 0)
    {

    exampleApprove.ExampleApproveID = exampleApproveXml.ExampleApproveLists.Count == 0 ? 1 : exampleApproveXml.ExampleApproveLists.Max(x => x.ExampleApproveID) + 1;
    exampleApprove.ExampleID = exampleID;
    exampleApprove.UserInfoID = exampleApprove._UserInfoID;
    exampleApprove.UserInfoJobTitle = exampleApprove._UserInfoJobTitle;
    exampleApproveXml.ExampleApproveLists.Add(exampleApprove);
    XmlSerialize(exampleApproveXml, xmlExampleApprove);
    }

    }
    }
    catch (Exception exception)
    {
    Log4ExceptionConnDb.ExXml(exception);
    }

    return exampleApprove;
    }

    public ExampleApprove DeleteViewExampleApprove(int exampleID)
    {

    ExampleApprove exampleApprove = new ExampleApprove();
    try
    {

    if(exampleID != 0)
    {

    ExampleApproveXml exampleApproveXml = XmlDeserialize<ExampleApproveXml>(xmlExampleApprove);

    if (exampleApproveXml.ExampleApproveLists == null)
    {
    exampleApproveXml.ExampleApproveLists = new List<ExampleApprove>();
    }

    exampleApproveXml.ExampleApproveLists.RemoveAll(x => x.ExampleID == exampleID);
    XmlSerialize(exampleApproveXml, xmlExampleApprove);

    exampleApprove.DeleteTrueFalse = true;

    }
    }
    catch (Exception exception)
    {
    Log4ExceptionConnDb.ExXml(exception);
    }

    return exampleApprove;
    }

    public ExampleLog InsertViewExampleLogXml(int exampleID, string memoMessage)
    {

    ExampleLog exampleLog = new ExampleLog();

    try
    {
    if (exampleID != 0)
    {


    ExampleLogXml exampleLogXml = XmlDeserialize<ExampleLogXml>(xmlExampleLog);

    if (exampleLogXml.ExampleLogLists == null)
    {
    exampleLogXml.ExampleLogLists = new List<ExampleLog>();
    }

    exampleLogXml.ExampleLogLists.Sort((u1, u2) => u1.ExampleID.CompareTo(u2.ExampleID));
    exampleLog.ExampleLogID = exampleLogXml.ExampleLogLists.Count == 0 ? 1 : exampleLogXml.ExampleLogLists.Max(x => x.ExampleLogID) + 1;
    exampleLog.ExampleID = exampleID;
    exampleLog.LogMessage = memoMessage;

    exampleLogXml.ExampleLogLists.Add(exampleLog);
    XmlSerialize(exampleLogXml, xmlExampleLog);

    }
    }
    catch (Exception exception)
    {
    Log4ExceptionConnDb.ExXml(exception);
    }

    return exampleLog;
    }


    private void XmlErrors(ViewExample viewExample)
    {
    viewExample.ErrID = 1;
    viewExample.ErrText = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
    }
    #endregion


    }
  

    }
  