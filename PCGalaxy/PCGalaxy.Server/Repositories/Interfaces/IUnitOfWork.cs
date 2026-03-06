namespace PCGalaxy.Server.Repositories.Interfaces
{
	public interface IUnitOfWork
	{
		IProductRepository ProductRepository { get; }
		ICategoryRepository CategoryRepository { get; }
		ICartItemRepository CartItemRepository { get; }
        IOrderItemRepository OrderItemRepository { get; }
        IOrderRepository OrderRepository { get; }
    }
}
