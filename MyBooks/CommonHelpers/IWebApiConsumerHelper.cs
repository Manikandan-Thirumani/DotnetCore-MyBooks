using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyBooks.CommonHelpers
{
   public interface IWebApiConsumerHelper<T>
   {
       public   Task<T> ConsumeWebApi(string apimethod, HttpMethod httpVerb, StringContent requestBody = null);

   }
}
