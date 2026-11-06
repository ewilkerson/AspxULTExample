
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace AspxULTExample.Models
{
    public partial class DmvStudyPracQuestion : BaseObject
    {
        #region Properties
        private int _dmvStudyPracQuestionID;
        /// <summary>
        ///DmvStudyPracQuestionID
        /// </summary>
        [ScaffoldColumn(false)]
        [DisplayName("Dmv Study Prac Question ID")]

        public int DmvStudyPracQuestionID
        {
            get { return _dmvStudyPracQuestionID; }
            set { _dmvStudyPracQuestionID = value; }
        }

        private int _dmvStudyPracID;
        /// <summary>
        ///DmvStudyPracID
        /// </summary>
        [Required(ErrorMessage = "This Dmv Study Prac ID is required.")]
        [DisplayName("Dmv Study Prac ID")]
        [Range(1, int.MaxValue, ErrorMessage = "Dmv Study Prac ID cannot be zero.")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public int DmvStudyPracID
        {
            get { return _dmvStudyPracID; }
            set { _dmvStudyPracID = value; }
        }

        private string _dmvStudyPracQuestionText;
        /// <summary>
        ///DmvStudyPracQuestionText
        /// </summary>
        [Required(ErrorMessage = "This Dmv Study Prac Question Text is required.")]
        [DisplayName("Dmv Study Prac Question Text")]
        [DataType(DataType.MultilineText)]
        [StringLength(500, MinimumLength = 1, ErrorMessage = "Dmv Study Prac Question Text cannot be null or empty or only have white space or 500 characters maximum.")]
        public string DmvStudyPracQuestionText
        {
            get { return _dmvStudyPracQuestionText; }
            set { _dmvStudyPracQuestionText = value; }
        }

        private string _dmvStudyPracQuestionAnswerText;
        /// <summary>
        ///DmvStudyPracQuestionAnswerText
        /// </summary>
        [Required(ErrorMessage = "This Dmv Study Prac Question Answer Text is required.")]
        [DisplayName("Dmv Study Prac Question Answer Text")]
        [DataType(DataType.MultilineText)]
        [StringLength(500, MinimumLength = 0, ErrorMessage = "Dmv Study Prac Question Answer Text cannot be 500 characters maximum.")]
        public string DmvStudyPracQuestionAnswerText
        {
            get { return _dmvStudyPracQuestionAnswerText; }
            set { _dmvStudyPracQuestionAnswerText = value; }
        }

        private bool _dmvStudyPracQuestionPicsYesNo;
        /// <summary>
        ///DmvStudyPracQuestionPicsYesNo
        /// </summary>
        [Required(ErrorMessage = "This Dmv Study Prac Question Pics Yes No is required.")]
        [DisplayName("Dmv Study Prac Question Pics Yes No")]

        public bool DmvStudyPracQuestionPicsYesNo
        {
            get { return _dmvStudyPracQuestionPicsYesNo; }
            set { _dmvStudyPracQuestionPicsYesNo = value; }
        }

        private bool _dmvStudyPracQuestionActiveYesNo;
        /// <summary>
        ///DmvStudyPracQuestionActiveYesNo
        /// </summary>
        [Required(ErrorMessage = "This Dmv Study Prac Question Active Yes No is required.")]
        [DisplayName("Dmv Study Prac Question Active Yes No")]

        public bool DmvStudyPracQuestionActiveYesNo
        {
            get { return _dmvStudyPracQuestionActiveYesNo; }
            set { _dmvStudyPracQuestionActiveYesNo = value; }
        }


        #endregion

        #region Constants

        #endregion

        #region Instance Methods
        public DmvStudyPracQuestion() : base()
        {
            _dmvStudyPracQuestionID = 0;
            _dmvStudyPracID = 0;
            _dmvStudyPracQuestionText = string.Empty;
            _dmvStudyPracQuestionAnswerText = string.Empty;
            _dmvStudyPracQuestionPicsYesNo = false;
            _dmvStudyPracQuestionActiveYesNo = false;

        }
        #endregion

    }
}
