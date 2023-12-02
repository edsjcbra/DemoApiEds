using DemoEdsApi.Interfaces;
using DemoEdsApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoEdsApi.Controllers
{
    [Route("api/v1/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            _employeeRepository.Add(employee);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var employees = _employeeRepository.Get();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
          var employee = _employeeRepository.GetById(id);
            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _employeeRepository.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody]Employee employee, [FromRoute] int id)
        {
            _employeeRepository.Update(employee, id);
            return Ok();
        }

    }
}
