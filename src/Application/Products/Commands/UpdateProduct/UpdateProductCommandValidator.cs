
namespace Code.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateProductCommandValidator(IApplicationDbContext context)
        {
            _context = context;
            RuleFor(p => p.ProductName)
                .NotNull().WithMessage("ProductName can not be null")
                .NotEmpty().WithMessage("ProductName is required")
                .MinimumLength(3).WithMessage("Min length must be 3 charcater")
                .MaximumLength(200).WithMessage("Max length must be 200 character")
                .MustAsync(BeUniqName).WithMessage("The specified CategoryName already exists");

            RuleFor(p => p.UnitPrice)
                .NotEmpty().WithMessage("UnitPrice is required")
                .GreaterThan(0).WithMessage("UnitPrice must be greate than 0");

            RuleFor(p => p.UnitInStock)
              .NotEmpty().WithMessage("UnitPrice is required");
        }

        public async Task<bool> BeUniqName(string productName, CancellationToken cancellationToken)
        {
            return await _context.Products.AllAsync(x => x.ProductName != productName, cancellationToken);
        }
    }
}
