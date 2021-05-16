using DAL.Interfaces;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWorks
{
    public class UnitOfWork: IUnitOfWork, IDisposable
    {
        private DBContext db;
        private AnswerRepository _answerRepository;
        private QuestionRepository _questionRepository;
        private TestRepository _testRepository;

        public UnitOfWork(string connectionString)
        {
            db = new DBContext(connectionString);
        }

        public IAnswerRepository Answer {
            get
            {
                if (_answerRepository == null)
                    _answerRepository = new AnswerRepository(db);
                return _answerRepository;
            }
        }
        public IQuestionRepository Question
        {
            get
            {
                if (_questionRepository == null)
                    _questionRepository = new QuestionRepository(db);
                return _questionRepository;
            }
        }
        public ITestRepository Test
        {
            get
            {
                if (_testRepository == null)
                    _testRepository = new TestRepository(db);
                return _testRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
