

namespace Code.Application.Products.Commands.DeleteProduct
{
    public record DeleteProductCommand (int id) : IRequest;

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
           var deleteProduct= await _context.Products.Where(p=>p.Id==request.id).SingleOrDefaultAsync();

            if (deleteProduct == null) throw new Exception("");

            _context.Products.Remove(deleteProduct);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }

}
