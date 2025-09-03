using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BookstoreApp.Validators;

namespace BookstoreApp.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Author { get; set; } = string.Empty;

        [Required]
       
        [ValidIsbn] // Custom validation for ISBN format [cite: 17]
        public string ISBN { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        
        [PriceRange(1.00, 1000.00)] // Custom validation for price constraints 
        public decimal Price { get; set; }
    }
}