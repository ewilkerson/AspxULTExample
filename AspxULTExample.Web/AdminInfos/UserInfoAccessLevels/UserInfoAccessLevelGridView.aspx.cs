
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Linq;
    using System.Security.Policy;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    //  using System.Drawing;
    using System.IO;
    using AspxULTExample.BL;
    using AspxULTExample.Models;
    using AspxULTExample.Models.Interface;
    using AspxULTExample.Repository;

    namespace AspxULTExample.Web.AdminInfos.UserInfoAccessLevels
    {
    
    public partial class UserInfoAccessLevelGridView : System.Web.UI.Page
    {

    private IUserInfoAccessLevelBL bl;

    public UserInfoAccessLevelGridView()
    {
    bl = new AdminUserInfoAccessLevelBL(new AdminUserInfoAccessLevelXmlRepository());
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    SessionRedirect();

    if (!IsPostBack)
    {
    BindUserInfo();
    }

    }


    private void BindUserInfo()
    {
    try
    {


    var userInfoAccessLevels = bl.GetUserInfoAccessLevels();

    ResultGridView.DataSource = userInfoAccessLevels;
    ResultGridView.DataBind();
    ResultGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
    ResultGridView.UseAccessibleHeader = true;

    if (ResultGridView.Rows.Count > 0)
    {
    ResultGridView.FooterRow.TableSection = TableRowSection.TableFooter;
    }

    }
    catch (Exception exception)
    {
    Log4ExceptionConnDb.Ex(exception);
    DisplayAlert("Unable to save changes. Try again, and if the problem persists see your system administrator.");

    }
    }

    protected void ResultGridView_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
    if (e.Row.RowType == DataControlRowType.DataRow)
    {

    foreach (LinkButton link in e.Row.Cells[6].Controls.OfType<LinkButton>
    ())
    {
    if (link.CommandName == "Delete")
    {
    link.OnClientClick = "javascript:return DeleteConfirm();";
    }
    }
    }
    }

    protected void ResultGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    ResultGridView.PageIndex = e.NewPageIndex;

    BindUserInfo();

    }


    protected void ResultGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    try
    {
    SessionRedirect();

    int userInfoAccessLevelID = ResultGridView.DataKeys[e.RowIndex].Values[0] == null ? 0 : (int)ResultGridView.DataKeys[e.RowIndex].Values[0];


    if(userInfoAccessLevelID != 0)
    {

    UserInfoAccessLevel userInfoAccessLevel = bl.GetUserInfoAccessLevelById(userInfoAccessLevelID);


    if (bl.DeleteUserInfoAccessLevel(userInfoAccessLevelID, userInfoAccessLevel))
    {
    if (userInfoAccessLevel.ErrID != 0)
    {
    DisplayAlert(userInfoAccessLevel.ErrText);
    }
    }
    else
    {
    DisplayAlert(MsgText(userInfoAccessLevel));    }

    }
    else
    {
    DisplayAlert("userInfoAccessLevelID cannot be zero.");
    }

    BindUserInfo();
    }
    catch (Exception exception)
    {
    Log4ExceptionConnDb.Ex(exception);
    DisplayAlert("Unable to save changes. Try again, and if the problem persists see your system administrator.");

    }
    }

    protected void ResultGridView_RowEditing(object sender, GridViewEditEventArgs e)
    {

    ResultGridView.EditIndex = e.NewEditIndex;

    BindUserInfo();

    }

    protected void ResultGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
    try
    {
    SessionRedirect();

    int userInfoAccessLevelID = ResultGridView.DataKeys[e.RowIndex].Values[0] == null ? 0 : (int)ResultGridView.DataKeys[e.RowIndex].Values[0];
string userInfoAccessLevelName = ((TextBox)ResultGridView.Rows[e.RowIndex].FindControl("txtUserInfoAccessLevelName")).Text;

    int userInfoAccessLevelNum;
    bool successUserInfoAccessLevelNum = int.TryParse(((TextBox)ResultGridView.Rows[e.RowIndex].FindControl("txtUserInfoAccessLevelNum")).Text, out userInfoAccessLevelNum);
    if (!successUserInfoAccessLevelNum)
    {
    userInfoAccessLevelNum = 0;
    }
  
bool userInfoAccessLevelActiveYesNo = ((CheckBox)ResultGridView.Rows[e.RowIndex].FindControl("CheckBoxUserInfoAccessLevelActiveYesNo")).Checked;


    UserInfoAccessLevel userInfoAccessLevel = new UserInfoAccessLevel()
    {
    UserInfoAccessLevelID = userInfoAccessLevelID,
UserInfoAccessLevelName = userInfoAccessLevelName,
UserInfoAccessLevelNum = userInfoAccessLevelNum,
UserInfoAccessLevelActiveYesNo = userInfoAccessLevelActiveYesNo
    };

    ValidationContext context = new ValidationContext(userInfoAccessLevel, serviceProvider: null, items: null);
    List<ValidationResult> results = new List<ValidationResult>();
    bool isValid = Validator.TryValidateObject(userInfoAccessLevel, context, results, false);

    Validate();
    if (Page.IsValid && isValid)
    {

    if (bl.UpdateUserInfoAccessLevel(userInfoAccessLevel))
    {
    if (userInfoAccessLevel.ErrID != 0)
    {
    DisplayAlert(userInfoAccessLevel.ErrText);
    }
    }
    else
    {
    DisplayAlert(MsgText(userInfoAccessLevel));
    }

    ResultGridView.EditIndex = -1;
    BindUserInfo();
    }

    }
    catch (Exception exception)
    {
    DisplayAlert("Unable to save changes. Try again, and if the problem persists see your system administrator.");
    Log4ExceptionConnDb.Ex(exception);

    }

    }

    protected void ResultGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

    ResultGridView.EditIndex = -1;

    BindUserInfo();

    }

    private string SessionName()
    {
    string sessionName = "AspxULTExample_";
    return sessionName;
    }

    private bool SessionAdminBool()
    {
    bool sessionBool = HttpContext.Current.Session != null && (int)HttpContext.Current.Session[SessionName() + "UserInfoAccessLevelID"] != 0 && (bool)HttpContext.Current.Session[SessionName() + "UserInfoActiveYesNo"];
    bool sessionAdminBool = sessionBool && ((int)HttpContext.Current.Session[SessionName() + "UserInfoAccessLevelID"] == (int)EnumUserInfoAccessLevelID.SuperAccessLevelSr || (int)HttpContext.Current.Session[SessionName() + "UserInfoAccessLevelID"] == (int)EnumUserInfoAccessLevelID.SuperAccessLevelJr);

    return sessionAdminBool;
    }

    private void SessionRedirect()
    {
    if (!SessionAdminBool())
    {
    Response.Redirect("~", false);
    }
    }


    protected string MsgText(UserInfoAccessLevel userInfoAccessLevel)
    {

    string msg = string.Empty;

    if (userInfoAccessLevel != null)
    {

    Dictionary<string, string>
    isVal = bl.UserInfoAccessLevelIsValid(userInfoAccessLevel);


    foreach (var kvp in isVal)
    msg += "*\t" + kvp.Value + "\n";

    }
    else
    {
    msg = "UserInfoAccessLevel cannot be null.";
    }

    return msg;
    }


    protected void DisplayAlert(string msg)
    {
    if(!string.IsNullOrWhiteSpace(msg)){
    string msgHtml = ((SiteMaster)Master)?.MsgHtml(msg);
    ((SiteMaster)Master)?.DisplayAlert(msgHtml);
    ModelState.AddModelError("", msgHtml);
    }
    }

    }
  
    }
  