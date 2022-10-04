
namespace Code.Application.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        private readonly IApplicationDbContext _context;
        public UpdateCategoryCommandValidator(IApplicationDbContext context)
        {
            this._context = context;
            RuleFor(v => v.CategoryName)
                .NotEmpty().WithMessage("CategoryName is required")
                .MaximumLength(200).WithMessage("CategoryName must not exceed 200 characaters")
            .MustAsync(BeUniqName).WithMessage("The specified CategoryName already exists");

        }

        public async Task<bool> BeUniqName(UpdateCategoryCommand model, string categoryName, CancellationToken cancellationToken)
        {
            return await _context.Categories
                .Where(x => x.Id != model.Id)
                .AllAsync(x => x.CategoryName != categoryName, cancellationToken);
        }
    }
}
