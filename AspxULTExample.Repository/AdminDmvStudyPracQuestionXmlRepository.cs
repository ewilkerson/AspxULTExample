
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

    
    public partial class AdminDmvStudyPracQuestionXmlRepository : SerializeDeserializeXmlRepository, IRepository<DmvStudyPracQuestion>
    {

    #region AdminDmvStudyPracQuestionXmlRepository

    private readonly string urlMapPath = HttpContext.Current.Server.MapPath("~");
    private string xmlDmvStudyPracQuestion;

    public AdminDmvStudyPracQuestionXmlRepository()
    {

    string xmlFolder = urlMapPath + "\\Xml";
    if (!Directory.Exists(xmlFolder))
    Directory.CreateDirectory(xmlFolder);

    xmlDmvStudyPracQuestion = xmlFolder + "\\DmvStudyPracQuestionXml.xml";
    if (!File.Exists(xmlDmvStudyPracQuestion))
    {
    File.WriteAllText(xmlDmvStudyPracQuestion, "<?xml version=\"1.0\" encoding=\"utf-8\"?><DmvStudyPracQuestionXml xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ><DmvStudyPracQuestionLists></DmvStudyPracQuestionLists></DmvStudyPracQuestionXml>");
    }


    }

    public IEnumerable<DmvStudyPracQuestion> GetAll()
    {
    List<DmvStudyPracQuestion> dmvStudyPracQuestionLists = new List<DmvStudyPracQuestion>();

    try
    {
    DmvStudyPracQuestionXml dmvStudyPracQuestionXml = XmlDeserialize<DmvStudyPracQuestionXml>(xmlDmvStudyPracQuestion);
    dmvStudyPracQuestionLists = dmvStudyPracQuestionXml.DmvStudyPracQuestionLists;
    dmvStudyPracQuestionLists.Sort((u1, u2) => u1.DmvStudyPracQuestionID.CompareTo(u2.DmvStudyPracQuestionID));
    }
    catch (Exception exception)
    {
    Log4ExceptionConnDb.ExXml(exception);
    }

    return dmvStudyPracQuestionLists;
    }

    public DmvStudyPracQuestion GetById(int dmvStudyPracQuestionID)
    {
    DmvStudyPracQuestion dmvStudyPracQuestion = new DmvStudyPracQuestion();

    try
    {

    if(dmvStudyPracQuestionID != 0)
    {

    List<DmvStudyPracQuestion> dmvStudyPracQuestionLists = new List<DmvStudyPracQuestion>();

    DmvStudyPracQuestionXml dmvStudyPracQuestionXml = XmlDeserialize<DmvStudyPracQuestionXml>(xmlDmvStudyPracQuestion);
    dmvStudyPracQuestionLists = dmvStudyPracQuestionXml.DmvStudyPracQuestionLists.Where(a => a.DmvStudyPracQuestionID == dmvStudyPracQuestionID).ToList();
    dmvStudyPracQuestionLists.Sort((u1, u2) => u1.DmvStudyPracQuestionID.CompareTo(u2.DmvStudyPracQuestionID));
    dmvStudyPracQuestion = dmvStudyPracQuestionLists.FirstOrDefault();

    }
    else
    {
    dmvStudyPracQuestion.ErrID = 1;
    dmvStudyPracQuestion.ErrText = "dmvStudyPracQuestionID cannot be zero.";
    }

    }
    catch (Exception exception)
    {
    XmlErrors(dmvStudyPracQuestion);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return dmvStudyPracQuestion;
    }

    public DmvStudyPracQuestion Insert(DmvStudyPracQuestion dmvStudyPracQuestion)
    {

    try
    {
    if(dmvStudyPracQuestion != null)
    {
    if(dmvStudyPracQuestion.DmvStudyPracQuestionID != 0)
    {

    DmvStudyPracQuestionXml dmvStudyPracQuestionXml = XmlDeserialize<DmvStudyPracQuestionXml>(xmlDmvStudyPracQuestion);

    if (dmvStudyPracQuestionXml.DmvStudyPracQuestionLists == null)
    {
    dmvStudyPracQuestionXml.DmvStudyPracQuestionLists = new List<DmvStudyPracQuestion>();
    }

    dmvStudyPracQuestionXml.DmvStudyPracQuestionLists.Sort((u1, u2) => u1.DmvStudyPracQuestionID.CompareTo(u2.DmvStudyPracQuestionID));
    dmvStudyPracQuestion.DmvStudyPracQuestionID = dmvStudyPracQuestionXml.DmvStudyPracQuestionLists.Count == 0 ? 1 : dmvStudyPracQuestionXml.DmvStudyPracQuestionLists.Max(x => x.DmvStudyPracQuestionID) + 1;
    dmvStudyPracQuestionXml.DmvStudyPracQuestionLists.Add(dmvStudyPracQuestion);
    XmlSerialize(dmvStudyPracQuestionXml, xmlDmvStudyPracQuestion);

    }
    else
    {
    dmvStudyPracQuestion.ErrID = 1;
    dmvStudyPracQuestion.ErrText = "DmvStudyPracQuestionID cannot be zero.";
    }

    }
    else
    {
    dmvStudyPracQuestion = new DmvStudyPracQuestion(){
    ErrID = 1,
    ErrText = "DmvStudyPracQuestion cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    XmlErrors(dmvStudyPracQuestion);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return dmvStudyPracQuestion;
    }

    public DmvStudyPracQuestion Update(DmvStudyPracQuestion dmvStudyPracQuestion)
    {

    try
    {
    if(dmvStudyPracQuestion != null)
    {
    if(dmvStudyPracQuestion.DmvStudyPracQuestionID != 0)
    {

    DmvStudyPracQuestionXml dmvStudyPracQuestionXml = XmlDeserialize<DmvStudyPracQuestionXml>(xmlDmvStudyPracQuestion);

    if (dmvStudyPracQuestionXml.DmvStudyPracQuestionLists == null)
    {
    dmvStudyPracQuestionXml.DmvStudyPracQuestionLists = new List<DmvStudyPracQuestion>();
    }

    foreach (DmvStudyPracQuestion _dmvStudyPracQuestion in dmvStudyPracQuestionXml.DmvStudyPracQuestionLists)
    {
    if (_dmvStudyPracQuestion.DmvStudyPracQuestionID == dmvStudyPracQuestion.DmvStudyPracQuestionID)
    {
    _dmvStudyPracQuestion.DmvStudyPracID = dmvStudyPracQuestion.DmvStudyPracID;
_dmvStudyPracQuestion.DmvStudyPracQuestionText = dmvStudyPracQuestion.DmvStudyPracQuestionText;
_dmvStudyPracQuestion.DmvStudyPracQuestionAnswerText = dmvStudyPracQuestion.DmvStudyPracQuestionAnswerText;
_dmvStudyPracQuestion.DmvStudyPracQuestionPicsYesNo = dmvStudyPracQuestion.DmvStudyPracQuestionPicsYesNo;
_dmvStudyPracQuestion.DmvStudyPracQuestionActiveYesNo = dmvStudyPracQuestion.DmvStudyPracQuestionActiveYesNo;

    _dmvStudyPracQuestion.UpdateUserName = dmvStudyPracQuestion.UpdateUserName;
    _dmvStudyPracQuestion.UpdateFullName = dmvStudyPracQuestion.UpdateFullName;
    _dmvStudyPracQuestion.UpdateDate = dmvStudyPracQuestion.UpdateDate;
    XmlSerialize(dmvStudyPracQuestionXml, xmlDmvStudyPracQuestion);
    break;
    }
    }

    }
    else
    {
    dmvStudyPracQuestion.ErrID = 1;
    dmvStudyPracQuestion.ErrText = "DmvStudyPracQuestionID cannot be zero.";
    }

    }
    else
    {
    dmvStudyPracQuestion = new DmvStudyPracQuestion(){
    ErrID = 1,
    ErrText = "DmvStudyPracQuestion cannot be null."
    };
    }


    }
    catch (Exception exception)
    {
    XmlErrors(dmvStudyPracQuestion);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return dmvStudyPracQuestion;
    }

    public DmvStudyPracQuestion Delete(int dmvStudyPracQuestionID, DmvStudyPracQuestion dmvStudyPracQuestion)
    {

    try
    {

    if(dmvStudyPracQuestion != null)
    {
    if(dmvStudyPracQuestionID != 0)
    {

    DmvStudyPracQuestionXml dmvStudyPracQuestionXml = XmlDeserialize<DmvStudyPracQuestionXml>(xmlDmvStudyPracQuestion);

    if (dmvStudyPracQuestionXml.DmvStudyPracQuestionLists == null)
    {
    dmvStudyPracQuestionXml.DmvStudyPracQuestionLists = new List<DmvStudyPracQuestion>();
    }

    dmvStudyPracQuestionXml.DmvStudyPracQuestionLists.RemoveAll(x => x.DmvStudyPracQuestionID == dmvStudyPracQuestionID);
    XmlSerialize(dmvStudyPracQuestionXml, xmlDmvStudyPracQuestion);

    dmvStudyPracQuestion.DeleteTrueFalse = true;

    }
    else
    {
    dmvStudyPracQuestion.ErrID = 1;
    dmvStudyPracQuestion.ErrText = "dmvStudyPracQuestionID cannot be zero.";
    }
    }
    else
    {
    dmvStudyPracQuestion = new DmvStudyPracQuestion(){
    ErrID = 1,
    ErrText = "DmvStudyPracQuestion cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    XmlErrors(dmvStudyPracQuestion);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return dmvStudyPracQuestion;
    }

    private void XmlErrors(DmvStudyPracQuestion dmvStudyPracQuestion)
    {
    if(dmvStudyPracQuestion != null)
    {

    dmvStudyPracQuestion.ErrID = 1;
    dmvStudyPracQuestion.ErrText = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
    }
    else
    {
    dmvStudyPracQuestion = new DmvStudyPracQuestion(){
    ErrID = 1,
    ErrText = "DmvStudyPracQuestion cannot be null."
    };
    }
    }

    #endregion
    }
  

    }
  