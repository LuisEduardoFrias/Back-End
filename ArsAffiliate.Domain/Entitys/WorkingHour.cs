using System;
using System.ComponentModel.DataAnnotations;

namespace ArsAffiliate.Domain.Entitys
{
    public class WorkingHour
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public DateTime TimeToLeaveWork { get; set; }
    }
}
