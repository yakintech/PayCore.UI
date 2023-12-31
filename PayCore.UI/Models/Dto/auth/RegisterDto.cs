﻿using System.ComponentModel.DataAnnotations;

namespace PayCore.UI.Models.Dto
{
    public class RegisterDto
    {
        [Required]
        [EmailAddress] 
        public string EMail { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; } = string.Empty; 
    }
}
