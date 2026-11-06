
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

    
    public partial class AdminDmvStudyPractXmlRepository : SerializeDeserializeXmlRepository, IRepository<DmvStudyPract>
    {

    #region AdminDmvStudyPractXmlRepository

    private readonly string urlMapPath = HttpContext.Current.Server.MapPath("~");
    private string xmlDmvStudyPract;

    public AdminDmvStudyPractXmlRepository()
    {

    string xmlFolder = urlMapPath + "\\Xml";
    if (!Directory.Exists(xmlFolder))
    Directory.CreateDirectory(xmlFolder);

    xmlDmvStudyPract = xmlFolder + "\\DmvStudyPractXml.xml";
    if (!File.Exists(xmlDmvStudyPract))
    {
    File.WriteAllText(xmlDmvStudyPract, "<?xml version=\"1.0\" encoding=\"utf-8\"?><DmvStudyPractXml xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ><DmvStudyPractLists></DmvStudyPractLists></DmvStudyPractXml>");
    }


    }

    public IEnumerable<DmvStudyPract> GetAll()
    {
    List<DmvStudyPract> dmvStudyPractLists = new List<DmvStudyPract>();

    try
    {
    DmvStudyPractXml dmvStudyPractXml = XmlDeserialize<DmvStudyPractXml>(xmlDmvStudyPract);
    dmvStudyPractLists = dmvStudyPractXml.DmvStudyPractLists;
    dmvStudyPractLists.Sort((u1, u2) => u1.DmvStudyPractID.CompareTo(u2.DmvStudyPractID));
    }
    catch (Exception exception)
    {
    Log4ExceptionConnDb.ExXml(exception);
    }

    return dmvStudyPractLists;
    }

    public DmvStudyPract GetById(int dmvStudyPractID)
    {
    DmvStudyPract dmvStudyPract = new DmvStudyPract();

    try
    {

    if(dmvStudyPractID != 0)
    {

    List<DmvStudyPract> dmvStudyPractLists = new List<DmvStudyPract>();

    DmvStudyPractXml dmvStudyPractXml = XmlDeserialize<DmvStudyPractXml>(xmlDmvStudyPract);
    dmvStudyPractLists = dmvStudyPractXml.DmvStudyPractLists.Where(a => a.DmvStudyPractID == dmvStudyPractID).ToList();
    dmvStudyPractLists.Sort((u1, u2) => u1.DmvStudyPractID.CompareTo(u2.DmvStudyPractID));
    dmvStudyPract = dmvStudyPractLists.FirstOrDefault();

    }
    else
    {
    dmvStudyPract.ErrID = 1;
    dmvStudyPract.ErrText = "dmvStudyPractID cannot be zero.";
    }

    }
    catch (Exception exception)
    {
    XmlErrors(dmvStudyPract);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return dmvStudyPract;
    }

    public DmvStudyPract Insert(DmvStudyPract dmvStudyPract)
    {

    try
    {
    if(dmvStudyPract != null)
    {
    if(dmvStudyPract.DmvStudyPractID != 0)
    {

    DmvStudyPractXml dmvStudyPractXml = XmlDeserialize<DmvStudyPractXml>(xmlDmvStudyPract);

    if (dmvStudyPractXml.DmvStudyPractLists == null)
    {
    dmvStudyPractXml.DmvStudyPractLists = new List<DmvStudyPract>();
    }

    dmvStudyPractXml.DmvStudyPractLists.Sort((u1, u2) => u1.DmvStudyPractID.CompareTo(u2.DmvStudyPractID));
    dmvStudyPract.DmvStudyPractID = dmvStudyPractXml.DmvStudyPractLists.Count == 0 ? 1 : dmvStudyPractXml.DmvStudyPractLists.Max(x => x.DmvStudyPractID) + 1;
    dmvStudyPractXml.DmvStudyPractLists.Add(dmvStudyPract);
    XmlSerialize(dmvStudyPractXml, xmlDmvStudyPract);

    }
    else
    {
    dmvStudyPract.ErrID = 1;
    dmvStudyPract.ErrText = "DmvStudyPractID cannot be zero.";
    }

    }
    else
    {
    dmvStudyPract = new DmvStudyPract(){
    ErrID = 1,
    ErrText = "DmvStudyPract cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    XmlErrors(dmvStudyPract);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return dmvStudyPract;
    }

    public DmvStudyPract Update(DmvStudyPract dmvStudyPract)
    {

    try
    {
    if(dmvStudyPract != null)
    {
    if(dmvStudyPract.DmvStudyPractID != 0)
    {

    DmvStudyPractXml dmvStudyPractXml = XmlDeserialize<DmvStudyPractXml>(xmlDmvStudyPract);

    if (dmvStudyPractXml.DmvStudyPractLists == null)
    {
    dmvStudyPractXml.DmvStudyPractLists = new List<DmvStudyPract>();
    }

    foreach (DmvStudyPract _dmvStudyPract in dmvStudyPractXml.DmvStudyPractLists)
    {
    if (_dmvStudyPract.DmvStudyPractID == dmvStudyPract.DmvStudyPractID)
    {
    _dmvStudyPract.DmvStudyPractNum = dmvStudyPract.DmvStudyPractNum;
_dmvStudyPract.DmvStudyPractTitle = dmvStudyPract.DmvStudyPractTitle;
_dmvStudyPract.DmvStudyPractActiveYesNo = dmvStudyPract.DmvStudyPractActiveYesNo;

    _dmvStudyPract.UpdateUserName = dmvStudyPract.UpdateUserName;
    _dmvStudyPract.UpdateFullName = dmvStudyPract.UpdateFullName;
    _dmvStudyPract.UpdateDate = dmvStudyPract.UpdateDate;
    XmlSerialize(dmvStudyPractXml, xmlDmvStudyPract);
    break;
    }
    }

    }
    else
    {
    dmvStudyPract.ErrID = 1;
    dmvStudyPract.ErrText = "DmvStudyPractID cannot be zero.";
    }

    }
    else
    {
    dmvStudyPract = new DmvStudyPract(){
    ErrID = 1,
    ErrText = "DmvStudyPract cannot be null."
    };
    }


    }
    catch (Exception exception)
    {
    XmlErrors(dmvStudyPract);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return dmvStudyPract;
    }

    public DmvStudyPract Delete(int dmvStudyPractID, DmvStudyPract dmvStudyPract)
    {

    try
    {

    if(dmvStudyPract != null)
    {
    if(dmvStudyPractID != 0)
    {

    DmvStudyPractXml dmvStudyPractXml = XmlDeserialize<DmvStudyPractXml>(xmlDmvStudyPract);

    if (dmvStudyPractXml.DmvStudyPractLists == null)
    {
    dmvStudyPractXml.DmvStudyPractLists = new List<DmvStudyPract>();
    }

    dmvStudyPractXml.DmvStudyPractLists.RemoveAll(x => x.DmvStudyPractID == dmvStudyPractID);
    XmlSerialize(dmvStudyPractXml, xmlDmvStudyPract);

    dmvStudyPract.DeleteTrueFalse = true;

    }
    else
    {
    dmvStudyPract.ErrID = 1;
    dmvStudyPract.ErrText = "dmvStudyPractID cannot be zero.";
    }
    }
    else
    {
    dmvStudyPract = new DmvStudyPract(){
    ErrID = 1,
    ErrText = "DmvStudyPract cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    XmlErrors(dmvStudyPract);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return dmvStudyPract;
    }

    private void XmlErrors(DmvStudyPract dmvStudyPract)
    {
    if(dmvStudyPract != null)
    {

    dmvStudyPract.ErrID = 1;
    dmvStudyPract.ErrText = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
    }
    else
    {
    dmvStudyPract = new DmvStudyPract(){
    ErrID = 1,
    ErrText = "DmvStudyPract cannot be null."
    };
    }
    }

    #endregion
    }
  

    }
  