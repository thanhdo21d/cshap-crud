using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace cru.Models
{
    public class Product
    {
        public Product()
        {
        }
        [DisplayName("Ten san pham")]

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }


        
        public int Id { get; set; }
        public string Description { get; set; }
        public int Number { get; set; }
        public string Category { get; set; }


    }
}
