namespace Lab20
{
    public interface IOrderRepository
    {
        void Save(Order order);
        Order GetById(int id);
    }
}
