
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    namespace AspxULTExample.Web
    {
    public partial class Site2Master : MasterPage
    {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void DisplayAlert(string msg)
    {
    if (!string.IsNullOrWhiteSpace(msg))
    {
    string da = "<script>displayAlert(\"" + msg + "\")</script>";
    ScriptManager.RegisterStartupScript(this, this.GetType(), "DisplayAlert", da, false);
    }
    }

    public string MsgHtml(string msg)
    {
    string msgHtml = string.Empty;

    if (!string.IsNullOrWhiteSpace(msg))
    {

    //<p></p>
    //\r\n - <br/>
    // - &nbsp;
    //& - &amp;
    //\" - &quot;
    //' - &apos;

    msgHtml = msg.Replace("&", "&amp;");
    msgHtml = msgHtml.Replace("\n", "<br>");
    msgHtml = msgHtml.Replace("\t", " ");
    msgHtml = msgHtml.Replace("\"", "&quot;");
    msgHtml = msgHtml.Replace("'", "&apos;");

    msgHtml = "<p>" + msgHtml + "</p>";
    }

    return msgHtml;
    }

    }
    }
  