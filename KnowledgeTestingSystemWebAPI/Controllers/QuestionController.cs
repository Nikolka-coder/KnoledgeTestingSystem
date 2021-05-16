using AutoMapper;
using DAL.Interfaces;
using DAL.DTO;
using KnowledgeTestingSystemWebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL.Infrastructure;

namespace KnowledgeQuestioningSystemWebAPI.Controllers
{
    public class QuestionController : ApiController
    {
        private IQuestionService _questionService;
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet]
        [Route("api/Question")]
        public IHttpActionResult Get()
        {
            IEnumerable<QuestionDTO> questionDTOs = _questionService.GetQuestions();
            return Ok(Mapper.Map<IEnumerable<QuestionVM>>(questionDTOs));
        }

        [HttpGet]
        [Route("api/Question/{id}")]
        public IHttpActionResult Get(int id)
        {
            if (id < 0)
            {
                return NotFound();
            }

            QuestionVM questionVM;
            try
            {
                questionVM = Mapper.Map<QuestionVM>(_questionService.GetQuestion(id));
            }
            catch (BILException myExc)
            {

                return InternalServerError(myExc);
            }
            if (questionVM == null)
            {
                return NotFound();
            }

            return Ok(questionVM);
        }

        [HttpPost]
        [Route("api/Question")]
        public IHttpActionResult Post([FromBody]QuestionVM questionVM)
        {
            if (questionVM == null || !questionVM.isWalid())
            {
                return BadRequest();
            }

            _questionService.AddQuestion(Mapper.Map<QuestionDTO>(questionVM));
            return Ok();
        }

        [HttpPost]
        [Route("api/Question/{id}")]
        public IHttpActionResult Put(int? id, [FromBody]QuestionVM questionVM)
        {
            if (id == null || questionVM == null || !questionVM.isWalid())
            {
                return BadRequest();
            }
            try
            {
                _questionService.Change(id.GetValueOrDefault(), Mapper.Map<QuestionDTO>(questionVM));
            }
            catch (BILException myExc)
            {
                return InternalServerError(myExc);
            }
            return Ok();
        }

        [HttpDelete]
        [Route("api/Question/{id}")]
        public IHttpActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                _questionService.DeleteQuestion(id);
            }
            catch (BILException myExc)
            {
                return InternalServerError(myExc);
            }
            return Ok();
        }
    }
}
