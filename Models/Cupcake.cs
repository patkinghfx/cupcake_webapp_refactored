namespace Cupcakes.Models
{
    public class Cupcake
    {
        public int CupcakeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageFilename {  get; set; } = string.Empty;
        public string Description {  get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
