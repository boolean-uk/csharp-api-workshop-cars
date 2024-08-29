using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        List<Car> GetCars();
        Car AddCar(Car entity);
    }
}
