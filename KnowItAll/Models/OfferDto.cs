using KnowItAll.Data;

namespace KnowItAll.Models
{
    public class OfferDto
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int Time { get; set; }
        public string? Material { get; set; }
    
    }
}
