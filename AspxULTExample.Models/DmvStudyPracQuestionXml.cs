
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    namespace AspxULTExample.Models
    {
    [XmlRoot("DmvStudyPracQuestionXml")]
    public partial class DmvStudyPracQuestionXml
    {

    #region DmvStudyPracQuestionsXml

    [XmlArray("DmvStudyPracQuestionLists")]
    [XmlArrayItem("DmvStudyPracQuestion")]
    public List<DmvStudyPracQuestion> DmvStudyPracQuestionLists;

    public DmvStudyPracQuestionXml()
    {
    DmvStudyPracQuestionLists = new List<DmvStudyPracQuestion>();
    }
    #endregion
    }
    }
  