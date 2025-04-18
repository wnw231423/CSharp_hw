using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderCLI.Models;

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderContext _context;

        public OrdersController(OrderContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _context.Orders
                .Include(o => o.User)
                .ToListAsync();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.Orders
                .Include(o => o.User)
                .Include(o => o.Details)
                .ThenInclude(d => d.Good)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            // 设置导航属性状态，避免 EF Core 尝试创建新的关联实体
            _context.Entry(order.User).State = EntityState.Unchanged;
            foreach (var detail in order.Details)
            {
                _context.Entry(detail.Good).State = EntityState.Unchanged;
            }
            
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            // 首先删除现有订单的详情项
            var existingOrder = await _context.Orders
                .Include(o => o.Details)
                .FirstOrDefaultAsync(o => o.Id == id);
            
            if (existingOrder == null)
            {
                return NotFound();
            }

            _context.OrderDetails.RemoveRange(existingOrder.Details);
            
            // 设置导航属性状态
            _context.Entry(order.User).State = EntityState.Unchanged;
            foreach (var detail in order.Details)
            {
                _context.Entry(detail.Good).State = EntityState.Unchanged;
            }

            // 更新订单
            _context.Entry(existingOrder).CurrentValues.SetValues(order);
            existingOrder.Details = order.Details;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders
                .Include(o => o.Details)
                .FirstOrDefaultAsync(o => o.Id == id);
            
            if (order == null)
            {
                return NotFound();
            }

            _context.OrderDetails.RemoveRange(order.Details);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/Orders/bygood/{name}
        [HttpGet("bygood/{name}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersByGoodName(string name)
        {
            return await _context.Orders
                .Include(o => o.Details).ThenInclude(d => d.Good)
                .Include(o => o.User)
                .Where(o => o.Details.Any(d => d.Good.Name == name))
                .ToListAsync();
        }

        // GET: api/Orders/byuser/{name}
        [HttpGet("byuser/{name}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersByUserName(string name)
        {
            return await _context.Orders
                .Include(o => o.Details).ThenInclude(d => d.Good)
                .Include(o => o.User)
                .Where(o => o.User.Name == name)
                .ToListAsync();
        }

        // GET: api/Orders/byprice?min=10&max=100
        [HttpGet("byprice")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersByPrice([FromQuery] decimal min, [FromQuery] decimal max)
        {
            return await _context.Orders
                .Include(o => o.Details).ThenInclude(d => d.Good)
                .Include(o => o.User)
                .Where(o => o.Details.Sum(d => d.Quantity * d.Good.Price) >= min && 
                            o.Details.Sum(d => d.Quantity * d.Good.Price) <= max)
                .ToListAsync();
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}