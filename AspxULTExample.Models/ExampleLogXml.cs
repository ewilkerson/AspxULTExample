
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    namespace AspxULTExample.Models
    {
    [XmlRoot("ExampleLogXml")]
    public partial class ExampleLogXml
    {

    #region ExampleLogsXml

    [XmlArray("ExampleLogLists")]
    [XmlArrayItem("ExampleLog")]
    public List<ExampleLog> ExampleLogLists;

    public ExampleLogXml()
    {
    ExampleLogLists = new List<ExampleLog>();
    }
    #endregion
    }
    }
  