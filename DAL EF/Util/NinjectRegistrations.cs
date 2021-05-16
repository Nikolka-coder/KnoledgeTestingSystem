using BIL.Interfaces;
using BIL.Repository;
using BIL.UnitOfWorks;
using Ninject.Modules;

namespace BIL.Util
{

    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IAnswerRepository>().To<AnswerRepository>();
            Bind<IQuestionRepository>().To<QuestionRepository>();
            Bind<ITestRepository>().To<TestRepository>();
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }

}
