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

namespace KnowledgeTestingSystemWebAPI.Controllers
{
    public class TestController : ApiController
    {

        private ITestService _testService;
        public TestController(ITestService testService)
        {
            _testService = testService;
        }


        [HttpGet]
        [Route("api/Test/connections/{id}")]
        public IHttpActionResult GetWithConnection(int id)
        {
            TestDTO testDTOs = _testService.GetTestWithConnection(id);
            return Ok(Mapper.Map<TestVM>(testDTOs));
        }

        [HttpGet]
        [Route("api/Test")]
        public IHttpActionResult Get()
        {
            IEnumerable<TestDTO> testDTOs = _testService.GetTests();
            return Ok(Mapper.Map<IEnumerable<TestVM>>(testDTOs));
        }


        [HttpGet]
        [Route("api/Test/{id}")]
        public IHttpActionResult Get(int id)
        {
            if (id < 0)
            {
                return NotFound();
            }

            TestVM testVM;
            try
            {
                testVM = Mapper.Map<TestVM>(_testService.GetTest(id));
            }
            catch (BILException myExc)
            {

                return InternalServerError(myExc);
            }
            if (testVM == null)
            {
                return NotFound();
            }

            return Ok(testVM);
        }

        [HttpPost]
        [Route("api/Test/")]
        public IHttpActionResult Post ([FromBody]TestVM testVM)
        {
            if (testVM == null || !testVM.isWalid())
            {
                return BadRequest();
            }

            _testService.AddTest(Mapper.Map<TestDTO>(testVM));
            return Ok();
        }

        [HttpPost]
        [Route("api/Test/{id}")]
        public IHttpActionResult Put(int? id, [FromBody]TestVM testVM)
        {
            if (id == null || testVM == null || !testVM.isWalid())
            {
                return BadRequest();
            }
            try
            {
                _testService.Change(id.GetValueOrDefault(), Mapper.Map<TestDTO>(testVM));
            }
            catch (BILException myExc)
            {
                return InternalServerError(myExc);
            }
            return Ok();
        }

        [HttpDelete]
        [Route("api/Test/{id}")]
        public IHttpActionResult Delete(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                _testService.DeleteTest(id);
            }
            catch (BILException myExc)
            {
                return InternalServerError(myExc);
            }
            return Ok();
        }
    }
}
