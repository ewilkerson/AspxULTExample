
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    namespace AspxULTExample.Models
    {
    [XmlRoot("UserInfoUserInfoCompanyXrefXml")]
    public partial class UserInfoUserInfoCompanyXrefXml
    {

    #region UserInfoUserInfoCompanyXrefsXml

    [XmlArray("UserInfoUserInfoCompanyXrefLists")]
    [XmlArrayItem("UserInfoUserInfoCompanyXref")]
    public List<UserInfoUserInfoCompanyXref> UserInfoUserInfoCompanyXrefLists;

    public UserInfoUserInfoCompanyXrefXml()
    {
    UserInfoUserInfoCompanyXrefLists = new List<UserInfoUserInfoCompanyXref>();
    }
    #endregion
    }
    }
  