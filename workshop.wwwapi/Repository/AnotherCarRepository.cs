using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class AnotherCarRepository : IRepository
    {
        public Car AddCar(Car entity)
        {
            VehicleData.AddVehicle(entity);
            return entity;
        }

        public List<Car> GetCars()
        {
            return VehicleData.GetVehicles();
        }
    }
}
