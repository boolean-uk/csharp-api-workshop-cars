using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public class VehicleData
    {
        private static List<Car> _vehicles = new List<Car>()
        {
            new Car(){Id=100, Make="Volkswagen", Model="Camper"}
        };

        public static List<Car> GetVehicles()
        {
            return _vehicles;
        }
        public static Car AddVehicle(Car entity)
        {
            //check it exists?
            //find a suitable id?

            _vehicles.Add(entity);
            return entity;
        }
    }
}
