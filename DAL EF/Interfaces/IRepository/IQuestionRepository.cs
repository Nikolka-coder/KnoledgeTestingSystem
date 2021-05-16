using DAL.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IQuestionRepository
    {
        ICollection<Question> GetAll();
        Question Get(int id);
        void Create(Question Question);
        void Update(Question Question);
        void Delete(int id);
    }
}
