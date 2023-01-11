using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KnowItAll.Data
{
    public class Material
    {
        public int MaterialId { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        [Required]
        public decimal Price { get; set; }

        public List<Material_Offer>? MaterialOffers { get; set; }

    }
}
