
    using System;
    using System.Collections.Generic;

    namespace AspxULTExample.Models.Interface
    {

    
    public interface IExampleBL
    {

    #region IExampleBL

    IEnumerable<Example>GetExamples();

    Example GetExampleById(int exampleID);

    bool InsertExample(Example example);

    bool UpdateExample(Example example);

    bool DeleteExample(int exampleID,Example example);

    Dictionary<string,string> ExampleIsValid(Example example);

    #endregion
    }
  

    }
  