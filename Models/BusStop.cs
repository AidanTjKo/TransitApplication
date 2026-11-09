using System.ComponentModel.DataAnnotations;

namespace TransitApplication.Models
{
    public class BusStop
    {
        public TransitRoute TransitRoute {get;set;} = null!;
        public int TransitRouteId{get;set;}
        public int Id {get; set;}

        [Required]
        public string Name {get;set;} = string.Empty;
    
        [Range(-90.0,90.0)]
        public double Latitude {get;set;}

        [Range(-180.0,180.0)]
        public double Longitude{get;set;}
    }
}