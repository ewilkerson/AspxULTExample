
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    namespace AspxULTExample.Models
    {
    [XmlRoot("UserInfoUserInfoAccessLevelXrefXml")]
    public partial class UserInfoUserInfoAccessLevelXrefXml
    {

    #region UserInfoUserInfoAccessLevelXrefsXml

    [XmlArray("UserInfoUserInfoAccessLevelXrefLists")]
    [XmlArrayItem("UserInfoUserInfoAccessLevelXref")]
    public List<UserInfoUserInfoAccessLevelXref> UserInfoUserInfoAccessLevelXrefLists;

    public UserInfoUserInfoAccessLevelXrefXml()
    {
    UserInfoUserInfoAccessLevelXrefLists = new List<UserInfoUserInfoAccessLevelXref>();
    }
    #endregion
    }
    }
  