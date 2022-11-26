using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Core.DbModels
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Price { get; set; }
        public string PictureUrl { get; set; }
        public ProductType ProductType { get; set; }
        public int? ProductTypeId { get; set; }
        public ProductBrand GetProductBrand { get; set; }
        public int ProductBrandId { get; set;}
    }
}
