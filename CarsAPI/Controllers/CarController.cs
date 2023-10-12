using CarsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace CarsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            using(var context = new CarContext()) 
            {
                return Ok(context.Cars.ToList());
            }
        }
        [HttpPost]
        public ActionResult<CarDto> Post(CreatedCarDto car)
        {
            using(var context = new CarContext())
            {
                var request = new Car
                {
                    Id = Guid.NewGuid(),
                    Name = car.Name,
                    Description = car.Description,
                    CreatedTime = DateTime.Now
                };
                context.Cars.Add(request);
                context.SaveChanges();
            }
            return Ok();
        }
        [HttpGet("{id}")]
        public ActionResult Get(Guid id) 
        { 
            using(var context = new CarContext())
            {
                var result = context.Cars.FirstOrDefault(x=> x.Id == id);
                return Ok(result);
                
            }
        }
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, UpdateCarDto update)
        {
            using (var context = new CarContext())
            {
                var existingCar = context.Cars.FirstOrDefault(x => x.Id == id);
                existingCar.Name = update.Name;
                existingCar.Description = update.Description;
                context.Cars.Add(existingCar);
                context.SaveChanges();
                return Ok();
            }
        }
    }
}
