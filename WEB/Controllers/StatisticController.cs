using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WEB.Infrastructure;
using WEB.ViewModels;

namespace WEB.Controllers
{
    public class StatisticController : Controller
    {
        private readonly IStatisticService _statisticService;

        private readonly IMapper _mapperToViewModel = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<EmployeeDTO, EmployeeViewModel>();
            cfg.CreateMap<SickLeaveDTO, SickLeaveViewModel>();
            cfg.CreateMap<VacationDTO, VacationViewModel>();
        }).CreateMapper();

        public StatisticController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        public ActionResult GetIntervalSickLeavesEmployee(Guid employeeId, DateTime startInterval, DateTime endInterval)
        {
            var dto = _statisticService.GetIntervalSickLeavesEmployee(employeeId, startInterval, endInterval);
            var model = _mapperToViewModel.Map<EmployeeViewModel>(dto);

            ViewBag.Type = TypeEntity.SickLeave;

            return View("GetIntervalEmployeeInfo", model);
        }

        public ActionResult GetIntervalVacationsEmployee(Guid employeeId, DateTime startInterval, DateTime endInterval)
        {
            var dto = _statisticService.GetIntervalVacationsEmployee(employeeId, startInterval, endInterval);
            var model = _mapperToViewModel.Map<EmployeeViewModel>(dto);

            ViewBag.Type = TypeEntity.Vacation;

            return View("GetIntervalEmployeeInfo", model);
        }

        public ActionResult GetIntervalSickLeaves(DateTime startInterval, DateTime endInterval)
        {
            var dtos = _statisticService.GetIntervalSickLeaves(startInterval, endInterval);
            var models = _mapperToViewModel.Map<IEnumerable<SickLeaveViewModel>>(dtos);

            return View(models);
        }

        public ActionResult GetIntervalVacations(DateTime startInterval, DateTime endInterval)
        {
            var dtos = _statisticService.GetIntervalVacations(startInterval, endInterval);
            var models = _mapperToViewModel.Map<IEnumerable<VacationViewModel>>(dtos);

            return View(models);
        }
    }
}