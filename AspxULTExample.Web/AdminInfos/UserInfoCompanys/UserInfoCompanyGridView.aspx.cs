
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

    namespace AspxULTExample.Web.AdminInfos.UserInfoCompanys
    {
    
    public partial class UserInfoCompanyGridView : System.Web.UI.Page
    {

    private IUserInfoCompanyBL bl;

    public UserInfoCompanyGridView()
    {
    bl = new AdminUserInfoCompanyBL(new AdminUserInfoCompanyXmlRepository());
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


    var userInfoCompanys = bl.GetUserInfoCompanys();

    ResultGridView.DataSource = userInfoCompanys;
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

    foreach (LinkButton link in e.Row.Cells[13].Controls.OfType<LinkButton>
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

    int userInfoCompanyID = ResultGridView.DataKeys[e.RowIndex].Values[0] == null ? 0 : (int)ResultGridView.DataKeys[e.RowIndex].Values[0];


    if(userInfoCompanyID != 0)
    {

    UserInfoCompany userInfoCompany = bl.GetUserInfoCompanyById(userInfoCompanyID);


    if (bl.DeleteUserInfoCompany(userInfoCompanyID, userInfoCompany))
    {
    if (userInfoCompany.ErrID != 0)
    {
    DisplayAlert(userInfoCompany.ErrText);
    }
    }
    else
    {
    DisplayAlert(MsgText(userInfoCompany));    }

    }
    else
    {
    DisplayAlert("userInfoCompanyID cannot be zero.");
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

    int userInfoCompanyID = ResultGridView.DataKeys[e.RowIndex].Values[0] == null ? 0 : (int)ResultGridView.DataKeys[e.RowIndex].Values[0];
string userInfoCompanyEIN = ((TextBox)ResultGridView.Rows[e.RowIndex].FindControl("txtUserInfoCompanyEIN")).Text;
string userInfoCompanyName = ((TextBox)ResultGridView.Rows[e.RowIndex].FindControl("txtUserInfoCompanyName")).Text;
string userInfoCompanyAddress1 = ((TextBox)ResultGridView.Rows[e.RowIndex].FindControl("txtUserInfoCompanyAddress1")).Text;
string userInfoCompanyAddress2 = ((TextBox)ResultGridView.Rows[e.RowIndex].FindControl("txtUserInfoCompanyAddress2")).Text;
string userInfoCompanyCityStateZip = ((TextBox)ResultGridView.Rows[e.RowIndex].FindControl("txtUserInfoCompanyCityStateZip")).Text;
string userInfoCompanyTelephone = ((TextBox)ResultGridView.Rows[e.RowIndex].FindControl("txtUserInfoCompanyTelephone")).Text;
string userInfoCompanyEmailAddress = ((TextBox)ResultGridView.Rows[e.RowIndex].FindControl("txtUserInfoCompanyEmailAddress")).Text;
string userCompanyWebsiteAddress = ((TextBox)ResultGridView.Rows[e.RowIndex].FindControl("txtUserCompanyWebsiteAddress")).Text;

    int userInfoCountriesID;
    bool successUserInfoCountriesID = int.TryParse(((TextBox)ResultGridView.Rows[e.RowIndex].FindControl("txtUserInfoCountriesID")).Text, out userInfoCountriesID);
    if (!successUserInfoCountriesID)
    {
    userInfoCountriesID = 0;
    }
  
bool userInfoCompanyActiveYesNo = ((CheckBox)ResultGridView.Rows[e.RowIndex].FindControl("CheckBoxUserInfoCompanyActiveYesNo")).Checked;


    UserInfoCompany userInfoCompany = new UserInfoCompany()
    {
    UserInfoCompanyID = userInfoCompanyID,
UserInfoCompanyEIN = userInfoCompanyEIN,
UserInfoCompanyName = userInfoCompanyName,
UserInfoCompanyAddress1 = userInfoCompanyAddress1,
UserInfoCompanyAddress2 = userInfoCompanyAddress2,
UserInfoCompanyCityStateZip = userInfoCompanyCityStateZip,
UserInfoCompanyTelephone = userInfoCompanyTelephone,
UserInfoCompanyEmailAddress = userInfoCompanyEmailAddress,
UserCompanyWebsiteAddress = userCompanyWebsiteAddress,
UserInfoCountriesID = userInfoCountriesID,
UserInfoCompanyActiveYesNo = userInfoCompanyActiveYesNo
    };

    ValidationContext context = new ValidationContext(userInfoCompany, serviceProvider: null, items: null);
    List<ValidationResult> results = new List<ValidationResult>();
    bool isValid = Validator.TryValidateObject(userInfoCompany, context, results, false);

    Validate();
    if (Page.IsValid && isValid)
    {

    if (bl.UpdateUserInfoCompany(userInfoCompany))
    {
    if (userInfoCompany.ErrID != 0)
    {
    DisplayAlert(userInfoCompany.ErrText);
    }
    }
    else
    {
    DisplayAlert(MsgText(userInfoCompany));
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


    protected string MsgText(UserInfoCompany userInfoCompany)
    {

    string msg = string.Empty;

    if (userInfoCompany != null)
    {

    Dictionary<string, string>
    isVal = bl.UserInfoCompanyIsValid(userInfoCompany);


    foreach (var kvp in isVal)
    msg += "*\t" + kvp.Value + "\n";

    }
    else
    {
    msg = "UserInfoCompany cannot be null.";
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
  