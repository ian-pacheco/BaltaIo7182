namespace Store.Domain.Repositories
{
    public interface IOrderRepository
    {
        void Save(IOrderRepository order);
    }
}
