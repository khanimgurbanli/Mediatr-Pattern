

namespace Code.Domain.Entity
{
    public class Product : BaseAudiTableEntity
    {
        public string ProductName { get; set; } = null!;
        public decimal UnitPrice { get; set; }
        public short UnitInStock { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
