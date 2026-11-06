
    using System;
    using System.Collections.Generic;
    using AspxULTExample.Models;
    using AspxULTExample.Models.Interface;

    namespace AspxULTExample.BL
    {

    
    public partial class AdminDmvStudyPractBL:IBL<DmvStudyPract>
    {

    #region AdminDmvStudyPractBL

    private readonly IRepository<DmvStudyPract> _context;

    public AdminDmvStudyPractBL(IRepository<DmvStudyPract> context)
    {
    this._context = context;
    }

    public IEnumerable<DmvStudyPract>
    GetAll()
    {
    return this._context.GetAll();
    }

    public DmvStudyPract GetById(int dmvStudyPractID)
    {
    return this._context.GetById(dmvStudyPractID);
    }

    public bool Insert(DmvStudyPract dmvStudyPract)
    {

    Dictionary<string, string> isVal = IsValid(dmvStudyPract);
    bool val = isVal.Count == 0;
    if(val)
    {
    this._context.Insert(dmvStudyPract);
    }
    return val;
    }

    public bool Update(DmvStudyPract dmvStudyPract)
    {
    Dictionary<string, string> isVal = IsValid(dmvStudyPract);
    bool val = isVal.Count == 0;

    if(val)
    {
    this._context.Update(dmvStudyPract);
    }
    return val;
    }

    public bool Delete(int dmvStudyPractID, DmvStudyPract dmvStudyPract)
    {

    bool val = dmvStudyPractID != 0;

    if(val)
    {
    this._context.Delete(dmvStudyPractID, dmvStudyPract);
    }
    return val;
    }

    public Dictionary<string,string>IsValid(DmvStudyPract dmvStudyPract)
    {
    Dictionary<string,string> isVal = new Dictionary<string, string>();

    
    if (dmvStudyPract != null){
    
    if (dmvStudyPract.DmvStudyPractID == 0)
    {
    isVal.Add("DmvStudyPractID", "Dmv Study Pract ID cannot be zero.");
    }
  

    if (dmvStudyPract.DmvStudyPractNum == 0)
    {
    isVal.Add("DmvStudyPractNum", "Dmv Study Pract Num cannot be zero.");
    }
  

    if (string.IsNullOrWhiteSpace(dmvStudyPract.DmvStudyPractTitle))
    {
    isVal.Add("DmvStudyPractTitle", "Dmv Study Pract Title cannot be null or empty or only have white space.");
    }
  


    } else
    {
    isVal.Add("dmvStudyPract", "dmvStudyPract cannot be null.");
    }
  

    return isVal;
    }

    #endregion

    }
  

    }
  