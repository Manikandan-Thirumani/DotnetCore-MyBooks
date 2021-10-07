using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBooks.Data.AuthorsRepository;
using MyBooks.Data.BooksRepository;
using MyBooks.Data.OrderBooksRepository;
using MyBooks.Entity.ViewModels;

namespace MyBooks.ViewComponents
{
    public class BookStatisticsViewComponent: ViewComponent
    {
        private readonly IAuthorsRepository _authorsrepo;
        private readonly IBooksRepository _booksrepo;
        private readonly IOrderBooksRepository _orderbooksrepo;
        public BookStatisticsViewComponent(IAuthorsRepository authorsrepo,IBooksRepository booksrepo,IOrderBooksRepository orderbooksrepo)
        {
            _authorsrepo = authorsrepo;
            _booksrepo = booksrepo;
            _orderbooksrepo = orderbooksrepo;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var statistics = new StatisticsViewModel();
            statistics.AuthorsCount = await _authorsrepo.AuthorsCount();

            statistics.BooksCount = await _booksrepo.GetBooksCount();

            statistics.OrdersCount = await _orderbooksrepo.GetOrdersCount();
            return View(statistics);
        }
    }
}
