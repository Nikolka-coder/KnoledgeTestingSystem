using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeTestingSystemWebAPI.ViewModels
{
    public class TestVM
    {
        public int TestId { get; set; }
        public string Name { get; set; }
        public int SecToFinish { get; set; }
        public virtual ICollection<QuestionVM> Questions { get; set; }

        public bool isWalid()
        {
            if (Name != null && SecToFinish != null)
            {
                return true;
            }
            return false;
        }
    }
}