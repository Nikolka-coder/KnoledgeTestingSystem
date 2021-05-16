using AutoMapper;
using DAL.Entitys;
using DAL.Interfaces;
using DAL.DTO;
using DAL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class AnswerService : IAnswerService
    {
        private IUnitOfWork _unitOfWork { get; set; }

        public AnswerService(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }

        public void AddAnswer(AnswerDTO answerDTO)
        {
            if (answerDTO == null)
                throw new BILException("answer null", "");

            Answer answer = new Answer
            {
                AnswerText = answerDTO.AnswerText,
                IsItWright = answerDTO.IsItWright,
                QuestionId = answerDTO.QuestionId
            };

            _unitOfWork.Answer.Create(answer);
            _unitOfWork.Save();
        }

        public void DeleteAnswer(int? id)
        {
            if (id == null)
                throw new BILException("we don't have this id", "");
            else
            {
                _unitOfWork.Answer.Delete(id.GetValueOrDefault());
                _unitOfWork.Save();
            }
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public AnswerDTO GetAnswer(int? id)
        {
            if (id == null)
                throw new BILException("we don't have this id", "");

            return Mapper.Map<AnswerDTO>(_unitOfWork.Answer.Get(id.GetValueOrDefault()));
        }

        public ICollection<AnswerDTO> GetAnswers()
        {
            return Mapper.Map<ICollection<AnswerDTO>>(_unitOfWork.Answer.GetAll());
        }

        public void Change(int id, AnswerDTO answerDTO)
        {
            Answer answer = _unitOfWork.Answer.Get(id);
            if (answer == null)
                throw new BILException("we don't have this id", "");

            answer.AnswerText = answerDTO.AnswerText;
            answer.IsItWright = answerDTO.IsItWright;
            answer.QuestionId = answer.QuestionId;
            _unitOfWork.Save();
        }
    }
}
