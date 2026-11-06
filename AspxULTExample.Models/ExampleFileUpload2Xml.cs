
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    namespace AspxULTExample.Models
    {
    [XmlRoot("ExampleFileUpload2Xml")]
    public partial class ExampleFileUpload2Xml
    {

    #region ExampleFileUpload2sXml

    [XmlArray("ExampleFileUpload2Lists")]
    [XmlArrayItem("ExampleFileUpload2")]
    public List<ExampleFileUpload2> ExampleFileUpload2Lists;

    public ExampleFileUpload2Xml()
    {
    ExampleFileUpload2Lists = new List<ExampleFileUpload2>();
    }
    #endregion
    }
    }
  