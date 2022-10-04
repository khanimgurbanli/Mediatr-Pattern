
namespace Code.Application.Categories.Commands.DeleteCategory
{
    public record DeleteCategoryCommand(int id) : IRequest;


    public class  DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCategoryCommandHandler(IApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<Unit>  Handle(DeleteCategoryCommand request,CancellationToken cancellationToken)
        {
            var deleteItem = await _context.Categories.Where(x => x.Id == request.id).SingleOrDefaultAsync();

            if (deleteItem == null) throw new Exception("");

            _context.Categories.Remove(deleteItem);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
