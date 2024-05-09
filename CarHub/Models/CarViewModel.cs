using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Carhub.Models;

namespace CarHub.Models
{

    public class CarViewModel
    {

        [Required]
        public int Id { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        [YearRange(1990, ErrorMessage = "Invalid Year entered; please enter a value in between 1990 and the current year.")]
        public int Year { get; set; }

        [Required]
        public string Trim { get; set; }

        [Required]
        public DateOnly PurchaseDate { get; set; }

        [Required]
        public decimal PurchasePrice { get; set; }
        public string? Repairs { get; set; }
        public decimal? RepairCost { get; set; }
        public DateOnly? LotDate { get; set; }

        [Required]
        public decimal SellingPrice { get; set; }

        public DateOnly? SaleDate { get; set; }

        [Required]
        public bool Available { get; set; }

        public byte[]? Image { get; set; }
    }
}
