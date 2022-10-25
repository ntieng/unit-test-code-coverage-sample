namespace Coffee.Api.Models
{
    public class CoffeeResponseModel
    {
        public string title { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public string[] ingredients { get; set; } = new string[0];
        public string image { get; set; } = string.Empty;
        public int id { get; set; }
    }
}
