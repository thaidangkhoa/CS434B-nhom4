using System;
using System.ComponentModel.DataAnnotations;

namespace GymManagement.Models
{
    public class TrialRegistration
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        public int? PackageId { get; set; }  // liên kết đến gói tập nếu có chọn

        public string Notes { get; set; }

        public DateTime RegisteredAt { get; set; } = DateTime.Now;

        // Optional: Navigation property
        public virtual Package Package { get; set; }
    }
}
