
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

    namespace AspxULTExample.Web.AdminInfos.UserInfoUserInfoAccessLevelXrefs
    {
    
    public partial class UserInfoUserInfoAccessLevelXrefGridView : System.Web.UI.Page
    {

    private IUserInfoUserInfoAccessLevelXrefBL bl;

    public UserInfoUserInfoAccessLevelXrefGridView()
    {
    bl = new AdminUserInfoUserInfoAccessLevelXrefBL(new AdminUserInfoUserInfoAccessLevelXrefXmlRepository());
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


    var userInfoUserInfoAccessLevelXrefs = bl.GetUserInfoUserInfoAccessLevelXrefs();

    ResultGridView.DataSource = userInfoUserInfoAccessLevelXrefs;
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

    int userInfoUserInfoAccessLevelXrefID = ResultGridView.DataKeys[e.RowIndex].Values[0] == null ? 0 : (int)ResultGridView.DataKeys[e.RowIndex].Values[0];


    if(userInfoUserInfoAccessLevelXrefID != 0)
    {

    UserInfoUserInfoAccessLevelXref userInfoUserInfoAccessLevelXref = bl.GetUserInfoUserInfoAccessLevelXrefById(userInfoUserInfoAccessLevelXrefID);


    if (bl.DeleteUserInfoUserInfoAccessLevelXref(userInfoUserInfoAccessLevelXrefID, userInfoUserInfoAccessLevelXref))
    {
    if (userInfoUserInfoAccessLevelXref.ErrID != 0)
    {
    DisplayAlert(userInfoUserInfoAccessLevelXref.ErrText);
    }
    }
    else
    {
    DisplayAlert(MsgText(userInfoUserInfoAccessLevelXref));    }

    }
    else
    {
    DisplayAlert("userInfoUserInfoAccessLevelXrefID cannot be zero.");
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

    int userInfoUserInfoAccessLevelXrefID = ResultGridView.DataKeys[e.RowIndex].Values[0] == null ? 0 : (int)ResultGridView.DataKeys[e.RowIndex].Values[0];

    int userInfoID;
    bool successUserInfoID = int.TryParse(((TextBox)ResultGridView.Rows[e.RowIndex].FindControl("txtUserInfoID")).Text, out userInfoID);
    if (!successUserInfoID)
    {
    userInfoID = 0;
    }
  

    int userInfoAccessLevelID;
    bool successUserInfoAccessLevelID = int.TryParse(((TextBox)ResultGridView.Rows[e.RowIndex].FindControl("txtUserInfoAccessLevelID")).Text, out userInfoAccessLevelID);
    if (!successUserInfoAccessLevelID)
    {
    userInfoAccessLevelID = 0;
    }
  
bool userInfoUserInfoAccessLevelXrefActiveYesNo = ((CheckBox)ResultGridView.Rows[e.RowIndex].FindControl("CheckBoxUserInfoUserInfoAccessLevelXrefActiveYesNo")).Checked;


    UserInfoUserInfoAccessLevelXref userInfoUserInfoAccessLevelXref = new UserInfoUserInfoAccessLevelXref()
    {
    UserInfoUserInfoAccessLevelXrefID = userInfoUserInfoAccessLevelXrefID,
UserInfoID = userInfoID,
UserInfoAccessLevelID = userInfoAccessLevelID,
UserInfoUserInfoAccessLevelXrefActiveYesNo = userInfoUserInfoAccessLevelXrefActiveYesNo
    };

    ValidationContext context = new ValidationContext(userInfoUserInfoAccessLevelXref, serviceProvider: null, items: null);
    List<ValidationResult> results = new List<ValidationResult>();
    bool isValid = Validator.TryValidateObject(userInfoUserInfoAccessLevelXref, context, results, false);

    Validate();
    if (Page.IsValid && isValid)
    {

    if (bl.UpdateUserInfoUserInfoAccessLevelXref(userInfoUserInfoAccessLevelXref))
    {
    if (userInfoUserInfoAccessLevelXref.ErrID != 0)
    {
    DisplayAlert(userInfoUserInfoAccessLevelXref.ErrText);
    }
    }
    else
    {
    DisplayAlert(MsgText(userInfoUserInfoAccessLevelXref));
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


    protected string MsgText(UserInfoUserInfoAccessLevelXref userInfoUserInfoAccessLevelXref)
    {

    string msg = string.Empty;

    if (userInfoUserInfoAccessLevelXref != null)
    {

    Dictionary<string, string>
    isVal = bl.UserInfoUserInfoAccessLevelXrefIsValid(userInfoUserInfoAccessLevelXref);


    foreach (var kvp in isVal)
    msg += "*\t" + kvp.Value + "\n";

    }
    else
    {
    msg = "UserInfoUserInfoAccessLevelXref cannot be null.";
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
  