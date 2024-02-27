namespace FastFood.DAL.Interface
{
    // Students ID: 00013836, 00014725, 00014896
    public interface IRepository<T>
    {
        IList<T> GetAll();

        T GetByID(int Id);

        int Create(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
