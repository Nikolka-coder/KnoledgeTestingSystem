using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entitys
{
    [Serializable]
    public class Test
    {
        [Key]
        [Required]
        public int TestId { get; set; }
        [MaxLength(40)]
        [Required]
        public string Name { get; set; }
        [Required]
        public int SecToFinish { get; set; }
        [Required]
        public DateTime TimeOfCreation { get; set; }
        [Required]
        public virtual ICollection<Question> Questions { get; set; }
    }
}
