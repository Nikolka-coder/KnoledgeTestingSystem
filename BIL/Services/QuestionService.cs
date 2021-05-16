using AutoMapper;
using DAL.Entitys;
using DAL.Interfaces;
using DAL.DTO;
using DAL.Infrastructure;
using System.Collections.Generic;

namespace DAL.Services
{
    public class QuestionService : IQuestionService
    {

        private IUnitOfWork _unitOfWork { get; set; }

        public QuestionService(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }

        public void AddQuestion(QuestionDTO questionDTO)
        {
            if (questionDTO == null)
                throw new BILException("question null", "");

            _unitOfWork.Question.Create(Mapper.Map<Question>(questionDTO));
            _unitOfWork.Save();
        }

        public void DeleteQuestion(int? id)
        {
            if (id == null)
                throw new BILException("we don't have this id", "");
            else
            {
                _unitOfWork.Question.Delete(id.GetValueOrDefault());
                _unitOfWork.Save();
            }
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public QuestionDTO GetQuestion(int? id)
        {
            if (id == null)
                throw new BILException("we don't have this id", "");

            return Mapper.Map<QuestionDTO>(_unitOfWork.Question.Get(id.GetValueOrDefault()));
        }

        public ICollection<QuestionDTO> GetQuestions()
        {
            return Mapper.Map<ICollection<QuestionDTO>>(_unitOfWork.Question.GetAll());
        }

        public void Change(int id, QuestionDTO questionDTO)
        {
            Question question = _unitOfWork.Question.Get(id);
            if (question == null)
                throw new BILException("we don't have this id", "");

            question.QuestionText = questionDTO.QuestionText;
            question.TestId = questionDTO.TestId;
            _unitOfWork.Save();
        }
    }
}
