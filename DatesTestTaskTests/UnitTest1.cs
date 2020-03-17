using NUnit.Framework;
using DatesTestTask.Services;
using DatesTestTask.Services.Validators;
using AutoMapper;
using DatesTestTask.Core.Data;
using System.Collections.Generic;
using DatesTestTask.Core;
using System;
using DatesTestTask.Services.DTO;

namespace DatesTestTaskTests
{
    [TestFixture]
    public class Tests
    {

        readonly IUnitOfWork unitOfWork = new UnitOfWork();
        readonly IDateValidator validator = new ValidatorCanCreate(mapper);

        [SetUp]        
        public void Setup()
        {
            IDatesRangeProcessing datesRangeProcessing;


            datesRangeProcessing = new DatesRangeProcessing(IUnitOfWork unitOfWork,
            IMapper mapper, IValidator val);

            List<DatesRange> list = new List<DatesRange>
            {
                new DatesRange{Id = 1, From = new DateTime(2020, 03, 16), To = new DateTime(2020, 03, 20)},
                new DatesRange{Id = 2, From = new DateTime(2020, 03, 14), To = new DateTime(2020,03, 12) },
                new DatesRange{Id = 3, From = new DateTime(2020, 03, 14), To = new DateTime(2020, 03, 21)},
                new DatesRange{Id = 4, From = new DateTime(2020, 03, 14), To = new DateTime(2020, 03, 17)},
                new DatesRange{Id = 5, From = new DateTime(2020, 03, 17), To = new DateTime(2020, 03, 22)}
            };


        }

        [Test]
        public void CreateDatesRangeServiceTest()
        {

            Assert.Pass();
        }

        [Test]
        public void GetRangeIntersectionService()
        {
            DatesRangeDTO dto = new DatesRangeDTO(new DateTime(2020, 03, 15), new DateTime(2020, 03, 23));

            var result = datesRangeProcessing.GetRangeIntersectionService(dto);

            Assert.AreEqual()
        }
    }
}