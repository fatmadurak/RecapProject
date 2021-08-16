using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<CarRentalContext, Car>, ICarDal
    {
        public List<CarDetailDto> GetCarDetailDtos()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from ca in context.Cars
                             join b in context.Brands
                             on ca.BrandId equals b.BrandId
                             join c in context.Colors
                             on ca.ColorId equals c.ColorId
                         
                             select new CarDetailDto { 
                             
                                 BrandName=b.BrandName,
                                 CarName=ca.CarName,
                                 ColorName=c.ColorName,
                                 DailyPrice=ca.DailyPrice


                             };




                return result.ToList();

            }

            
        }
    }
}
