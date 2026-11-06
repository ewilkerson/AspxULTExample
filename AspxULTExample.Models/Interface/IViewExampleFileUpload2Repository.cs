
using System;
using System.Collections.Generic;

namespace AspxULTExample.Models.Interface
{


    public interface IViewExampleFileUpload2Repository
    {

        #region IViewExampleFileUpload2Repository

        IEnumerable<ViewExampleFileUpload2> GetViewExampleFileUpload2s();

        ViewExampleFileUpload2 GetViewExampleFileUpload2ById(int exampleFileUpload2ID);

        ViewExampleFileUpload2 InsertViewExampleFileUpload2(ViewExampleFileUpload2 viewExampleFileUpload2);

        ViewExampleFileUpload2 UpdateViewExampleFileUpload2(ViewExampleFileUpload2 viewExampleFileUpload2);

        ViewExampleFileUpload2 DeleteViewExampleFileUpload2(int exampleFileUpload2ID, ViewExampleFileUpload2 viewExampleFileUpload2);

        #endregion
    }


}
