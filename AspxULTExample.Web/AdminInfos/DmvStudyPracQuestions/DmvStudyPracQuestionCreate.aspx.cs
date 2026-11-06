
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

    namespace AspxULTExample.Web.AdminInfos.DmvStudyPracQuestions
    {
    
    public partial class DmvStudyPracQuestionCreate : System.Web.UI.Page
    {

    private IBL<DmvStudyPracQuestion> bl;

    public DmvStudyPracQuestionCreate()
    {
    bl = new AdminDmvStudyPracQuestionBL(new AdminDmvStudyPracQuestionXmlRepository());
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    SessionRedirect();
    }

    protected void Submit_Create(Object sender, EventArgs e)
    {
    try
    {
    SessionRedirect();

    
    int dmvStudyPracID;
    bool successDmvStudyPracID = int.TryParse(TextBoxDmvStudyPracID.Text, out dmvStudyPracID);
    if (!successDmvStudyPracID)
    {
    dmvStudyPracID = 0;
    }
  
string dmvStudyPracQuestionText = TextBoxDmvStudyPracQuestionText.Text;
string dmvStudyPracQuestionAnswerText = TextBoxDmvStudyPracQuestionAnswerText.Text;
bool dmvStudyPracQuestionPicsYesNo = CheckBoxDmvStudyPracQuestionPicsYesNo.Checked;
bool dmvStudyPracQuestionActiveYesNo = CheckBoxDmvStudyPracQuestionActiveYesNo.Checked;


    DmvStudyPracQuestion dmvStudyPracQuestion = new DmvStudyPracQuestion()
    {
    DmvStudyPracQuestionID = 1,
DmvStudyPracID = dmvStudyPracID,
DmvStudyPracQuestionText = dmvStudyPracQuestionText,
DmvStudyPracQuestionAnswerText = dmvStudyPracQuestionAnswerText,
DmvStudyPracQuestionPicsYesNo = dmvStudyPracQuestionPicsYesNo,
DmvStudyPracQuestionActiveYesNo = dmvStudyPracQuestionActiveYesNo
    };

    ValidationContext context = new ValidationContext(dmvStudyPracQuestion, serviceProvider: null, items: null);
    List<ValidationResult> results = new List<ValidationResult>();
    bool isValid = Validator.TryValidateObject(dmvStudyPracQuestion, context, results, false);

    Validate();
    if (Page.IsValid && isValid)
    {

    if (bl.Insert(dmvStudyPracQuestion))
    {
    if (dmvStudyPracQuestion.ErrID != 0)
    {
    DisplayAlert(dmvStudyPracQuestion.ErrText);
    }
    else
    {
    Response.Redirect("../DmvStudyPracQuestions/DmvStudyPracQuestionGridView.aspx",false);
    }

    }
    else
    {
    DisplayAlert(MsgText(dmvStudyPracQuestion));
    }

    }
    }
    catch (DataException exception)
    {
    DisplayAlert("Unable to save changes. Try again, and if the problem persists see your system administrator.");
    Log4ExceptionConnDb.Ex(exception);
    }

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

    protected string MsgText(DmvStudyPracQuestion dmvStudyPracQuestion)
    {
    string msg = string.Empty;

    if (dmvStudyPracQuestion != null)
    {

    Dictionary<string, string>
    isVal = bl.IsValid(dmvStudyPracQuestion);


    foreach (var kvp in isVal)
    msg += "*\t" + kvp.Value + "\n";

    }
    else
    {
    msg = "DmvStudyPracQuestion cannot be null.";
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
  