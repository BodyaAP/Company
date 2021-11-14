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
    public class CalendarService : ICalendarService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapperToDTO = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Employee, EmployeeDTO>();
            cfg.CreateMap<SickLeave, SickLeaveDTO>();
            cfg.CreateMap<Vacation, VacationDTO>();
        }).CreateMapper();

        public CalendarService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddSickLeave(SickLeaveDTO dto)
        {
            var _mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SickLeaveDTO, SickLeave>();
                cfg.CreateMap<EmployeeDTO, Employee>();
            }).CreateMapper();

            var employee = _unitOfWork.Employees.Get(dto.Employee.Id);

            var sickLeave = _mapper.Map<SickLeave>(dto);

            sickLeave.Employee = employee;

            if (employee != null)
            {
                _unitOfWork.SickLeaves.Create(sickLeave);
            }
            else
            {
                throw new Exception("Employee did not found");
            }
        }

        public void AddVacation(VacationDTO dto)
        {
            var _mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<VacationDTO, Vacation>();
                cfg.CreateMap<EmployeeDTO, Employee>();
            }).CreateMapper();

            var employee = _unitOfWork.Employees.Get(dto.Employee.Id);

            var vacation = _mapper.Map<Vacation>(dto);

            vacation.Employee = employee;

            if (employee != null)
            {
                _unitOfWork.Vacations.Create(vacation);
            }
            else
            {
                throw new Exception("Employee did not found");
            }
        }

        public IEnumerable<SickLeaveDTO> GetSickLeaves()
        {
            var sickLeaves = _unitOfWork.SickLeaves.GetAll().OrderBy(sl => sl.Employee.LastName); ;

            var dtos = _mapperToDTO.Map<IEnumerable<SickLeaveDTO>>(sickLeaves);

            return dtos;
        }

        public IEnumerable<VacationDTO> GetVacation()
        {
            var vacations = _unitOfWork.Vacations.GetAll().OrderBy(v => v.Employee.LastName);

            var dtos = _mapperToDTO.Map<IEnumerable<VacationDTO>>(vacations);

            return dtos;
        }

        public void DeleteSickLeave(Guid sickLeaveId)
        {
            var sickLeave = _unitOfWork.SickLeaves.Get(sickLeaveId);

            if (sickLeave != null)
            {
                _unitOfWork.SickLeaves.Delete(sickLeave.Id);
            }
            else
            {
                throw new Exception("Sick leave did not found");
            }
        }

        public void DeleteVacation(Guid vacationId)
        {
            var vacation = _unitOfWork.Vacations.Get(vacationId);

            if (vacation != null)
            {
                _unitOfWork.Vacations.Delete(vacation.Id);
            }
            else
            {
                throw new Exception("Vacation did not found");
            }
        }
    }
}
