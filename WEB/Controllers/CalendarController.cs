using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WEB.ViewModels;

namespace WEB.Controllers
{
    public class CalendarController : Controller
    {
        private readonly ICalendarService _calendarService;
        private readonly IEmployeeService _employeeService;

        private readonly IMapper _mapperToViewModel = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<EmployeeDTO, EmployeeViewModel>();
            cfg.CreateMap<SickLeaveDTO, SickLeaveViewModel>();
            cfg.CreateMap<VacationDTO, VacationViewModel>();
        }).CreateMapper();

        private readonly IMapper _mapperSickLeaveToDTO = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<SickLeaveViewModel, SickLeaveDTO>();
            cfg.CreateMap<EmployeeViewModel, EmployeeDTO>();
        }).CreateMapper();

        private readonly IMapper _mapperVacationToDTO = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<VacationViewModel, VacationDTO>();
            cfg.CreateMap<EmployeeViewModel, EmployeeDTO>();
        }).CreateMapper();

        public CalendarController(ICalendarService calendarService, IEmployeeService employeeService)
        {
            _calendarService = calendarService;
            _employeeService = employeeService;
        }

        [HttpGet]
        public ActionResult AddSickLeave(Guid employeeId)
        {
            var dto = _employeeService.GetEmployee(employeeId);
            var employee = _mapperToViewModel.Map<EmployeeViewModel>(dto);

            var model = new SickLeaveViewModel()
            {
                Employee = employee
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult AddSickLeave(SickLeaveViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dto = _mapperSickLeaveToDTO.Map<SickLeaveDTO>(model);
                _calendarService.AddSickLeave(dto);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult AddVacation(Guid employeeId)
        {
            var dto = _employeeService.GetEmployee(employeeId);
            var employee = _mapperToViewModel.Map<EmployeeViewModel>(dto);

            var model = new VacationViewModel()
            {
                Employee = employee
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult AddVacation(VacationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dto = _mapperVacationToDTO.Map<VacationDTO>(model);
                _calendarService.AddVacation(dto);
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult DeleteSickLeave(Guid id)
        {
            _calendarService.DeleteSickLeave(id);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult DeleteVacation(Guid id)
        {
            _calendarService.DeleteVacation(id);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult GetSickLeaves()
        {
            var dtos = _calendarService.GetSickLeaves();
            var models = _mapperToViewModel.Map<IEnumerable<SickLeaveViewModel>>(dtos);

            return View(models);
        }

        public ActionResult GetVacations()
        {
            var dtos = _calendarService.GetVacation();
            var models = _mapperToViewModel.Map<IEnumerable<VacationViewModel>>(dtos);

            return View(models);
        }
    }
}