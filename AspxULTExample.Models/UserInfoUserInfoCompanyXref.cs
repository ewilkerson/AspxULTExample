
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace AspxULTExample.Models
{
    public partial class UserInfoUserInfoCompanyXref : BaseObject
    {
        #region Properties
        private int _userInfoUserInfoCompanyXrefID;
        /// <summary>
        ///UserInfoUserInfoCompanyXrefID
        /// </summary>
        [ScaffoldColumn(false)]
        [DisplayName("User Info User Info Company Xref ID")]

        public int UserInfoUserInfoCompanyXrefID
        {
            get { return _userInfoUserInfoCompanyXrefID; }
            set { _userInfoUserInfoCompanyXrefID = value; }
        }

        private int _userInfoID;
        /// <summary>
        ///UserInfoID
        /// </summary>
        [Required(ErrorMessage = "This User Info ID is required.")]
        [DisplayName("User Info ID")]
        [Range(1, int.MaxValue, ErrorMessage = "User Info ID cannot be zero.")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public int UserInfoID
        {
            get { return _userInfoID; }
            set { _userInfoID = value; }
        }

        private int _userInfoCompanyID;
        /// <summary>
        ///UserInfoCompanyID
        /// </summary>
        [Required(ErrorMessage = "This User Info Company ID is required.")]
        [DisplayName("User Info Company ID")]
        [Range(1, int.MaxValue, ErrorMessage = "User Info Company ID cannot be zero.")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public int UserInfoCompanyID
        {
            get { return _userInfoCompanyID; }
            set { _userInfoCompanyID = value; }
        }

        private bool _userInfoUserInfoCompanyXrefEmailAddressActiveYesNo;
        /// <summary>
        ///UserInfoUserInfoCompanyXrefEmailAddressActiveYesNo
        /// </summary>
        [Required(ErrorMessage = "This User Info User Info Company Xref Email Address Active Yes No is required.")]
        [DisplayName("User Info User Info Company Xref Email Address Active Yes No")]

        public bool UserInfoUserInfoCompanyXrefEmailAddressActiveYesNo
        {
            get { return _userInfoUserInfoCompanyXrefEmailAddressActiveYesNo; }
            set { _userInfoUserInfoCompanyXrefEmailAddressActiveYesNo = value; }
        }

        private bool _userInfoUserInfoCompanyXrefActiveYesNo;
        /// <summary>
        ///UserInfoUserInfoCompanyXrefActiveYesNo
        /// </summary>
        [Required(ErrorMessage = "This User Info User Info Company Xref Active Yes No is required.")]
        [DisplayName("User Info User Info Company Xref Active Yes No")]

        public bool UserInfoUserInfoCompanyXrefActiveYesNo
        {
            get { return _userInfoUserInfoCompanyXrefActiveYesNo; }
            set { _userInfoUserInfoCompanyXrefActiveYesNo = value; }
        }

        private string _userInfoCompanyName;
        /// <summary>
        ///UserInfoCompanyName
        /// </summary>
        [DisplayName("User Info Company Name")]
        [DataType(DataType.MultilineText)]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "User Info Company Name cannot be null or empty or only have white space or 200 characters maximum.")]
        public string UserInfoCompanyName
        {
            get { return _userInfoCompanyName; }
            set { _userInfoCompanyName = value; }
        }

        #endregion

        #region Constants

        #endregion

        #region Instance Methods
        public UserInfoUserInfoCompanyXref() : base()
        {
            _userInfoUserInfoCompanyXrefID = 0;
            _userInfoID = 0;
            _userInfoCompanyID = 0;
            _userInfoUserInfoCompanyXrefEmailAddressActiveYesNo = false;
            _userInfoUserInfoCompanyXrefActiveYesNo = false;

        }
        #endregion

    }
}
