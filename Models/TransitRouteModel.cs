namespace TransitApplication.Models
{
    public class TransitRoute
    {
        public int Id {get; set;}
        public int RouteNumber {get;set;}
        public string Name {get; set;} = string.Empty;
        public bool IsActive {get;set;}
    }
}