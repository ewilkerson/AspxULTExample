
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    namespace AspxULTExample.Models
    {
    [XmlRoot("UserInfoCountriesXml")]
    public partial class UserInfoCountriesXml
    {

    #region UserInfoCountriessXml

    [XmlArray("UserInfoCountriesLists")]
    [XmlArrayItem("UserInfoCountries")]
    public List<UserInfoCountries> UserInfoCountriesLists;

    public UserInfoCountriesXml()
    {
    UserInfoCountriesLists = new List<UserInfoCountries>();
    }
    #endregion
    }
    }
  