
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    namespace AspxULTExample.Models
    {
    [XmlRoot("UserInfoCompanyXml")]
    public partial class UserInfoCompanyXml
    {

    #region UserInfoCompanysXml

    [XmlArray("UserInfoCompanyLists")]
    [XmlArrayItem("UserInfoCompany")]
    public List<UserInfoCompany> UserInfoCompanyLists;

    public UserInfoCompanyXml()
    {
    UserInfoCompanyLists = new List<UserInfoCompany>();
    }
    #endregion
    }
    }
  