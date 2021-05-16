using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entitys
{
    [Serializable]
    public class Answer
    {
        [Key]
        [Required]
        public int AnswerId { get; set; }
        [Required]
        public bool IsItWright { get; set; }
        [MaxLength(90)]
        [Required]
        public string  AnswerText { get; set; }
        [Required]
        public int QuestionId { get; set; }
    }
}
