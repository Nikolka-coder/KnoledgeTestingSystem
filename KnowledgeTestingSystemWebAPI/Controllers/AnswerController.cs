using AutoMapper;
using DAL.DTO;
using DAL.Infrastructure;
using DAL.Interfaces;
using KnowledgeTestingSystemWebAPI.ViewModels;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KnowledgeTestingSystemWebAPI.Controllers
{
    public class AnswerController : ApiController
    {

        private IAnswerService _answerService;
        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        [HttpGet]
        [Route("api/Answer")]
        public IHttpActionResult Get()
        {
            IEnumerable<AnswerDTO> answerDTOs = _answerService.GetAnswers();
            return Ok(Mapper.Map<IEnumerable<AnswerVM>>(answerDTOs));
        }

        [HttpGet]
        [Route("api/Answer/{id}")]
        public IHttpActionResult Get(int id)
        {
            if (id < 0)
            {
                return NotFound();
            }

            AnswerVM answerVM;
            try
            {
                answerVM = Mapper.Map<AnswerVM>(_answerService.GetAnswer(id));
            }
            catch (BILException myExc)
            {

                return InternalServerError(myExc);
            }
            if (answerVM == null)
            {
                return NotFound();
            }
            
            return Ok(answerVM);
        }

        [HttpPost]
        [Route("api/Answer")]
        public IHttpActionResult Post([FromBody]AnswerVM answerVM)
        {
            if (answerVM == null || !answerVM.isWalid())
            {
                return BadRequest();
            }
            _answerService.AddAnswer(Mapper.Map<AnswerDTO>(answerVM));
            return Ok();
        }

        [HttpPost]
        [Route("api/Answer/{id}")]
        public IHttpActionResult Put(int? id, [FromBody]AnswerVM answerVM)
        {
            if (id == null || answerVM == null || !answerVM.isWalid() )
            {
                return BadRequest();
            }
            try
            {
                _answerService.Change(id.GetValueOrDefault(), (Mapper.Map<AnswerDTO>(answerVM)));
            }
            catch (BILException myExc)
            {
                return InternalServerError(myExc);
            }
            return Ok();
        }

        [HttpDelete]
        [Route("api/Answer/{id}")]
        public IHttpActionResult Delete(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                _answerService.DeleteAnswer(id);
            }
            catch (BILException myExc)
            {
                return InternalServerError(myExc);
            }
            return Ok();
        }
    }
}