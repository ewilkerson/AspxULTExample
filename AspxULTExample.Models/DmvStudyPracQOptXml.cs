
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    namespace AspxULTExample.Models
    {
    [XmlRoot("DmvStudyPracQOptXml")]
    public partial class DmvStudyPracQOptXml
    {

    #region DmvStudyPracQOptsXml

    [XmlArray("DmvStudyPracQOptLists")]
    [XmlArrayItem("DmvStudyPracQOpt")]
    public List<DmvStudyPracQOpt> DmvStudyPracQOptLists;

    public DmvStudyPracQOptXml()
    {
    DmvStudyPracQOptLists = new List<DmvStudyPracQOpt>();
    }
    #endregion
    }
    }
  