
using System;
using System.Collections.Generic;
using AspxULTExample.Models;
using AspxULTExample.Models.Interface;

namespace AspxULTExample.BL
{


    public partial class AdminDmvStudyPracQuestionBL : IBL<DmvStudyPracQuestion>
    {

        #region AdminDmvStudyPracQuestionBL

        private readonly IRepository<DmvStudyPracQuestion> _context;

        public AdminDmvStudyPracQuestionBL(IRepository<DmvStudyPracQuestion> context)
        {
            this._context = context;
        }

        public IEnumerable<DmvStudyPracQuestion>
        GetAll()
        {
            return this._context.GetAll();
        }

        public DmvStudyPracQuestion GetById(int dmvStudyPracQuestionID)
        {
            return this._context.GetById(dmvStudyPracQuestionID);
        }

        public bool Insert(DmvStudyPracQuestion dmvStudyPracQuestion)
        {

            Dictionary<string, string> isVal = IsValid(dmvStudyPracQuestion);
            bool val = isVal.Count == 0;
            if (val)
            {
                this._context.Insert(dmvStudyPracQuestion);
            }
            return val;
        }

        public bool Update(DmvStudyPracQuestion dmvStudyPracQuestion)
        {
            Dictionary<string, string> isVal = IsValid(dmvStudyPracQuestion);
            bool val = isVal.Count == 0;

            if (val)
            {
                this._context.Update(dmvStudyPracQuestion);
            }
            return val;
        }

        public bool Delete(int dmvStudyPracQuestionID, DmvStudyPracQuestion dmvStudyPracQuestion)
        {

            bool val = dmvStudyPracQuestionID != 0;

            if (val)
            {
                this._context.Delete(dmvStudyPracQuestionID, dmvStudyPracQuestion);
            }
            return val;
        }

        public Dictionary<string, string> IsValid(DmvStudyPracQuestion dmvStudyPracQuestion)
        {
            Dictionary<string, string> isVal = new Dictionary<string, string>();


            if (dmvStudyPracQuestion != null)
            {

                if (dmvStudyPracQuestion.DmvStudyPracQuestionID == 0)
                {
                    isVal.Add("DmvStudyPracQuestionID", "Dmv Study Prac Question ID cannot be zero.");
                }


                if (dmvStudyPracQuestion.DmvStudyPracID == 0)
                {
                    isVal.Add("DmvStudyPracID", "Dmv Study Prac ID cannot be zero.");
                }


                if (string.IsNullOrWhiteSpace(dmvStudyPracQuestion.DmvStudyPracQuestionText))
                {
                    isVal.Add("DmvStudyPracQuestionText", "Dmv Study Prac Question Text cannot be null or empty or only have white space.");
                }


                if (string.IsNullOrWhiteSpace(dmvStudyPracQuestion.DmvStudyPracQuestionAnswerText))
                {
                    isVal.Add("DmvStudyPracQuestionAnswerText", "Dmv Study Prac Question Answer Text cannot be null or empty or only have white space.");
                }




            }
            else
            {
                isVal.Add("dmvStudyPracQuestion", "dmvStudyPracQuestion cannot be null.");
            }


            return isVal;
        }

        #endregion

    }


}
