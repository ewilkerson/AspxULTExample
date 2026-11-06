
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;

    namespace AspxULTExample.Models
    {
    public class ContactUs : BaseObject
    {
    #region Properties
    private string _fullName;
    /// 
      ///FullName
      ///
    
    [Required(ErrorMessage = "This Full Name is required.")]
    [DisplayName("Full Name")]
    [DataType(DataType.Text)]
    [StringLength(50, MinimumLength = 1, ErrorMessage = "Full Name cannot be null or empty or only have white space or 50 characters maximum.")]
    public string FullName
    {
    get { return _fullName; }
    set { _fullName = value; }
    }

    private string _emailAddress;
    /// 
      ///EmailAddress
      ///
    
    [Required(ErrorMessage = "This Email Address is required.")]
    [DisplayName("Email Address")]
    [DataType(DataType.EmailAddress)]
    [EmailAddress]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "Email Address cannot be null or empty or only have white space or 100 characters maximum.")]
    public string EmailAddress
    {
    get { return _emailAddress; }
    set { _emailAddress = value; }
    }

    private string _comments;
    /// 
      ///Comments
      ///
    
    [Required(ErrorMessage = "This Comments is required.")]
    [DisplayName("Comments")]
    [DataType(DataType.MultilineText)]
    [StringLength(8000, MinimumLength = 1, ErrorMessage = "Comments cannot be null or empty or only have white space or 8000 characters maximum.")]
    public string Comments
    {
    get { return _comments; }
    set { _comments = value; }
    }
    #endregion

    #region Constants

    #endregion

    #region Instance Methods
    public ContactUs() : base()
    {
    _fullName = string.Empty;
    _emailAddress = string.Empty;
    _comments = string.Empty;
    }
    #endregion


    }
    }
  