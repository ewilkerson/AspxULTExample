
    using System;
    using System.Collections.Generic;

    namespace AspxULTExample.Models.Interface
    {

    
    public interface IExampleRepository
    {

    #region IExampleRepository

    IEnumerable<Example>GetExamples();

    Example GetExampleById(int exampleID);

    Example InsertExample(Example example);

    Example UpdateExample(Example example);

    Example DeleteExample(int exampleID,Example example);

    #endregion
    }
  

    }
  