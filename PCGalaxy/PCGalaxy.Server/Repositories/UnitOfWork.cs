using PCGalaxy.Server.Repositories.Interfaces;

namespace PCGalaxy.Server.Repositories
{
	public class UnitOfWork(
		IProductRepository productRepository,
		ICategoryRepository categoryRepository,
		ICartItemRepository cartItemRepository,
		IOrderItemRepository orderItemRepository,
		IOrderRepository orderRepository) : IUnitOfWork
	{
		public IProductRepository ProductRepository { get; } = productRepository;
		public ICategoryRepository CategoryRepository { get; } = categoryRepository;
		public ICartItemRepository CartItemRepository { get; } = cartItemRepository;
		public IOrderItemRepository OrderItemRepository { get; } = orderItemRepository;
		public IOrderRepository OrderRepository { get; } = orderRepository;
    }
}
