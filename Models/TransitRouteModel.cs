using System.ComponentModel.DataAnnotations;

namespace TransitApplication.Models
{
    public class TransitRoute
    {
        public int Id {get; set;}

        [Range(1, int.MaxValue)]
        public int RouteNumber {get;set;}
        [Required]
        public string Name {get; set;} = string.Empty;
        public bool IsActive {get;set;}
        public ICollection<BusStop> BusStops {get;set;} = new List<BusStop>();
    }
}