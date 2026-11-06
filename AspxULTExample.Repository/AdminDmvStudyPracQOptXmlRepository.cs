
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

    
    public partial class AdminDmvStudyPracQOptXmlRepository : SerializeDeserializeXmlRepository, IRepository<DmvStudyPracQOpt>
    {

    #region AdminDmvStudyPracQOptXmlRepository

    private readonly string urlMapPath = HttpContext.Current.Server.MapPath("~");
    private string xmlDmvStudyPracQOpt;

    public AdminDmvStudyPracQOptXmlRepository()
    {

    string xmlFolder = urlMapPath + "\\Xml";
    if (!Directory.Exists(xmlFolder))
    Directory.CreateDirectory(xmlFolder);

    xmlDmvStudyPracQOpt = xmlFolder + "\\DmvStudyPracQOptXml.xml";
    if (!File.Exists(xmlDmvStudyPracQOpt))
    {
    File.WriteAllText(xmlDmvStudyPracQOpt, "<?xml version=\"1.0\" encoding=\"utf-8\"?><DmvStudyPracQOptXml xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ><DmvStudyPracQOptLists></DmvStudyPracQOptLists></DmvStudyPracQOptXml>");
    }


    }

    public IEnumerable<DmvStudyPracQOpt> GetAll()
    {
    List<DmvStudyPracQOpt> dmvStudyPracQOptLists = new List<DmvStudyPracQOpt>();

    try
    {
    DmvStudyPracQOptXml dmvStudyPracQOptXml = XmlDeserialize<DmvStudyPracQOptXml>(xmlDmvStudyPracQOpt);
    dmvStudyPracQOptLists = dmvStudyPracQOptXml.DmvStudyPracQOptLists;
    dmvStudyPracQOptLists.Sort((u1, u2) => u1.DmvStudyPracQOptID.CompareTo(u2.DmvStudyPracQOptID));
    }
    catch (Exception exception)
    {
    Log4ExceptionConnDb.ExXml(exception);
    }

    return dmvStudyPracQOptLists;
    }

    public DmvStudyPracQOpt GetById(int dmvStudyPracQOptID)
    {
    DmvStudyPracQOpt dmvStudyPracQOpt = new DmvStudyPracQOpt();

    try
    {

    if(dmvStudyPracQOptID != 0)
    {

    List<DmvStudyPracQOpt> dmvStudyPracQOptLists = new List<DmvStudyPracQOpt>();

    DmvStudyPracQOptXml dmvStudyPracQOptXml = XmlDeserialize<DmvStudyPracQOptXml>(xmlDmvStudyPracQOpt);
    dmvStudyPracQOptLists = dmvStudyPracQOptXml.DmvStudyPracQOptLists.Where(a => a.DmvStudyPracQOptID == dmvStudyPracQOptID).ToList();
    dmvStudyPracQOptLists.Sort((u1, u2) => u1.DmvStudyPracQOptID.CompareTo(u2.DmvStudyPracQOptID));
    dmvStudyPracQOpt = dmvStudyPracQOptLists.FirstOrDefault();

    }
    else
    {
    dmvStudyPracQOpt.ErrID = 1;
    dmvStudyPracQOpt.ErrText = "dmvStudyPracQOptID cannot be zero.";
    }

    }
    catch (Exception exception)
    {
    XmlErrors(dmvStudyPracQOpt);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return dmvStudyPracQOpt;
    }

    public DmvStudyPracQOpt Insert(DmvStudyPracQOpt dmvStudyPracQOpt)
    {

    try
    {
    if(dmvStudyPracQOpt != null)
    {
    if(dmvStudyPracQOpt.DmvStudyPracQOptID != 0)
    {

    DmvStudyPracQOptXml dmvStudyPracQOptXml = XmlDeserialize<DmvStudyPracQOptXml>(xmlDmvStudyPracQOpt);

    if (dmvStudyPracQOptXml.DmvStudyPracQOptLists == null)
    {
    dmvStudyPracQOptXml.DmvStudyPracQOptLists = new List<DmvStudyPracQOpt>();
    }

    dmvStudyPracQOptXml.DmvStudyPracQOptLists.Sort((u1, u2) => u1.DmvStudyPracQOptID.CompareTo(u2.DmvStudyPracQOptID));
    dmvStudyPracQOpt.DmvStudyPracQOptID = dmvStudyPracQOptXml.DmvStudyPracQOptLists.Count == 0 ? 1 : dmvStudyPracQOptXml.DmvStudyPracQOptLists.Max(x => x.DmvStudyPracQOptID) + 1;
    dmvStudyPracQOptXml.DmvStudyPracQOptLists.Add(dmvStudyPracQOpt);
    XmlSerialize(dmvStudyPracQOptXml, xmlDmvStudyPracQOpt);

    }
    else
    {
    dmvStudyPracQOpt.ErrID = 1;
    dmvStudyPracQOpt.ErrText = "DmvStudyPracQOptID cannot be zero.";
    }

    }
    else
    {
    dmvStudyPracQOpt = new DmvStudyPracQOpt(){
    ErrID = 1,
    ErrText = "DmvStudyPracQOpt cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    XmlErrors(dmvStudyPracQOpt);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return dmvStudyPracQOpt;
    }

    public DmvStudyPracQOpt Update(DmvStudyPracQOpt dmvStudyPracQOpt)
    {

    try
    {
    if(dmvStudyPracQOpt != null)
    {
    if(dmvStudyPracQOpt.DmvStudyPracQOptID != 0)
    {

    DmvStudyPracQOptXml dmvStudyPracQOptXml = XmlDeserialize<DmvStudyPracQOptXml>(xmlDmvStudyPracQOpt);

    if (dmvStudyPracQOptXml.DmvStudyPracQOptLists == null)
    {
    dmvStudyPracQOptXml.DmvStudyPracQOptLists = new List<DmvStudyPracQOpt>();
    }

    foreach (DmvStudyPracQOpt _dmvStudyPracQOpt in dmvStudyPracQOptXml.DmvStudyPracQOptLists)
    {
    if (_dmvStudyPracQOpt.DmvStudyPracQOptID == dmvStudyPracQOpt.DmvStudyPracQOptID)
    {
    _dmvStudyPracQOpt.DmvStudyPracQuestionID = dmvStudyPracQOpt.DmvStudyPracQuestionID;
_dmvStudyPracQOpt.DmvStudyPracQOptText = dmvStudyPracQOpt.DmvStudyPracQOptText;
_dmvStudyPracQOpt.DmvStudyPracQOptAnswerYesNo = dmvStudyPracQOpt.DmvStudyPracQOptAnswerYesNo;
_dmvStudyPracQOpt.DmvStudyPracQOptActiveYesNo = dmvStudyPracQOpt.DmvStudyPracQOptActiveYesNo;

    _dmvStudyPracQOpt.UpdateUserName = dmvStudyPracQOpt.UpdateUserName;
    _dmvStudyPracQOpt.UpdateFullName = dmvStudyPracQOpt.UpdateFullName;
    _dmvStudyPracQOpt.UpdateDate = dmvStudyPracQOpt.UpdateDate;
    XmlSerialize(dmvStudyPracQOptXml, xmlDmvStudyPracQOpt);
    break;
    }
    }

    }
    else
    {
    dmvStudyPracQOpt.ErrID = 1;
    dmvStudyPracQOpt.ErrText = "DmvStudyPracQOptID cannot be zero.";
    }

    }
    else
    {
    dmvStudyPracQOpt = new DmvStudyPracQOpt(){
    ErrID = 1,
    ErrText = "DmvStudyPracQOpt cannot be null."
    };
    }


    }
    catch (Exception exception)
    {
    XmlErrors(dmvStudyPracQOpt);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return dmvStudyPracQOpt;
    }

    public DmvStudyPracQOpt Delete(int dmvStudyPracQOptID, DmvStudyPracQOpt dmvStudyPracQOpt)
    {

    try
    {

    if(dmvStudyPracQOpt != null)
    {
    if(dmvStudyPracQOptID != 0)
    {

    DmvStudyPracQOptXml dmvStudyPracQOptXml = XmlDeserialize<DmvStudyPracQOptXml>(xmlDmvStudyPracQOpt);

    if (dmvStudyPracQOptXml.DmvStudyPracQOptLists == null)
    {
    dmvStudyPracQOptXml.DmvStudyPracQOptLists = new List<DmvStudyPracQOpt>();
    }

    dmvStudyPracQOptXml.DmvStudyPracQOptLists.RemoveAll(x => x.DmvStudyPracQOptID == dmvStudyPracQOptID);
    XmlSerialize(dmvStudyPracQOptXml, xmlDmvStudyPracQOpt);

    dmvStudyPracQOpt.DeleteTrueFalse = true;

    }
    else
    {
    dmvStudyPracQOpt.ErrID = 1;
    dmvStudyPracQOpt.ErrText = "dmvStudyPracQOptID cannot be zero.";
    }
    }
    else
    {
    dmvStudyPracQOpt = new DmvStudyPracQOpt(){
    ErrID = 1,
    ErrText = "DmvStudyPracQOpt cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    XmlErrors(dmvStudyPracQOpt);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return dmvStudyPracQOpt;
    }

    private void XmlErrors(DmvStudyPracQOpt dmvStudyPracQOpt)
    {
    if(dmvStudyPracQOpt != null)
    {

    dmvStudyPracQOpt.ErrID = 1;
    dmvStudyPracQOpt.ErrText = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
    }
    else
    {
    dmvStudyPracQOpt = new DmvStudyPracQOpt(){
    ErrID = 1,
    ErrText = "DmvStudyPracQOpt cannot be null."
    };
    }
    }

    #endregion
    }
  

    }
  