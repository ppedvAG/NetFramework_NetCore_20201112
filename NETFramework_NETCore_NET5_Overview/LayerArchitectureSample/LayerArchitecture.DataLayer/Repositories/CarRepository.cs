using EFRepository;
using LayerArchitecture.DataLayer.EFContext;
using LayerArchitecture.DataLayer.Repositories.Contracts;
using LayerArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace LayerArchitecture.DataLayer.Repositories
{
    public class CarRepository : GenericRepository<Car, Guid>, ICarRepository
    {

        public CarRepository()
            :base(new CarDBV2Context())
        {

        }

        public Car GetTheBestCar()
        {
            return new Car { Id = Guid.NewGuid(), Brand = "Daimler", ConstructYear = DateTime.Now.ToString(), Model = "Batmobil", Farbe = "black", IsCaprio = true, MitRadio = true };
        }
    }
}
