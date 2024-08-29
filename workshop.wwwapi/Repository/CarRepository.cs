using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class CarRepository : IRepository
    {
        public Car AddCar(Car entity)
        {
            CarData.AddCar(entity);
            return entity;
        }

        public List<Car> GetCars()
        {
            return CarData.GetCars();
        }
    }
}
