using DAL.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ITestRepository
    {
        ICollection<Test> GetAll();
        Test Get(int id);
        Test GetWithConnection(int id);
        void Create(Test Test);
        void Update(Test Test);
        void Delete(int id);
    }
}
