
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

    namespace AspxULTExample.Web.AdminInfos.UserInfoUserInfoCompanyXrefs
    {
    
    public partial class UserInfoUserInfoCompanyXrefGridView : System.Web.UI.Page
    {

    private IUserInfoUserInfoCompanyXrefBL bl;

    public UserInfoUserInfoCompanyXrefGridView()
    {
    bl = new AdminUserInfoUserInfoCompanyXrefBL(new AdminUserInfoUserInfoCompanyXrefXmlRepository());
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


    var userInfoUserInfoCompanyXrefs = bl.GetUserInfoUserInfoCompanyXrefs();

    ResultGridView.DataSource = userInfoUserInfoCompanyXrefs;
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

    foreach (LinkButton link in e.Row.Cells[7].Controls.OfType<LinkButton>
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

    int userInfoUserInfoCompanyXrefID = ResultGridView.DataKeys[e.RowIndex].Values[0] == null ? 0 : (int)ResultGridView.DataKeys[e.RowIndex].Values[0];


    if(userInfoUserInfoCompanyXrefID != 0)
    {

    UserInfoUserInfoCompanyXref userInfoUserInfoCompanyXref = bl.GetUserInfoUserInfoCompanyXrefById(userInfoUserInfoCompanyXrefID);


    if (bl.DeleteUserInfoUserInfoCompanyXref(userInfoUserInfoCompanyXrefID, userInfoUserInfoCompanyXref))
    {
    if (userInfoUserInfoCompanyXref.ErrID != 0)
    {
    DisplayAlert(userInfoUserInfoCompanyXref.ErrText);
    }
    }
    else
    {
    DisplayAlert(MsgText(userInfoUserInfoCompanyXref));    }

    }
    else
    {
    DisplayAlert("userInfoUserInfoCompanyXrefID cannot be zero.");
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

    int userInfoUserInfoCompanyXrefID = ResultGridView.DataKeys[e.RowIndex].Values[0] == null ? 0 : (int)ResultGridView.DataKeys[e.RowIndex].Values[0];

    int userInfoID;
    bool successUserInfoID = int.TryParse(((TextBox)ResultGridView.Rows[e.RowIndex].FindControl("txtUserInfoID")).Text, out userInfoID);
    if (!successUserInfoID)
    {
    userInfoID = 0;
    }
  

    int userInfoCompanyID;
    bool successUserInfoCompanyID = int.TryParse(((TextBox)ResultGridView.Rows[e.RowIndex].FindControl("txtUserInfoCompanyID")).Text, out userInfoCompanyID);
    if (!successUserInfoCompanyID)
    {
    userInfoCompanyID = 0;
    }
  
bool userInfoUserInfoCompanyXrefEmailAddressActiveYesNo = ((CheckBox)ResultGridView.Rows[e.RowIndex].FindControl("CheckBoxUserInfoUserInfoCompanyXrefEmailAddressActiveYesNo")).Checked;
bool userInfoUserInfoCompanyXrefActiveYesNo = ((CheckBox)ResultGridView.Rows[e.RowIndex].FindControl("CheckBoxUserInfoUserInfoCompanyXrefActiveYesNo")).Checked;


    UserInfoUserInfoCompanyXref userInfoUserInfoCompanyXref = new UserInfoUserInfoCompanyXref()
    {
    UserInfoUserInfoCompanyXrefID = userInfoUserInfoCompanyXrefID,
UserInfoID = userInfoID,
UserInfoCompanyID = userInfoCompanyID,
UserInfoUserInfoCompanyXrefEmailAddressActiveYesNo = userInfoUserInfoCompanyXrefEmailAddressActiveYesNo,
UserInfoUserInfoCompanyXrefActiveYesNo = userInfoUserInfoCompanyXrefActiveYesNo
    };

    ValidationContext context = new ValidationContext(userInfoUserInfoCompanyXref, serviceProvider: null, items: null);
    List<ValidationResult> results = new List<ValidationResult>();
    bool isValid = Validator.TryValidateObject(userInfoUserInfoCompanyXref, context, results, false);

    Validate();
    if (Page.IsValid && isValid)
    {

    if (bl.UpdateUserInfoUserInfoCompanyXref(userInfoUserInfoCompanyXref))
    {
    if (userInfoUserInfoCompanyXref.ErrID != 0)
    {
    DisplayAlert(userInfoUserInfoCompanyXref.ErrText);
    }
    }
    else
    {
    DisplayAlert(MsgText(userInfoUserInfoCompanyXref));
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


    protected string MsgText(UserInfoUserInfoCompanyXref userInfoUserInfoCompanyXref)
    {

    string msg = string.Empty;

    if (userInfoUserInfoCompanyXref != null)
    {

    Dictionary<string, string>
    isVal = bl.UserInfoUserInfoCompanyXrefIsValid(userInfoUserInfoCompanyXref);


    foreach (var kvp in isVal)
    msg += "*\t" + kvp.Value + "\n";

    }
    else
    {
    msg = "UserInfoUserInfoCompanyXref cannot be null.";
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
  