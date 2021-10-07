using MyBooks.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyBooks.Data.OrderBooksRepository
{
  public  interface IOrderBooksRepository
  {
      Task CreateOrders(CreateOrdersViewModel _createOrdersViewModel);
      Task<int> GetOrdersCount();
  }
}
