
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    namespace AspxULTExample.Models
    {
    [XmlRoot("UserInfoXml")]
    public partial class UserInfoXml
    {

    #region UserInfosXml

    [XmlArray("UserInfoLists")]
    [XmlArrayItem("UserInfo")]
    public List<UserInfo> UserInfoLists;

    public UserInfoXml()
    {
    UserInfoLists = new List<UserInfo>();
    }
    #endregion
    }
    }
  