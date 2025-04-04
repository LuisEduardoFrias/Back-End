﻿using System.ComponentModel.DataAnnotations;

namespace ArsAffiliate.Domain.Dtos
{
    public class LogerDto
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
