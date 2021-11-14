using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Services.Interfaces;
using DataLayer.Entity;
using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogicLayer.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<EmployeeInfos> GetEmployees()
        {
            var _mapper = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeInfos>()
                    .ForMember(ei => ei.CountSickLeaves, i => i.MapFrom(e => e.SickLeaves.Count()))
                    .ForMember(ei => ei.CountVacation, i => i.MapFrom(e => e.Vacations.Count())))
                .CreateMapper();

            return _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeInfos>>(_unitOfWork.Employees.GetAll());
        }

        public EmployeeDTO GetEmployee(Guid employeeId)
        {
            var _mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDTO>();
                cfg.CreateMap<SickLeave, SickLeaveDTO>();
                cfg.CreateMap<Vacation, VacationDTO>();
            }).CreateMapper();

            var employee = _unitOfWork.Employees.Get(employeeId);

            return _mapper.Map<EmployeeDTO>(employee);
        }

        public void CreateEmployee(EmployeeDTO dto)
        {
            var _mapper = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeDTO, Employee>()
                    .ForMember(e => e.Id, edto => edto.Ignore())
                    .ForMember(e => e.SickLeaves, edto => edto.Ignore())
                    .ForMember(e => e.Vacations, edto => edto.Ignore()))
                .CreateMapper();

            var employee = _mapper.Map<Employee>(dto);

            _unitOfWork.Employees.Create(employee);
        }

        public void EditEmployee(EmployeeDTO dto)
        {
            var employee = _unitOfWork.Employees.Get(dto.Id);

            var _mapper = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeDTO, Employee>()
                    .ForMember(e => e.Id, edto => edto.Ignore())
                    .ForMember(e => e.SickLeaves, edto => edto.Ignore())
                    .ForMember(e => e.Vacations, edto => edto.Ignore()))
                .CreateMapper();

            _mapper.Map(dto, employee);

            _unitOfWork.Employees.Update(employee);
        }

        public void DeleteEmployee(Guid employeeId)
        {
            var employee = _unitOfWork.Employees.Get(employeeId);

            foreach (var sickLeave in employee.SickLeaves)
            {
                _unitOfWork.SickLeaves.Delete(sickLeave.Id);
            }

            foreach (var vacation in employee.Vacations)
            {
                _unitOfWork.Vacations.Delete(vacation.Id);
            }

            _unitOfWork.Employees.Delete(employee.Id);
        }
    }
}
