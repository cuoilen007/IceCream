﻿using IceCreamClient.Models;
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

        //view list book
        public async Task<IActionResult> ShowBooks()
        {
            HttpClient client = factory.CreateClient();//tạo và nhận data
            var result = await client.GetAsync(BASE_URL + "/api/book");
            //cần kiểm tra return code => để xem có dữ liệu hay ko? :tự làm
            var data = await result.Content.ReadAsStringAsync();
            var books = JsonConvert.DeserializeObject<List<BookIceCream>>(data);
            ViewData["ListBook"] = books;
            client.Dispose();
            return View(books);//trả về view obj book hiện tại để hiển thị thông tin book, ko có sẽ bị lỗi null model khi show list bên ShowBooks.cshtml
        }
        //end view book

        //view book by category
        public async Task<IActionResult> ShowBookByCategory(int CatId)
        {
            HttpClient client = factory.CreateClient();
            var result = await client.GetStringAsync(BASE_URL + $"/api/book/category/{CatId}");//GetStringAsync ko cần ReadAsStringAsync()
            var book = JsonConvert.DeserializeObject<List<BookIceCream>>(result);

            client.Dispose();
            return View(book);
        }
        //end view book

        //DETAILS BOOK
        public async Task<IActionResult> BookDetails(int bookId) // bookId phải giống với link bookId = item.BookId bên ShowBooks.cshtml
        {
            HttpClient client = factory.CreateClient();
            //chuyển đối tượng customer thành chuỗi json để truyền đi
            client.BaseAddress = new Uri(BASE_URL);
            var response = await client.GetStringAsync($"/api/book/{bookId}");
            var book = JsonConvert.DeserializeObject<BookIceCream>(response);
            ViewData["Details"] = book;

            //show relate book
            var responseRelate = await client.GetStringAsync($"/api/book/relatedBook/5");
            var relateBook = JsonConvert.DeserializeObject<List<BookIceCream>>(responseRelate);
            ViewData["RelateBook"] = relateBook;

            client.Dispose();
            return View();
        }
    }
}
