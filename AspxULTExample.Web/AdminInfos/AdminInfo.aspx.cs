
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using AspxULTExample.Models;

    namespace AspxULTExample.Web.AdminInfos
    {
    public partial class AdminInfo : System.Web.UI.Page
    {
    protected void Page_Load(object sender, EventArgs e)
    {
    string sessionName = "AspxULTExample_";
    bool sessionBool = HttpContext.Current.Session != null && (int)HttpContext.Current.Session[sessionName + "UserInfoAccessLevelID"] != 0 && (bool)HttpContext.Current.Session[sessionName + "UserInfoActiveYesNo"];
    bool sessionAdminBool = sessionBool && ((int)HttpContext.Current.Session[sessionName + "UserInfoAccessLevelID"] == (int)EnumUserInfoAccessLevelID.SuperAccessLevelSr || (int)HttpContext.Current.Session[sessionName + "UserInfoAccessLevelID"] == (int)EnumUserInfoAccessLevelID.SuperAccessLevelJr);

    if (!sessionAdminBool)
    {
    Response.Redirect("~");
    }

    }
    }
    }
  