using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using OrderWebApi.Models;

namespace OrderWebApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMongoCollection<Order> _orderCollection;
        public OrderController()
        {
            var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
            var dbName = Environment.GetEnvironmentVariable("DB_NAME");
            var connectionString = $"mongodb://{dbHost}:27017/{dbName}";

            var mongoUrl = MongoUrl.Create(connectionString);
            var client = new MongoClient(mongoUrl);
            var database = client.GetDatabase(mongoUrl.DatabaseName);
            _orderCollection = database.GetCollection<Order>("order");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _orderCollection.Find(Builders<Order>.Filter.Empty).ToListAsync();
        }

        [HttpGet("{orderId}")]
        public async Task<ActionResult<Order>> GetById(string orderId)
        {
            var filterDefination = Builders<Order>.Filter.Eq(x => x.OrderId, orderId);
            return await _orderCollection.Find(filterDefination).FirstOrDefaultAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(Order order)
        {
            await _orderCollection.InsertOneAsync(order);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<Order>> UpdateOrder(Order order)
        {
            var filterDefination = Builders<Order>.Filter.Eq(x => x.OrderId, order.OrderId);
            await _orderCollection.ReplaceOneAsync(filterDefination, order);
            return Ok();
        }

        [HttpDelete("{orderId}")]
        public async Task<ActionResult<Order>> DeleteOrder(string orderId)
        {
            var filterDefination = Builders<Order>.Filter.Eq(x => x.OrderId, orderId);
            await _orderCollection.DeleteOneAsync(filterDefination);
            return Ok();
        }
    }
}