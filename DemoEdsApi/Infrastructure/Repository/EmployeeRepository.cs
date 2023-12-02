using DemoEdsApi.Infrastructure.DbContex;
using DemoEdsApi.Interfaces;
using DemoEdsApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DemoEdsApi.Infrastructure.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ConnectionContext _context;

        public EmployeeRepository(ConnectionContext connectionContext)
        {
            _context = connectionContext;
        }
        public void Add(Employee employee)
        {
            if (employee == null)
            {
                throw new Exception("Usuario nao encontrado");
            }
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var employee = _context.Employees.FirstOrDefault(x => x.Id == id);
            if (employee == null)
            {
                throw new Exception("Usuario nao encontrado");
            }
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }

        public List<Employee> Get()
        {
            return _context.Employees.ToList();
        }

        public Employee GetById(int id)
        {
            var employee = _context.Employees.FirstOrDefault(x => x.Id == id);
            if (employee == null)
            {
                throw new Exception("Usuario nao encontrado");
            }
            return employee;
        }

        public void Update(Employee employee, int id)
        {
            var employeeBanco = _context.Employees.FirstOrDefault(x => x.Id == id);
            if (employeeBanco == null)
            {
                throw new Exception("Usuario nao encontrado");
            }

            employeeBanco.name = employee.name;
            employeeBanco.age = employee.age;
            employeeBanco.photo = employee.photo;

            _context.Employees.Update(employeeBanco);
            _context.SaveChanges();
        }
    }
}
