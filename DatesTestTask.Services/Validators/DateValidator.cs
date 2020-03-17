using AutoMapper;
using DatesTestTask.Core;
using DatesTestTask.Services.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatesTestTask.Services.Validators
{
    public interface IDateValidator
    {
        public void CanCreate(DatesRangeDTO datesRangeDTO);
    }
    public class DateValidator : IDateValidator
    {
        public void CanCreate(DatesRangeDTO datesRangeDTO)
        {
            if (datesRangeDTO.From > datesRangeDTO.To)
            {
                throw new Exception("Invalid Data Range (From > To)");
            }

        }
    }
}
