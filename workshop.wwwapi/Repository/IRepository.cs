using workshop.wwwapi.Models;
using workshop.wwwapi.ViewModels;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<List<Car>> GetCars();
        Task<Car> AddCar(Car entity);
        Task<bool> DeleteCar(int id);
        Task<Car> GetACarById(int id);
        Task<Car> UpdateCarById(int id, Car model);
    }
}
