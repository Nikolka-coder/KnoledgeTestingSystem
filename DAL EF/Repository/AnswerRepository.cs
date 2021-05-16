using DAL.Entitys;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class AnswerRepository: IAnswerRepository
    {
        private IContext db;

        public AnswerRepository(IContext context)
        {
            db = context;
        }

        public ICollection<Answer> GetAll()
        {
            return db.Answers.ToList();
        }

        public Answer Get(int id)
        {
            return db.Answers.Find(id);
        }

        public ICollection<Answer> GetAllWithConnection()
        {
            return db.Answers.Include("Question").ToList();
        }

        public Answer GetWithConnection(int id)
        {
            return db.Answers.Include("Question").First(ex => ex.AnswerId == id);
        }

        public void Create(Answer Answer)
        {
            db.Answers.Add(Answer);
        }

        public void Update(Answer Answer)
        {
            ((DBContext)db).Entry(Answer).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Answer answer = db.Answers.Find(id);
            if (answer != null)
                db.Answers.Remove(answer);
        }
    }
}
