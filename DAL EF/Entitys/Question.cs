using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entitys
{
    [Serializable]
    public class Question
    {
        [Key]
        [Required]
        public int QuestionId { get; set; }
        [MaxLength(90)]
        [Required]
        public string QuestionText { get; set; }
        [Required]
        public int TestId { get; set; }
        [Required]
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
