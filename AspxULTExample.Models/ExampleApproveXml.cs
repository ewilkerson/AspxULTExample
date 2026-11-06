
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    namespace AspxULTExample.Models
    {
    [XmlRoot("ExampleApproveXml")]
    public partial class ExampleApproveXml
    {

    #region ExampleApprovesXml

    [XmlArray("ExampleApproveLists")]
    [XmlArrayItem("ExampleApprove")]
    public List<ExampleApprove> ExampleApproveLists;

    public ExampleApproveXml()
    {
    ExampleApproveLists = new List<ExampleApprove>();
    }
    #endregion
    }
    }
  