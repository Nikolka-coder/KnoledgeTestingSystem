using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class AnswerDTO
    {
        public int AnswerId { get; set; }
        public bool IsItWright { get; set; }
        public string AnswerText { get; set; }
        public int QuestionId { get; set; }
    }
}
