using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp;

namespace MyBooks.CommonHelpers
{
    public  class WebApiConsumerHelper<T>: IWebApiConsumerHelper<T>
    {
        public async Task<T> ConsumeWebApi(string apimethod, HttpMethod httpVerb, StringContent requestBody =null)
        {
            string apiurl = MyBooks.Entity.Global.GlobalVariables.apiBaseUrl;
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage Response = null;
                if (httpVerb == HttpMethod.Get)
                {
                    Response = await client.GetAsync($"{apiurl}{apimethod}");

                }
                else if (httpVerb == HttpMethod.Delete)
                {
                    Response = await client.DeleteAsync($"{apiurl}{apimethod}");

                }
                else if (httpVerb == HttpMethod.Post)
                {
                    Response = await client.PostAsync($"{apiurl}{apimethod}", requestBody);

                }
                else if (httpVerb == HttpMethod.Put)
                {
                    Response = await client.PutAsync($"{apiurl}{apimethod}",requestBody);

                }
                var result = await Response.Content.ReadAsAsync<T>();
                    return result;
            }
        }

    }
}
