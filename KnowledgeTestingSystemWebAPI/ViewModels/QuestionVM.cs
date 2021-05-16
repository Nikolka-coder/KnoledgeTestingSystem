using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeTestingSystemWebAPI.ViewModels
{
    public class QuestionVM
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public int? TestId { get; set; }
        public virtual ICollection<AnswerVM> Answers { get; set; }

        public bool isWalid()
        {
            if (QuestionText != null && TestId != null)
            {
                return true;
            }
            return false;
        }
    }
}