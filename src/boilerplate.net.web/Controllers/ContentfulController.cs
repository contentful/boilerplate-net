using boilerplate.net.web.Models;
using Contentful.Core;
using Contentful.Core.Models;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace boilerplate.net.web.Controllers
{
    public class ContentfulController : Controller
    {
        private readonly IContentfulClient _client;

        public ContentfulController(IContentfulClient client)
        {
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            var space = await _client.GetSpaceAsync();
            var entries = await _client.GetEntriesAsync<Entry<dynamic>>();
            var assets = await _client.GetAssetsAsync();

            var contentfulExampleModel = new ContentfulExampleModel()
            {
                Space = space,
                Entries = entries.ToList(),
                Assets = assets.ToList()
            };

            return View(contentfulExampleModel);
        }
    }
}
