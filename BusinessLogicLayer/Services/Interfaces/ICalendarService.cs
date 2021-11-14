using BusinessLogicLayer.DTO;
using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface ICalendarService
    {
        void DeleteSickLeave(Guid sickLeaveId);
        void DeleteVacation(Guid vacationId);
        IEnumerable<SickLeaveDTO> GetSickLeaves();
        IEnumerable<VacationDTO> GetVacation();
        void AddSickLeave(SickLeaveDTO sickLeave);
        void AddVacation(VacationDTO vacation);
    }
}