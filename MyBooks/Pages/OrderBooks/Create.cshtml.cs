using Microsoft.AspNetCore.Mvc.RazorPages;
using MyBooks.Data.BooksRepository;
using MyBooks.Entity.BookOrders;
using MyBooks.Entity.Books;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBooks.Data.OrderBooksRepository;
using MyBooks.Entity.ViewModels;

namespace MyBooks.Pages.OrderBooks
{
    public class CreateModel : PageModel
    {
        private readonly IBooksRepository _booksrepo;
        private readonly IOrderBooksRepository _orderbookrepo;
        public readonly IHttpContextAccessor _httpContextAccessor;
        public List<Books> AllBooks { get; set; }
        [BindProperty]
        public CreateOrdersViewModel OrderCreationModel { get; set; }

        public CreateModel(IBooksRepository booksrepo, IHttpContextAccessor httpContextAccessor, IOrderBooksRepository orderbookrepo)
        {
            _booksrepo = booksrepo;
            _orderbookrepo = orderbookrepo;
            _httpContextAccessor = httpContextAccessor;

            _httpContextAccessor.HttpContext.Session.SetString("UserId", "1");//TODO: change it after login page implemented
        }

        public async Task<IActionResult> OnGet(int? id)
        {
          await  HandleShoppingCartProcess(id);
            return Page();
        }

        


        public async Task<IActionResult> OnPostAsync()
        {
            await HandleShoppingCartProcess(null);
            if (!ModelState.IsValid)
            {
                return Page();
            }

          await  _orderbookrepo.CreateOrders(OrderCreationModel);
          TempData["SuccessMessage"] = "Order Created Successfully.";
          await clearvalues();
          return Page();
        }

        private async Task HandleShoppingCartProcess(int? id)
        {
            var CartIds = new List<int>();

            if (!string.IsNullOrEmpty(_httpContextAccessor.HttpContext.Session.GetString("CartBooks")))
            {
                CartIds = JsonConvert.DeserializeObject<List<int>>(_httpContextAccessor.HttpContext.Session.GetString("CartBooks"));
            }

            if (id.HasValue)
            {
                CartIds.Add((int)id);
            }
            _httpContextAccessor.HttpContext.Session.SetString("CartBooks", JsonConvert.SerializeObject(CartIds));

            var bookList = (List<Books>)await _booksrepo.GetBooks();
            AllBooks = bookList.Except(bookList.Where(x => CartIds.Contains(x.BookId))).ToList();
            if (OrderCreationModel == null)
            {
                OrderCreationModel = new CreateOrdersViewModel();
            }

            OrderCreationModel.CartBooks = bookList.Where(x => CartIds.Contains(x.BookId)).ToList();
        }

        private async Task clearvalues()
        {
            _httpContextAccessor.HttpContext.Session.Remove("CartBooks");
            OrderCreationModel = new CreateOrdersViewModel();
            AllBooks= (List<Books>)await _booksrepo.GetBooks();


        }
    }
}
