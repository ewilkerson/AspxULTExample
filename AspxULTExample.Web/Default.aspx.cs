
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AspxULTExample.Models;
using AspxULTExample.Repository;

namespace AspxULTExample.Web
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionRedirect();

            if (!IsPostBack)
            {
                BindUserInfo();
            }

            string user = "Sven\r\nis\r\na\r\nmechanical\r\nengineer\r\nby\r\nday,\r\nand\r\nis\r\nthe\r\nguitarist\r\nin\r\na\r\nmetal\r\nband\r\nat\r\nnight.\r\nHe\r\nis\r\nnewly\r\nmarried\r\nand\r\nlives\r\nwith\r\nhis\r\nwife\r\nand\r\ncat\r\nin\r\nthe\r\nsuburbs\r\nof\r\nMaryland.\r\nHe\r\nplays\r\non\r\nan\r\nice\r\nhockey\r\nteam,\r\nand\r\nreally\r\nlikes\r\nsushi.\r\nHe\r\nis\r\n28\r\nyears\r\nold,\r\nand\r\nlike\r\nother\r\n28\r\nyear\r\nolds\r\nhe\r\nhas\r\na\r\ntendency\r\nto\r\nmulti-­‐task\r\nwhenever\r\nheuses\r\nhis\r\ncomputer.\r\nHis\r\nultimate\r\ngoal\r\nwith\r\nthe\r\nband\r\nis\r\nfor\r\nit\r\nto\r\nbecome\r\nvery\r\npopular\r\nso\r\nhe\r\ncan\r\ngo\r\non\r\nworldwide\r\ntours.\r\nHe\r\noften\r\nmakes\r\npromotional\r\ngraphics\r\nto\r\nsupport\r\nhis\r\nband’s\r\nimage.\r\nHe\r\nhas\r\npretty\r\nhigh\r\ntechnical\r\nabilities,\r\nsince\r\nhe’s\r\nbeen\r\nusing\r\ncomputers\r\nsince\r\nhe\r\nwas\r\na\r\nkid,\r\nalways\r\ntrying\r\nto\r\nfind\r\nbetter\r\nways\r\nof\r\naccomplishing\r\ntasks.\r\nHe\r\nmakes\r\nflyers,\r\nposters,\r\nCD\r\nartwork,\r\nimages\r\nfor\r\nthe\r\nband\r\nwebsite,\r\nand\r\nedits\r\nband\r\nphotos.\r\nHe\r\nhas\r\nused\r\nGimp\r\na\r\nfew\r\ntimes\r\npreviously,\r\nwhen\r\nhe\r\ndid\r\nnot\r\nhave\r\naccess\r\nto\r\nPhotoshop.\r\nHe\r\nthought\r\nit\r\nwas\r\nclunky\r\nand\r\nnot\r\nan\r\neffective\r\nway\r\nto\r\nmanipulate\r\nimages.\r\nI\r\nchose\r\nto\r\ninterview\r\nSven\r\nbecause\r\nhe\r\nhas\r\nenough\r\nexperience\r\nwith\r\nthe\r\napplication\r\nto\r\ngive\r\nme\r\nfeedback\r\non\r\nhow\r\nit\r\nshould\r\nbe\r\nimproved,\r\nand\r\nany\r\nmajor\r\ndrawbacks\r\nit\r\nhas.\r\nOur\r\nsingle\r\ninterview\r\nsession\r\nwas\r\ndone\r\non\r\nSeptember\r\n30th,\r\n2012,\r\nin\r\nhis\r\nhome,\r\nwith\r\na\r\ngoal\r\nto\r\nfind\r\nproblems\r\nand\r\nimprove\r\nusability\r\nof\r\nthe\r\napplication.\r\nThe\r\nsession\r\nlasted\r\na\r\nbit\r\nover\r\n45\r\nminutes\r\nand\r\nwas\r\ncompleted\r\non\r\nhis\r\nDell\r\nLatitude\r\nWindows\r\n7\r\nlaptop\r\nin\r\nhis\r\nliving\r\nroom,\r\nsince\r\nthe\r\nlaptop\r\nis\r\nportable\r\nand\r\nhe\r\nuses\r\nit\r\nall\r\nover\r\nthe\r\nhouse,\r\noften\r\nwhile\r\nwatching\r\nTV.";
            string user1 = user.Replace("\r\n", " ");
            Console.WriteLine(user1);
            Console.WriteLine();
        }

        private void BindUserInfo()
        {
            DropDownListTemperatureUnit.DataValueField = "Value";
            DropDownListTemperatureUnit.DataTextField = "Text";
            DropDownListTemperatureUnit.DataBind();

            foreach (int tu in Enum.GetValues(typeof(EnumTemperatureUnit)))
            {
                if (tu != 0)
                {
                    ListItem item = new ListItem(Enum.GetName(typeof(EnumTemperatureUnit), tu), tu.ToString());
                    DropDownListTemperatureUnit.Items.Add(item);
                }
            }
        }

        protected void ConvertTemperatureCFK(Object sender, EventArgs e)
        {
            try
            {
                SessionRedirect();

                double temperature;
                bool successPrice = double.TryParse(TextBoxTemperature.Text, out temperature);
                if (!successPrice)
                {
                    temperature = double.MinValue;
                }

                int temperatureUnitID;
                bool successTemperatureUnitID = int.TryParse(DropDownListTemperatureUnit.SelectedValue, out temperatureUnitID);
                if (!successTemperatureUnitID)
                {
                    temperatureUnitID = 0;
                }

                ConvertTemperature convertTemperature = new ConvertTemperature()
                {
                    Temperature = temperature,
                    TemperatureUnitEnum = (EnumTemperatureUnit)temperatureUnitID
                };

                LabelResult2.Text = string.Empty;

                ValidationContext context = new ValidationContext(convertTemperature, serviceProvider: null, items: null);
                List<ValidationResult> results = new List<ValidationResult>();
                bool isValid = Validator.TryValidateObject(convertTemperature, context, results, false);

                Validate();
                if (Page.IsValid && isValid)
                {
                    if (convertTemperature.TemperatureUnitEnum == EnumTemperatureUnit.Celsius)
                    {
                        convertTemperature.FahrenheitKelvinTemperature();
                    }
                    else if (convertTemperature.TemperatureUnitEnum == EnumTemperatureUnit.Fahrenheit)
                    {
                        convertTemperature.CelsiusKelvinTemperature();
                    }
                    else if (convertTemperature.TemperatureUnitEnum == EnumTemperatureUnit.Kelvin)
                    {
                        convertTemperature.CelsiusFahrenheitTemperature();
                    }

                    if (convertTemperature.ErrID != 0)
                    {
                        DisplayAlert(convertTemperature.ErrText);
                    }
                    else
                    {
                        LabelResult2.Text = convertTemperature.Results;
                    }

                }

            }
            catch (Exception exception)
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

        private bool SessionBool()
        {
            bool sessionBool = HttpContext.Current.Session != null && (int)HttpContext.Current.Session[SessionName() + "UserInfoAccessLevelID"] != 0 && (bool)HttpContext.Current.Session[SessionName() + "UserInfoActiveYesNo"];
            return sessionBool;
        }

        private void SessionRedirect()
        {
            if (!SessionBool())
            {
                Response.Redirect("AccessDenied.aspx", false);
            }

        }

        protected void DisplayAlert(string msg)
        {
            if (!string.IsNullOrWhiteSpace(msg))
            {
                string msgHtml = ((SiteMaster)Master)?.MsgHtml(msg);
                ((SiteMaster)Master)?.DisplayAlert(msgHtml);
                ModelState.AddModelError("", msgHtml);
            }
        }


    }
}
