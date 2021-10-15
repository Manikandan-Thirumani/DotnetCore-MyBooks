using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBooks.Data.BooksRepository;
using MyBooks.Data.OrderBooksRepository;
using MyBooks.Entity.Books;
using MyBooks.Entity.ViewModels;

namespace MyBooks.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly IOrderBooksRepository _repo;

        public OrdersController(IOrderBooksRepository repo)
        {
            _repo = repo;
        }
        [HttpPost]
        public async Task<ActionResult> PostBook(CreateOrdersViewModel model)
        {
            await _repo.CreateOrders(model);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<int>> GetOrdersCount()
        {
            return await _repo.GetOrdersCount();
        }
    }
}
