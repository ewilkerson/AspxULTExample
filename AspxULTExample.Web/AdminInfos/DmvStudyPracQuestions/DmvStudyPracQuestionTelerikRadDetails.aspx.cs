
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
    
    public partial class DmvStudyPracQuestionTelerikRadDetails : System.Web.UI.Page
    {

    private IBL<DmvStudyPracQuestion> bl;

    public DmvStudyPracQuestionTelerikRadDetails()
    {
    bl = new AdminDmvStudyPracQuestionBL(new AdminDmvStudyPracQuestionXmlRepository());
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    SessionRedirect();


    if (!IsPostBack)
    {
    
    string rawDmvStudyPracQuestionID = Request.QueryString["id"];
    int dmvStudyPracQuestionID;
    bool successDmvStudyPracQuestionID = int.TryParse(rawDmvStudyPracQuestionID, out dmvStudyPracQuestionID);
    if (!successDmvStudyPracQuestionID)
    {
    dmvStudyPracQuestionID = 0;
    }
  


    if (dmvStudyPracQuestionID != 0)
    {

    DmvStudyPracQuestion dmvStudyPracQuestion = bl.GetById(dmvStudyPracQuestionID);
    
    HiddenField_DmvStudyPracQuestionID.Value = dmvStudyPracQuestion.DmvStudyPracQuestionID.ToString();
    LabelDisplayForDmvStudyPracQuestionID.Text = dmvStudyPracQuestion.DmvStudyPracQuestionID.ToString();
  

    LabelDisplayForDmvStudyPracID.Text = dmvStudyPracQuestion.DmvStudyPracID.ToString();
  

    LabelDisplayForDmvStudyPracQuestionText.Text = dmvStudyPracQuestion.DmvStudyPracQuestionText.ToString();
  

    LabelDisplayForDmvStudyPracQuestionAnswerText.Text = dmvStudyPracQuestion.DmvStudyPracQuestionAnswerText.ToString();
  

    LabelDisplayForDmvStudyPracQuestionPicsYesNo.Text = dmvStudyPracQuestion.DmvStudyPracQuestionPicsYesNo.ToString();
  

    LabelDisplayForDmvStudyPracQuestionActiveYesNo.Text = dmvStudyPracQuestion.DmvStudyPracQuestionActiveYesNo.ToString();
  

    }
    else
    {
    DisplayAlert("dmvStudyPracQuestionID cannot be zero.");
    }

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
  