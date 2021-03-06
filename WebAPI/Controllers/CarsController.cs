using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carservice;

        public CarsController(ICarService carService)
        {
            _carservice = carService;
        }


        [HttpGet("getall")]

        public IActionResult GetAll() {

          var result=  _carservice.GetAll();

            if (result.Success)
            {
                return Ok(result);

            }

            return BadRequest(result);
        
        }
        [HttpGet("getbyid")]
        public IActionResult GetByCarId(int id) 
        {
            var result = _carservice.GetById(id);


            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpPost("add")]

        public IActionResult Add(Car car) 
        {
            var result = _carservice.Add(car);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        
        }

        [HttpPost("delete")]

        public IActionResult Delete(Car car) 
        {

            var result = _carservice.Delete(car);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }



        [HttpPost("update")]

        public IActionResult Update(Car car)
        {

            var result = _carservice.Update(car);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }






    }
}
