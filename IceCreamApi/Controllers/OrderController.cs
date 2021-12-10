using IceCreamApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IceCreamApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        projectContext db = new projectContext();

        [HttpGet("AllOrder")]
        public async Task<ActionResult> ViewAll(int id)
        {
            var foundOrders = await db.BookOrders.ToListAsync();

            if (foundOrders == null)
            {
                return NotFound();
            }

            return Ok(foundOrders);
        }
        [HttpGet("GetOrder/{id}")]
        public async Task<ActionResult> GetOrder(int id)
        {
            var foundOrder = await db.BookOrders.Where(o => o.Id==id).SingleOrDefaultAsync();

            if (foundOrder == null)
            {
                return NotFound();
            }

            return Ok(foundOrder);
        }

        [HttpGet("OrderDetail/{id}")]
        public async Task<ActionResult> ViewAllDetail(int id)
        {
            var foundDetails = await db.BookOrderDetails.Where(o=>o.BookOrderId==id).ToListAsync();

            if (foundDetails == null)
            {
                return NotFound();
            }

            return Ok(foundDetails);
        }


        [HttpPost]
        public async Task<ActionResult> AddOrder(BookOrder order)
        {
            if (order == null)
            {
                return NotFound();
            }
            order.IsCompleted = false;
            db.BookOrders.Add(order);
            await db.SaveChangesAsync();
            var neworder = await db.BookOrders.SingleOrDefaultAsync(o => o == order);
            return Ok(neworder.Id);
        }

        [HttpGet("Detail/{details}/{orderId}")]
        public async Task<IActionResult> AddDetail(List<BookOrderDetail> details, int orderId)
        {
            if (details == null || orderId == 0)
            {
                return NotFound();
            }
            var neworder = await db.BookOrders.FirstOrDefaultAsync(o => o.Id == orderId);
            foreach (var detail in details)
            {
                detail.BookOrderId = neworder.Id;
                db.BookOrderDetails.Add(detail);
            }
            return Ok();
        }

        [HttpGet("Completed/{id}")]
        public async Task<ActionResult> Completed(int id)
        {
            var foundOrder = await db.BookOrders.SingleOrDefaultAsync(m => m.Id == id);
            if (foundOrder == null)
            {
                return NotFound();
            }

            foundOrder.IsCompleted = true;
            db.BookOrders.Update(foundOrder);
            await db.SaveChangesAsync();
            return Ok(foundOrder);
        }
    }
}
