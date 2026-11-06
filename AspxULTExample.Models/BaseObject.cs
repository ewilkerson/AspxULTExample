
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Xml.Serialization;

namespace AspxULTExample.Models
{

    public abstract class BaseObject
    {
        private int _errId;

        [XmlIgnore]
        public int ErrID
        {
            get
            {
                return _errId;
            }

            set
            {
                _errId = value;
            }

        }

        private string _errText;

        [XmlIgnore]
        public string ErrText
        {
            get
            {
                return _errText;
            }

            set
            {
                _errText = value;
            }
        }
        private bool _deleteTrueFalse;

        [XmlIgnore]
        public bool DeleteTrueFalse
        {
            get
            {
                return _deleteTrueFalse;
            }

            set
            {
                _deleteTrueFalse = value;
            }
        }

        private string _noteMessage;

        [XmlIgnore]
        public string NoteMessage
        {
            get
            {
                return _noteMessage;
            }

            set
            {
                _noteMessage = value;
            }
        }

        private int _userInfoID;

        [XmlIgnore]
        public int _UserInfoID
        {
            get { return _userInfoID; }
            set { _userInfoID = value; }
        }

        private string _userInfoJobTitle;

        [XmlIgnore]
        public string _UserInfoJobTitle
        {
            get { return _userInfoJobTitle; }
            set { _userInfoJobTitle = value; }
        }


        private DateTime _createDate;

        public DateTime CreateDate
        {
            get
            {
                return _createDate;
            }

            set
            {
                _createDate = value;
            }
        }


        private string _createUserName;

        public string CreateUserName
        {
            get
            {
                return _createUserName;
            }

            set
            {
                _createUserName = value;
            }
        }


        private string _createFullName;

        public string CreateFullName
        {
            get
            {
                return _createFullName;
            }

            set
            {
                _createFullName = value;
            }
        }


        private DateTime _updateDate;

        public DateTime UpdateDate
        {
            get
            {
                return _updateDate;
            }

            set
            {
                _updateDate = value;
            }
        }


        private string _updateUserName;

        public string UpdateUserName
        {
            get
            {
                return _updateUserName;
            }

            set
            {
                _updateUserName = value;
            }
        }


        private string _updateFullName;

        public string UpdateFullName
        {
            get
            {
                return _updateFullName;
            }

            set
            {
                _updateFullName = value;
            }
        }


        public BaseObject()
        {
            DateTime updateDate = DateTime.Now;

            _errId = 0;
            _errText = string.Empty;
            _noteMessage = string.Empty;
            _userInfoID = 0;
            _userInfoJobTitle = string.Empty;
            _createDate = updateDate;
            _createFullName = string.Empty;
            _createUserName = string.Empty;
            _updateDate = updateDate;
            _updateFullName = string.Empty;
            _updateUserName = string.Empty;
            _deleteTrueFalse = false;

            if (HttpContext.Current != null && HttpContext.Current.Session != null && HttpContext.Current.Session.Count != 0)
            {
                string sessionName = "AspxULTExample_";
                string updateFullName = HttpContext.Current.Session[sessionName + "UserInfoFullName"].ToString();
                string updateUserName = HttpContext.Current.Session[sessionName + "UserInfoUserName"].ToString();

                _createFullName = updateFullName;
                _createUserName = updateUserName;
                _updateFullName = updateFullName;
                _updateUserName = updateUserName;

                _userInfoID = (int)HttpContext.Current.Session[sessionName + "UserInfoID"];
                _userInfoJobTitle = HttpContext.Current.Session[sessionName + "UserInfoJobTitle"].ToString();

            }

        }
    }

}


