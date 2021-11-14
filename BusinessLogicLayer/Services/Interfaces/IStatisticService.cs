using BusinessLogicLayer.DTO;
using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IStatisticService
    {
        IEnumerable<SickLeaveDTO> GetIntervalSickLeaves(DateTime startInterval, DateTime endInterval);
        EmployeeDTO GetIntervalSickLeavesEmployee(Guid employeeId, DateTime startInterval, DateTime endInterval);
        IEnumerable<VacationDTO> GetIntervalVacations(DateTime startInterval, DateTime endInterval);
        EmployeeDTO GetIntervalVacationsEmployee(Guid employeeId, DateTime startInterval, DateTime endInterval);
    }
}