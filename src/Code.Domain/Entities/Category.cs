

namespace Code.Domain.Entity
{
    public class Category : BaseAudiTableEntity
    {
        public Category()
        {
            this.Products = new HashSet<Product>();
        }

        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; } 

        public virtual ICollection<Product> Products { get; set; }  
    }
}
