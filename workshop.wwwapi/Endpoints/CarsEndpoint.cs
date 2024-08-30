using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;
using workshop.wwwapi.ViewModels;

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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static IResult AddCar(IRepository repository, CarPostModel model)
        {
                        
            Payload<Car> payload = new Payload<Car>();
            
            payload.data = repository.AddCar(new Car() { Make=model.Make, Model=model.Model});
            
            return TypedResults.Ok(payload);
        }
    }
}
