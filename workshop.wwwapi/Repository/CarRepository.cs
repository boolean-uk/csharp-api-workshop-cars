
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class CarRepository : IRepository
    {

        private DataContext _db;
        public CarRepository(DataContext db)
        {
            _db = db;
        }
        public Car AddCar(Car entity)
        {
            //_db.Cars.Add(entity);
            _db.Add(entity);
            _db.SaveChanges();
            return entity;
        }

        public List<Car> GetCars()
        {
            return _db.Cars.ToList();
         
        }
    }
}
