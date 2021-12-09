using IceCreamApi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IceCreamApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        projectContext ctx;
        

        public BookController(projectContext ctx)
        {
            this.ctx = ctx;
        }

        //VIEW ALL BOOK
        [HttpGet] //fix lỗi swagger
        public async Task<ActionResult<List<BookIceCream>>> GetBooks()
        {
            var result = await ctx.BookIceCreams.ToListAsync();
            if (result == null)
            {
                return NotFound();//mã 404
            }
            return Ok(result);//tìm thấy mã 200->299, mã 300 redirect
        }
        //END VIEW

        //CREATE
        //post create
        [HttpPost] //fix lỗi swagger
        public async Task<ActionResult<BookIceCream>> CreateBook(BookIceCream book)//đặt post ở đầu để đảm bảo post và fix lỗi swagger
        {
            ctx.BookIceCreams.Add(book);
            await ctx.SaveChangesAsync();

            //tìm employee vừa tạo
            var b = await ctx.BookIceCreams.OrderByDescending(c => c.BookId).SingleOrDefaultAsync();
            return CreatedAtAction("GetBooks", new { BookID = b.BookId }, b);
        }
        //END CREATE

        //update Book
        //lấy id theo EmpId dùng cho hàm update
        [HttpGet("{id}")]
        public async Task<ActionResult<BookIceCream>> GetBook(int id)
        {
            var result = await ctx.BookIceCreams.SingleOrDefaultAsync(c => c.BookId == id);
            if (result == null)
            {
                return NotFound(); //mã 404
            }
            return Ok(result); //tìm thấy mã 200->299, mã 300 redirect
        }

        [HttpPut]//vì dùng method Put khác method update salary nên ko sợ trùng route
        public async Task<ActionResult> PutUpdateBook(BookIceCream book)//đặt put ở đầu để đảm bảo put
        {
            ctx.Entry(book).State = EntityState.Modified;
            await ctx.SaveChangesAsync();

            return NoContent();
        }
        //end update
    }
}
