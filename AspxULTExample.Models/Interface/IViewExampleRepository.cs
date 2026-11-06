
    using System;
    using System.Collections.Generic;

    namespace AspxULTExample.Models.Interface
    {

    
    public interface IViewExampleRepository
    {

    #region IViewExampleRepository

    IEnumerable<ViewExample>GetViewExamples(int userInfoID);

    IEnumerable<ExampleApprove> GetViewExampleApprovesById(int exampleID);

    IEnumerable<ExampleLog> GetViewExampleLogsById(int exampleID);

    IEnumerable<UserInfoUserInfoCompanyXref> GetLoadUserInfoUserInfoCompanyXrefsById(int userInfoID);

    ViewExample GetViewExampleById(int exampleID);

    ViewExample InsertViewExample(ViewExample viewExample);

    ViewExample UpdateViewExample(ViewExample viewExample);

    ViewExample SignedUnsignedUpdateViewExample(ViewExample viewExample);

    ViewExample ApproveCompeteRejectRevokeViewExample(ViewExample viewExample, string noteMessage);

    ViewExample DeleteViewExample(int exampleID,ViewExample viewExample);

    #endregion
    }
  

    }
  