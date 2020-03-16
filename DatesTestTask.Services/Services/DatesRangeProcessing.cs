using System;
using AutoMapper;
using DatesTestTask.Core;
using DatesTestTask.Core.Data;
using DatesTestTask.Services.DTO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DatesTestTask.Services.Validators;

namespace DatesTestTask.Services.Services
{
    class DatesRangeProcessing : IDatesRangeProcessing
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator _val;

        public DatesRangeProcessing(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IValidator val)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _val = val;
        }

        public async Task<bool> CreateDatesRangeService(DatesRangeDTO datesRangeDTO)
        {
            
            _val.CanCreate(datesRangeDTO);

            var result = _mapper.Map<DatesRange>(datesRangeDTO);

            _unitOfWork.GetRepository<DatesRange>().Insert(result);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<List<DatesRange>> GetRangeIntersectionService(DatesRangeDTO datesRangeDTO)
        {
            return await _unitOfWork.GetRepository<DatesRange>().TableNoTracking.Where( t =>
                (datesRangeDTO.From > t.From && datesRangeDTO.From < t.To && datesRangeDTO.To > t.To)||(datesRangeDTO.To > t.From && datesRangeDTO.To < t.To && datesRangeDTO.From < t.From)
                ).ToListAsync();
        }
    }
}


