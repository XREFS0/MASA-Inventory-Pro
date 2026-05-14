using System;

namespace inventory.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public int StockQuantity { get; set; }
        public int MinStockAlert { get; set; }
        public byte[] ProductImage { get; set; }
        public string Unit { get; set; } // pcs, kg, etc.
        public DateTime CreatedAt { get; set; }
    }
}
