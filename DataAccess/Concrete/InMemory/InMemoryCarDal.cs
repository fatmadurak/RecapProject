using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal:ICarDal
    {


        List<Car> _cars;
        public InMemoryCarDal()
        {
          _cars=  new List<Car>
        {
             new Car{CarId=1,BrandId=1,ColorId=1,ModelYear=2021,DailyPrice=1000,Description="BMW 730d"},
             new Car{CarId=2,BrandId=1,ColorId=2,ModelYear=1992,DailyPrice=500,Description="BMW 520i"},
             new Car{CarId=3,BrandId=2,ColorId=1,ModelYear=1998,DailyPrice=300,Description="Volkswagen Golf Mk4"},
             new Car{CarId=4,BrandId=2,ColorId=3,ModelYear=1998,DailyPrice=700,Description="Volkswagen Golf Mk8"},
             new Car{CarId=5, BrandId=3,ColorId=2,ModelYear=2016,DailyPrice=450,Description="Fiat Linea 1.3 Multijet"},



        };
        }




        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {

            var carToDelete = _cars.SingleOrDefault(c=>c.CarId==car.CarId);

            _cars.Remove(carToDelete);

        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter=null)
        {
            return _cars;
        }

      

        public void Update(Car car)
        {
            var carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);

            carToUpdate.CarId = car.CarId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.Description = car.Description;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
          

        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailDtos()
        {
            throw new NotImplementedException();
        }
    }
}
