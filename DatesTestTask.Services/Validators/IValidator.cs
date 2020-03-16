using DatesTestTask.Services.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatesTestTask.Services.Validators
{
    public interface IValidator
    {
        public bool CanCreate(DatesRangeDTO datesRangeDTO);
    }
}
