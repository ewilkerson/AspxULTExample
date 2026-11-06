
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.IO;
using System.Web;
using System.Xml.Serialization;
using System.Linq;
using AspxULTExample.Models;
using AspxULTExample.Models.Interface;

namespace AspxULTExample.Repository
{


    public partial class AdminDmvStudyPracQOptXml2Repository : SerializeDeserializeXmlRepository, IRepository2<DmvStudyPracQOpt>
    {

        #region AdminDmvStudyPracQOptXmlRepository

        private readonly string urlMapPath = HttpContext.Current.Server.MapPath("~");
        private string xmlDmvStudyPracQOpt;

        public AdminDmvStudyPracQOptXml2Repository()
        {

            string xmlFolder = urlMapPath + "\\Xml";
            if (!Directory.Exists(xmlFolder))
                Directory.CreateDirectory(xmlFolder);

            xmlDmvStudyPracQOpt = xmlFolder + "\\DmvStudyPracQOptXml.xml";
            if (!File.Exists(xmlDmvStudyPracQOpt))
            {
                File.WriteAllText(xmlDmvStudyPracQOpt, "<?xml version=\"1.0\" encoding=\"utf-8\"?><DmvStudyPracQOptXml xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ><DmvStudyPracQOptLists></DmvStudyPracQOptLists></DmvStudyPracQOptXml>");
            }


        }

        public IEnumerable<DmvStudyPracQOpt> GetAllById(int dmvStudyPracQuestionID)
        {
            List<DmvStudyPracQOpt> dmvStudyPracQOptLists = new List<DmvStudyPracQOpt>();

            try
            {
                if (dmvStudyPracQuestionID != 0)
                {
                    DmvStudyPracQOptXml dmvStudyPracQOptXml = XmlDeserialize<DmvStudyPracQOptXml>(xmlDmvStudyPracQOpt);
                    dmvStudyPracQOptLists = dmvStudyPracQOptXml.DmvStudyPracQOptLists.Where(a => a.DmvStudyPracQuestionID == dmvStudyPracQuestionID).ToList();
                    dmvStudyPracQOptLists.Sort((u1, u2) => u1.DmvStudyPracQOptID.CompareTo(u2.DmvStudyPracQOptID));
                }
            }
            catch (Exception exception)
            {
                Log4ExceptionConnDb.ExXml(exception);
            }

            return dmvStudyPracQOptLists;
        }

        #endregion
    }


}
