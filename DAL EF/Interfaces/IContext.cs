using DAL.Entitys;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IContext
    {
       DbSet<Answer> Answers { get; set; }
       DbSet<Question> Questions { get; set; }
       DbSet<Test> Tests { get; set; }
    }
}
