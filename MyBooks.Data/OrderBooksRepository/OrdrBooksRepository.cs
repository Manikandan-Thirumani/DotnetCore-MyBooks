using MyBooks.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBooks.Entity.BookOrders;

namespace MyBooks.Data.OrderBooksRepository
{
    public class OrderBooksRepository : IOrderBooksRepository
    {
        private readonly MyBooksDBContext _context;

        public OrderBooksRepository(MyBooksDBContext context)
        {
            this._context = context;

        }
        public async Task CreateOrders(CreateOrdersViewModel _createOrdersViewModel)
        {
            BookOrders order = null;
            var orderid = GetMax() + 1;
            foreach (var item in _createOrdersViewModel.CartBooks)
            {
                order = new BookOrders();
                order.CustomerName = _createOrdersViewModel.CustomerName;
                order.CustomerAddress = _createOrdersViewModel.CustomerAddress;
                order.BookId = item.BookId;
                order.OrderId = orderid;
                _context.BookOrders.Add(order);
                await Commit();
            }
        }
        private async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        private int GetMax()
        {
            int? id = _context.BookOrders.DefaultIfEmpty().Max(r => r == null ? 0 : r.OrderId);
            return id.HasValue ? (int)id : 0;
        }
    }
}
