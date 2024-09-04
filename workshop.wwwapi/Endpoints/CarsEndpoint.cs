using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;
using workshop.wwwapi.Validators;
using workshop.wwwapi.ViewModels;

namespace workshop.wwwapi.Endpoints
{
    public static class CarsEndpoint
    {
        public static void ConfigureCarEndpoint(this WebApplication app)
        {
            var cars = app.MapGroup("cars");
            cars.MapGet("/", GetCars);
            cars.MapPost("/", AddCar).AddEndpointFilter<ValidationFilter<CarPostModel>>();
            cars.MapDelete("/{id}", DeleteCar);
            cars.MapPut("/{id}", UpdateCar);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCars(IRepository<Car> repository)
        {
            Payload<List<Car>> payload = new Payload<List<Car>>();
            
            var results = await repository.Get();
            payload.data = results.ToList();

            return TypedResults.Ok(payload);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]        
        public static async Task<IResult> AddCar(IRepository<Car> repository, CarPostModel model)
        {
            try
            {              
                Payload<Car> payload = new Payload<Car>();
                payload.data = await repository.Insert(new Car() { Make = model.Make, Model = model.Model });
                return TypedResults.Ok(payload);               
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
}
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static async Task<IResult> DeleteCar(IRepository<Car> repository, int id)
        {
            try
            {
                var model = await repository.Delete(id);
                if (model!=null) return Results.Ok(new { Make=model.Make, Model=model.Model });
                return TypedResults.NotFound();
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static async Task<IResult> UpdateCar(IRepository<Car> repository, int id, CarPutModel model)
        {
            try
            {
                var entity = await repository.GetById(id);
                
                if(entity==null) return Results.NotFound();

                entity.Make = !string.IsNullOrEmpty(model.Make) ? model.Make : entity.Make;
                entity.Model = !string.IsNullOrEmpty(model.Model) ? model.Model : entity.Model;               
                var result = await repository.Update(entity);
                return TypedResults.Ok(new { Make = entity.Make, Model = entity.Model });
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
    }
}
