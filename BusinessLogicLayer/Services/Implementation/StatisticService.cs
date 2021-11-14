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
    public class StatisticService : IStatisticService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapperToDTO = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Employee, EmployeeDTO>();
            cfg.CreateMap<SickLeave, SickLeaveDTO>();
            cfg.CreateMap<Vacation, VacationDTO>();
        }).CreateMapper();

        public StatisticService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public EmployeeDTO GetIntervalSickLeavesEmployee(Guid employeeId, DateTime startInterval, DateTime endInterval)
        {
            var employee = _unitOfWork.Employees.Get(employeeId);

            var sickLeaves = _unitOfWork.SickLeaves.GetAll()
                        .Where(sl => sl.Employee.Id == employee.Id)
                        .Where(sl => sl.Start >= startInterval && sl.End <= endInterval)
                        .ToList();

            var employeeDto = _mapperToDTO.Map<EmployeeDTO>(employee);
            var sickLeaveDtos = _mapperToDTO.Map<IEnumerable<SickLeaveDTO>>(sickLeaves);
            employeeDto.SickLeaves = sickLeaveDtos.ToList();

            return employeeDto;
        }

        public EmployeeDTO GetIntervalVacationsEmployee(Guid employeeId, DateTime startInterval, DateTime endInterval)
        {
            var employee = _unitOfWork.Employees.Get(employeeId);

            var vacations = _unitOfWork.Vacations.GetAll()
                        .Where(v => v.Employee.Id == employee.Id)
                        .Where(v => v.Start >= startInterval && v.End <= endInterval)
                        .ToList();

            var employeeDto = _mapperToDTO.Map<EmployeeDTO>(employee);
            var vacationDtos = _mapperToDTO.Map<IEnumerable<VacationDTO>>(vacations);
            employeeDto.Vacations = vacationDtos.ToList();

            return employeeDto;
        }

        public IEnumerable<SickLeaveDTO> GetIntervalSickLeaves(DateTime startInterval, DateTime endInterval)
        {
            var sickLeaves = _unitOfWork.SickLeaves.GetAll()
                    .Where(sl => sl.Start >= startInterval && sl.End <= endInterval)
                    .ToList();

            return _mapperToDTO.Map<IEnumerable<SickLeaveDTO>>(sickLeaves);
        }

        public IEnumerable<VacationDTO> GetIntervalVacations(DateTime startInterval, DateTime endInterval)
        {
            var vacations = _unitOfWork.Vacations.GetAll()
                    .Where(v => v.Start >= startInterval && v.End <= endInterval)
                    .ToList();

            return _mapperToDTO.Map<IEnumerable<VacationDTO>>(vacations);
        }
    }
}
