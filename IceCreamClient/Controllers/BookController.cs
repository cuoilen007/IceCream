using IceCreamClient.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamClient.Controllers
{
    public class BookController : Controller
    {
        const string BASE_URL = "http://localhost:47255";
        IHttpClientFactory factory;

        public BookController(IHttpClientFactory factory)
        {
            this.factory = factory;
        }

        public IActionResult Index()
        {
            return View();
        }

        //menu
        public IActionResult Menu()
        {
            return View();
        }

        //view book
        public async Task<IActionResult> ShowBooks()
        {
            HttpClient client = factory.CreateClient();//tạo và nhận data
            var result = await client.GetAsync(BASE_URL + "/api/book");
            //cần kiểm tra return code => để xem có dữ liệu hay ko? :tự làm
            var data = await result.Content.ReadAsStringAsync();
            var books = JsonConvert.DeserializeObject<List<BookIceCream>>(data);
            client.Dispose();
            return View(books);//trả về view obj book hiện tại để hiển thị thông tin book, ko có sẽ bị lỗi null model khi show list bên ShowEmps.cshtml
        }
        //end view book

        //create
        public IActionResult CreateBook()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(BookIceCream book)
        {
            HttpClient client = factory.CreateClient();
            var customerJson = JsonConvert.SerializeObject(book);
            var stringContent = new StringContent(customerJson, Encoding.UTF8, "application/json");
            var result = await client.PostAsync(BASE_URL + "/api/book/", stringContent);
            client.Dispose();
            return View("Menu");
        }
        //end create

        //Update book
        public async Task<IActionResult> UpdateBook(int bookId) // bookId phải giống với link bookId = item.BookId bên ShowBooks.cshtml
        {
            HttpClient client = factory.CreateClient();
            client.BaseAddress = new Uri(BASE_URL);
            var response = await client.GetStringAsync($"/api/book/{bookId}");
            var book = JsonConvert.DeserializeObject<BookIceCream>(response);
            client.Dispose();
            return View(book);//trả về view obj customer hiện tại để hiển thị thông tin sau edit, ko có sẽ bị lỗi null model khi show list bên showEmps.cshtml
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBook(int bookId, BookIceCream book)
        {
            if (ModelState.IsValid)//tìm thấy
            {
                HttpClient client = factory.CreateClient();
                client.BaseAddress = new Uri(BASE_URL);
                var json = JsonConvert.SerializeObject(book);
                var stringContent = new StringContent(json, Encoding.UTF8,
               "application/json");
                var respone = await client.PutAsync("/api/book", stringContent);
                if (respone.IsSuccessStatusCode)
                {
                    ViewData["error"] = "Update book Successful.";
                }
                client.Dispose();
                return RedirectToAction("Menu");
            }
            return View();
        }
        //END UPDATE

        //delete book
        [Route("{bookId}")]
        public async Task<IActionResult> Delete(int bookId) // bookId phải giống với link bookId = item.BookId bên ShowBooks.cshtml
        {
            HttpClient client = factory.CreateClient();
            var result = await client.DeleteAsync(BASE_URL + $"/api/book/{bookId}");
            client.Dispose();
            return RedirectToAction("ShowBooks");
        }

        //DETAILS BOOK
        public async Task<IActionResult> BookDetails(int bookId) // bookId phải giống với link bookId = item.BookId bên ShowBooks.cshtml
        {
            HttpClient client = factory.CreateClient();
            //chuyển đối tượng customer thành chuỗi json để truyền đi
            client.BaseAddress = new Uri(BASE_URL);
            var response = await client.GetStringAsync($"/api/book/{bookId}");
            var book = JsonConvert.DeserializeObject<BookIceCream>(response);
            client.Dispose();
            return View(book);
        }
    }
}
