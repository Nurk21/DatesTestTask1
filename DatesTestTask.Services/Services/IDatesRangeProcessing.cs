using DatesTestTask.Core;
using DatesTestTask.Services.DTO;
using DatesTestTask.Services.Validators;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatesTestTask.Services
{
    public interface IDatesRangeProcessing
    {
        Task<bool> CreateDatesRangeService(DatesRangeDTO datesRangeDTO);
        Task<List<DatesRange>> GetRangeIntersectionService(DatesRangeDTO datesRangeDTO);
    }
}
