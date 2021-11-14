using BusinessLogicLayer.DTO;
using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IEmployeeService
    {
        void CreateEmployee(EmployeeDTO dto);
        void DeleteEmployee(Guid employeeId);
        void EditEmployee(EmployeeDTO dto);
        EmployeeDTO GetEmployee(Guid employeeId);
        IEnumerable<EmployeeInfos> GetEmployees();
    }
}