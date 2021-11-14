using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Services.Interfaces;
using System;
using System.Web.Mvc;
using WEB.Infrastructure;
using WEB.ViewModels;

namespace WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapperToDTO = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<EmployeeViewModel, EmployeeDTO>();
            cfg.CreateMap<SickLeaveViewModel, SickLeaveDTO>();
            cfg.CreateMap<VacationViewModel, VacationDTO>();
        }).CreateMapper();
        private readonly IMapper _mapperToViemModel = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<EmployeeDTO, EmployeeViewModel>();
            cfg.CreateMap<SickLeaveDTO, SickLeaveViewModel>();
            cfg.CreateMap<VacationDTO, VacationViewModel>();
        }).CreateMapper();

        public HomeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public ActionResult Index()
        {
            var employees = _employeeService.GetEmployees();

            return View(employees);
        }

        [HttpGet]
        public ActionResult AddEmployee()
        {
            var model = new EmployeeViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult AddEmployee(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dto = _mapperToDTO.Map<EmployeeDTO>(model);

                _employeeService.CreateEmployee(dto);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditEmployee(Guid id)
        {
            var dto = _employeeService.GetEmployee(id);
            var model = _mapperToViemModel.Map<EmployeeViewModel>(dto);

            return View(model);
        }

        [HttpPost]
        public ActionResult EditEmployee(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dto = _mapperToDTO.Map<EmployeeDTO>(model);

                _employeeService.EditEmployee(dto);
            }

            return RedirectToAction("Index");
        }

        public ActionResult GetEmployeeInfo(Guid id, TypeEntity type)
        {
            var dto = _employeeService.GetEmployee(id);
            var model = _mapperToViemModel.Map<EmployeeViewModel>(dto);

            ViewBag.Type = type;

            return View(model);
        }
    }
}