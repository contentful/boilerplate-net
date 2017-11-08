using boilerplate.net.web.Models;
using Contentful.Core;
using Contentful.Core.Configuration;
using Contentful.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace boilerplate.net.web.Controllers
{
    public class ContentfulController : Controller
    {
        private readonly IContentfulClient _client;
        private bool appsettingsEmpty = false;

        public ContentfulController(IContentfulClient client, IOptions<ContentfulOptions> contentfulOptions)
        {
            _client = client;

            if(string.IsNullOrEmpty(contentfulOptions.Value.SpaceId) || string.IsNullOrEmpty(contentfulOptions.Value.DeliveryApiKey))
            {
                appsettingsEmpty = true;
            }
        }

        public async Task<IActionResult> Index()
        {
            if (appsettingsEmpty)
            {
                return View("NoAppSettings");
            }

            var space = await _client.GetSpace();
            var entries = await _client.GetEntries<dynamic>();
            var assets = await _client.GetAssets();

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
