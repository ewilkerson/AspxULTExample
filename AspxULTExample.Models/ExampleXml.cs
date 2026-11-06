
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    namespace AspxULTExample.Models
    {
    [XmlRoot("ExampleXml")]
    public partial class ExampleXml
    {

    #region ExamplesXml

    [XmlArray("ExampleLists")]
    [XmlArrayItem("Example")]
    public List<Example> ExampleLists;

    public ExampleXml()
    {
    ExampleLists = new List<Example>();
    }
    #endregion
    }
    }
  