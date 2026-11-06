
    using System;
    using System.Web;
    using System.Web.UI;

    namespace AspxULTExample.Web.HomeInfos
    {
    public partial class HomeInfo : Page
    {

    protected void Page_Load(object sender, EventArgs e)
    {
    string sessionName = "AspxULTExample_";
    bool sessionBool = HttpContext.Current.Session != null && (int)HttpContext.Current.Session[sessionName + "UserInfoAccessLevelID"] != 0 && (bool)HttpContext.Current.Session[sessionName + "UserInfoActiveYesNo"];

    if (!sessionBool)
    {
    Response.Redirect("~", false);
    }
    }
    }
    }
  