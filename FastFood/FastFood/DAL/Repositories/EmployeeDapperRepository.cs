using FastFood.DAL.Interface;
using FastFood.DAL.Models;

namespace FastFood.DAL.Repositories
{
    public class EmployeeDapperRepository : IRepository<Employee>
    {
        private readonly string? _connStr;

        public EmployeeDapperRepository(string? connStr)
        {
            _connStr = connStr;
        }

        public int Create(Employee entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Employee entity)
        {
            throw new NotImplementedException();
        }

        public IList<Employee> GetAll()
        {
            throw new NotImplementedException();
        }

        public Employee GetByID(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
