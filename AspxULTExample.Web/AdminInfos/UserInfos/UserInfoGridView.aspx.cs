
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

    namespace AspxULTExample.Web.AdminInfos.UserInfos
    {
    
    public partial class UserInfoGridView : System.Web.UI.Page
    {

    private IUserInfoBL bl;

    public UserInfoGridView()
    {
    bl = new AdminUserInfoBL(new AdminUserInfoXmlRepository());
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


    var userInfos = bl.GetUserInfos();

    ResultGridView.DataSource = userInfos;
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

    foreach (LinkButton link in e.Row.Cells[9].Controls.OfType<LinkButton>
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

    int userInfoID = ResultGridView.DataKeys[e.RowIndex].Values[0] == null ? 0 : (int)ResultGridView.DataKeys[e.RowIndex].Values[0];


    if(userInfoID != 0)
    {

    UserInfo userInfo = bl.GetUserInfoById(userInfoID);


    if (bl.DeleteUserInfo(userInfoID, userInfo))
    {
    if (userInfo.ErrID != 0)
    {
    DisplayAlert(userInfo.ErrText);
    }
    }
    else
    {
    DisplayAlert(MsgText(userInfo));    }

    }
    else
    {
    DisplayAlert("userInfoID cannot be zero.");
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

    int userInfoID = ResultGridView.DataKeys[e.RowIndex].Values[0] == null ? 0 : (int)ResultGridView.DataKeys[e.RowIndex].Values[0];
string userInfoUserIdentityName = ((TextBox)ResultGridView.Rows[e.RowIndex].FindControl("txtUserInfoUserIdentityName")).Text;
string userInfoUserName = ((TextBox)ResultGridView.Rows[e.RowIndex].FindControl("txtUserInfoUserName")).Text;
string userInfoFullName = ((TextBox)ResultGridView.Rows[e.RowIndex].FindControl("txtUserInfoFullName")).Text;
string userInfoEmailAddress = ((TextBox)ResultGridView.Rows[e.RowIndex].FindControl("txtUserInfoEmailAddress")).Text;
string userInfoJobTitle = ((TextBox)ResultGridView.Rows[e.RowIndex].FindControl("txtUserInfoJobTitle")).Text;
bool userInfoActiveYesNo = ((CheckBox)ResultGridView.Rows[e.RowIndex].FindControl("CheckBoxUserInfoActiveYesNo")).Checked;


    UserInfo userInfo = new UserInfo()
    {
    UserInfoID = userInfoID,
UserInfoUserIdentityName = userInfoUserIdentityName,
UserInfoUserName = userInfoUserName,
UserInfoFullName = userInfoFullName,
UserInfoEmailAddress = userInfoEmailAddress,
UserInfoJobTitle = userInfoJobTitle,
UserInfoActiveYesNo = userInfoActiveYesNo
    };

    ValidationContext context = new ValidationContext(userInfo, serviceProvider: null, items: null);
    List<ValidationResult> results = new List<ValidationResult>();
    bool isValid = Validator.TryValidateObject(userInfo, context, results, false);

    Validate();
    if (Page.IsValid && isValid)
    {

    if (bl.UpdateUserInfo(userInfo))
    {
    if (userInfo.ErrID != 0)
    {
    DisplayAlert(userInfo.ErrText);
    }
    }
    else
    {
    DisplayAlert(MsgText(userInfo));
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


    protected string MsgText(UserInfo userInfo)
    {

    string msg = string.Empty;

    if (userInfo != null)
    {

    Dictionary<string, string>
    isVal = bl.UserInfoIsValid(userInfo);


    foreach (var kvp in isVal)
    msg += "*\t" + kvp.Value + "\n";

    }
    else
    {
    msg = "UserInfo cannot be null.";
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
  