using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeTestingSystemWebAPI.ViewModels
{
    public class AnswerVM
    {
        public int? AnswerId { get; set; }
        public bool? IsItWright { get; set; }
        public string AnswerText { get; set; }
        public int? QuestionId { get; set; }

        public bool isWalid()
        {
            if (this.AnswerText != null && IsItWright != null && QuestionId != null)
            {
                return true;
            }
            return false;
        }
    }
}