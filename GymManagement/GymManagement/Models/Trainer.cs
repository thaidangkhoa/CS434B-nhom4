using System;
using System.ComponentModel.DataAnnotations;

namespace GymManagement.Models
{
    public class Trainer
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Specialty { get; set; } // chuyên môn

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
