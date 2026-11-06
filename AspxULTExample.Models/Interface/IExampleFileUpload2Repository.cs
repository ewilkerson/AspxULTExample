
    using System;
    using System.Collections.Generic;

    namespace AspxULTExample.Models.Interface
    {

    
    public interface IExampleFileUpload2Repository
    {

    #region IExampleFileUpload2Repository

    IEnumerable<ExampleFileUpload2>GetExampleFileUpload2s();

    ExampleFileUpload2 GetExampleFileUpload2ById(int exampleFileUpload2ID);

    ExampleFileUpload2 InsertExampleFileUpload2(ExampleFileUpload2 exampleFileUpload2);

    ExampleFileUpload2 UpdateExampleFileUpload2(ExampleFileUpload2 exampleFileUpload2);

    ExampleFileUpload2 DeleteExampleFileUpload2(int exampleFileUpload2ID,ExampleFileUpload2 exampleFileUpload2);

    #endregion
    }
  

    }
  