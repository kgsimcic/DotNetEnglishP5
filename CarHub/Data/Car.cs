using CarHub.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Buffers.Text;

namespace CarHub.Data
{
    public partial class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
// s[YearRange(1990, (int)DateTime.Now.Month, ErrorMessage = "Invalid Year entered; please enter a value in between 1990 and the current year.")]
        public int Year { get; set; }
        public string Trim { get; set; }
        public DateOnly PurchaseDate { get; set; }
        public decimal PurchasePrice { get; set; }
        public string? Repairs { get; set; }
        public decimal? RepairCost { get; set; }
        public DateOnly? LotDate { get; set; }
        public decimal SellingPrice { get; set; }
        public DateOnly? SaleDate { get; set; }
        public bool Available { get; set; }
        public byte[]? Image { get; set; }

        public String GetImageFromData(byte[]? image)
        {
            if (image == null)
            {
                return "data:,";
            }
            else
            {
                return @Convert.ToBase64String(image);
            }
        }
    }

}
