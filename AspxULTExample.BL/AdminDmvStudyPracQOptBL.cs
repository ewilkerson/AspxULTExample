
    using System;
    using System.Collections.Generic;
    using AspxULTExample.Models;
    using AspxULTExample.Models.Interface;

    namespace AspxULTExample.BL
    {

    
    public partial class AdminDmvStudyPracQOptBL:IBL<DmvStudyPracQOpt>
    {

    #region AdminDmvStudyPracQOptBL

    private readonly IRepository<DmvStudyPracQOpt> _context;

    public AdminDmvStudyPracQOptBL(IRepository<DmvStudyPracQOpt> context)
    {
    this._context = context;
    }

    public IEnumerable<DmvStudyPracQOpt>
    GetAll()
    {
    return this._context.GetAll();
    }

    public DmvStudyPracQOpt GetById(int dmvStudyPracQOptID)
    {
    return this._context.GetById(dmvStudyPracQOptID);
    }

    public bool Insert(DmvStudyPracQOpt dmvStudyPracQOpt)
    {

    Dictionary<string, string> isVal = IsValid(dmvStudyPracQOpt);
    bool val = isVal.Count == 0;
    if(val)
    {
    this._context.Insert(dmvStudyPracQOpt);
    }
    return val;
    }

    public bool Update(DmvStudyPracQOpt dmvStudyPracQOpt)
    {
    Dictionary<string, string> isVal = IsValid(dmvStudyPracQOpt);
    bool val = isVal.Count == 0;

    if(val)
    {
    this._context.Update(dmvStudyPracQOpt);
    }
    return val;
    }

    public bool Delete(int dmvStudyPracQOptID, DmvStudyPracQOpt dmvStudyPracQOpt)
    {

    bool val = dmvStudyPracQOptID != 0;

    if(val)
    {
    this._context.Delete(dmvStudyPracQOptID, dmvStudyPracQOpt);
    }
    return val;
    }

    public Dictionary<string,string>IsValid(DmvStudyPracQOpt dmvStudyPracQOpt)
    {
    Dictionary<string,string> isVal = new Dictionary<string, string>();

    
    if (dmvStudyPracQOpt != null){
    
    if (dmvStudyPracQOpt.DmvStudyPracQOptID == 0)
    {
    isVal.Add("DmvStudyPracQOptID", "Dmv Study Prac Q Opt ID cannot be zero.");
    }
  

    if (dmvStudyPracQOpt.DmvStudyPracQuestionID == 0)
    {
    isVal.Add("DmvStudyPracQuestionID", "Dmv Study Prac Question ID cannot be zero.");
    }
  

    if (string.IsNullOrWhiteSpace(dmvStudyPracQOpt.DmvStudyPracQOptText))
    {
    isVal.Add("DmvStudyPracQOptText", "Dmv Study Prac Q Opt Text cannot be null or empty or only have white space.");
    }
  



    } else
    {
    isVal.Add("dmvStudyPracQOpt", "dmvStudyPracQOpt cannot be null.");
    }
  

    return isVal;
    }

    #endregion

    }
  

    }
  