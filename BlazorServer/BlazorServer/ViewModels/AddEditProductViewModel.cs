﻿using System.ComponentModel.DataAnnotations;

namespace BlazorServer.ViewModels
{
    public class AddEditProductViewModel
    {
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; } = "";
        [Required]
        public decimal ProductPrice { get; set; }
    }
}
