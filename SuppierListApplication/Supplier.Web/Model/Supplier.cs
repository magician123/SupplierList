using System.ComponentModel.DataAnnotations;

namespace Supplier.Web.Model
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
