using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace AspxULTExample.Models
{
    public class DmvStudyPracQuestionOptions
    {
        public DmvStudyPracQuestion Question { get; set; }
        public List<DmvStudyPracQOpt> Options { get; set; }

        public DmvStudyPracQuestionOptions(DmvStudyPracQuestion question, List<DmvStudyPracQOpt> options)
        {
            Question = question;
            Options = options;
        }
    }
}