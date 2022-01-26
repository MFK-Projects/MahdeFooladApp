using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net.Http;

namespace MahdeFoolad.Components
{
    public class UserProfileViewComponent : ViewComponent
    {

        private  readonly  HttpClient _client;
        public UserProfileViewComponent(IHttpClientFactory httphelper)
        {
            _client = httphelper.CreateClient();
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return null;
        }
    }
}