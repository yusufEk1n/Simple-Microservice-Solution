using CustomerWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        // customerDbContext nesnesine bağımlılık oluşturuyoruz(dependency injection).
        private readonly CustomerDbContext _customerDbContext;
        public CustomerController(CustomerDbContext customerDbContext)
        {
            _customerDbContext = customerDbContext;
        }

        // GET: api/<CustomerController>
        // customerDbContext nesnesi ile veritabanından customer verilerini çekiyoruz.
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            return _customerDbContext.Customers;
        }

        // GET api/<CustomerController>/1
        // customerDbContext nesnesi ile veritabanından gelen id değerine göre customer verisini çekiyoruz.
        [HttpGet("{customerId}")]
        public async Task<ActionResult<Customer>> GetById(int customerId)
        {
            var customer = await _customerDbContext.Customers.FindAsync(customerId);
            return customer;
        }

        // POST api/<CustomerController>
        // customerDbContext nesnesi ile veritabanına customer verisini ekliyoruz.
        [HttpPost]
        public async Task<ActionResult> Create(Customer customer)
        {
            _customerDbContext.Customers.Add(customer);
            await _customerDbContext.SaveChangesAsync();
            return Ok();
        }

        // PUT api/<CustomerController>/1
        // customerDbContext nesnesi ile veritabanındaki customer verisini güncelliyoruz.
        [HttpPut]
        public async Task<ActionResult> Update(Customer customer)
        {
            _customerDbContext.Update(customer);
            await _customerDbContext.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<CustomerController>/1
        // customerDbContext nesnesi ile veritabanından gelen id değerine göre customer verisini siliyoruz.
        [HttpDelete("{customerId}")]
        public async Task<ActionResult> Delete(int customerId)
        {
            var customer = await _customerDbContext.Customers.FindAsync(customerId);
            _customerDbContext.Customers.Remove(customer);
            await _customerDbContext.SaveChangesAsync();
            return Ok();
        }
    }
}