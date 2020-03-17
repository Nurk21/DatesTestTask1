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
    public interface IDatesService
    {
        Task CreateRangeAsync(DatesRangeDTO datesRangeDTO);
        Task<List<DatesRange>> GetRangesAsync(DatesRangeDTO datesRangeDTO);
    }
    public class DatesService : IDatesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDateValidator _dateValidator;

        public DatesService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IDateValidator dateValidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _dateValidator = dateValidator;
        }
        public async Task CreateRangeAsync(DatesRangeDTO datesRangeDTO)
        {            
            _dateValidator.CanCreate(datesRangeDTO);
            var result = _mapper.Map<DatesRange>(datesRangeDTO);
            _unitOfWork.GetRepository<DatesRange>().Insert(result);
            await _unitOfWork.SaveChangesAsync();          
        }
        public async Task<List<DatesRange>> GetRangesAsync(DatesRangeDTO datesRangeDTO)
        {
            return await _unitOfWork.GetRepository<DatesRange>().TableNoTracking.Where( t =>
                (datesRangeDTO.From > t.From && datesRangeDTO.From < t.To && datesRangeDTO.To > t.To)||(datesRangeDTO.To > t.From && datesRangeDTO.To < t.To && datesRangeDTO.From < t.From)
                ).ToListAsync();
        }
    }
}


