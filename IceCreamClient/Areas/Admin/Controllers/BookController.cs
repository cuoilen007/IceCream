using IceCreamClient.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamClient.Areas.Admin.Controllers
{
    [Area("Admin")]//thêm route /admin/book cho trang admin
    public class BookController : Controller
    {
        const string BASE_URL = "http://localhost:47255";
        IHttpClientFactory factory;
        IWebHostEnvironment env; //upload image

        public BookController(IHttpClientFactory factory, IWebHostEnvironment env)
        {
            this.factory = factory;
            this.env = env;
        }

        //view book
        public async Task<IActionResult> ShowBooks()
        {
            //check admin login
            if (HttpContext.Session.GetString("adname") == null)
            {
                return RedirectToAction("Login", "Home");
            }

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
        public async Task<IActionResult> CreateBook(BookIceCream book, IFormFile Image)
        {
            //check admin login
            if (HttpContext.Session.GetString("adname") == null)
            {
                return RedirectToAction("Login", "Home");
            }

            if (ModelState.IsValid)//validate
            {
                HttpClient client = factory.CreateClient();//tạo và nhận data

                if (Image != null)
                    {
                    //ADD IMAGE
                    //upload file
                    string filename = Image.FileName;

                    //auto check and create folder
                    var imagesFolder = Path.Combine(env.WebRootPath, "images/book");
                    if (!Directory.Exists(imagesFolder))
                    {
                        Directory.CreateDirectory(imagesFolder);
                    }

                    var filePath = Path.Combine(imagesFolder, filename);
                    var stream = new FileStream(filePath, FileMode.Create);
                    await Image.CopyToAsync(stream);
                    book.Image = filename;
                }

                //create book
                var bookJson = JsonConvert.SerializeObject(book);
                var stringContent = new StringContent(bookJson, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(BASE_URL + "/api/book/", stringContent);
                client.Dispose();
                return RedirectToAction("ShowBooks");
            }
            return View();
        }
        //end create

        //hàm GetBook để lấy data của obj book từ db theo id
        public async Task<BookIceCream> GetBook(int id)
        {
            HttpClient client = factory.CreateClient();
            //chuyển đối tượng customer thành chuỗi json để truyền đi
            client.BaseAddress = new Uri(BASE_URL);
            var response = await client.GetStringAsync($"/api/book/{id}");
            var book = JsonConvert.DeserializeObject<BookIceCream>(response);
            client.Dispose();
            return book;
        }
        //end

        //Update book
        public async Task<IActionResult> UpdateBook(int bookId) // bookId phải giống với link bookId = item.BookId bên ShowBooks.cshtml
        {
            //check admin login
            if (HttpContext.Session.GetString("adname") == null)
            {
                return RedirectToAction("Login", "Home");
            }

            HttpClient client = factory.CreateClient();
            client.BaseAddress = new Uri(BASE_URL);
            var response = await client.GetStringAsync($"/api/book/{bookId}");
            var book = JsonConvert.DeserializeObject<BookIceCream>(response);
            client.Dispose();
            return View(book);//trả về view obj customer hiện tại để hiển thị thông tin sau edit, ko có sẽ bị lỗi null model khi show list bên showEmps.cshtml
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBook(int bookId, BookIceCream book, IFormFile Image)
        {
            if (ModelState.IsValid)//validate
            {
                HttpClient client = factory.CreateClient();

                if (Image != null) //checking if upload new image
                {
                    //ADD IMAGE
                    //upload file
                    string filename = Image.FileName;

                    //auto check and create folder
                    var imagesFolder = Path.Combine(env.WebRootPath, "images/book");
                    if (!Directory.Exists(imagesFolder))
                    {
                        Directory.CreateDirectory(imagesFolder);
                    }

                    var filePath = Path.Combine(imagesFolder, filename);
                    var stream = new FileStream(filePath, FileMode.Create);
                    await Image.CopyToAsync(stream);
                    book.Image = filename;
                }
                else//no upload new image
                {
                    var oldImage = await GetBook(bookId);
                    book.Image = oldImage.Image;
                }
                client.BaseAddress = new Uri(BASE_URL);
                var json = JsonConvert.SerializeObject(book);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var result = await client.PutAsync("/api/book", stringContent);
                if (result.IsSuccessStatusCode)
                {
                    ViewData["success"] = "Updated Book successful.";
                }
                client.Dispose();
                return View(book);
            }
            return View(book);//trả về view obj customer hiện tại để hiển thị thông tin sau edit, ko có sẽ bị lỗi null model khi update failed
        }
        //END UPDATE

        //DETAILS BOOK
        public async Task<IActionResult> BookDetails(int bookId) // bookId phải giống với link bookId = item.BookId bên ShowBooks.cshtml
        {
            //check admin login
            if (HttpContext.Session.GetString("adname") == null)
            {
                return RedirectToAction("Login", "Home");
            }

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
