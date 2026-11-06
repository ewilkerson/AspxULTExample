
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    namespace AspxULTExample.Models
    {
    [XmlRoot("UserInfoStatusXml")]
    public partial class UserInfoStatusXml
    {

    #region UserInfoStatussXml

    [XmlArray("UserInfoStatusLists")]
    [XmlArrayItem("UserInfoStatus")]
    public List<UserInfoStatus> UserInfoStatusLists;

    public UserInfoStatusXml()
    {
    UserInfoStatusLists = new List<UserInfoStatus>();
    }
    #endregion
    }
    }
  