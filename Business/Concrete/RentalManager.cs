using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {

        IRentalDal _rentaldal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentaldal = rentalDal;
        }
        public IResult Add(Rental rental)
        {

            var result = _rentaldal.GetRentalDetailDtos(r => r.CarId == rental.CarId && rental.RentDate >= r.ReturnDate);


            if (result.Count <= 0) {



                return new ErrorResult(Messages.InvalidAddedMessage);


            }


            _rentaldal.Add(rental);
            return new SuccessResult(Messages.AddedMessage);

        }

        public IResult Delete(Rental rental)
        {
            _rentaldal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentaldal.GetAll(), Messages.ListedMessage);
        }

        public IDataResult<Rental> GetByRentalId(int id)
        {
            return new SuccessDataResult<Rental>(_rentaldal.Get(r => r.RentalId == id));


        }

        public IResult Update(Rental rental)
        {
            _rentaldal.Update(rental);
            return new SuccessResult();
        }
    }
}