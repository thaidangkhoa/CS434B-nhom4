using System.ComponentModel.DataAnnotations;

namespace GymManagement.Models
{
    public class Package
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Duration { get; set; } // Đơn vị: tháng


    }
}
