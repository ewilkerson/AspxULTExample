
using System;
using System.Collections.Generic;
using AspxULTExample.Models;
using AspxULTExample.Models.Interface;

namespace AspxULTExample.BL
{


    public partial class AdminDmvStudyPracQuestion2BL : IBL3<DmvStudyPracQuestion>
    {

        #region AdminDmvStudyPracQuestion2BL

        private readonly IRepository3<DmvStudyPracQuestion> _context;

        public AdminDmvStudyPracQuestion2BL(IRepository3<DmvStudyPracQuestion> context)
        {
            this._context = context;
        }

        public IEnumerable<DmvStudyPracQuestion> GetAll_Ten()
        {
            return this._context.GetAll_Ten();
        }


        public IEnumerable<DmvStudyPracQuestion> GetAll_Thirty()
        {
            return this._context.GetAll_Thirty();
        }

        #endregion

    }


}
