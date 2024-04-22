namespace CarHub.Data
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
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
        public string? ImageUrl { get; set; }
    }
}
