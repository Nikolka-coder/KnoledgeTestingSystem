using AutoMapper;
using DAL.DTO;
using KnowledgeTestingSystemWebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeTestingSystemWebAPI.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<AnswerDTO, AnswerVM>();
                cfg.CreateMap<AnswerVM, AnswerDTO>();
                cfg.CreateMap<TestVM, TestDTO>();
                cfg.CreateMap<TestDTO,TestVM > ();
                cfg.CreateMap<QuestionVM, QuestionDTO>();
            });
        }
    }
}