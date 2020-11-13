using GenericGepositorySample;
using LayerArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using GenericGepositorySample;

namespace LayerArchitecture.DataLayer.Repositories.Contracts
{
    public interface ICarRepository : IRepository<Car, Guid>
    {
        //Hier kannst weitere spezifische Methoden zu deiner Car-Tabelle reinschreiben
        //z.b gebe mir alle Autos zurück die ein Radio haben und vor 1980 gebaut wurden

        Car GetTheBestCar();
    }
}
