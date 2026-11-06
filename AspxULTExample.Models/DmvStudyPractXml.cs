
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    namespace AspxULTExample.Models
    {
    [XmlRoot("DmvStudyPractXml")]
    public partial class DmvStudyPractXml
    {

    #region DmvStudyPractsXml

    [XmlArray("DmvStudyPractLists")]
    [XmlArrayItem("DmvStudyPract")]
    public List<DmvStudyPract> DmvStudyPractLists;

    public DmvStudyPractXml()
    {
    DmvStudyPractLists = new List<DmvStudyPract>();
    }
    #endregion
    }
    }
  