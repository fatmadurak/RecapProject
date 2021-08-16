using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<CarRentalContext, Rental>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetailDtos(Expression<Func<Rental, bool>> filter = null)
        {
            using (CarRentalContext context=new CarRentalContext())
            {


                var result = from r in filter is null ?
                          context.Rentals
                         : context.Rentals.Where(filter)

                             join c in context.Cars
                             on r.CarId equals c.CarId
                             join cu in context.Customers
                         on r.CustomerId equals cu.CustomerId
                             join u in context.Users
                             on cu.UserId equals u.UserId

                             select new RentalDetailDto
                             {
                                 CarId = c.CarId,
                                 CompanyName = cu.CompanyName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 FirstName=u.FirstName,
                                 LastName=u.LastName
                                 
                                
                                 };
                return result.ToList();

                }


            }
        }
    }


