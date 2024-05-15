using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Customer name is required.")]
        [MinLength(3, ErrorMessage = "Customer name must be at least 3 characters.")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(20)]
        [MinLength(3, ErrorMessage = "City name must be at least 3 characters.")]
        public string City { get; set; }

        [MinLength(6, ErrorMessage = "Phone number must be at least 6 numbers.")]
        public string PhoneNumber { get; set; }

        public Cart Cart { get; set; }
        public List<Order> Orders { get; set; }

    }
}
