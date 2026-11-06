
    using System;
    using System.Collections.Generic;

    namespace AspxULTExample.Models.Interface
    {

    
    public interface IViewExampleXmlRepository
    {

    ExampleApprove InsertViewExampleApprove(int exampleID);
    ExampleApprove DeleteViewExampleApprove(int exampleID);
    ExampleLog InsertViewExampleLogXml(int exampleID, string noteMessage);

    }
  

    }
  