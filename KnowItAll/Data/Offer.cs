using KnowItAll.Models;
using KnowItAll.Enum;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace KnowItAll.Data
{
    public class Offer
    {
        public int OfferId { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int Time { get; set; }
        public Status Status { get; set; }

       public List<Material_Offer>? MaterialOffers { get;}
    }
}
