
using System;
using System.Collections.Generic;
using AspxULTExample.Models;
using AspxULTExample.Models.Interface;

namespace AspxULTExample.BL
{


    public partial class AdminDmvStudyPracQOpt2BL : IBL2<DmvStudyPracQOpt>
    {

        #region AdminDmvStudyPracQOptBL

        private readonly IRepository2<DmvStudyPracQOpt> _context;

        public AdminDmvStudyPracQOpt2BL(IRepository2<DmvStudyPracQOpt> context)
        {
            this._context = context;
        }

        public IEnumerable<DmvStudyPracQOpt> GetAllById(int dmvStudyPracQuestionID)
        {
            return this._context.GetAllById(dmvStudyPracQuestionID);
        }

        #endregion

    }


}
