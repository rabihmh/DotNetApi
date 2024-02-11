using System.ComponentModel.DataAnnotations;

namespace DotNetApi.Data
{
    public class Product
    {
        [Required]
        public  int Id { get; set; }
        [Required]
        public  string  Name { get; set; }
        [Required]
        public  string  sku { get; set; }
    }
}
