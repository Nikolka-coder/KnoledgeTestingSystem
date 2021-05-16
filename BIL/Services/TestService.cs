using System.Collections.Generic;
using AutoMapper;
using DAL.Entitys;
using DAL.Interfaces;
using DAL.DTO;
using DAL.Infrastructure;

namespace DAL.Services
{
    public class TestService : ITestService
    {
        IUnitOfWork _unitOfWork { get; set; }

        public TestService(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }

        public void AddTest(TestDTO testDTO)
        {
            if (testDTO == null)
                throw new BILException("test null", "");

            _unitOfWork.Test.Create(Mapper.Map<Test>(testDTO));
            _unitOfWork.Save();
        }

        public void DeleteTest(int? id)
        {
            if (id == null)
                throw new BILException("we don't have this id", "");
            else
            {
                _unitOfWork.Test.Delete(id.GetValueOrDefault());
                _unitOfWork.Save();
            }
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public TestDTO GetTest(int? id)
        {
            if (id == null)
                throw new BILException("we don't have this id", "");

            return Mapper.Map<TestDTO>(_unitOfWork.Test.Get(id.GetValueOrDefault()));
        }

        public ICollection<TestDTO> GetTests()
        {
            return Mapper.Map<ICollection<TestDTO>>(_unitOfWork.Test.GetAll());
        }

        public TestDTO GetTestWithConnection(int? id)
        {
            return Mapper.Map<TestDTO>(_unitOfWork.Test.GetWithConnection(id.GetValueOrDefault()));
        }

        public void Change(int id, TestDTO testDTO)
        {
            Test test  = _unitOfWork.Test.Get(id);
            if (test == null)
                throw new BILException("we don't have this id", "");

            test.Name = testDTO.Name;
            test.SecToFinish = testDTO.SecToFinish;
            test.TimeOfCreation = test.TimeOfCreation;
            _unitOfWork.Save();
        }
    }
}
