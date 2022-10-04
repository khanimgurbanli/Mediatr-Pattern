
namespace Code.Application.Products.Commands.DeleteProduct
{
    public  class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteProductCommandValidator(IApplicationDbContext context)
        {
            _context = context;
        }
    }
}
