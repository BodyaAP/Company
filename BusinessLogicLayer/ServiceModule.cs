using BusinessLogicLayer.Services.Implementation;
using BusinessLogicLayer.Services.Interfaces;
using DataLayer.Interfaces;
using DataLayer.Repositories;
using Ninject.Modules;

namespace BusinessLogicLayer
{
    public class ServiceModule : NinjectModule
    {
        private readonly string connectionString;

        public ServiceModule(string connectin)
        {
            connectionString = connectin;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<NHUnitOfWork>().WithConstructorArgument(connectionString);
            Bind<IEmployeeService>().To<EmployeeService>();
            Bind<ICalendarService>().To<CalendarService>();
            Bind<IStatisticService>().To<StatisticService>();
        }
    }
}
