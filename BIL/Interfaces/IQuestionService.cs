using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IQuestionService: IDisposable
    {
        void AddQuestion(QuestionDTO questionDTO);
        QuestionDTO GetQuestion(int? id);
        ICollection<QuestionDTO> GetQuestions();
        void Change(int id, QuestionDTO answerDTO);
        void DeleteQuestion(int? id);
    }
}
