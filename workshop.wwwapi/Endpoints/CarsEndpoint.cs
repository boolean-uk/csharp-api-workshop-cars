using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class CarsEndpoint
    {
        public static void ConfigureCarEndpoint(this WebApplication app)
        {
            var cars = app.MapGroup("cars");
            cars.MapGet("/", GetCars);
            cars.MapPost("/", AddCar);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetCars(IRepository repository)
        {
            Payload<List<Car>> payload = new Payload<List<Car>>();
            payload.data = repository.GetCars();
            return TypedResults.Ok(payload);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult AddCar(IRepository repository, Car model)
        {
            Payload<Car> payload = new Payload<Car>();
            payload.data = repository.AddCar(model);
            return TypedResults.Ok(payload);
        }
    }
}
