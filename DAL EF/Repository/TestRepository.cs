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
    public class TestRepository: ITestRepository
    {
        private IContext db;

        public TestRepository(IContext context)
        {
            db = context;
        }

        public ICollection<Test> GetAll()
        {
            return db.Tests.ToList();
        }

        public Test Get(int id)
        {
            return db.Tests.Find(id);
        }

        public void Create(Test Test)
        {
            db.Tests.Add(Test);
        }

        public void Update(Test Test)
        {
            ((DBContext)db).Entry(Test).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Test test = db.Tests.Find(id);
            if (test != null)
                db.Tests.Remove(test);
        }

        public Test GetWithConnection(int id)
        {
            return db.Tests.Include(c => c.Questions.Select(o => o.Answers)).First(t => t.TestId == id);
        }
    }
}
