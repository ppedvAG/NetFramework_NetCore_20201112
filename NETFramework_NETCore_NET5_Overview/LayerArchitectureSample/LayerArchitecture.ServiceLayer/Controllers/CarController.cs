using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LayerArchitecture.DataLayer.EFContext;
using LayerArchitecture.Domain.Entities;
using GenericGepositorySample;
using LayerArchitecture.DataLayer.Repositories.Contracts;
using LayerArchitecture.DataLayer.Repositories;

namespace LayerArchitecture.ServiceLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        

        ICarRepository _carRepository;

        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }


        

        // GET: api/Car
        [HttpGet]
        public async Task<ActionResult<IList<Car>>> GetCar()
        {
             IList<Car> carList  =  await _carRepository.GetAll();
            return carList.ToList();
        }

        // GET: api/Car/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(Guid id)
        {
            Car currentCar = await _carRepository.GetById(id);

            if (currentCar == null)
            {
                return NotFound();
            }

            return currentCar;
        }

        // PUT: api/Car/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(Guid id, Car car)
        {
            if (id != car.Id)
            {
                return BadRequest();
            }

            await _carRepository.Update(id, car);

            return NoContent();
        }

        // POST: api/Car
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Car>> PostCar(Car car)
        {

            if (car.Id == Guid.Empty)
                car.Id = Guid.NewGuid();

            await _carRepository.Insert(car);

            return car;
        }

        // DELETE: api/Car/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Car>> DeleteCar(Guid id)
        {
            var car = await _carRepository.GetById(id);
            if (car == null)
            {
                return NotFound();
            }

            await _carRepository.Delete(car.Id);
            return car;
        }
    }
}
