
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


    public partial class AdminDmvStudyPracQuestionXml2Repository : SerializeDeserializeXmlRepository, IRepository3<DmvStudyPracQuestion>
    {

        #region AdminDmvStudyPracQuestionXml2Repository

        private readonly string urlMapPath = HttpContext.Current.Server.MapPath("~");
        private string xmlDmvStudyPracQuestion;

        public AdminDmvStudyPracQuestionXml2Repository()
        {

            string xmlFolder = urlMapPath + "\\Xml";
            if (!Directory.Exists(xmlFolder))
                Directory.CreateDirectory(xmlFolder);

            xmlDmvStudyPracQuestion = xmlFolder + "\\DmvStudyPracQuestionXml.xml";
            if (!File.Exists(xmlDmvStudyPracQuestion))
            {
                File.WriteAllText(xmlDmvStudyPracQuestion, "<?xml version=\"1.0\" encoding=\"utf-8\"?><DmvStudyPracQuestionXml xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ><DmvStudyPracQuestionLists></DmvStudyPracQuestionLists></DmvStudyPracQuestionXml>");
            }


        }

        public IEnumerable<DmvStudyPracQuestion> GetAll_Ten()
        {
            List<DmvStudyPracQuestion> dmvStudyPracQuestionLists = new List<DmvStudyPracQuestion>();

            try
            {
                DmvStudyPracQuestionXml dmvStudyPracQuestionXml = XmlDeserialize<DmvStudyPracQuestionXml>(xmlDmvStudyPracQuestion);
                dmvStudyPracQuestionLists = dmvStudyPracQuestionXml.DmvStudyPracQuestionLists;
                dmvStudyPracQuestionLists.Sort((u1, u2) => u1.DmvStudyPracQuestionID.CompareTo(u2.DmvStudyPracQuestionID));

                List<DmvStudyPracQuestion> dmvStudyPracQuestionTenLists = dmvStudyPracQuestionLists.Where(x => x.DmvStudyPracID == 1).ToList();

                int intCount = 10;
                RandomObject randomize = new RandomObject();
                List<DmvStudyPracQuestion> dmvStudyPracQuestionsRandomizeList =
                    randomize.Randomize<DmvStudyPracQuestion>(dmvStudyPracQuestionTenLists).GetRange(0, intCount);

                dmvStudyPracQuestionLists = dmvStudyPracQuestionsRandomizeList;

            }
            catch (Exception exception)
            {
                Log4ExceptionConnDb.ExXml(exception);
            }

            return dmvStudyPracQuestionLists;
        }

        public IEnumerable<DmvStudyPracQuestion> GetAll_Thirty()
        {
            List<DmvStudyPracQuestion> dmvStudyPracQuestionLists = new List<DmvStudyPracQuestion>();

            try
            {
                DmvStudyPracQuestionXml dmvStudyPracQuestionXml = XmlDeserialize<DmvStudyPracQuestionXml>(xmlDmvStudyPracQuestion);
                dmvStudyPracQuestionLists = dmvStudyPracQuestionXml.DmvStudyPracQuestionLists;
                dmvStudyPracQuestionLists.Sort((u1, u2) => u1.DmvStudyPracQuestionID.CompareTo(u2.DmvStudyPracQuestionID));

                int intCount = 10; //30
                RandomObject randomize = new RandomObject();
                List<DmvStudyPracQuestion> dmvStudyPracQuestionsRandomizeList =
                    randomize.Randomize<DmvStudyPracQuestion>(dmvStudyPracQuestionLists).GetRange(0, intCount);

                dmvStudyPracQuestionLists = dmvStudyPracQuestionsRandomizeList;

            }
            catch (Exception exception)
            {
                Log4ExceptionConnDb.ExXml(exception);
            }

            return dmvStudyPracQuestionLists;
        }


        #endregion
    }


}
