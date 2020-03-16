using AutoMapper;
using DatesTestTask.Core;
using DatesTestTask.Services.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatesTestTask.Services.Validators
{
    public class ValidatorCanCreate : IValidator
    {
        private readonly IMapper _mapper;
        public ValidatorCanCreate(IMapper mapper) {
            _mapper = mapper;
        }
        public bool CanCreate(DatesRangeDTO datesRangeDTO)
        {
            if (datesRangeDTO.From < datesRangeDTO.To)
                try
                {
                    var result = _mapper.Map<DatesRange>(datesRangeDTO);
                }
                catch
                {
                    throw new Exception();
                }
            return true;

        }
    }
}
