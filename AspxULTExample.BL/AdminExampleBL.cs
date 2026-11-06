
using System;
using System.Collections.Generic;
using AspxULTExample.Models;
using AspxULTExample.Models.Interface;

namespace AspxULTExample.BL
{


    public partial class AdminExampleBL : IExampleBL
    {
        #region AdminExampleBL

        private readonly IExampleRepository _context;

        public AdminExampleBL(IExampleRepository context)
        {
            this._context = context;
        }

        public IEnumerable<Example>
        GetExamples()
        {
            return this._context.GetExamples();
        }

        public Example GetExampleById(int exampleID)
        {
            return this._context.GetExampleById(exampleID);
        }

        public bool InsertExample(Example example)
        {

            Dictionary<string, string> isVal = ExampleIsValid(example);
            bool val = isVal.Count == 0;
            if (val)
            {
                this._context.InsertExample(example);
            }
            return val;
        }

        public bool UpdateExample(Example example)
        {
            Dictionary<string, string> isVal = ExampleIsValid(example);
            bool val = isVal.Count == 0;

            if (val)
            {
                this._context.UpdateExample(example);
            }
            return val;
        }

        public bool DeleteExample(int exampleID, Example example)
        {

            bool val = exampleID != 0;

            if (val)
            {
                this._context.DeleteExample(exampleID, example);
            }
            return val;
        }

        public Dictionary<string, string> ExampleIsValid(Example example)
        {
            Dictionary<string, string> isVal = new Dictionary<string, string>();


            if (example != null)
            {

                if (example.ExampleID == 0)
                {
                    isVal.Add("ExampleID", "Example ID cannot be zero.");
                }


                if (example.ExampleUserInfoStatusID == 0)
                {
                    isVal.Add("ExampleUserInfoStatusID", "Example User Info Status ID cannot be zero.");
                }


                if (example.ExampleUserInfoCompanyID == 0)
                {
                    isVal.Add("ExampleUserInfoCompanyID", "Example User Info Company ID cannot be zero.");
                }


                if (string.IsNullOrWhiteSpace(example.Title))
                {
                    isVal.Add("Title", "Title cannot be null or empty or only have white space.");
                }


                if (example.Release == 0)
                {
                    isVal.Add("Release", "Release cannot be zero.");
                }



                if (string.IsNullOrWhiteSpace(example.Genre))
                {
                    isVal.Add("Genre", "Genre cannot be null or empty or only have white space.");
                }


                if (example.Price == 0)
                {
                    isVal.Add("Price", "Price cannot be zero.");
                }





                if (string.IsNullOrWhiteSpace(example.Message))
                {
                    isVal.Add("Message", "Message cannot be null or empty or only have white space.");
                }


                if (string.IsNullOrWhiteSpace(example.Message2))
                {
                    isVal.Add("Message2", "Message2 cannot be null or empty or only have white space.");
                }


                if (string.IsNullOrWhiteSpace(example.PhoneNumber))
                {
                    isVal.Add("PhoneNumber", "Phone Number cannot be null or empty or only have white space.");
                }


                if (string.IsNullOrWhiteSpace(example.EmailAddress))
                {
                    isVal.Add("EmailAddress", "Email Address cannot be null or empty or only have white space.");
                }


                if (string.IsNullOrWhiteSpace(example.CreditCard))
                {
                    isVal.Add("CreditCard", "Credit Card cannot be null or empty or only have white space.");
                }


                if (string.IsNullOrWhiteSpace(example.Password))
                {
                    isVal.Add("Password", "Password cannot be null or empty or only have white space.");
                }


                if (string.IsNullOrWhiteSpace(example.Url))
                {
                    isVal.Add("Url", "Url cannot be null or empty or only have white space.");
                }



            }
            else
            {
                isVal.Add("example", "example cannot be null.");
            }


            return isVal;
        }

        #endregion

    }


}
