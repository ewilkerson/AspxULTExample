
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    namespace AspxULTExample.Models
    {
    [XmlRoot("UserInfoAccessLevelXml")]
    public partial class UserInfoAccessLevelXml
    {

    #region UserInfoAccessLevelsXml

    [XmlArray("UserInfoAccessLevelLists")]
    [XmlArrayItem("UserInfoAccessLevel")]
    public List<UserInfoAccessLevel> UserInfoAccessLevelLists;

    public UserInfoAccessLevelXml()
    {
    UserInfoAccessLevelLists = new List<UserInfoAccessLevel>();
    }
    #endregion
    }
    }
  