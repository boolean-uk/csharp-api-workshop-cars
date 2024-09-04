using System.ComponentModel.DataAnnotations;

namespace workshop.wwwapi.ViewModels
{
    public class CarPostModel
    {
        [Required(ErrorMessage = "Make is required")]
        public string Make { get; set; }
        [Required(ErrorMessage = "Model is required")]
        public string Model { get; set; }
        public int DoorCount { get; set; }
    }
}
