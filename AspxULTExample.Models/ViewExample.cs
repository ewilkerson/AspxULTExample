
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    namespace AspxULTExample.Models
    {
    public partial class ViewExample : BaseObject
    {
    #region Properties
    private int _exampleID;
/// <summary>
///ExampleID
/// </summary>
[ScaffoldColumn(false)]
[DisplayName("Example ID")]

public int ExampleID {
get {return _exampleID;}
set{ _exampleID = value;}
}

private int _exampleUserInfoStatusID;
/// <summary>
///ExampleUserInfoStatusID
/// </summary>
[Required(ErrorMessage = "This Example User Info Status ID is required.")]
[DisplayName("Example User Info Status ID")]
[Range(1, int.MaxValue, ErrorMessage="Example User Info Status ID cannot be zero.")]
[DisplayFormat(DataFormatString = "{0:d}")]
public int ExampleUserInfoStatusID {
get {return _exampleUserInfoStatusID;}
set{ _exampleUserInfoStatusID = value;}
}

private int _exampleUserInfoCompanyID;
/// <summary>
///ExampleUserInfoCompanyID
/// </summary>
[Required(ErrorMessage = "This Example User Info Company ID is required.")]
[DisplayName("Example User Info Company ID")]
[Range(1, int.MaxValue, ErrorMessage="Example User Info Company ID cannot be zero.")]
[DisplayFormat(DataFormatString = "{0:d}")]
public int ExampleUserInfoCompanyID {
get {return _exampleUserInfoCompanyID;}
set{ _exampleUserInfoCompanyID = value;}
}

private string _title;
/// <summary>
///Title
/// </summary>
[Required(ErrorMessage = "This Title is required.")]
[DisplayName("Title")]
[DataType(DataType.Text)]
[StringLength(50, MinimumLength = 1, ErrorMessage="Title cannot be null or empty or only have white space or 50 characters maximum.")]
public string Title {
get {return _title;}
set{ _title = value;}
}

private int _release;
/// <summary>
///Release
/// </summary>
[Required(ErrorMessage = "This Release is required.")]
[DisplayName("Release")]
[Range(1, int.MaxValue, ErrorMessage="Release cannot be zero.")]
[DisplayFormat(DataFormatString = "{0:d}")]
public int Release {
get {return _release;}
set{ _release = value;}
}

private DateTime _releaseDateTime;
/// <summary>
///ReleaseDateTime
/// </summary>
[Required(ErrorMessage = "This Release Date Time is required.")]
[DisplayName("Release Date Time")]
[DataType(DataType.DateTime)]
[DisplayFormat(DataFormatString = "{0:M/d/yyyy HH:mm:ss}")]
public DateTime ReleaseDateTime {
get {return _releaseDateTime;}
set{ _releaseDateTime = value;}
}

private string _genre;
/// <summary>
///Genre
/// </summary>
[Required(ErrorMessage = "This Genre is required.")]
[DisplayName("Genre")]
[DataType(DataType.Text)]
[StringLength(1, MinimumLength = 1, ErrorMessage="Genre cannot be null or empty or only have white space or 1 characters maximum.")]
public string Genre {
get {return _genre;}
set{ _genre = value;}
}

private decimal _price;
/// <summary>
///Price
/// </summary>
[Required(ErrorMessage = "This Price is required.")]
[DisplayName("Price")]
[Range(.01, double.MaxValue, ErrorMessage="Price cannot be zero.")]
[DisplayFormat(DataFormatString = "{0:f}")]
public decimal Price {
get {return _price;}
set{ _price = value;}
}

private bool _priceYesNo;
/// <summary>
///PriceYesNo
/// </summary>
[Required(ErrorMessage = "This Price Yes No is required.")]
[DisplayName("Price Yes No")]

public bool PriceYesNo {
get {return _priceYesNo;}
set{ _priceYesNo = value;}
}

private DateTime _releaseDate;
/// <summary>
///ReleaseDate
/// </summary>
[Required(ErrorMessage = "This Release Date is required.")]
[DisplayName("Release Date")]
[DataType(DataType.Date)]
[DisplayFormat(DataFormatString = "{0:M/d/yyyy}")]
public DateTime ReleaseDate {
get {return _releaseDate;}
set{ _releaseDate = value;}
}

private TimeSpan _releaseTime;
/// <summary>
///ReleaseTime
/// </summary>
[Required(ErrorMessage = "This Release Time is required.")]
[DisplayName("Release Time")]
[DataType("Time")]
[DisplayFormat(DataFormatString = "{0:HH\\:mm\\:ss}")]
[XmlElement(typeof(XmlTimeSpan))]
public TimeSpan ReleaseTime {
get {return _releaseTime;}
set{ _releaseTime = value;}
}

private string _message;
/// <summary>
///Message
/// </summary>
[Required(ErrorMessage = "This Message is required.")]
[DisplayName("Message")]
[DataType(DataType.MultilineText)]
[StringLength(4000, MinimumLength = 1, ErrorMessage="Message cannot be null or empty or only have white space or 4000 characters maximum.")]
public string Message {
get {return _message;}
set{ _message = value;}
}

private string _message2;
/// <summary>
///Message2
/// </summary>
[Required(ErrorMessage = "This Message2 is required.")]
[DisplayName("Message2")]
[DataType(DataType.MultilineText)]
[StringLength(8000, MinimumLength = 1, ErrorMessage="Message2 cannot be null or empty or only have white space or 8000 characters maximum.")]
public string Message2 {
get {return _message2;}
set{ _message2 = value;}
}

private string _phoneNumber;
/// <summary>
///PhoneNumber
/// </summary>
[Required(ErrorMessage = "This Phone Number is required.")]
[DisplayName("Phone Number")]
[DataType(DataType.PhoneNumber)]
[Phone]
[RegularExpression(@"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$", ErrorMessage="Phone Number cannot be 100 characters maximum.")]
[StringLength(100, MinimumLength = 1, ErrorMessage="Phone Number cannot be null or empty or only have white space or 100 characters maximum.")]
public string PhoneNumber {
get {return _phoneNumber;}
set{ _phoneNumber = value;}
}

private string _emailAddress;
/// <summary>
///EmailAddress
/// </summary>
[Required(ErrorMessage = "This Email Address is required.")]
[DisplayName("Email Address")]
[DataType(DataType.EmailAddress)]
[EmailAddress]
[RegularExpression(@"^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{{|}}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$", ErrorMessage="Email Address cannot be 100 characters maximum.")]
[StringLength(100, MinimumLength = 1, ErrorMessage="Email Address cannot be null or empty or only have white space or 100 characters maximum.")]
public string EmailAddress {
get {return _emailAddress;}
set{ _emailAddress = value;}
}

private string _creditCard;
/// <summary>
///CreditCard
/// </summary>
[Required(ErrorMessage = "This Credit Card is required.")]
[DisplayName("Credit Card")]
[DataType(DataType.CreditCard)]
[RegularExpression(@"^(?:(4[0-9]{12}(?:[0-9]{3})?)|(5[1-5][0-9]{14})|(6(?:011|5[0-9]{2})[0-9]{12})|(3[47][0-9]{13})|(3(?:0[0-5]|[68][0-9])[0-9]{11})|((?:2131|1800|35[0-9]{3})[0-9]{11}))$", ErrorMessage="Credit Card cannot be 100 characters maximum.")]
[StringLength(100, MinimumLength = 1, ErrorMessage="Credit Card cannot be null or empty or only have white space or 100 characters maximum.")]
public string CreditCard {
get {return _creditCard;}
set{ _creditCard = value;}
}

private string _password;
/// <summary>
///Password
/// </summary>
[Required(ErrorMessage = "This Password is required.")]
[DisplayName("Password")]
[DataType(DataType.Password)]
[RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{10,100}$", ErrorMessage="Password cannot be 100 characters maximum.")]
[StringLength(100, MinimumLength = 1, ErrorMessage="Password cannot be null or empty or only have white space or 100 characters maximum.")]
public string Password {
get {return _password;}
set{ _password = value;}
}

private string _url;
/// <summary>
///Url
/// </summary>
[Required(ErrorMessage = "This Url is required.")]
[DisplayName("Url")]
[DataType(DataType.Url)]
[Url]
[RegularExpression(@"^(http|ftp|https)://[\w-]+(\.[\w-]+)+([\w.,@?^=%&:/~+#-]*[\w@?^=%&/~+#-])?$", ErrorMessage="Url cannot be 100 characters maximum.")]
[StringLength(100, MinimumLength = 1, ErrorMessage="Url cannot be null or empty or only have white space or 100 characters maximum.")]
public string Url {
get {return _url;}
set{ _url = value;}
}

private bool _exampleActiveYesNo;
/// <summary>
///ExampleActiveYesNo
/// </summary>
[Required(ErrorMessage = "This Example Active Yes No is required.")]
[DisplayName("Example Active Yes No")]

public bool ExampleActiveYesNo {
get {return _exampleActiveYesNo;}
set{ _exampleActiveYesNo = value;}
}

private string _userInfoCompanyName;
/// <summary>
///UserInfoCompanyName
/// </summary>

[DisplayName("User Info Company Name")]
[DataType(DataType.MultilineText)]
[StringLength(200, MinimumLength = 1, ErrorMessage="User Info Company Name cannot be null or empty or only have white space or 200 characters maximum.")]
public string UserInfoCompanyName {
get {return _userInfoCompanyName;}
set{ _userInfoCompanyName = value;}
}

private string _userInfoStatusName;
/// <summary>
///UserInfoStatusName
/// </summary>

[DisplayName("User Info Status Name")]
[DataType(DataType.Text)]
[StringLength(50, MinimumLength = 1, ErrorMessage="User Info Status Name cannot be null or empty or only have white space or 50 characters maximum.")]
public string UserInfoStatusName {
get {return _userInfoStatusName;}
set{ _userInfoStatusName = value;}
}


    #endregion

    #region Constants
    
    #endregion

    #region Instance Methods
    public ViewExample():base()
    {
    _exampleID = 0;
_exampleUserInfoStatusID = 0;
_exampleUserInfoCompanyID = 0;
_title = string.Empty;
_release = 0;
_releaseDateTime = DateTime.Now;
_genre = string.Empty;
_price = 0.0M;
_priceYesNo = false;
_releaseDate = DateTime.Now.Date;
_releaseTime = TimeSpan.Zero;
_message = string.Empty;
_message2 = string.Empty;
_phoneNumber = string.Empty;
_emailAddress = string.Empty;
_creditCard = string.Empty;
_password = string.Empty;
_url = string.Empty;
_exampleActiveYesNo = false;
_userInfoCompanyName = string.Empty;
_userInfoStatusName = string.Empty;

    }
    #endregion

    }
    }
  