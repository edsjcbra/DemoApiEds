using DemoEdsApi.Models;

namespace DemoEdsApi.Interfaces
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);

        List<Employee> Get();

        Employee GetById(int id);

        void Update(Employee employee, int id);

        void Delete(int id);
    }
}
