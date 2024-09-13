using System.ComponentModel.DataAnnotations;

namespace workshop.wwwapi.ViewModels
{
    public class CarPutModel
    {
       
        public string? Make { get; set; }
       
        public string? Model { get; set; }
        public int? Wheels { get; set; }

    }
}
