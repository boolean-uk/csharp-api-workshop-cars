
using Microsoft.EntityFrameworkCore;
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
        public async Task<Car> AddCar(Car entity)
        {
            //_db.Cars.Add(entity);
            _db.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
        public async Task<Car> GetACarById(int id)
        {
            var entity = await _db.Cars.FirstOrDefaultAsync(car => car.Id == id);
            return entity;           
        }
        public async Task<List<Car>> GetCars()
        {
            return await _db.Cars.ToListAsync();
         
        }
        public async Task<bool> DeleteCar(int id)
        {           
            var car = _db.Cars.Find(id);
            if (car != null)
            {
                _db.Remove(car);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
            
        }

        public async Task<Car> UpdateCarById(int id, Car model)
        {
            var entity = _db.Cars.Find(id);
            entity.UpdatedDate = DateTime.UtcNow;
            _db.Attach(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
